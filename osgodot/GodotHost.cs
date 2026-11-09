using Godot;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Tasks;
using static Godot.OS;
using static MyDrawer;

namespace osgf
{
    [GlobalClass]
    public partial class GodotHost : Node
    {
        private static GodotHost _instance;
        public static GodotHost godotHostInstance => _instance;

        // Потоки для обработки ввода/вывода
        private Thread inputThread;
        private CancellationTokenSource cancellationTokenSource;

        // Очередь команд для синхронизации с основным потоком Godot
        private Queue<CommandMessage> commandQueue = new Queue<CommandMessage>();
        private object queueLock = new object();

        private GodotHost mainNode; // Главный узел.
        private Window rootWindow; // Главное окно.
        public static string gameFormsItemKey; // У библиотеки тоже будет КлючЭлемента.

        // Словари соответствий объектов и их ключей.
        public static ConcurrentDictionary<string, dynamic> dictKeyEl = new ConcurrentDictionary<string, dynamic>();
        public static ConcurrentDictionary<dynamic, string> dictElKey = new ConcurrentDictionary<dynamic, string>();

        // Словарь для хранения задач, ожидающих кадр.
        private ConcurrentDictionary<string, TaskCompletionSource<object>> imageCaptureTasks =
            new ConcurrentDictionary<string, TaskCompletionSource<object>>();

        private int lastEventHash = 0;

        public override void _Ready()
        {
            _instance = this;

            GD.Print("C# процесс запущен, ожидание команд...");

            // Устанавливаем кодировку для stdin и stdout
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            // Запускаем поток для чтения stdin
            cancellationTokenSource = new CancellationTokenSource();
            inputThread = new Thread(ReadStdIn);
            inputThread.Start();

            // Получаем главный узел.
            mainNode = GetNode<GodotHost>("/root/GodotHost");
            mainNode.TreeExited += MainNode_TreeExited;

            // Получаем главное окно.
            rootWindow = GetTree().Root;

            // Сообщаем о готовности
            SendReadySignal();

            // Отправляем КлючЭлемента для корневого окна.
            SendRootWindow();

            // Отправляем КлючЭлемента для библиотеки GameForms.
            // Это для корректного срабатывания события ПриСрабатыванииОдноразовогоТаймера (OneTimerTriggered).
            SendGameFormsItemKey();
        }

        private void MainNode_TreeExited()
        {
            CleanupOrphanedNodes();
            _ExitTree();
            GD.Print("Дерево главного узла закрыто.");
        }

        public void CleanupOrphanedNodes()
        {
            // Найти все узлы, не имеющие родителя, и удалить их
            foreach (var item in dictKeyEl.Values)
            {
                if (item is Node node && node.GetParent() == null)
                {
                    node.QueueFree(); // Запланировать удаление узла
                }
            }
        }

        public override void _Process(double delta)
        {
            // Обрабатываем команды в основном потоке Godot
            ProcessCommandQueue();
        }

        public override void _ExitTree()
        {
            // Останавливаем поток при завершении
            cancellationTokenSource?.Cancel();
            inputThread?.Join(1000); // Ждём завершения потока до 1 с
        }


        public override void _Input(InputEvent @event)
        {
            if (@event is InputEventKey keyEvent)
            {
                int currentHash = HashCode.Combine(
                    (int)keyEvent.Keycode,
                    keyEvent.Pressed,
                    (int)keyEvent.GetModifiersMask()
                );
                if (currentHash != lastEventHash)
                {
                    string eventName = "KeyPress";
                    Dictionary<string, object> dictionaryKeyPress = new Dictionary<string, object>
                    {
                        { "keycode", (int)keyEvent.Keycode },
                        { "pressed", keyEvent.Pressed },
                        { "modifiersMask", (int)keyEvent.GetModifiersMask() },
                    };
                    string eventData = GodotHost.Serialize(dictionaryKeyPress);
                    string itemKey = gameFormsItemKey;
                    SendEvent(eventName, eventData, itemKey);
                    lastEventHash = currentHash;
                }
            }
        }

        #region Обработка stdin/stdout

        private void ReadStdIn()
        {
            try
            {
                using (var stdin = Console.OpenStandardInput())
                using (var reader = new System.IO.StreamReader(stdin, Encoding.UTF8))
                {
                    while (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        var line = reader.ReadLine();
                        if (line == null) break; // EOF

                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            // Добавляем команду в очередь для обработки в основном потоке
                            ProcessIncomingCommand(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GD.PrintErr($"Ошибка чтения stdin: {ex.Message}");
            }
        }

        private void ProcessIncomingCommand(string jsonCommand)
        {
            try
            {
                //GD.Print($"Получена команда: {jsonCommand}");
                var command = Deserialize(jsonCommand);
                if (command == null) return;

                // Создаем объект команды для очереди
                var commandMessage = new CommandMessage
                {
                    id = command["id"].ToString(),
                    cmd = command["cmd"].ToString(),
                    paramsJson = (JsonElement)command["paramsJson"]
                };

                // Добавляем в очередь для обработки в основном потоке
                lock (queueLock)
                {
                    commandQueue.Enqueue(commandMessage);
                }
            }
            catch (Exception ex)
            {
                GD.PrintErr($"Ошибка парсинга команды: {ex.Message}");
                SendError("parse_error", ex.Message);
            }
        }

        private void ProcessCommandQueue()
        {
            lock (queueLock)
            {
                while (commandQueue.Count > 0)
                {
                    var command = commandQueue.Dequeue();
                    ExecuteCommand(command);
                }
            }
        }

        // Получаем имя присланной команды и назначаем ей обработчик.
        private void ExecuteCommand(CommandMessage command)
        {
            try
            {
                // Обрабатываем команду
                object result = command.cmd switch
                {
                    "LoadModel" => HandleLoadModel(command),
                    "DefaultFont" => HandleDefaultFont(command),
                    "SetFont" => HandleSetFont(command),
                    "SetIcon" => HandleSetIcon(command),
                    "SetFontSize" => HandleSetFontSize(command),
                    "GetFont" => HandleGetFont(command),
                    "GetStylebox" => HandleGetStylebox(command),
                    "GetFontSize" => HandleGetFontSize(command),
                    "GetIcon" => HandleGetIcon(command),
                    "ClearFont" => HandleClearFont(command),
                    "ClearColor" => HandleClearColor(command),
                    "ClearStylebox" => HandleClearStylebox(command),
                    "ClearFontSize" => HandleClearFontSize(command),
                    "ClearConstant" => HandleClearConstant(command),
                    "ClearIcon" => HandleClearIcon(command),
                    "SetStylebox" => HandleSetStylebox(command),
                    "GetConstant" => HandleGetConstant(command),
                    "SetConstant" => HandleSetConstant(command),
                    "GetColor" => HandleGetColor(command),
                    "SetColor" => HandleSetColor(command),
                    "ClearTheme" => HandleClearTheme(command),
                    "ClipboardSet" => HandleClipboardSet(command),
                    "ClipboardGet" => HandleClipboardGet(command),
                    "GetLabel" => HandleGetLabel(command),
                    "GetPixel" => HandleGetPixel(command),
                    "GetSnapshot" => HandleGetSnapshot(command),
                    "GetSystemDir" => HandleGetSystemDir(command),
                    "Toggled" => HandleToggled(command),
                    "Resized" => HandleResized(command),
                    "GetNode" => HandleGetNode(command),
                    "FindCenter" => HandleFindCenter(command),
                    "IsStopped" => HandleIsStopped(command),
                    "Stop" => HandleStop(command),
                    "Start" => HandleStart(command),
                    "SetBorderWidthAll" => HandleSetBorderWidthAll(command),
                    "SetCornerRadiusAll" => HandleSetCornerRadiusAll(command),
                    "SetTextureMarginAll" => HandleSetTextureMarginAll(command),
                    "SetExpandMarginAll" => HandleSetExpandMarginAll(command),
                    "ResourceLoad" => HandleResourceLoad(command),
                    "ResourceSave" => HandleResourceSave(command),
                    "GrabFocus" => HandleGrabFocus(command),
                    "HasFocus" => HandleHasFocus(command),
                    "SendConsoleKey" => HandleSendConsoleKey(command),
                    "Center" => HandleCenter(command),
                    "SetCenterToPoint" => HandleSetCenterToPoint(command),
                    "Duplicate" => HandleDuplicate(command),
                    "GetThemeStyleboxLine" => HandleGetThemeStyleboxLine(command),
                    "GetThemeStyleboxFlat" => HandleGetThemeStyleboxFlat(command),
                    "GetThemeStyleboxEmpty" => HandleGetThemeStyleboxEmpty(command),
                    "GetThemeStyleboxTexture" => HandleGetThemeStyleboxTexture(command),
                    "RemoveThemeStyleboxOverride" => HandleRemoveThemeStyleboxOverride(command),
                    "AddThemeStyleboxOverride" => HandleAddThemeStyleboxOverride(command),
                    "ProgrammPressed" => HandleProgrammPressed(command),
                    "Delete" => HandleDelete(command),
                    "GetChildren" => HandleGetChildren(command),
                    "SendToBack" => HandleSendToBack(command),
                    "BringToFront" => HandleBringToFront(command),
                    "PlaceRightBottom" => HandlePlaceRightBottom(command),
                    "PlaceRightTop" => HandlePlaceRightTop(command),
                    "PlaceBottomRight" => HandlePlaceBottomRight(command),
                    "PlaceBottomLeft" => HandlePlaceBottomLeft(command),
                    "PlaceLeftBottom" => HandlePlaceLeftBottom(command),
                    "PlaceLeftTop" => HandlePlaceLeftTop(command),
                    "PlaceTopRight" => HandlePlaceTopRight(command),
                    "PlaceTopLeft" => HandlePlaceTopLeft(command),
                    "PlaceRight" => HandlePlaceRight(command),
                    "PlaceLeft" => HandlePlaceLeft(command),
                    "PlaceBottom" => HandlePlaceBottom(command),
                    "PlaceTop" => HandlePlaceTop(command),
                    "FitChildInRect" => HandleFitChildInRect(command),
                    "GetOkButton" => HandleGetOkButton(command),
                    "AddCancelButton" => HandleAddCancelButton(command),
                    "AddButton" => HandleAddButton(command),
                    "RemoveButton" => HandleRemoveButton(command),
                    "PopupCentered" => HandlePopupCentered(command),
                    "Popup" => HandlePopup(command),
                    "PopupCenteredAcceptDialog" => HandlePopupCenteredAcceptDialog(command),
                    "PopupAcceptDialog" => HandlePopupAcceptDialog(command),
                    "Show" => HandleShow(command),
                    "Hide" => HandleHide(command),
                    "GetLocalMousePosition" => HandleGetLocalMousePosition(command),
                    "ProgramClick" => HandleProgramClick(command),
                    "GetMousePosition" => HandleGetMousePosition(command),
                    "Timeout" => HandleTimeout(command),
                    "SceneTreeTimer" => HandleSceneTreeTimer(command),
                    "RemoveElement" => HandleRemoveElement(command),
                    "LoadFromFile" => HandleLoadFromFile(command),
                    "CreateNode" => HandleCreateNode(command),
                    "GetExecutablePath" => HandleGetExecutablePath(command),
                    "Shutdown" => HandleShutdown(command),
                    "GetDrawMode" => HandleGetDrawMode(command),
                    "GetParent" => HandleGetParent(command),
                    "GetWindow" => HandleGetWindow(command),
                    "RemoveChild" => HandleRemoveChild(command),
                    "AddChild" => HandleAddChild(command),
                    "SetProperty" => HandleSetProperty(command),
                    "GetProperty" => HandleGetProperty(command),
                    "FocusExited" => HandleFocusExited(command),
                    "FocusEntered" => HandleFocusEntered(command),
                    "ButtonUp" => HandleButtonUp(command),
                    "ButtonDown" => HandleButtonDown(command),
                    "Pressed" => HandlePressed(command),
                    "MouseEntered" => HandleMouseEntered(command),
                    "MouseExited" => HandleMouseExited(command),
                    "MouseMove" => HandleMouseMove(command),
                    "Clear" => HandleClear(command),
                    "WarpMouseToControl" => HandleWarpMouseToControl(command),
                    "WarpMouseToVector" => HandleWarpMouseToVector(command),
                    "ControlWarpMouse" => HandleControlWarpMouse(command),
                    "DrawSetTransform" => DoDrawMethod(command, "DrawSetTransform"), // Обязательно перед другими Draw.
                    "DrawPolylineColors" => DoDrawMethod(command, "DrawPolylineColors"),
                    "DrawTextureRectRegion" => DoDrawMethod(command, "DrawTextureRectRegion"),
                    "DrawTextureRect" => DoDrawMethod(command, "DrawTextureRect"),
                    "DrawTexture" => DoDrawMethod(command, "DrawTexture"),
                    "DrawStringOutline" => DoDrawMethod(command, "DrawStringOutline"),
                    "DrawString" => DoDrawMethod(command, "DrawString"),
                    "DrawPolyline" => DoDrawMethod(command, "DrawPolyline"),
                    "DrawMultilineStringOutline" => DoDrawMethod(command, "DrawMultilineStringOutline"),
                    "DrawMultilineString" => DoDrawMethod(command, "DrawMultilineString"),
                    "DrawMultilineColors" => DoDrawMethod(command, "DrawMultilineColors"),
                    "DrawMultiline" => DoDrawMethod(command, "DrawMultiline"),
                    "DrawCircle" => DoDrawMethod(command, "DrawCircle"),
                    "DrawRect" => DoDrawMethod(command, "DrawRect"),
                    "DrawEllipse" => DoDrawMethod(command, "DrawEllipse"),
                    "DrawEllipseArc" => DoDrawMethod(command, "DrawEllipseArc"),
                    "DrawPolygon" => DoDrawMethod(command, "DrawPolygon"),
                    "DrawColoredPolygon" => DoDrawMethod(command, "DrawColoredPolygon"),
                    "DrawLine" => DoDrawMethod(command, "DrawLine"),
                    "DrawArc" => DoDrawMethod(command, "DrawArc"),
                    "DrawChar" => DoDrawMethod(command, "DrawChar"),
                    "DrawCharOutline" => DoDrawMethod(command, "DrawCharOutline"),
                    "DrawDashedLine" => DoDrawMethod(command, "DrawDashedLine"),

                    // ... другие команды

                    _ => HandleUnknownCommand(command) // аналог default
                };

                // Отправляем успешный ответ
                SendResponse(command.id, result);
            }
            catch (Exception ex)
            {
                GD.PrintErr($"Ошибка выполнения команды {command.cmd}: {ex.Message}");
                SendError(command.id, ex.Message);
            }
        }

        #endregion

        #region Обработчики команд

        private dynamic GetElementFromCommand(CommandMessage command)
        {
            JsonElement prop = command.paramsJson.Value;
            string elementItemKey = prop.GetProperty("ItemKey").GetString();
            if (!dictKeyEl.TryGetValue(elementItemKey, out var element))
            {
                GD.Print($"Элемент {elementItemKey} не найден.");
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {elementItemKey} не найден." };
            }
            else
            {
                return element;
            }
        }

        // Чтобы имитировать нажатие клавиши
        private void SimulateKeyPress(int keyCode, bool shiftModifier, bool altModifier, bool ctrlModifier)
        {
            var ev = new InputEventKey();
            ev.Pressed = true; // true - нажата, false - отпущена
            ev.Keycode = (Key)keyCode;
            // Устанавливаем модификаторы
            if (shiftModifier) ev.ShiftPressed = true;
            if (altModifier) ev.AltPressed = true;
            if (ctrlModifier) ev.CtrlPressed = true;
            Input.ParseInputEvent(ev);
        }

        // Чтобы имитировать отпускание клавиши
        private void SimulateKeyRelease(int keyCode, bool shiftModifier, bool altModifier, bool ctrlModifier)
        {
            var releaseEv = new InputEventKey();
            releaseEv.Pressed = false; // true - нажата, false - отпущена
            releaseEv.Keycode = (Key)keyCode;
            // Устанавливаем модификаторы
            if (shiftModifier) releaseEv.ShiftPressed = true;
            if (altModifier) releaseEv.AltPressed = true;
            if (ctrlModifier) releaseEv.CtrlPressed = true;
            Input.ParseInputEvent(releaseEv);
        }




        private void PrintNodeTree(Node node, int depth = 0)
        {
            GD.Print($"{new string(' ', depth * 2)}{node.Name} ({node.GetType().Name})");
            foreach (Node child in node.GetChildren())
                PrintNodeTree(child, depth + 1);
        }

        private object HandleLoadModel(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                string path = TryGetValue<string>(props, nameof(path));

                // Проверяем, существует ли файл на диске
                if (!File.Exists(path))
                {
                    GD.PrintErr($"File not found at {path}");
                    return new { success = false, error = "File not found" };
                }

                var light = new DirectionalLight3D();
                light.RotationDegrees = new Vector3(-45, -45, 0);
                rootWindow.AddChild(light);

                var env = new Godot.Environment();
                env.BackgroundMode = Godot.Environment.BGMode.Color;
                env.BackgroundColor = new Color(0.2f, 0.2f, 0.25f); // Серый фон
                env.AmbientLightSource = Godot.Environment.AmbientSource.Color;
                env.AmbientLightColor = new Color(0.6f, 0.6f, 0.6f); // Общий свет
                env.AmbientLightEnergy = 1.0f;

                var worldEnv = new WorldEnvironment();
                worldEnv.Environment = env;
                rootWindow.AddChild(worldEnv);


                var camera = new Camera3D();
                rootWindow.AddChild(camera);
                camera.LookAtFromPosition(new Vector3(0, 15, 30), Vector3.Zero);
                camera.MakeCurrent();

                // Используем GLTFDocument для прямой загрузки с диска
                var document = new GltfDocument();
                var state = new GltfState();

                Error error = document.AppendFromFile(path, state);
                if (error != Error.Ok)
                {
                    GD.PrintErr($"Не удалось прочитать GLB: {error}");
                    return new { success = false, error = "GLTF parsing error" };
                }

                //Node sceneRoot = document.GenerateScene(state);
                Node3D sceneRoot = document.GenerateScene(state) as Node3D;
                if (sceneRoot != null)
                {
                    rootWindow.AddChild(sceneRoot);
                    GD.Print($"Model added. Parent: {sceneRoot.GetParent()?.Name}, InTree: {sceneRoot.IsInsideTree()}");
                    // Проверяем, есть ли MeshInstance3D
                    var mesh = sceneRoot.GetNodeOrNull<MeshInstance3D>("*"); // или используйте рекурсивный поиск
                    GD.Print($"Mesh found: {mesh != null}");

                    GD.Print($"Model position: {sceneRoot.Position}, scale: {sceneRoot.Scale}");

                    PrintNodeTree(sceneRoot);

                    return new { success = true };
                }
                else
                {
                    return new { success = false, error = "Failed to generate scene" };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        ////private object HandleLoadModel(CommandMessage command)
        ////{
        ////    try
        ////    {
        ////        JsonElement props = GetProps(command);
        ////        string path = TryGetValue<string>(props, nameof(path));

        ////        // Проверяем, существует ли файл на диске
        ////        if (!OS.FileAccess.FileExists(path))
        ////        {
        ////            GD.PrintErr($"File not found at {path}");
        ////            return new { success = false, error = "File not found" };
        ////        }

        ////        // Используем GLTFDocument для прямой загрузки с диска
        ////        var document = new GLTFDocument();
        ////        var state = new GLTFState();

        ////        Error error = document.AppendFromFile(path, state);
        ////        if (error != Error.Ok)
        ////        {
        ////            GD.PrintErr($"Error loading GLB: {error}");
        ////            return new { success = false, error = "GLTF parsing error" };
        ////        }

        ////        Node3D sceneRoot = document.GenerateScene(state);
        ////        if (sceneRoot != null)
        ////        {
        ////            AddChild(sceneRoot);
        ////            return new { success = true };
        ////        }
        ////        else
        ////        {
        ////            return new { success = false, error = "Failed to generate scene" };
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.Message };
        ////    }
        ////}





        private object HandleResourceLoad(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                string resourceItemKey = TryGetValue<string>(props, nameof(resourceItemKey));
                string resource_path = TryGetValue<string>(props, nameof(resource_path));
                var resource = ResourceLoader.Load(resource_path);
                //var resource = GD.Load(resource_path); // Это тоже работающий запасной вариант.
                dictKeyEl.TryAdd(resourceItemKey, resource);
                dictElKey.TryAdd(resource, resourceItemKey);
                string typeResource = resource.ResourceName;
                return new { success = true, report = typeResource };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetCornerRadiusAll(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                int cornerRadius = TryGetValue<int>(props, nameof(cornerRadius));
                element.SetCornerRadiusAll(cornerRadius);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetBorderWidthAll(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                int borderWidth = TryGetValue<int>(props, nameof(borderWidth));
                element.SetBorderWidthAll(borderWidth);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetTextureMarginAll(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                float textureMargin = TryGetValue<float>(props, nameof(textureMargin));
                element.SetTextureMarginAll(textureMargin);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetExpandMarginAll(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                float expandMargin = TryGetValue<float>(props, nameof(expandMargin));
                element.SetExpandMarginAll(expandMargin);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleResourceSave(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string resource_path = TryGetValue<string>(props, nameof(resource_path));
                ResourceSaver.Save(element, resource_path);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private T TryGetValue<T>(JsonElement props, string name)
        {
            if (name == "element")
            {
                if (!props.TryGetProperty(name, out var el))
                {
                    throw new KeyNotFoundException($"TryGetValue: свойство '{name}' отсутствует");
                }
                string elementItemKey = el.ToString();
                if (!dictKeyEl.TryGetValue(elementItemKey, out var element))
                {
                    GD.Print($"TryGetValue: элемент по ключу '{elementItemKey}' не найден");
                    throw new KeyNotFoundException($"TryGetValue: элемент по ключу '{elementItemKey}' не найден");
                }
                else
                {
                    return element;
                }
            }
            else if (name == "Font")
            {
                if (!props.TryGetProperty(name, out var el))
                {
                    throw new KeyNotFoundException($"TryGetValue: свойство '{name}' отсутствует");
                }
                string elementItemKey = el.ToString();
                if (!dictKeyEl.TryGetValue(elementItemKey, out var element))
                {
                    GD.Print($"TryGetValue: элемент по ключу '{elementItemKey}' не найден");
                    throw new KeyNotFoundException($"TryGetValue: элемент по ключу '{elementItemKey}' не найден");
                }
                else
                {
                    return element;
                }
            }
            else if (name == "Texture")
            {
                if (!props.TryGetProperty(name, out var el))
                {
                    throw new KeyNotFoundException($"TryGetValue: свойство '{name}' отсутствует");
                }
                string elementItemKey = el.ToString();
                if (!dictKeyEl.TryGetValue(elementItemKey, out var element))
                {
                    GD.Print($"TryGetValue: элемент по ключу '{elementItemKey}' не найден");
                    throw new KeyNotFoundException($"TryGetValue: элемент по ключу '{elementItemKey}' не найден");
                }
                else
                {
                    return element;
                }
            }
            else if (name == "Points")
            {
                var properties = Deserialize(props.ToString());
                JsonElement jsonElement = (JsonElement)properties[name];
                Godot.Collections.Array pointsArray = new Godot.Collections.Array();
                for (int i = 0; i < jsonElement.GetArrayLength(); i++)
                {
                    JsonElement arrayItem = jsonElement[i];
                    Vector2 position = new Vector2(arrayItem[0].GetSingle(), arrayItem[1].GetSingle());
                    pointsArray.Add(position);
                }
                dynamic points = new Vector2[pointsArray.Count];
                for (int i = 0; i < pointsArray.Count; i++)
                {
                    points[i] = (Vector2)pointsArray[i];
                }
                return points;
            }
            else if (name == "Colors")
            {
                var properties = Deserialize(props.ToString());
                JsonElement jsonElement = (JsonElement)properties[name];
                Godot.Collections.Array colorsArray = new Godot.Collections.Array();
                for (int i = 0; i < jsonElement.GetArrayLength(); i++)
                {
                    JsonElement arrayItem = jsonElement[i];
                    Godot.Color color = new Godot.Color(arrayItem[0].GetSingle(), arrayItem[1].GetSingle(), arrayItem[2].GetSingle(), arrayItem[3].GetSingle());
                    colorsArray.Add(color);
                }
                dynamic colors = new Color[colorsArray.Count];
                for (int i = 0; i < colorsArray.Count; i++)
                {
                    colors[i] = (Color)colorsArray[i];
                }
                return colors;
            }
            else if (name == "TexturePoints")
            {
                var properties = Deserialize(props.ToString());
                JsonElement jsonElement = (JsonElement)properties[name];
                Godot.Collections.Array pointsArray = new Godot.Collections.Array();
                for (int i = 0; i < jsonElement.GetArrayLength(); i++)
                {
                    JsonElement arrayItem = jsonElement[i];
                    Vector2 position = new Vector2(arrayItem[0].GetSingle(), arrayItem[1].GetSingle());
                    pointsArray.Add(position);
                }
                dynamic points = new Vector2[pointsArray.Count];
                for (int i = 0; i < pointsArray.Count; i++)
                {
                    points[i] = (Vector2)pointsArray[i];
                }
                return points;
            }
            else if (name == "Rect2")
            {
                var properties = Deserialize(props.ToString());
                JsonElement jsonElement = (JsonElement)properties[name];
                Vector2 position = new Vector2(jsonElement[0].GetSingle(), jsonElement[1].GetSingle());
                Vector2 size = new Vector2(jsonElement[2].GetSingle(), jsonElement[3].GetSingle());
                dynamic rect2 = new Rect2(position, size);
                return rect2;
            }
            else if (name == "PointsArray")
            {
                var properties = Deserialize(props.ToString());
                JsonElement jsonElement = (JsonElement)properties[name];
                Godot.Collections.Array linesArray = new Godot.Collections.Array();
                for (int i = 0; i < jsonElement.GetArrayLength(); i++)
                {
                    JsonElement entry = jsonElement[i];
                    // Извлекаем точки начала и конца из "Ключа"
                    JsonElement key = entry.GetProperty("Key");
                    Vector2 from = new Vector2(
                        key[0][0].GetSingle(), key[0][1].GetSingle()
                    );
                    Vector2 to = new Vector2(
                        key[1][0].GetSingle(), key[1][1].GetSingle()
                    );
                    linesArray.Add(from);
                    linesArray.Add(to);
                }
                // Преобразуем Godot.Collections.Array в стандартный массив Vector2[]
                dynamic points = new Vector2[linesArray.Count];
                for (int i = 0; i < linesArray.Count; i++)
                {
                    points[i] = (Vector2)linesArray[i];
                }
                return points;
            }
            else if (name == "ColorsArray")
            {
                var properties = Deserialize(props.ToString());
                JsonElement jsonElement = (JsonElement)properties[name];
                Godot.Collections.Array colorsArray = new Godot.Collections.Array();
                for (int i = 0; i < jsonElement.GetArrayLength(); i++)
                {
                    JsonElement entry = jsonElement[i];
                    // Извлекаем цвет из "Значения"
                    JsonElement value = entry.GetProperty("Value");
                    Godot.Color color = new Godot.Color(
                        value[0].GetSingle(),
                        value[1].GetSingle(),
                        value[2].GetSingle(),
                        value[3].GetSingle()
                    );
                    colorsArray.Add(color);
                }
                // Преобразуем Godot.Collections.Array в стандартный массив Colors[]
                dynamic colors = new Color[colorsArray.Count];
                for (int i = 0; i < colorsArray.Count; i++)
                {
                    colors[i] = (Color)colorsArray[i];
                }
                return colors;
            }
            try
            {
                if (!props.TryGetProperty(name, out var el))
                {
                    throw new KeyNotFoundException($"TryGetValue: свойство '{name}' отсутствует");
                }
                return ConvertValueForSet(el, typeof(T).ToString());
            }
            catch (Exception)
            {
                GD.Print($"TryGetValue - Не удалось получить значение для переменной: {name}");
                throw new Exception($"TryGetValue - Не удалось получить значение для переменной: {name}");
            }
        }

        private JsonElement GetProps(CommandMessage command)
        {
            JsonElement prop = command.paramsJson.Value;
            var dictionary = Deserialize(prop);
            JsonElement props = (JsonElement)dictionary["Properties"];
            return props;
        }

        private object HandleSendConsoleKey(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                int keyCode = TryGetValue<int>(props, nameof(keyCode));
                bool shiftModifier = TryGetValue<bool>(props, nameof(shiftModifier));
                bool altModifier = TryGetValue<bool>(props, nameof(altModifier));
                bool ctrlModifier = TryGetValue<bool>(props, nameof(ctrlModifier));

                SimulateKeyPress(keyCode, shiftModifier, altModifier, ctrlModifier);
                // Ждем немного перед отпусканием основной клавиши
                GetTree().CreateTimer(0.08).Timeout += () =>
                {
                    try
                    {
                        SimulateKeyRelease(keyCode, shiftModifier, altModifier, ctrlModifier);
                    }
                    catch (Exception)
                    {
                        GD.PrintErr("Не удалось выполнить SimulateKeyRelease");
                    }
                };
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGrabFocus(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                ((Control)element).GrabFocus();
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleHasFocus(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool hasFocus = ((Control)element).HasFocus();
                return new { success = true, report = hasFocus };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleFindCenter(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                Vector2 position = element.Position;
                if (element.Equals(rootWindow))
                {
                    position = new Vector2I();
                }
                Vector2 size = element.Size;
                float[] positionArr = { position.X + (element.Size.X / 2f), position.Y + (element.Size.Y / 2f) };
                Dictionary<string, object> dictionaryFindCenter = new Dictionary<string, object>
                {
                    { "propertyValue", positionArr },
                    { "propertyType", "osgf.GfVector2" },
                };
                object res = Serialize(dictionaryFindCenter);
                return new { success = true, report = res };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetCenterToPoint(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                if (element.Position.GetType() == typeof(Vector2))
                {
                    Vector2 position = TryGetValue<Vector2>(props, nameof(position));
                    float halfWidth = ((Control)element).Size.X / 2;
                    float halfHeigth = ((Control)element).Size.Y / 2;
                    Vector2 vector2 = new Vector2(position.X - halfWidth, position.Y - halfHeigth);
                    element.Position = vector2;
                }
                else
                {
                    Vector2I position = TryGetValue<Vector2I>(props, nameof(position));
                    float halfWidth = ((Control)element).Size.X / 2;
                    float halfHeigth = ((Control)element).Size.Y / 2;
                    Vector2I vector2i = new Vector2I(position.X - Convert.ToInt32(halfWidth), position.Y - Convert.ToInt32(halfHeigth));
                    element.Position = vector2i;
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleCenter(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                if (element.Position.GetType() == typeof(Vector2))
                {
                    float shiftX = TryGetValue<float>(props, nameof(shiftX));
                    float shiftY = TryGetValue<float>(props, nameof(shiftY));
                    var parent = element.GetParent();
                    element.Position = new Vector2(
                        ((parent.Size.X - element.Size.X) / 2f) + shiftX,
                        ((parent.Size.Y - element.Size.Y) / 2f) + shiftY
                    );
                }
                else
                {
                    int shiftX = TryGetValue<int>(props, nameof(shiftX));
                    int shiftY = TryGetValue<int>(props, nameof(shiftY));
                    var parent = element.GetParent();
                    element.Position = new Vector2I(
                        Convert.ToInt32((parent.Size.X - element.Size.X) / 2f) + shiftX,
                        Convert.ToInt32((parent.Size.Y - element.Size.Y) / 2f) + shiftY
                    );
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleDuplicate(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string resourceItemKey = TryGetValue<string>(props, nameof(resourceItemKey));
                Resource resource = ((Resource)element).Duplicate();
                dictKeyEl.TryAdd(resourceItemKey, resource);
                dictElKey.TryAdd(resource, resourceItemKey);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetThemeStyleboxLine(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string styleName = TryGetValue<string>(props, nameof(styleName));
                string styleBoxItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                StyleBoxLine styleBoxLine = null;
                try
                {
                    styleBoxLine = ((Control)element).GetThemeStylebox(styleName) as StyleBoxLine;
                }
                catch { }
                if (styleBoxLine != null)
                {
                    if (dictElKey.TryGetValue(styleBoxLine, out string styleBoxKey))
                    {
                        return new { success = true, report = styleBoxKey };
                    }
                    else
                    {
                        dictKeyEl.TryAdd(styleBoxItemKey, styleBoxLine);
                        dictElKey.TryAdd(styleBoxLine, styleBoxItemKey);
                        return new { success = true, report = styleBoxItemKey };
                    }
                }
                else
                {
                    styleBoxLine = new StyleBoxLine();
                    dictKeyEl.TryAdd(styleBoxItemKey, styleBoxLine);
                    dictElKey.TryAdd(styleBoxLine, styleBoxItemKey);
                    return new { success = true, report = styleBoxItemKey };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetThemeStyleboxEmpty(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string styleName = TryGetValue<string>(props, nameof(styleName));
                string styleBoxItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                StyleBoxEmpty styleBoxEmpty = null;
                try
                {
                    styleBoxEmpty = ((Control)element).GetThemeStylebox(styleName) as StyleBoxEmpty;
                }
                catch { }
                if (styleBoxEmpty != null)
                {
                    if (dictElKey.TryGetValue(styleBoxEmpty, out string styleBoxKey))
                    {
                        return new { success = true, report = styleBoxKey };
                    }
                    else
                    {
                        dictKeyEl.TryAdd(styleBoxItemKey, styleBoxEmpty);
                        dictElKey.TryAdd(styleBoxEmpty, styleBoxItemKey);
                        return new { success = true, report = styleBoxItemKey };
                    }
                }
                else
                {
                    styleBoxEmpty = new StyleBoxEmpty();
                    dictKeyEl.TryAdd(styleBoxItemKey, styleBoxEmpty);
                    dictElKey.TryAdd(styleBoxEmpty, styleBoxItemKey);
                    return new { success = true, report = styleBoxItemKey };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetThemeStyleboxTexture(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string styleName = TryGetValue<string>(props, nameof(styleName));
                string styleBoxItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                StyleBoxTexture styleBoxTexture = null;
                try
                {
                    styleBoxTexture = ((Control)element).GetThemeStylebox(styleName) as StyleBoxTexture;
                }
                catch { }
                if (styleBoxTexture != null)
                {
                    if (dictElKey.TryGetValue(styleBoxTexture, out string styleBoxKey))
                    {
                        return new { success = true, report = styleBoxKey };
                    }
                    else
                    {
                        dictKeyEl.TryAdd(styleBoxItemKey, styleBoxTexture);
                        dictElKey.TryAdd(styleBoxTexture, styleBoxItemKey);
                        return new { success = true, report = styleBoxItemKey };
                    }
                }
                else
                {
                    styleBoxTexture = new StyleBoxTexture();
                    dictKeyEl.TryAdd(styleBoxItemKey, styleBoxTexture);
                    dictElKey.TryAdd(styleBoxTexture, styleBoxItemKey);
                    return new { success = true, report = styleBoxItemKey };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetThemeStyleboxFlat(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string styleName = TryGetValue<string>(props, nameof(styleName));
                string styleBoxItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                StyleBoxFlat styleBoxFlat = null;
                try
                {
                    styleBoxFlat = ((Control)element).GetThemeStylebox(styleName) as StyleBoxFlat;
                }
                catch { }
                if (styleBoxFlat != null)
                {
                    if (dictElKey.TryGetValue(styleBoxFlat, out string styleBoxKey))
                    {
                        return new { success = true, report = styleBoxKey };
                    }
                    else
                    {
                        dictKeyEl.TryAdd(styleBoxItemKey, styleBoxFlat);
                        dictElKey.TryAdd(styleBoxFlat, styleBoxItemKey);
                        return new { success = true, report = styleBoxItemKey };
                    }
                }
                else
                {
                    styleBoxFlat = new StyleBoxFlat();
                    dictKeyEl.TryAdd(styleBoxItemKey, styleBoxFlat);
                    dictElKey.TryAdd(styleBoxFlat, styleBoxItemKey);
                    return new { success = true, report = styleBoxItemKey };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleRemoveThemeStyleboxOverride(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string styleName = TryGetValue<string>(props, nameof(styleName));
                element.RemoveThemeStyleboxOverride(styleName);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleAddThemeStyleboxOverride(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string styleName = TryGetValue<string>(props, nameof(styleName));
                string styleBoxItemKey = TryGetValue<string>(props, nameof(styleBoxItemKey));
                if (!dictKeyEl.TryGetValue(styleBoxItemKey, out var styleBox))
                {
                    GD.Print($"Элемент {styleBoxItemKey} не найден");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {styleBoxItemKey} не найден" };
                }
                element.AddThemeStyleboxOverride(styleName, styleBox);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleBringToFront(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                var parent = element.GetParent();
                parent.MoveChild(element, parent.GetChildCount() - 1);
                try
                {
                    element.Hide();
                    element.Show();
                }
                catch { }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleDelete(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                element.QueueFree();
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetChildren(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                object res = null;
                Godot.Collections.Array<Node> arrayChildren = ((Node)element).GetChildren(true);
                string[] children = new string[arrayChildren.Count];
                for (int i = 0; i < arrayChildren.Count(); i++)
                {
                    var _element = arrayChildren[i];
                    if (dictElKey.TryGetValue(_element, out string _elementKey))
                    {
                        children[i] = _elementKey;
                    }
                    else
                    {
                        children[i] = "<Object#null>";
                    }
                }
                Dictionary<string, object> dictionaryChildren = new Dictionary<string, object>
                {
                    { "children", children },
                };
                res = Serialize(dictionaryChildren);
                return new { success = true, report = res };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSendToBack(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                var parent = element.GetParent();
                parent.MoveChild(element, 0);
                try
                {
                    element.Hide();
                    element.Show();
                }
                catch { }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleUnknownCommand(CommandMessage command)
        {
            return new { demand = $"Unknown command (Неизвестная команда): {command}." };
        }

        private object HandleGetSystemDir(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                int enumSystemDir = TryGetValue<int>(props, nameof(enumSystemDir));
                string systemDir = OS.GetSystemDir((SystemDir)enumSystemDir);
                return new { success = true, report = systemDir };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleClipboardGet(CommandMessage command)
        {
            try
            {
                string textFromClipboard = DisplayServer.ClipboardGet();
                return new { success = true, report = textFromClipboard };
            }
            catch (Exception)
            {
                return new { success = true, report = "<Object#null>" };
            }
        }

        private object HandleClipboardSet(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                string textToClipboard = TryGetValue<string>(props, nameof(textToClipboard));
                DisplayServer.ClipboardSet(textToClipboard);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetExecutablePath(CommandMessage command)
        {
            try
            {
                string executablePath = OS.GetExecutablePath();
                return new { success = true, report = executablePath };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleCreateNode(CommandMessage command)
        {
            try
            {
                Node node;
                JsonElement props = GetProps(command);
                string typeNode = TryGetValue<string>(props, nameof(typeNode));
                string itemKey = TryGetValue<string>(props, nameof(itemKey));

                if (typeNode == "Graphics")
                {
                    node = new MyDrawer();
                }
                else if (typeNode == "Button")
                {
                    Button button = new Button();
                    dictKeyEl.TryAdd(itemKey, button);
                    dictElKey.TryAdd(button, itemKey);
                    CreateElementProxy(button);
                    return new { success = true };
                }
                else if (typeNode == "ThemeScene")
                {
                    Theme theme = new Theme();
                    dictKeyEl.TryAdd(itemKey, theme);
                    dictElKey.TryAdd(theme, itemKey);
                    return new { success = true };
                }
                else if (typeNode == "ThemeButton"
                    || typeNode == "ThemeWindow"
                    )
                {
                    Theme theme = new Theme();
                    dictKeyEl.TryAdd(itemKey, theme);
                    dictElKey.TryAdd(theme, itemKey);
                    return new { success = true };
                }
                else if (typeNode == "FontFile")
                {
                    FontFile fontFile = new FontFile();
                    string resource_path = TryGetValue<string>(props, nameof(resource_path));

                    // Для внешних шрифтов.
                    Error err = fontFile.LoadDynamicFont(resource_path);
                    if (err == Error.Ok)
                    {
                        dictKeyEl.TryAdd(itemKey, fontFile);
                        dictElKey.TryAdd(fontFile, itemKey);
                    }
                    else
                    {
                        GD.PrintErr("Не удалось загрузить шрифт: " + resource_path);
                        return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + "Не удалось загрузить шрифт: " + resource_path };
                    }
                    return new { success = true };
                }
                else if (typeNode == "FontVariation")
                {
                    FontVariation fontVariation = new FontVariation();
                    string resource_path = TryGetValue<string>(props, nameof(resource_path));

                    // Для внешних шрифтов.
                    var fontFile = new FontFile();
                    Error err = fontFile.LoadDynamicFont(resource_path);
                    if (err == Error.Ok)
                    {
                        fontVariation.BaseFont = fontFile;
                        dictKeyEl.TryAdd(itemKey, fontVariation);
                        dictElKey.TryAdd(fontVariation, itemKey);
                    }
                    else
                    {
                        GD.PrintErr("Не удалось загрузить шрифт: " + resource_path);
                        return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + "Не удалось загрузить шрифт: " + resource_path };
                    }
                    return new { success = true };
                }
                else if (typeNode == "ImageTexture")
                {
                    ImageTexture imageTexture = new Godot.ImageTexture();
                    string resource_path = TryGetValue<string>(props, nameof(resource_path));

                    var image = Godot.Image.LoadFromFile(resource_path);
                    imageTexture = ImageTexture.CreateFromImage(image);
                    imageTexture.ResourcePath = resource_path;

                    dictKeyEl.TryAdd(itemKey, imageTexture);
                    dictElKey.TryAdd(imageTexture, itemKey);
                    return new { success = true };
                }
                else if (typeNode == "Image")
                {
                    Godot.Image image = new Godot.Image();
                    string resource_path = TryGetValue<string>(props, nameof(resource_path));

                    image = Godot.Image.LoadFromFile(resource_path);
                    image.ResourcePath = resource_path;

                    dictKeyEl.TryAdd(itemKey, image);
                    dictElKey.TryAdd(image, itemKey);
                    return new { success = true };
                }
                else if (typeNode == "StyleBoxFlat")
                {
                    StyleBoxFlat styleBoxFlat = new StyleBoxFlat();
                    dictKeyEl.TryAdd(itemKey, styleBoxFlat);
                    dictElKey.TryAdd(styleBoxFlat, itemKey);
                    return new { success = true };
                }
                else if (typeNode == "StyleBoxEmpty")
                {
                    StyleBoxEmpty styleBoxEmpty = new StyleBoxEmpty();
                    dictKeyEl.TryAdd(itemKey, styleBoxEmpty);
                    dictElKey.TryAdd(styleBoxEmpty, itemKey);
                    return new { success = true };
                }
                else if (typeNode == "StyleBoxLine")
                {
                    StyleBoxLine styleBoxLine = new StyleBoxLine();
                    dictKeyEl.TryAdd(itemKey, styleBoxLine);
                    dictElKey.TryAdd(styleBoxLine, itemKey);
                    return new { success = true };
                }
                else if (typeNode == "StyleBoxTexture")
                {
                    StyleBoxTexture styleBoxTexture = new StyleBoxTexture();
                    dictKeyEl.TryAdd(itemKey, styleBoxTexture);
                    dictElKey.TryAdd(styleBoxTexture, itemKey);
                    return new { success = true };
                }
                else
                {
                    node = (Node)Activator.CreateInstance(Type.GetType($"Godot.{typeNode}, GodotSharp"));
                }
                dictKeyEl.TryAdd(itemKey, node);
                dictElKey.TryAdd(node, itemKey);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private void CreateElementProxy(Control control)
        {
            var proxy = new ElementProxy();
            proxy.Name = "ElementProxy";
            proxy.OnProcess = (delta) =>
            {
                // Если мышь над элементом, получаем и отправляем её позицию
                if (proxy.isMouseOver)
                {
                    Vector2 localPos = control.GetLocalMousePosition();
                    if (proxy.mouseOldPosition != localPos)
                    {
                        if (proxy.mouseMoveSubscribed)
                        {
                            string eventName = "MouseMove";
                            float[] position = { localPos.X, localPos.Y };
                            Dictionary<string, object> dictionaryPosition = new Dictionary<string, object>
                            {
                                { "position", position },
                            };
                            string eventData = GodotHost.Serialize(dictionaryPosition);
                            dictElKey.TryGetValue(control, out string controlKey);
                            string itemKey = controlKey;
                            SendEvent(eventName, eventData, itemKey);
                        }
                        proxy.mouseOldPosition = localPos;
                    }
                }
            };

            proxy.OnReady = () =>
            {
                if (control.GetType() == typeof(Button))
                {
                    ((Button)control).Toggled += (toggledOn) =>
                    {
                        if (proxy.toggledSubscribed)
                        {
                            string eventName = "Toggled";
                            Dictionary<string, object> dictionary = new Dictionary<string, object>()
                            {
                                {"toggledOn", toggledOn },
                            };
                            string eventData = GodotHost.Serialize(dictionary);
                            dictElKey.TryGetValue(control, out string controlKey);
                            string itemKey = controlKey;
                            SendEvent(eventName, eventData, itemKey);
                        }
                    };
                }

                control.MouseEntered += () =>
                {
                    proxy.thisMouseEntered = true;
                    if (proxy.mouseMoveSubscribed)
                    {
                        proxy.isMouseOver = true;
                        GD.Print("Курсор вошёл в область элемента");
                        control.Modulate = Colors.LightBlue;
                    }
                    if (proxy.mouseEnteredSubscribed)
                    {
                        string eventName = "MouseEntered";
                        Godot.Vector2 position = control.GetLocalMousePosition();
                        Dictionary<string, object> dictionary = new Dictionary<string, object>()
                        {
                            { "position", new float[] { position.X , position.Y } },
                        };

                        string eventData = GodotHost.Serialize(dictionary);
                        dictElKey.TryGetValue(control, out string controlKey);
                        string itemKey = controlKey;
                        SendEvent(eventName, eventData, itemKey);
                    }
                };
                control.MouseExited += () =>
                {
                    proxy.thisMouseEntered = false;
                    if (proxy.mouseMoveSubscribed)
                    {
                        proxy.isMouseOver = false;
                        GD.Print("Курсор покинул область элемента");
                        control.Modulate = Colors.White;
                    }
                    if (proxy.mouseExitedSubscribed)
                    {
                        Godot.Vector2 position = control.GetLocalMousePosition();
                        string eventName = "MouseExited";
                        Dictionary<string, object> dictionary = new Dictionary<string, object>()
                                {
                                    { "position", new float[] { position.X , position.Y } },
                                };

                        string eventData = GodotHost.Serialize(dictionary);
                        dictElKey.TryGetValue(control, out string controlKey);
                        string itemKey = controlKey;
                        SendEvent(eventName, eventData, itemKey);
                    }
                };
                control.FocusEntered += () =>
                {
                    if (proxy.focusEnteredSubscribed)
                    {
                        string eventName = "FocusEntered";
                        Dictionary<string, object> dictionary = new Dictionary<string, object>() { };
                        string eventData = GodotHost.Serialize(dictionary);
                        dictElKey.TryGetValue(control, out string controlKey);
                        string itemKey = controlKey;
                        SendEvent(eventName, eventData, itemKey);
                    }
                };
                control.FocusExited += () =>
                {
                    if (proxy.focusExitedSubscribed)
                    {
                        string eventName = "FocusExited";
                        Dictionary<string, object> dictionary = new Dictionary<string, object>() { };
                        string eventData = GodotHost.Serialize(dictionary);
                        dictElKey.TryGetValue(control, out string controlKey);
                        string itemKey = controlKey;
                        SendEvent(eventName, eventData, itemKey);
                    }
                };
                control.Resized += () =>
                {
                    if (proxy.resizedSubscribed)
                    {
                        string eventName = "Resized";
                        Dictionary<string, object> dictionary = new Dictionary<string, object>() { };
                        string eventData = GodotHost.Serialize(dictionary);
                        dictElKey.TryGetValue(control, out string controlKey);
                        string itemKey = controlKey;
                        SendEvent(eventName, eventData, itemKey);
                    }
                };
            };

            proxy.OnInput = (@event) =>
            {
                if (!proxy.thisMouseEntered)
                {
                    return;
                }

                if (@event is InputEventMouseButton eventMouseButton)
                {
                    //GD.Print("Mouse Click/Unclick at: ", eventMouseButton.Position);
                    if (proxy.pressedSubscribed)
                    {
                        // Учитываем только при отпускании мыши.
                        if (!eventMouseButton.Pressed)
                        {
                            string eventName = "Pressed";
                            Dictionary<string, object> dictionary = new Dictionary<string, object>()
                                    {
                                        { "mouseButtonMask", eventMouseButton.ButtonMask },
                                        { "mouseButton", eventMouseButton.ButtonIndex },
                                        { "position", new float[] { eventMouseButton.Position.X , eventMouseButton.Position.Y } },
                                    };
                            string eventData = GodotHost.Serialize(dictionary);
                            dictElKey.TryGetValue(control, out string controlKey);
                            string itemKey = controlKey;
                            SendEvent(eventName, eventData, itemKey);
                        }
                    }
                    if (proxy.buttonDownSubscribed)
                    {
                        // Учитываем только при нажатии мыши.
                        if (eventMouseButton.Pressed)
                        {
                            string eventName = "ButtonDown";
                            Dictionary<string, object> dictionary = new Dictionary<string, object>()
                                    {
                                        { "mouseButtonMask", eventMouseButton.ButtonMask },
                                        { "mouseButton", eventMouseButton.ButtonIndex },
                                        { "position", new float[] { eventMouseButton.Position.X , eventMouseButton.Position.Y } },
                                    };
                            string eventData = GodotHost.Serialize(dictionary);
                            dictElKey.TryGetValue(control, out string controlKey);
                            string itemKey = controlKey;
                            SendEvent(eventName, eventData, itemKey);
                        }
                    }
                    if (proxy.buttonUpSubscribed)
                    {
                        // Учитываем только при отпускании мыши.
                        if (!eventMouseButton.Pressed)
                        {
                            string eventName = "ButtonUp";
                            Dictionary<string, object> dictionary = new Dictionary<string, object>()
                                    {
                                        { "mouseButtonMask", eventMouseButton.ButtonMask },
                                        { "mouseButton", eventMouseButton.ButtonIndex },
                                        { "position", new float[] { eventMouseButton.Position.X , eventMouseButton.Position.Y } },
                                    };
                            string eventData = GodotHost.Serialize(dictionary);
                            dictElKey.TryGetValue(control, out string controlKey);
                            string itemKey = controlKey;
                            SendEvent(eventName, eventData, itemKey);
                        }
                    }
                }
                else if (@event is InputEventKey eventKey)
                {
                    if (control.HasFocus())
                    {
                        //GD.Print("eventKey Keycode: ", eventKey.Keycode);
                    }
                }
                else if (@event is InputEventAction eventAction)
                {
                    if (control.HasFocus())
                    {
                        //GD.Print("eventAction Pressed: ", eventAction.Pressed);
                    }
                }
            };

            control.AddChild(proxy);
        }

        private object HandleShutdown(CommandMessage command)
        {
            // Даем время на отправку ответа
            Task.Delay(1000).ContinueWith(_ =>
            {
                GetTree().CreateTimer(1.0).Timeout += () => GetTree().Quit();
            });
            return new { success = true, report = true };
        }

        private object HandleGetDrawMode(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                var drawMode = ((Button)element).GetDrawMode();
                return new { success = true, report = $"{drawMode}" };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetParent(CommandMessage command)
        {
            JsonElement props = GetProps(command);
            dynamic element = TryGetValue<dynamic>(props, nameof(element));
            var parent = element.GetParent();
            dictElKey.TryGetValue(parent, out string parentKey);
            return new { success = true, report = parentKey };
        }

        private object HandleGetNode(CommandMessage command)
        {
            JsonElement props = GetProps(command);
            dynamic element = TryGetValue<dynamic>(props, nameof(element));
            string name = TryGetValue<string>(props, nameof(name));
            var child = element.GetNode<Node>(name);
            try
            {
                dictElKey.TryGetValue(child, out string childKey);
                return new { demand = command.cmd, report = childKey };
            }
            catch (Exception)
            {
                return new { demand = command.cmd, report = $"<Object#null>" };
            }
        }

        private object HandleGetSnapshot(CommandMessage command)
        {
            JsonElement props = GetProps(command);
            dynamic element = TryGetValue<dynamic>(props, nameof(element));
            string path = TryGetValue<string>(props, nameof(path));
            int imageFormat = TryGetValue<int>(props, nameof(imageFormat));

            Godot.Image image = element.GetViewport().GetTexture().GetImage();

            bool successSave = false;
            if (image == null || image.GetWidth() == 0 || image.GetHeight() == 0)
            {
            }
            else
            {
                // 3. Сохраняем изображение на диск.
                switch (imageFormat)
                {
                    case 0:
                        path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".png");
                        if (image.SavePng(path) == Error.Ok)
                        {
                            successSave = true;
                        }
                        break;
                    case 1:
                        path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".jpg");
                        if (image.SaveJpg(path) == Error.Ok)
                        {
                            successSave = true;
                        }
                        break;
                    case 2:
                        path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".webp");
                        if (image.SaveWebp(path) == Error.Ok)
                        {
                            successSave = true;
                        }
                        break;
                }
            }

            if (successSave)
            {
                return new { success = true, report = path };
            }
            else
            {
                return new { success = false };
            }
        }

        private object HandleGetWindow(CommandMessage command)
        {
            JsonElement props = GetProps(command);
            dynamic element = TryGetValue<dynamic>(props, nameof(element));
            var parent = element.GetWindow();
            dictElKey.TryGetValue(parent, out string parentKey);
            return new { demand = command.cmd, report = parentKey };
        }

        private object HandlePlaceRightBottom(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 anchorSize = anchor.Size;
                Vector2 elementSize = element.Size;
                int offsetRight = TryGetValue<int>(props, nameof(offsetRight));
                int offsetBottom = TryGetValue<int>(props, nameof(offsetBottom));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X + anchorSize.X + offsetRight, anchorPosition.Y + anchorSize.Y + offsetBottom);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X + anchorSize.X + offsetRight), Convert.ToInt32(anchorPosition.Y + anchorSize.Y + offsetBottom));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceRightTop(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 anchorSize = anchor.Size;
                Vector2 elementSize = element.Size;
                int offsetRight = TryGetValue<int>(props, nameof(offsetRight));
                int offsetTop = TryGetValue<int>(props, nameof(offsetTop));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X + anchorSize.X + offsetRight, anchorPosition.Y - elementSize.Y - offsetTop);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X + anchorSize.X + offsetRight), Convert.ToInt32(anchorPosition.Y - elementSize.Y - offsetTop));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceBottomRight(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 anchorSize = anchor.Size;
                Vector2 elementSize = element.Size;
                int offsetBottom = TryGetValue<int>(props, nameof(offsetBottom));
                int offsetRight = TryGetValue<int>(props, nameof(offsetRight));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X + anchorSize.X + offsetRight, anchorPosition.Y + anchorSize.Y + offsetBottom);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X + anchorSize.X + offsetRight), Convert.ToInt32(anchorPosition.Y + anchorSize.Y + offsetBottom));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceBottomLeft(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 anchorSize = anchor.Size;
                Vector2 elementSize = element.Size;
                int offsetBottom = TryGetValue<int>(props, nameof(offsetBottom));
                int offsetLeft = TryGetValue<int>(props, nameof(offsetLeft));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X - elementSize.X - offsetLeft, anchorPosition.Y + anchorSize.Y + offsetBottom);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X - elementSize.X - offsetLeft), Convert.ToInt32(anchorPosition.Y + anchorSize.Y + offsetBottom));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceLeftBottom(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 anchorSize = anchor.Size;
                Vector2 elementSize = element.Size;
                int offsetLeft = TryGetValue<int>(props, nameof(offsetLeft));
                int offsetBottom = TryGetValue<int>(props, nameof(offsetBottom));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X - elementSize.X - offsetLeft, anchorPosition.Y + anchorSize.Y + offsetBottom);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X - elementSize.X - offsetLeft), Convert.ToInt32(anchorPosition.Y + anchorSize.Y + offsetBottom));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceLeftTop(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 anchorSize = anchor.Size;
                Vector2 elementSize = element.Size;
                int offsetLeft = TryGetValue<int>(props, nameof(offsetLeft));
                int offsetTop = TryGetValue<int>(props, nameof(offsetTop));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X - elementSize.X - offsetLeft, anchorPosition.Y - elementSize.Y - offsetTop);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X - elementSize.X - offsetLeft), Convert.ToInt32(anchorPosition.Y - elementSize.Y - offsetTop));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceTopRight(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 anchorSize = anchor.Size;
                Vector2 elementSize = element.Size;
                int offsetTop = TryGetValue<int>(props, nameof(offsetTop));
                int offsetRight = TryGetValue<int>(props, nameof(offsetRight));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X + anchorSize.X + offsetRight, anchorPosition.Y - elementSize.Y - offsetTop);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X + anchorSize.X + offsetRight), Convert.ToInt32(anchorPosition.Y - elementSize.Y - offsetTop));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceTopLeft(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 anchorSize = anchor.Size;
                Vector2 elementSize = element.Size;
                int offsetTop = TryGetValue<int>(props, nameof(offsetTop));
                int offsetLeft = TryGetValue<int>(props, nameof(offsetLeft));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X - elementSize.X - offsetLeft, anchorPosition.Y - elementSize.Y - offsetTop);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X - elementSize.X - offsetLeft), Convert.ToInt32(anchorPosition.Y - elementSize.Y - offsetTop));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceRight(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 anchorSize = anchor.Size;
                int offset = TryGetValue<int>(props, nameof(offset));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X + anchorSize.X + offset, anchorPosition.Y);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X + anchorSize.X + offset), Convert.ToInt32(anchorPosition.Y));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceLeft(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 elementSize = element.Size;
                int offset = TryGetValue<int>(props, nameof(offset));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X - elementSize.X - offset, anchorPosition.Y);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X - elementSize.X - offset), Convert.ToInt32(anchorPosition.Y));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceBottom(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 anchorSize = anchor.Size;
                int offset = TryGetValue<int>(props, nameof(offset));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X, anchorPosition.Y + anchorSize.Y + offset);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X), Convert.ToInt32(anchorPosition.Y + anchorSize.Y + offset));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePlaceTop(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string anchorItemKey = TryGetValue<string>(props, nameof(anchorItemKey));
                if (!dictKeyEl.TryGetValue(anchorItemKey, out var anchor))
                {
                    GD.Print($"Элемент {anchorItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {anchorItemKey} не найден." };
                }
                Vector2 anchorPosition = anchor.Position;
                Vector2 elementSize = element.Size;
                int offset = TryGetValue<int>(props, nameof(offset));
                if (element.GetType() == typeof(Control))
                {
                    element.Position = new Vector2(anchorPosition.X, anchorPosition.Y - elementSize.Y - offset);
                }
                else
                {
                    element.Position = new Vector2I(Convert.ToInt32(anchorPosition.X), Convert.ToInt32(anchorPosition.Y - elementSize.Y - offset));
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleRemoveChild(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string childItemKey = TryGetValue<string>(props, nameof(childItemKey));
                if (!dictKeyEl.TryGetValue(childItemKey, out var child))
                {
                    GD.Print($"Элемент {childItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {childItemKey} не найден." };
                }
                element.RemoveChild(child);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleAddChild(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string childItemKey = TryGetValue<string>(props, nameof(childItemKey));
                if (!dictKeyEl.TryGetValue(childItemKey, out var child))
                {
                    GD.Print($"Элемент {childItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {childItemKey} не найден." };
                }
                element.AddChild(child);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleFitChildInRect(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string childKeyItem = TryGetValue<string>(props, nameof(childKeyItem));
                Vector2 position = TryGetValue<Vector2>(props, nameof(position));
                Vector2 size = TryGetValue<Vector2>(props, nameof(size));
                Rect2 rect2 = new Rect2(position, size);
                if (childKeyItem != "")
                {
                    if (!dictKeyEl.TryGetValue(childKeyItem, out var child))
                    {
                        GD.Print($"Элемент {childKeyItem} не найден.");
                        return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {childKeyItem} не найден." };
                    }
                    ((Container)element).FitChildInRect(child, rect2);
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetLabel(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                Label label = ((AcceptDialog)element).GetLabel();
                if (dictElKey.TryGetValue(label, out string labelKey))
                {
                    return new { success = true, report = labelKey };
                }
                string labelItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                dictKeyEl.TryAdd(labelItemKey, label);
                dictElKey.TryAdd(label, labelItemKey);
                return new { success = true, report = labelItemKey };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetOkButton(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                Button button = ((AcceptDialog)element).GetOkButton();
                if (dictElKey.TryGetValue(button, out string buttonKey))
                {
                    return new { success = true, report = buttonKey };
                }
                string okButtonItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                dictKeyEl.TryAdd(okButtonItemKey, button);
                dictElKey.TryAdd(button, okButtonItemKey);
                return new { success = true, report = okButtonItemKey };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleAddCancelButton(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string addedButtonItemKey = TryGetValue<string>(props, nameof(addedButtonItemKey));
                string text = TryGetValue<string>(props, nameof(text));
                Button button = element.AddCancelButton(text);
                dictKeyEl.TryAdd(addedButtonItemKey, button);
                dictElKey.TryAdd(button, addedButtonItemKey);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleAddButton(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string addedButtonItemKey = TryGetValue<string>(props, nameof(addedButtonItemKey));
                string text = TryGetValue<string>(props, nameof(text));
                bool right = TryGetValue<bool>(props, nameof(right));
                Button button = element.AddButton(text, right);
                dictKeyEl.TryAdd(addedButtonItemKey, button);
                dictElKey.TryAdd(button, addedButtonItemKey);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleRemoveButton(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string buttonItemKey = TryGetValue<string>(props, nameof(buttonItemKey));
                if (!dictKeyEl.TryGetValue(buttonItemKey, out var button))
                {
                    GD.Print($"Элемент {buttonItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {buttonItemKey} не найден." };
                }
                element.RemoveButton(button);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePopupCentered(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string itemKey = TryGetValue<string>(props, nameof(itemKey));
                float timeout = TryGetValue<float>(props, nameof(timeout));
                Vector2I minsize = TryGetValue<Vector2I>(props, nameof(minsize));
                if (timeout > 0f)
                {
                    _ = Task.Run(async () =>
                    {
                        await RunSceneTreeTimer(timeout / 1000);
                        var dialog = (Window)element;
                        // Подписываемся на сигнал удаления
                        dialog.TreeExited += () =>
                        {
                            if (dictKeyEl.TryGetValue(itemKey, out var _))
                            {
                                dictKeyEl.TryRemove(itemKey, out _);
                            }
                        };
                        dialog.QueueFree();
                    });
                }
                element.PopupCentered(minsize);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePopupCenteredAcceptDialog(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string itemKey = TryGetValue<string>(props, nameof(itemKey));
                float timeout = TryGetValue<float>(props, nameof(timeout));
                string dialog_text = TryGetValue<string>(props, nameof(dialog_text));
                string title = TryGetValue<string>(props, nameof(title));
                Vector2I minsize = TryGetValue<Vector2I>(props, nameof(minsize));
                if (timeout > 0f)
                {
                    _ = Task.Run(async () =>
                    {
                        await RunSceneTreeTimer(timeout / 1000);
                        var dialog = (Window)element;
                        // Подписываемся на сигнал удаления
                        dialog.TreeExited += () =>
                        {
                            if (dictKeyEl.TryGetValue(itemKey, out var _))
                            {
                                dictKeyEl.TryRemove(itemKey, out _);
                            }
                        };
                        dialog.QueueFree();
                    });
                }
                element.DialogText = dialog_text;
                element.Title = title;
                element.PopupCentered(minsize);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePopupAcceptDialog(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string itemKey = TryGetValue<string>(props, nameof(itemKey));
                string dialog_text = TryGetValue<string>(props, nameof(dialog_text));
                string title = TryGetValue<string>(props, nameof(title));
                Vector2I position = TryGetValue<Vector2I>(props, nameof(position));
                Vector2I size = TryGetValue<Vector2I>(props, nameof(size));
                float timeout = TryGetValue<float>(props, nameof(timeout));
                if (timeout > 0f)
                {
                    _ = Task.Run(async () =>
                    {
                        await RunSceneTreeTimer(timeout / 1000);
                        var dialog = (Window)element;
                        // Подписываемся на сигнал удаления
                        dialog.TreeExited += () =>
                        {
                            if (dictKeyEl.TryGetValue(itemKey, out var _))
                            {
                                dictKeyEl.TryRemove(itemKey, out _);
                            }
                        };
                        dialog.QueueFree();
                    });
                }
                element.DialogText = dialog_text;
                element.Title = title;
                Rect2I rect2I = new Rect2I(position, size);
                element.Popup(rect2I);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePopup(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                string itemKey = TryGetValue<string>(props, nameof(itemKey));
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                Vector2I position = TryGetValue<Vector2I>(props, nameof(position));
                Vector2I size = TryGetValue<Vector2I>(props, nameof(size));
                float timeout = TryGetValue<float>(props, nameof(timeout));
                if (timeout > 0f)
                {
                    _ = Task.Run(async () =>
                    {
                        await RunSceneTreeTimer(timeout / 1000);
                        var dialog = (Window)element;
                        // Подписываемся на сигнал удаления
                        dialog.TreeExited += () =>
                        {
                            if (dictKeyEl.TryGetValue(itemKey, out var _))
                            {
                                dictKeyEl.TryRemove(itemKey, out _);
                            }
                        };
                        dialog.QueueFree();
                    });
                }
                Rect2I rect2I = new Rect2I(position, size);
                element.Popup(rect2I);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleShow(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                element.Show();
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleHide(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                if (!element.Equals(rootWindow))
                {
                    element.Hide();
                }
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetPixel(CommandMessage command)
        {
            JsonElement props = GetProps(command);
            dynamic element = TryGetValue<dynamic>(props, nameof(element));
            int x = TryGetValue<int>(props, nameof(x));
            int y = TryGetValue<int>(props, nameof(y));
            Godot.Color color = element.GetPixel(x, y);
            object res = ConvertValueForSend(color);
            return new { success = true, report = res };
        }

        private object HandleGetLocalMousePosition(CommandMessage command)
        {
            JsonElement props = GetProps(command);
            dynamic element = TryGetValue<dynamic>(props, nameof(element));
            Vector2 positionMouse = element.GetLocalMousePosition();
            object res = ConvertValueForSend(positionMouse);
            return new { demand = command.cmd, report = res };
        }

        private object HandleProgramClick(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                int mouseButton = TryGetValue<int>(props, nameof(mouseButton));
                Vector2 mousePos = GetViewport().GetMousePosition();
                var pressEvent = new InputEventMouseButton
                {
                    ButtonIndex = (MouseButton)mouseButton,
                    Position = mousePos,
                    Pressed = true,
                    ButtonMask = 0
                };
                var releaseEvent = new InputEventMouseButton
                {
                    ButtonIndex = (MouseButton)mouseButton,
                    Position = mousePos,
                    Pressed = false,
                    ButtonMask = 0
                };
                Input.ParseInputEvent(pressEvent);
                Input.ParseInputEvent(releaseEvent);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetMousePosition(CommandMessage command)
        {
            Vector2 positionMouse = GetViewport().GetMousePosition();
            float[] positionMouseArr = { positionMouse.X, positionMouse.Y };
            Dictionary<string, object> dictionaryPositionMouse = new Dictionary<string, object>
            {
                { "position", positionMouseArr },
            };
            object res = Serialize(dictionaryPositionMouse);
            return new { demand = command.cmd, report = res };
        }

        private object HandleIsStopped(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                Variant res = ((Godot.Timer)element).Call("is_stopped");
                return new { success = true, report = res.Obj };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleStop(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                element.Stop();
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleStart(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                double time_sec = TryGetValue<double>(props, nameof(time_sec));
                element.Start(time_sec);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleTimeout(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                Godot.Timer element = (Godot.Timer)TryGetValue<dynamic>(props, nameof(element));
                element.Timeout += () =>
                {
                    string eventName = "Timeout";
                    Dictionary<string, object> dictionary = new Dictionary<string, object>() { };
                    string eventData = Serialize(dictionary);
                    dictElKey.TryGetValue(element, out string elementKey);
                    string itemKey = elementKey;
                    SendEvent(eventName, eventData, itemKey);
                };
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        public object HandleSceneTreeTimer(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                float time = TryGetValue<float>(props, nameof(time));
                _ = Task.Run(async () =>
                {
                    await RunSceneTreeTimer(time / 1000);
                    string eventName = "OneTimerTriggered";
                    Dictionary<string, object> dictionaryEvent = new Dictionary<string, object>() { };
                    string eventData = Serialize(dictionaryEvent);
                    string itemKey = gameFormsItemKey;
                    SendEvent(eventName, eventData, itemKey);
                });
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        public async Task RunSceneTreeTimer(float time)
        {
            await ToSignal(GetTree().CreateTimer(time), SceneTreeTimer.SignalName.Timeout);
        }

        private object HandleRemoveElement(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string itemKey = TryGetValue<string>(props, nameof(itemKey));
                // Удаляем из словарей
                dictElKey.TryRemove(element, out string _);
                dictKeyEl.TryRemove(itemKey, out _);

                // Теперь обрабатываем удаление в зависимости от типа
                if (element is Node node)
                {
                    node.QueueFree();
                    GD.Print($"Узел {node.Name} с ключом {itemKey} удален");
                }
                else if (element is Resource resource)
                {
                    // Для ресурсов - можно освободить память
                    resource.Dispose();
                    GD.Print($"Ресурс с ключом {itemKey} удален");
                }
                else if (element is RefCounted refCounted)
                {
                    // Для RefCounted - уменьшаем счетчик ссылок
                    // Обычно они сами удаляются, но можно принудительно
                    refCounted.Dispose();
                    GD.Print($"RefCounted объект с ключом {itemKey} удален");
                }
                else
                {
                    // Для обычных объектов - просто удаляем ссылку
                    GD.Print($"Объект {element.GetType().Name} с ключом {itemKey} удален из словарей");
                }
                return new { success = true, elementType = element.GetType().Name };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleLoadFromFile(CommandMessage command)
        {
            try
            {
                string itemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                JsonElement props = GetProps(command);
                string path = TryGetValue<string>(props, nameof(path));
                Godot.Image image = Godot.Image.LoadFromFile(path);
                image.ResourcePath = path;
                dictKeyEl.TryAdd(itemKey, image);
                dictElKey.TryAdd(image, itemKey);

                return new { success = true, report = itemKey };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object DoDrawMethod(CommandMessage command, string drawMethod)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                MyDrawer.DrawerConfig drawerConfig = new MyDrawer.DrawerConfig();
                var properties = Deserialize(props.ToString());
                foreach (var item in properties)
                {
                    if (item.Key == "element")
                    {
                        continue;
                    }
                    string propertyName = item.Key;
                    drawerConfig[propertyName] = GetJsonElementProperty(props, item.Key);
                }
                element.DrawParams[drawMethod] = drawerConfig;
                element.MarkDirty();
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleControlWarpMouse(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                Vector2 position = TryGetValue<Vector2>(props, nameof(position));
                float duration = TryGetValue<float>(props, nameof(duration));
                Vector2 elementPosition = element.Position;
                Vector2 newPosition = new Vector2(elementPosition.X + position.X, elementPosition.Y + position.Y);
                DoWarpMouseDuration(newPosition, duration);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleWarpMouseToControl(CommandMessage command)
        {
            try
            {
                Vector2 position = new Vector2();
                JsonElement props = GetProps(command);
                string itemKey = TryGetValue<string>(props, nameof(itemKey));
                float duration = TryGetValue<float>(props, nameof(duration));
                if (itemKey != "")
                {
                    if (!dictKeyEl.TryGetValue(itemKey, out var targetElement))
                    {
                        GD.Print($"Элемент {itemKey} не найден.");
                        return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {itemKey} не найден." };
                    }
                    else
                    {
                        position = new Vector2(targetElement.Position.X + (targetElement.Size.X / 2f), targetElement.Position.Y + (targetElement.Size.Y / 2f));
                        DoWarpMouseDuration(position, duration);
                        return new { success = true };
                    }
                }
                else
                {
                    GD.Print($"Элемент {itemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {itemKey} не найден." };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleWarpMouseToVector(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                Vector2 position = TryGetValue<Vector2>(props, nameof(position));
                float duration = TryGetValue<float>(props, nameof(duration));
                DoWarpMouseDuration(position, duration);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        public async void DoWarpMouseDuration(Vector2 position, float duration)
        {
            Vector2 startPosition = GetViewport().GetMousePosition();
            float elapsed = 0;
            while (elapsed < duration)
            {
                elapsed += (float)GetProcessDeltaTime();
                float t = Math.Min(elapsed / duration, 1.0f);
                float smoothT = t * t * (3f - 2f * t);
                Vector2 currentPos = startPosition.Lerp(position, smoothT);
                Window _mainWindow = GetTree().Root;
                _mainWindow.WarpMouse(currentPos);
                await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
            }
            Window mainWindow = GetTree().Root;
            mainWindow.WarpMouse(position);
        }

        private dynamic ConvertValueForSet(JsonElement itemValue, string strPropertyType)
        {
            if (strPropertyType == "Godot.Color")
            {
                Godot.Color color = new Godot.Color()
                {
                    R = itemValue[0].GetSingle(),
                    G = itemValue[1].GetSingle(),
                    B = itemValue[2].GetSingle(),
                    A = itemValue[3].GetSingle(),
                };
                return color;
            }
            else if (strPropertyType == "System.String")
            {
                return itemValue.GetString();
            }
            else if (strPropertyType == "System.Decimal")
            {
                return itemValue.GetSingle();
            }
            else if (strPropertyType == "System.Single")
            {
                return itemValue.GetSingle();
            }
            else if (strPropertyType == "System.Double")
            {
                return itemValue.GetSingle();
            }
            else if (strPropertyType == "System.Int64")
            {
                return itemValue.GetInt32();
            }
            else if (strPropertyType == "System.Int32")
            {
                return itemValue.GetInt32();
            }
            else if (strPropertyType == "System.Boolean")
            {
                return itemValue.GetBoolean();
            }
            else if (strPropertyType == "Godot.Vector2")
            {
                return new Godot.Vector2(itemValue[0].GetSingle(), itemValue[1].GetSingle());
            }
            else if (strPropertyType == "Godot.Vector2I")
            {
                return new Godot.Vector2I(itemValue[0].GetInt32(), itemValue[1].GetInt32());
            }
            else if (strPropertyType == "Godot.ImageTexture")
            {
                return itemValue.GetString();
            }
            else if (strPropertyType == "Godot.Rect2")
            {
                Godot.Rect2 rect2 = new Godot.Rect2()
                {
                    Position = new Godot.Vector2(itemValue[0].GetSingle(), itemValue[1].GetSingle()),
                    Size = new Godot.Vector2(itemValue[2].GetSingle(), itemValue[3].GetSingle()),
                };
                return rect2;
            }
            else
            {
                GD.Print($"ConvertValueForSet - Не учтено значение для типа: {strPropertyType} - {itemValue.ToString()}");
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Не учтено значение для типа: {strPropertyType} - {itemValue.ToString()}" };
            }
        }

        private object HandleSetProperty(CommandMessage command)
        {
            try
            {
                JsonElement prop = command.paramsJson.Value;
                var dictionary = Deserialize(prop);
                var properties = Deserialize(dictionary["Properties"].ToString());
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string propName = TryGetValue<string>(props, nameof(propName));
                JsonElement itemValue = (JsonElement)properties["propValue"];
                //Для свойств у которых не можем получить element.Get(propName).
                if (SetSpecialProperties.TryGetValue(propName, out var setter))
                {
                    setter(element, itemValue);
                    return new { success = true };
                }
                // Для остальных свойств.
                var propElement = element.Get(propName);

                if (propElement.Obj == null)
                {
                    GD.Print($"HandleSetProperty: свойство {propName} у {element.Name} равно null. Задействуйте словарь SetSpecialProperties.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"свойство {propName} у {element.Name} равно null. Задействуйте словарь SetSpecialProperties." };
                }
                string strPropertyType = propElement.Obj.GetType().FullName;
                var propValue = ConvertValueForSet(itemValue, strPropertyType);
                ((GodotObject)element).Set(propName, propValue);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        public static object ConvertValueForSend(dynamic obj)
        {
            string strPropertyType;
            try
            {
                strPropertyType = obj.GetType().FullName;
            }
            catch (Exception)
            {
                GD.Print($"ConvertValueForSend - Не удалось получить значение для типа strPropertyType для: {obj?.ToString()}");
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Не удалось получить значение для типа strPropertyType для: {obj?.ToString()}" };
            }
            if (strPropertyType == "Godot.Color")
            {
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                    {
                        { "propertyValue", new float[] { obj.R, obj.G, obj.B, obj.A } },
                        { "propertyType", "osgf.GfColor" },
                    };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "Godot.FontVariation")
            {
                dictElKey.TryGetValue(obj, out string objKey);
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                {
                    { "propertyValue", objKey },
                    { "propertyType", "osgf.GfFontVariation" },
                };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "Godot.Theme")
            {
                dictElKey.TryGetValue(obj, out string objKey);
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                {
                    { "propertyValue", objKey },
                    { "propertyType", "osgf.GfTheme" },
                };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "Godot.ImageTexture")
            {
                dictElKey.TryGetValue(obj, out string objKey);
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                {
                    { "propertyValue", objKey },
                    { "propertyType", "osgf.GfImageTexture" },
                };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "Godot.Rect2")
            {
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                    {
                        { "propertyValue", new float[] { obj.Position.X , obj.Position.Y, obj.Size.X, obj.Size.Y } },
                        { "propertyType", "osgf.GfRect2" },
                    };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "System.Double")
            {
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                    {
                        { "propertyValue", obj },
                        { "propertyType", "System.Decimal" },
                    };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "System.Int32")
            {
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                    {
                        { "propertyValue", obj },
                        { "propertyType", "System.Int32" },
                    };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "System.Int64")
            {
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                    {
                        { "propertyValue", obj },
                        { "propertyType", "System.Int32" },
                    };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "Godot.StringName")
            {
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                    {
                        { "propertyValue", obj.ToString() },
                        { "propertyType", "System.String" },
                    };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "System.String")
            {
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                    {
                        { "propertyValue", obj },
                        { "propertyType", "System.String" },
                    };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "System.Boolean")
            {
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                    {
                        { "propertyValue", obj },
                        { "propertyType", "System.Boolean" },
                    };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "Godot.Vector2")
            {
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                    {
                        { "propertyValue", new float[] { obj.X , obj.Y } },
                        { "propertyType", "osgf.GfVector2" },
                    };
                return Serialize(dictionaryProp);
            }
            else if (strPropertyType == "Godot.Vector2I")
            {
                Dictionary<string, object> dictionaryProp = new Dictionary<string, object>
                    {
                        { "propertyValue", new int[] { obj.X , obj.Y } },
                        { "propertyType", "osgf.GfVector2i" },
                    };
                return Serialize(dictionaryProp);
            }
            else
            {
                GD.Print($"ConvertValueForSend - Не учтено значение для типа: {obj.GetType().FullName} - {obj?.ToString()}");
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Не учтено значение для типа: {obj.GetType().FullName} - {obj?.ToString()}" };
            }
        }

        private object HandleGetProperty(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string propName = TryGetValue<string>(props, nameof(propName));
                // Для свойств у которых не можем получить element.Get(propName).
                if (GetSpecialProperties.TryGetValue(propName, out var getter))
                {
                    object val = getter(element);
                    return new { success = true, report = ConvertValueForSend(val) };
                }
                // Для свойств со значением <Object#null>. Значение свойства не задано.
                Variant rez = element.Get(propName);
                if (rez.Obj == null)
                {
                    return new { success = true, report = "<Object#null>" };
                }
                // Для остальных свойств.
                object res = ConvertValueForSend(rez.Obj);
                return new { success = true, report = res };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private static string GetCSharpPropertyName(string godotName)
        {
            if (string.IsNullOrEmpty(godotName))
            {
                return godotName;
            }

            var sb = new StringBuilder(godotName.Length);
            bool nextUpper = false;
            bool firstCharSet = false;

            for (int i = 0; i < godotName.Length; i++)
            {
                char c = godotName[i];

                if (c == '_')
                {
                    nextUpper = true;
                    continue;
                }

                if (nextUpper)
                {
                    sb.Append(char.ToUpperInvariant(c));
                    nextUpper = false;
                    firstCharSet = true;
                }
                else
                {
                    // Первую букву делаем заглавной, остальные — как есть
                    if (!firstCharSet)
                    {
                        sb.Append(char.ToUpperInvariant(c));
                        firstCharSet = true;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }
            return sb.ToString();
        }

        // Этот метод для класса Графика. Возвращает значение для свойства, имя которого указанного в формате C#.
        private dynamic GetJsonElementProperty(JsonElement props, string propName)
        {
            if (propName == "Radius"
            || propName == "Width"
            || propName == "Major"
            || propName == "Minor"
            || propName == "Oversampling"
            || propName == "StartAngle"
            || propName == "DashLength"
            || propName == "EndAngle")
            {
                return TryGetValue<float>(props, propName);
            }
            else if (propName == "Rotation")
            {
                return TryGetValue<float>(props, propName) * float.Pi / 180; // Значение в радианах. (радианы = градусы * PI / 180);
            }
            else if (propName == "Rect2"
                || propName == "SrcRect"
                || propName == "DestRect")
            {
                return TryGetValue<Rect2>(props, propName);
            }
            else if (propName == "Position"
                || propName == "Center"
                || propName == "From"
                || propName == "To"
                || propName == "Scale"
                || propName == "Size")
            {
                return TryGetValue<Vector2>(props, propName);
            }
            else if (propName == "PointsArray"
                || propName == "TexturePoints"
                || propName == "Points")
            {
                return TryGetValue<Vector2[]>(props, propName);
            }
            else if (propName == "ColorsArray"
                || propName == "Colors")
            {
                return TryGetValue<Color[]>(props, propName);
            }
            else if (propName == "Color"
                || propName == "Modulate")
            {
                return TryGetValue<Color>(props, propName);
            }
            else if (propName == "Antialiased"
                || propName == "Tile"
                || propName == "Transpose"
                || propName == "Filled"
                || propName == "Aligned"
                || propName == "ClipUv")
            {
                return TryGetValue<Boolean>(props, propName);
            }
            else if (propName == "PointCount"
                || propName == "OutlineSize"
                || propName == "FontSize"
                || propName == "Alignment"
                || propName == "MaxLines"
                || propName == "BrkFlags"
                || propName == "JustificationFlags"
                || propName == "Direction"
                || propName == "Orientation")
            {
                return TryGetValue<Int32>(props, propName);
            }
            else if (propName == "Font")
            {
                return TryGetValue<Font>(props, propName);
            }
            else if (propName == "Texture")
            {
                return TryGetValue<Texture>(props, propName);
            }
            else if (propName == "Char"
                || propName == "Text")
            {
                return TryGetValue<string>(props, propName);
            }
            else
            {
                GD.Print($"Ошибка получения {propName} в методе GetJsonElementProperty.");
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Ошибка получения {propName}." };
            }
        }

        private object HandleMouseMove(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool actionIsNull = TryGetValue<bool>(props, nameof(actionIsNull));
                ElementProxy proxy = element.GetNode<ElementProxy>("ElementProxy");
                proxy.mouseMoveSubscribed = !actionIsNull;
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleProgrammPressed(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));

                // Нажатие кнопки мыши
                var pressEvent = new InputEventMouseButton
                {
                    ButtonIndex = MouseButton.Left,
                    Position = element.Position,
                    Pressed = true,
                    ButtonMask = MouseButtonMask.Left
                };
                Input.ParseInputEvent(pressEvent);

                var releaseEvent = new InputEventMouseButton
                {

                    ButtonIndex = MouseButton.Left,
                    Position = element.Position,
                    Pressed = false,
                    ButtonMask = 0
                };
                Input.ParseInputEvent(releaseEvent);

                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleMouseExited(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool actionIsNull = TryGetValue<bool>(props, nameof(actionIsNull));
                ElementProxy proxy = element.GetNode<ElementProxy>("ElementProxy");
                proxy.mouseExitedSubscribed = !actionIsNull;
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleMouseEntered(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool actionIsNull = TryGetValue<bool>(props, nameof(actionIsNull));
                ElementProxy proxy = element.GetNode<ElementProxy>("ElementProxy");
                proxy.mouseEnteredSubscribed = !actionIsNull;
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleFocusEntered(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool actionIsNull = TryGetValue<bool>(props, nameof(actionIsNull));
                ElementProxy proxy = element.GetNode<ElementProxy>("ElementProxy");
                proxy.focusEnteredSubscribed = !actionIsNull;
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleFocusExited(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool actionIsNull = TryGetValue<bool>(props, nameof(actionIsNull));
                ElementProxy proxy = element.GetNode<ElementProxy>("ElementProxy");
                proxy.focusExitedSubscribed = !actionIsNull;
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleButtonUp(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool actionIsNull = TryGetValue<bool>(props, nameof(actionIsNull));
                ElementProxy proxy = element.GetNode<ElementProxy>("ElementProxy");
                proxy.buttonUpSubscribed = !actionIsNull;
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleButtonDown(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool actionIsNull = TryGetValue<bool>(props, nameof(actionIsNull));
                ElementProxy proxy = element.GetNode<ElementProxy>("ElementProxy");
                proxy.buttonDownSubscribed = !actionIsNull;
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleToggled(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool actionIsNull = TryGetValue<bool>(props, nameof(actionIsNull));
                ElementProxy proxy = element.GetNode<ElementProxy>("ElementProxy");
                proxy.toggledSubscribed = !actionIsNull;
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleResized(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool actionIsNull = TryGetValue<bool>(props, nameof(actionIsNull));
                ElementProxy proxy = element.GetNode<ElementProxy>("ElementProxy");
                proxy.resizedSubscribed = !actionIsNull;
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandlePressed(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                bool actionIsNull = TryGetValue<bool>(props, nameof(actionIsNull));
                ElementProxy proxy = element.GetNode<ElementProxy>("ElementProxy");
                proxy.pressedSubscribed = !actionIsNull;
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleClearTheme(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                element.Clear();
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetConstant(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                int constanta = element.GetConstant(name, theme_type);
                object res = ConvertValueForSend(constanta);
                return new { success = true, report = res };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetColor(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                Color color = element.GetColor(name, theme_type);
                object res = ConvertValueForSend(color);
                return new { demand = command.cmd, report = res };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetConstant(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                int constanta = TryGetValue<int>(props, nameof(constanta));
                element.SetConstant(name, theme_type, constanta);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetStylebox(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                string styleboxItemKey = TryGetValue<string>(props, nameof(styleboxItemKey));
                if (!dictKeyEl.TryGetValue(styleboxItemKey, out var stylebox))
                {
                    GD.Print($"Элемент {styleboxItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {styleboxItemKey} не найден." };
                }
                element.SetStylebox(name, theme_type, stylebox);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleClearIcon(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                element.ClearIcon(name, theme_type);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleClearConstant(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                element.ClearConstant(name, theme_type);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleClearFontSize(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                element.ClearFontSize(name, theme_type);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleClearStylebox(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                element.ClearStylebox(name, theme_type);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleClearColor(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                element.ClearColor(name, theme_type);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleClearFont(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                element.ClearFont(name, theme_type);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetFontSize(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                int fontSize = TryGetValue<int>(props, nameof(fontSize));
                element.SetFontSize(name, theme_type, fontSize);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetIcon(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                string iconItemKey = TryGetValue<string>(props, nameof(iconItemKey));
                if (!dictKeyEl.TryGetValue(iconItemKey, out var icon))
                {
                    GD.Print($"Элемент {iconItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {iconItemKey} не найден." };
                }
                element.SetIcon(name, theme_type, icon);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleDefaultFont(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                Font font = ((Theme)element).DefaultFont;
                if (dictElKey.TryGetValue(font, out var fontItemKey))
                {
                    //1.Если font найдем в словаре, тогда передаем его ItemKey
                    return new { success = false, report = fontItemKey };
                }
                else
                {
                    //2.Если font не найдем в словаре, тогда создаем ему ItemKey и заносим его в словарь.
                    //3.Передаем его ItemKey.
                    string newFontItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                    dictKeyEl.TryAdd(newFontItemKey, font);
                    dictElKey.TryAdd(font, newFontItemKey);
                    return new { success = true, report = newFontItemKey };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetFontSize(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                var fontSize = ((Theme)element).GetFontSize(name, theme_type);
                object res = ConvertValueForSend(fontSize);
                return new { success = true, report = res };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetIcon(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                var icon = ((Theme)element).GetIcon(name, theme_type);
                if (dictElKey.TryGetValue(icon, out var iconItemKey))
                {
                    //1.Если icon найдем в словаре, тогда передаем его ItemKey
                    return new { success = false, report = iconItemKey };
                }
                else
                {
                    //2.Если icon не найдем в словаре, тогда создаем ему ItemKey и заносим его в словарь.
                    //3.Передаем его ItemKey.
                    string newIconItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                    dictKeyEl.TryAdd(newIconItemKey, icon);
                    dictElKey.TryAdd(icon, newIconItemKey);
                    return new { success = true, report = newIconItemKey };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetStylebox(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                var stylebox = ((Theme)element).GetStylebox(name, theme_type);
                if (dictElKey.TryGetValue(stylebox, out var styleboxItemKey))
                {
                    //1.Если stylebox найдем в словаре, тогда передаем его ItemKey
                    return new { success = false, report = styleboxItemKey };
                }
                else
                {
                    //2.Если stylebox не найдем в словаре, тогда создаем ему ItemKey и заносим его в словарь.
                    //3.Передаем его ItemKey.
                    string newStyleboxItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                    dictKeyEl.TryAdd(newStyleboxItemKey, stylebox);
                    dictElKey.TryAdd(stylebox, newStyleboxItemKey);
                    return new { success = true, report = newStyleboxItemKey };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleGetFont(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                Font font = ((Theme)element).GetFont(name, theme_type);
                if (dictElKey.TryGetValue(font, out var fontItemKey))
                {
                    //1.Если font найдем в словаре, тогда передаем его ItemKey
                    return new { success = false, report = fontItemKey };
                }
                else
                {
                    //2.Если font не найдем в словаре, тогда создаем ему ItemKey и заносим его в словарь.
                    //3.Передаем его ItemKey.
                    string newFontItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
                    dictKeyEl.TryAdd(newFontItemKey, font);
                    dictElKey.TryAdd(font, newFontItemKey);
                    return new { success = true, report = newFontItemKey };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetFont(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                string fontItemKey = TryGetValue<string>(props, nameof(fontItemKey));
                if (!dictKeyEl.TryGetValue(fontItemKey, out var font))
                {
                    GD.Print($"Элемент {fontItemKey} не найден.");
                    return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + $"Элемент {fontItemKey} не найден." };
                }
                element.SetFont(name, theme_type, font);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleSetColor(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                string name = TryGetValue<string>(props, nameof(name));
                string theme_type = TryGetValue<string>(props, nameof(theme_type));
                Color color = TryGetValue<Color>(props, nameof(color));
                element.SetColor(name, theme_type, color);
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        private object HandleClear(CommandMessage command)
        {
            try
            {
                JsonElement props = GetProps(command);
                dynamic element = TryGetValue<dynamic>(props, nameof(element));
                ((Dictionary<string, DrawerConfig>)element.DrawParams).Clear();
                element.MarkDirty();
                return new { success = true };
            }
            catch (Exception ex)
            {
                return new { success = false, error = "Ошибка в методе " + MethodBase.GetCurrentMethod().Name + ": " + ex.StackTrace };
            }
        }

        #endregion

        #region Отправка ответов

        private void SendReadySignal()
        {
            var readyMessage = new CommandMessage
            {
                cmd = "ready",
                id = "system"
            };
            string json = SerializeWithUnicode(readyMessage);
            SendToStdOut(json);
        }

        private void SendGameFormsItemKey()
        {
            gameFormsItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
            dictKeyEl.TryAdd(gameFormsItemKey, this);
            dictElKey.TryAdd(this, gameFormsItemKey);
            var readyMessage = new CommandMessage
            {
                cmd = "GameFormsItemKey",
                id = "system",
                ItemKey = gameFormsItemKey
            };
            string json = SerializeWithUnicode(readyMessage);
            SendToStdOut(json);
        }

        private void SendRootWindow()
        {
            string itemKey = "d" + Path.GetRandomFileName().Replace(".", "");
            dictKeyEl.TryAdd(itemKey, rootWindow);
            dictElKey.TryAdd(rootWindow, itemKey);
            var readyMessage = new CommandMessage
            {
                cmd = "rootWindow",
                id = "system",
                ItemKey = itemKey
            };
            string json = SerializeWithUnicode(readyMessage);
            SendToStdOut(json);
        }

        public void SendResponse(string commandId, object result)
        {
            var response = new CommandMessage
            {
                id = commandId,
                result = result
            };
            string json = SerializeWithUnicode(response);
            SendToStdOut(json);
        }

        private string SerializeWithUnicode(object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }

        private void SendError(string commandId, string errorMessage)
        {
            var response = new CommandMessage
            {
                id = commandId,
                error = errorMessage
            };
            string json = SerializeWithUnicode(response);
            SendToStdOut(json);
        }

        public void SendEvent(string eventName, object eventData, string itemKey)
        {
            var eventMessage = new CommandMessage
            {
                id = "godotEvent",
                ItemKey = itemKey,
                nameEvent = eventName,
                dataEvent = eventData
            };
            string json = SerializeWithUnicode(eventMessage);
            SendToStdOut(json);
        }

        private void SendToStdOut(string message)
        {
            try
            {
                // Важно: добавляем символ новой строки как разделитель сообщений
                Console.WriteLine(message);
                // Немедленно отправляем
                Console.Out.Flush();
                //GD.Print($"Отправлен ответ: {message}");
            }
            catch (Exception ex)
            {
                GD.PrintErr($"Ошибка записи в stdout: {ex.Message}");
            }
        }

        #endregion

        public static Dictionary<string, object> Deserialize(string obj)
        {
            Dictionary<string, object> answer = JsonSerializer.Deserialize<Dictionary<string, object>>(obj);
            return answer;
        }

        public static Dictionary<string, object> Deserialize(JsonElement obj)
        {
            Dictionary<string, object> answer = JsonSerializer.Deserialize<Dictionary<string, object>>(obj);
            return answer;
        }

        public static string Serialize(Dictionary<string, object> obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static string Serialize(CommandMessage obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        private static readonly Dictionary<string, Func<Godot.Node, object>> GetSpecialProperties = new()
        {
            ["z_index"] = node =>
            {
                int index = node.GetIndex();
                var parent = node.GetParent();
                if (parent != null)
                {
                    Godot.Collections.Array<Node> array = ((Node)parent).GetChildren();
                    for (int i = 0; i < array.Count; i++)
                    {
                        var item = array[i];
                        if (item.Equals(node))
                        {
                            index = i;
                            break;
                        }
                    }
                }
                return index;
            },
        };

        private static readonly Dictionary<string, Action<dynamic, JsonElement>> SetSpecialProperties = new()
        {
            ["z_index"] = (element, itemValue) =>
            {
                var parent = element.GetParent();
                if (parent == null)
                {
                    GD.Print($"SetSpecialProperties: у узла {element.Name} нет родителя — невозможно установить z_index");
                    return;
                }
                int index = itemValue.GetInt32();
                int maxIndex = ((Node)parent).GetChildren().Count - 1; // учтем сам элемент, поэтому отнимем единицу.
                if (index > maxIndex)
                {
                    parent.MoveChild(element, maxIndex);
                }
                else
                {
                    parent.MoveChild(element, index);
                }
                Godot.Collections.Array<Node> children = ((Node)parent).GetChildren();
                for (int i = 0; i < children.Count; i++)
                {
                    Node child = children[i];
                    try
                    {
                        ((Control)child).Hide();
                        ((Control)child).Show();
                    }
                    catch { }
                }
            },
            ["texture"] = (element, itemValue) =>
            {
                dictKeyEl.TryGetValue(itemValue.GetString(), out var texture);
                ((GodotObject)element).Set("texture", texture);
            },
            ["theme"] = (element, itemValue) =>
            {
                dictKeyEl.TryGetValue(itemValue.GetString(), out var theme);
                ((GodotObject)element).Set("theme", theme);
            },
            ["embedded_border"] = (element, itemValue) =>
            {
                dictKeyEl.TryGetValue(itemValue.GetString(), out var styleBox);
                ((GodotObject)element).Set("styleBox", styleBox);
            },
            ["default_font"] = (element, itemValue) =>
            {
                dictKeyEl.TryGetValue(itemValue.GetString(), out var font);
                ((GodotObject)element).Set("default_font", font);
            },
        };
    }

    #region Классы данных

    public class CommandMessage
    {
        public string cmd { get; set; } = null;
        public string id { get; set; } = null;
        public object result { get; set; } = null;
        public JsonElement? paramsJson { get; set; } = null;
        public string error { get; set; } = null;
        public string ItemKey { get; set; } = null; // Ключ элемента.
        public string nameEvent { get; set; } = null;
        public object dataEvent { get; set; } = null;
    }

    #endregion

}
