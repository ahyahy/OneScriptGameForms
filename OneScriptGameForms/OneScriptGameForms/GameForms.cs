using OneScript.Contexts;
using OneScript.Execution;
using OneScript.Language;
using OneScript.StandardLibrary;
using OneScript.StandardLibrary.Collections;
using ScriptEngine;
using ScriptEngine.HostedScript;
using ScriptEngine.HostedScript.Extensions;
using ScriptEngine.Hosting;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    [ContextClass("ИгровыеФормы", "GameForms")]
    public class GameForms : AutoContext<GameForms>, IDisposable
    {
        public static GameForms instance;
        public static GfAction EventAction = null;
        public static ConcurrentQueue<GfEventArgs> EventQueue = new ConcurrentQueue<GfEventArgs>();
        private static object syncRoot = new Object();
        public static ConcurrentDictionary<string, dynamic> dictKeyEl = new ConcurrentDictionary<string, dynamic>();
        public static ConcurrentDictionary<dynamic, string> dictElKey = new ConcurrentDictionary<dynamic, string>();
        public static GfWindow rootWindow;
        public static string gameFormsItemKey;
        public GameForms dll_obj = null;
        public static bool displayServiceMessages = false;
        private bool godotLaunched = false;
        public event Action<string> OnTestException; // Для отлова событий в сценарных обработчиках событий.

        // Процесс Godot
        private static System.Diagnostics.Process godotProcess;
        private static ConcurrentDictionary<string, TaskCompletionSource<string>> pendingCommands
            = new ConcurrentDictionary<string, TaskCompletionSource<string>>();

        // Для синхронизации запуска, подтверждение запуска Godo.
        private static ManualResetEventSlim godotReady = new ManualResetEventSlim(false);

        private static ScriptingEngine engine;

        // Статический кэш: "ПанельныйКонтейнер" → typeof(GfPanelContainer)
        private static readonly Dictionary<string, Type> _typeCache = BuildTypeCache();

        private static Dictionary<string, Type> BuildTypeCache()
        {
            var cache = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (!type.IsClass || !type.IsPublic)
                {
                    continue;
                }
                var attr = type.GetCustomAttribute<ContextClassAttribute>();
                if (attr == null)
                {
                    continue;
                }
                // attr.Name выглядит как "ИфПанельныйКонтейнер"
                // убираем префикс "Иф" → "ПанельныйКонтейнер"
                var key = attr.Name.Replace("Иф", "");
                cache[key] = type;
                // Добавляем английские имена классов.
                // ФлагПереносаСтроки = osgf.GfLineBreakFlag
                var key2 = type.ToString().Replace("osgf.Gf", "");
                cache[key2] = type;
            }
            return cache;
        }

        // Подключение к сценарию и запуск Godot =======================================================
        public static GameForms getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    instance = new GameForms();
                    instance.OnTestException += GameForms_OnTestException;
                }
            }
            return instance;
        }

        private static void GameForms_OnTestException(string obj)
        {
            OsUtils.Echo(obj);
            try
            {
                instance.Shutdown();
            }
            catch { }
            System.Environment.Exit(1);
        }

        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor()
        {
            // Устанавливаем кодировку для stdin и stdout
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            instance = getInstance();
            instance.dll_obj = instance;
            StartEventProcessing();
            return instance;
        }

        public static void StartEventProcessing()
        {
            ScriptingEngine Engine = DefaultEngineBuilder.Create()
                .SetupConfiguration(providers => { }) // Здесь можно подключить свои кастомные провайдеры
                .SetDefaultOptions() // Подключает Строку, Число, Булево и т.д.
                .UseImports() // Позволяет писать "Импорт *" внутри скриптов
                .UseNativeRuntime() // Доступ к нативным объектам CLR
                .UseFileSystemLibraries()
                .Build();

            engine = Engine;

            // Регистрируем сборку по имени любого из стандартных классов движка
            Engine.AttachAssembly(System.Reflection.Assembly.GetAssembly(typeof(ArrayImpl)));

            HostedScriptEngine Hosted = new HostedScriptEngine(Engine);
            Hosted.Initialize();

            var cs = Engine.GetCompilerService();
            IBslProcess Process = Engine.NewProcess();

            string startEventProcessing = @"
Процедура ЗапускСобытий(параметр1) Экспорт
    Контекст = Новый Структура();
    Контекст.Вставить(""ИФ"", параметр1);
    Стр = ""
    |Пока ИФ.Продолжать Цикл
    |   Попытка
    |       Пока ИФ.Продолжать Цикл
    |            ИФ.ПолучитьСобытие().Выполнить();
    |       КонецЦикла;
    |   Исключение
    |       Ошибка = ИнформацияОбОшибке();
    |       ИФ.ПроброситьИсключение(""""{Модуль """" + Ошибка.ИмяМодуля + """" / Ошибка в строке: """" + Ошибка.НомерСтроки + """" / """" + Ошибка.Описание);
    |   КонецПопытки;
    |КонецЦикла;
    |"";
    ЗагрузитьСценарийИзСтроки(Стр, Контекст);
КонецПроцедуры

МассивПараметров = Новый Массив(1);
МассивПараметров[0] = ИФ;
Задание = ФоновыеЗадания.Выполнить(ЭтотОбъект, ""ЗапускСобытий"", МассивПараметров);
";
            ExternalContextData extContext = new()
            {
                { "ИФ", instance }
            };
            Engine.AttachedScriptsFactory.LoadFromString(cs, startEventProcessing, Process, extContext);
        }

        private void Initialize(string godotPath)
        {
            // Запускаем Godot процесс асинхронно
            _ = Task.Run(() => StartGodotProcess(godotPath));

            int count = 0;
            while (!godotReady.IsSet && count < 100)
            {
                System.Threading.Thread.Sleep(1000);
                count += 1;
            }
            if (!godotReady.IsSet)
            {
                OsUtils.Echo("Ошибка: Godot не ответил в течение 100 секунд");
            }
            else
            {
                godotLaunched = true;
            }
        }

        private void StartGodotProcess(string godotPath)
        {
            try
            {
                if (!File.Exists(godotPath))
                {
                    OsUtils.Echo($"Ошибка: Godot приложение не найдено по пути {godotPath}");
                    return;
                }

                var process = new System.Diagnostics.Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = godotPath,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        StandardOutputEncoding = System.Text.Encoding.UTF8,
                        StandardErrorEncoding = System.Text.Encoding.UTF8,
                    },
                    EnableRaisingEvents = true
                };

                // Подписываемся на события
                process.OutputDataReceived += Process_OutputDataReceived;
                process.ErrorDataReceived += Process_ErrorDataReceived;
                process.Exited += Process_Exited;

                godotProcess = process;
                process.Start();

                // Начинаем асинхронное чтение
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }
            catch (Exception ex)
            {
                OsUtils.Echo($"Ошибка при запуске Godot: {ex.Message}");
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            if (DisplayServiceMessages)
            {
                OsUtils.Echo("Godot процесс завершен");
            }
            GoOn = false;

            godotLaunched = false;

            // Отменяем все ожидающие команды
            foreach (var kvp in pendingCommands)
            {
                kvp.Value.TrySetCanceled();
            }
            pendingCommands.Clear();
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                OsUtils.Echo($"Error: {e.Data}");
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
            {
                return;
            }

            if (DisplayServiceMessages)
            {
                try
                {
                    // Подавим вывод некоторых ненужных данных.
                    if (e.Data.Length > 7 && e.Data.Substring(0, 7) != "{\u0022cmd\u0022:")
                    {
                        OsUtils.Echo($">>> {e.Data}");
                    }
                }
                catch
                {
                    OsUtils.Echo($">>> {e.Data}"); // Это для упрощения отладки. Не обработанное, пришедшее от Godot, сообщение.
                }
            }

            Dictionary<string, object> response = null;
            // Парсим JSON ответ
            try
            {
                response = OsUtils.Deserialize(e.Data);
            }
            catch { }
            if (response != null)
            {
                if (DisplayServiceMessages)
                {
                    OsUtils.Echo($"Получил: {e.Data}");
                }

                foreach (var item in response)
                {
                    if (DisplayServiceMessages)
                    {
                        OsUtils.Echo($"key: {item.Key} = {item.Value}");
                    }
                }
                // Проверяем, является ли это ответом на команду
                if (response.ContainsKey("id") && response.ContainsKey("result"))
                {
                    string commandId = ((JsonElement)response["id"]).GetString();

                    // Ищем ожидающую команду
                    if (pendingCommands.TryRemove(commandId, out var tcs))
                    {
                        // Завершаем задачу с результатом
                        tcs.SetResult(e.Data);
                    }
                }
                // Проверяем сигнал готовности
                try
                {
                    if (response.ContainsKey("cmd") && response["cmd"].ToString() == "ready")
                    {
                        godotReady.Set();
                        if (DisplayServiceMessages)
                        {
                            OsUtils.Echo("Godot процесс запущен.");
                        }
                    }
                }
                catch { }
                // Получаем ключ для игровых форм.
                try
                {
                    if (response.ContainsKey("cmd") && response["cmd"].ToString() == "GameFormsItemKey")
                    {
                        gameFormsItemKey = ((JsonElement)response["ItemKey"]).GetString();
                        dictKeyEl.TryAdd(gameFormsItemKey, this);
                        dictElKey.TryAdd(this, gameFormsItemKey);
                    }
                }
                catch { }

                try
                {
                    if (response.ContainsKey("cmd") && response["cmd"].ToString() == "rootWindow")
                    {
                        string itemKey = ((JsonElement)response["ItemKey"]).GetString();
                        rootWindow = new GfWindow(itemKey);
                    }
                }
                catch { }

                // Проверяем, является ли это событием от Godot
                if (response["id"].ToString() == "godotEvent")
                {
                    string elementItemKey = response["ItemKey"].ToString();
                    if (!dictKeyEl.TryGetValue(elementItemKey, out var element))
                    {
                        if (DisplayServiceMessages)
                        {
                            OsUtils.Echo($"Элемент {elementItemKey} не найден (1)");
                        }
                    }
                    else
                    {
                        string nameEvent = response["nameEvent"].ToString();
                        int num = nameEvent.IndexOf("_");
                        GfAction eventAction = null;
                        if (num >= 0)
                        {
                            nameEvent = element[nameEvent.Substring(num)];
                        }

                        try
                        {
                            eventAction = element[nameEvent];
                        }
                        catch { }

                        var dataEvent = OsUtils.Deserialize(response["dataEvent"].ToString());
                        GfVector2 _vector = null;
                        bool _pressed = false;
                        IValue _modifiersMask = null;
                        IValue _keycode = null;
                        IValue _mouseButton = null;
                        IValue _mouseButtonMask = null;
                        bool _toggledOn = false;
                        try
                        {
                            foreach (var item in dataEvent)
                            {
                                var itemValue = (JsonElement)item.Value;
                                switch (item.Key)
                                {
                                    case "position" when itemValue.ValueKind == JsonValueKind.Array:
                                        _vector = new GfVector2(itemValue[0].GetDecimal(), itemValue[1].GetDecimal());
                                        break;
                                    case "pressed":
                                        _pressed = itemValue.GetBoolean();
                                        break;
                                    case "modifiersMask":
                                        _modifiersMask = ValueFactory.Create(itemValue.GetInt32());
                                        break;
                                    case "keycode":
                                        _keycode = ValueFactory.Create(itemValue.GetInt32());
                                        break;
                                    case "mouseButton":
                                        _mouseButton = ValueFactory.Create(itemValue.GetInt32());
                                        break;
                                    case "mouseButtonMask":
                                        _mouseButtonMask = ValueFactory.Create(itemValue.GetInt32());
                                        break;
                                    case "toggledOn":
                                        _toggledOn = itemValue.GetBoolean();
                                        break;
                                }
                            }
                        }
                        catch { }

                        if (eventAction != null)
                        {
                            if (eventAction.MethodName == "")
                            {
                                return;
                            }
                            var args = new GfEventArgs
                            {
                                eventAction = eventAction,
                                sender = element.dll_obj,
                                position = _vector,
                                pressed = _pressed,
                                modifiersMask = _modifiersMask,
                                keycode = _keycode,
                                parameter = eventAction.Parameter,
                                mouseButtonMask = _mouseButtonMask,
                                mouseButton = _mouseButton,
                                toggledOn = _toggledOn,
                            };
                            EventQueue.Enqueue(args);
                        }
                    }
                }
            }
        }

        // Обеспечение цикла событий =====================================================================
        [ContextMethod("Действие", "Action")]
        public GfAction Action(IRuntimeContextInstance script = null, string methodName = null, IValue param = null)
        {
            return new GfAction(script, methodName, param);
        }

        public static GfEventArgs Event = null;
        [ContextProperty("АргументыСобытия", "EventArgs")]
        public GfEventArgs EventArgsProp
        {
            get { return Event; }
        }

        public bool goOn = true;
        [ContextProperty("Продолжать", "GoOn")]
        public bool GoOn
        {
            get { return goOn; }
            set { goOn = value; }
        }

        [ContextMethod("ПолучитьСобытие", "DoEvents")]
        public DelegateAction DoEvents()
        {
            while (EventQueue.Count == 0)
            {
                System.Threading.Thread.Sleep(7);
            }
            if (EventQueue.TryDequeue(out var item))
            {
                Event = item;
                EventAction = item.EventAction;
            }
            return DelegateAction.Create(item.EventAction.Script, item.EventAction.MethodName);
        }

        [ContextMethod("Выполнить", "Execute")]
        public void Execute(GfAction action)
        {
            var args = new GfEventArgs
            {
                eventAction = action,
                parameter = action.Parameter,
            };
            EventQueue.Enqueue(args);
        }

        [ContextProperty("ПриСрабатыванииОдноразовогоТаймера", "OneTimerTriggered")] // Не показываем в справке, но здесь необходимо оставить.
        public GfAction OneTimerTriggered { get; set; }

        // Свойства =======================================================================================
        [ContextProperty("ОсевоеРастяжение", "AxisStretchMode")]
        public GfAxisStretchMode AxisStretchModeProp
        {
            get { return new GfAxisStretchMode(); }
        }

        [ContextProperty("Направление", "Direction")]
        public GfDirection DirectionProp
        {
            get { return new GfDirection(); }
        }

        [ContextProperty("ГодоЗапущен", "GodotLaunched")]
        public bool GodotLaunched
        {
            get { return godotLaunched; }
            private set { godotLaunched = value; }
        }

        [ContextProperty("КорневоеОкно", "RootWindow")]
        public GfWindow RootWindow
        {
            get { return rootWindow; }
        }

        [ContextProperty("Цвет", "Color")]
        public GfColor ColorProp
        {
            get { return new GfColor(); }
        }

        [ContextProperty("СистемныйКаталог", "SystemDir")]
        public GfSystemDir SystemDirProp
        {
            get { return new GfSystemDir(); }
        }

        [ContextProperty("РежимОтрисовки", "DrawMode")]
        public GfDrawMode DrawModeProp
        {
            get { return new GfDrawMode(); }
        }

        [ContextProperty("КнопкаМыши", "MouseButton")]
        public GfMouseButton MouseButtonProp
        {
            get { return new GfMouseButton(); }
        }

        [ContextProperty("ВыводитьСлужебныеСообщения", "DisplayServiceMessages")]
        public bool DisplayServiceMessages
        {
            get { return displayServiceMessages; }
            set { displayServiceMessages = value; }
        }

        [ContextProperty("ЛогФайл", "PathLog")]
        public string PathLog { get; set; }

        [ContextProperty("КаталогБиблиотеки", "AssemblyDirectoryName")]
        public string AssemblyDirectoryName
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        }

        [ContextProperty("Ориентация", "Orientation")]
        public GfOrientation OrientationProp
        {
            get { return new GfOrientation(); }
        }

        [ContextProperty("ФлагПереносаСтроки", "LineBreakFlag")]
        public GfLineBreakFlag LineBreakFlagProp
        {
            get { return new GfLineBreakFlag(); }
        }

        [ContextProperty("ФлагВыравниванияПоШирине", "JustificationFlag")]
        public GfJustificationFlag JustificationFlagProp
        {
            get { return new GfJustificationFlag(); }
        }

        [ContextProperty("Клавиши", "Keys")]
        public GfKeys KeysProp
        {
            get { return new GfKeys(); }
        }

        [ContextProperty("КлавишаНажата", "KeyPress")]
        public GfAction KeyPress { get; set; }

        [ContextProperty("Модификаторы", "KeyModifierMask")]
        public GfKeyModifierMask KeyModifierMask
        {
            get { return new GfKeyModifierMask(); }
        }

        [ContextProperty("ФорматИзображения", "ImageFormat")]
        public GfImageFormat ImageFormat
        {
            get { return new GfImageFormat(); }
        }

        [ContextProperty("РежимФокусировки", "FocusMode")]
        public GfFocusMode FocusModeProp
        {
            get { return new GfFocusMode(); }
        }

        [ContextProperty("Автоперенос", "AutowrapMode")]
        public GfAutowrapMode AutowrapModeProp
        {
            get { return new GfAutowrapMode(); }
        }

        [ContextProperty("ТипЭлементаТемы", "ThemeDataType")]
        public GfThemeDataType ThemeDataType
        {
            get { return new GfThemeDataType(); }
        }

        [ContextProperty("ИмяСвойстваТемыНадпись", "NamePropertyThemeLabel")]
        public GfNamePropertyThemeLabel NamePropertyThemeLabel
        {
            get { return new GfNamePropertyThemeLabel(); }
        }

        [ContextProperty("ИмяСвойстваТемыОкно", "NamePropertyThemeWindow")]
        public GfNamePropertyThemeWindow NamePropertyThemeWindow
        {
            get { return new GfNamePropertyThemeWindow(); }
        }

        [ContextProperty("ИмяСвойстваТемыВертикальнаяГруппа", "NamePropertyThemeVBoxContainer")]
        public GfNamePropertyThemeVBoxContainer NamePropertyThemeVBoxContainer
        {
            get { return new GfNamePropertyThemeVBoxContainer(); }
        }

        [ContextProperty("ИмяСвойстваТемыГоризонтальнаяГруппа", "NamePropertyThemeHBoxContainer")]
        public GfNamePropertyThemeHBoxContainer NamePropertyThemeHBoxContainer
        {
            get { return new GfNamePropertyThemeHBoxContainer(); }
        }

        [ContextProperty("ИмяСвойстваТемыКнопка", "NamePropertyThemeButton")]
        public GfNamePropertyThemeButton NamePropertyThemeButton
        {
            get { return new GfNamePropertyThemeButton(); }
        }

        [ContextProperty("ИмяСвойстваТемыОкноСообщений", "NamePropertyThemeConfirmationDialog")]
        public GfNamePropertyThemeConfirmationDialog NamePropertyThemeConfirmationDialog
        {
            get { return new GfNamePropertyThemeConfirmationDialog(); }
        }

        [ContextProperty("ИмяСвойстваТемыПанельныйКонтейнер", "NamePropertyThemePanelContainer")]
        public GfNamePropertyThemePanelContainer NamePropertyThemePanelContainer
        {
            get { return new GfNamePropertyThemePanelContainer(); }
        }

        [ContextProperty("ИмяСвойстваТемыУведомление", "NamePropertyThemeAcceptDialog")]
        public GfNamePropertyThemeAcceptDialog NamePropertyThemeAcceptDialog
        {
            get { return new GfNamePropertyThemeAcceptDialog(); }
        }

        // Методы =======================================================================================
        [ContextMethod("ЗагрузитьМодель", "LoadModel")]
        public void LoadModel(string _path)
        {
            string path = OsUtils.ToGodotPath(_path);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "path", path },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        [ContextMethod("ТемаСцена", "ThemeScene")]
        public GfThemeScene ThemeScene()
        {
            return new GfThemeScene();
        }

        [ContextMethod("ТемаКнопка", "ThemeButton")]
        public GfThemeButton ThemeButton()
        {
            return new GfThemeButton();
        }

        [ContextMethod("ТемаНадпись", "ThemeLabel")]
        public GfThemeLabel ThemeLabel()
        {
            return new GfThemeLabel();
        }

        [ContextMethod("ТемаОкно", "ThemeWindow")]
        public GfThemeWindow ThemeWindow()
        {
            return new GfThemeWindow();
        }

        [ContextMethod("ТемаПанельныйКонтейнер", "ThemePanelContainer")]
        public GfThemePanelContainer ThemePanelContainer()
        {
            return new GfThemePanelContainer();
        }

        [ContextMethod("ТемаУведомление", "ThemeAcceptDialog")]
        public GfThemeAcceptDialog ThemeAcceptDialog()
        {
            return new GfThemeAcceptDialog();
        }

        [ContextMethod("ПолучитьТекстБуфераОбмена", "ClipboardGet")]
        public string ClipboardGet()
        {
            return OsUtils.ClipboardGet();
        }

        [ContextMethod("УстановитьТекстБуфераОбмена", "ClipboardSet")]
        public void ClipboardSet(string p1)
        {
            OsUtils.ClipboardSet(p1);
        }

        [ContextMethod("НотацияЗмеинуюВПаскаля", "SnakeCaseToPascalCase")]
        public string SnakeCaseToPascalCase(string path)
        {
            return OsUtils.GetCSharpName(path);
        }

        [ContextMethod("НотацияПаскаляВЗмеиную", "PascalCaseToSnakeCase")]
        public string PascalCaseToSnakeCase(string path)
        {
            return OsUtils.GetGodotName(path);
        }

        [ContextMethod("ПолучитьСнимок", "GetSnapshot")]
        public GfImage GetSnapshot(IValue node, string path, int imageFormat = 0)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  ((dynamic)node).ItemKey },
                    { "path",  path },
                    { "imageFormat",  imageFormat },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetSnapshot", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                string newPath = ((JsonElement)answer["report"]).GetString();
                return new GfImage(newPath);
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ПолучитьСнимок.");
                return null;
            }
        }

        [ContextMethod("НормализоватьПуть", "NormalizedPath")]
        public string NormalizedPath(string path)
        {
            return OsUtils.ToGodotPath(path);
        }

        [ContextMethod("НовыйОбъект", "NewObject")]
        public IValue NewObject(string p1)
        {
            if (!_typeCache.TryGetValue(p1, out var type))
            {
                OsUtils.Echo($"Неизвестный тип: {p1}");
                return null;
            }

            try
            {
                return (IValue)Activator.CreateInstance(type);
            }
            catch (Exception)
            {
                OsUtils.Echo($"Ошибка создания объекта: {type.Name}");
                return null;
            }
        }

        [ContextMethod("НайтиЦентр", "FindCenter")]
        public GfVector2 FindCenter(IValue p1)
        {
            string itemKey = ((dynamic)p1).Base_obj.ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  itemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("FindCenter", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                var report = OsUtils.Deserialize(answer["report"].ToString());
                return (GfVector2)OsUtils.ConvertValueForGameForms(report);
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод НайтиЦентр");
                return null;
            }
        }

        [ContextMethod("ОтправитьКлавишуКонсоли", "SendConsoleKey")]
        public void SendConsoleKey(int keyCode, bool shiftModifier = false, bool altModifier = false, bool ctrlModifier = false)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "keyCode", keyCode },
                    { "shiftModifier", shiftModifier },
                    { "altModifier", altModifier },
                    { "ctrlModifier", ctrlModifier },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        [ContextMethod("Выравнивание", "AlignmentMode")]
        public GfAlignmentMode AlignmentMode()
        {
            return new GfAlignmentMode();
        }

        [ContextMethod("Направление", "Direction")]
        public GfDirection Direction()
        {
            return new GfDirection();
        }

        [ContextMethod("РежимОтрисовки", "DrawMode")]
        public GfDrawMode DrawMode()
        {
            return new GfDrawMode();
        }

        [ContextMethod("Кодировка", "Encoding")]
        public GfEncoding Encoding()
        {
            return new GfEncoding();
        }

        [ContextMethod("ГоризонтальнаяГруппа", "HBoxContainer")]
        public GfHBoxContainer HBoxContainer()
        {
            return new GfHBoxContainer();
        }

        [ContextMethod("ГоризонтальноеВыравнивание", "HorizontalAlignment")]
        public GfHorizontalAlignment HorizontalAlignment()
        {
            return new GfHorizontalAlignment();
        }

        [ContextMethod("ФлагВыравниванияПоШирине", "JustificationFlag")]
        public GfJustificationFlag JustificationFlag()
        {
            return new GfJustificationFlag();
        }

        [ContextMethod("Надпись", "Label")]
        public GfLabel Label()
        {
            return new GfLabel();
        }

        [ContextMethod("ФлагПереносаСтроки", "LineBreakFlag")]
        public GfLineBreakFlag LineBreakFlag()
        {
            return new GfLineBreakFlag();
        }

        [ContextMethod("КнопкаМыши", "MouseButton")]
        public GfMouseButton MouseButton()
        {
            return new GfMouseButton();
        }

        [ContextMethod("Ориентация", "Orientation")]
        public GfOrientation Orientation()
        {
            return new GfOrientation();
        }

        [ContextMethod("Спрайт2д", "Sprite2D")]
        public GfSprite2D Sprite2D()
        {
            return new GfSprite2D();
        }

        [ContextMethod("СтильПанелиПусто", "StyleBoxEmpty")]
        public GfStyleBoxEmpty StyleBoxEmpty()
        {
            return new GfStyleBoxEmpty();
        }

        [ContextMethod("СтильПанелиЛиния", "StyleBoxLine")]
        public GfStyleBoxLine StyleBoxLine()
        {
            return new GfStyleBoxLine();
        }

        [ContextMethod("СтильПанелиТекстура", "StyleBoxTexture")]
        public GfStyleBoxTexture StyleBoxTexture()
        {
            return new GfStyleBoxTexture();
        }

        [ContextMethod("Таймер", "Timer")]
        public GfTimer Timer()
        {
            return new GfTimer();
        }

        [ContextMethod("СистемныйКаталог", "SystemDir")]
        public GfSystemDir SystemDir()
        {
            return new GfSystemDir();
        }

        [ContextMethod("ПанельныйКонтейнер", "PanelContainer")]
        public GfPanelContainer PanelContainer()
        {
            return new GfPanelContainer();
        }

        [ContextMethod("СтильПанелиПлоский", "StyleBoxFlat")]
        public GfStyleBoxFlat StyleBoxFlat()
        {
            return new GfStyleBoxFlat();
        }

        [ContextMethod("ВертикальнаяГруппа", "VBoxContainer")]
        public GfVBoxContainer VBoxContainer()
        {
            return new GfVBoxContainer();
        }

        [ContextMethod("Прямоугольник2ц", "Rect2i")]
        public GfRect2i Rect2i(GfVector2i p1 = null, GfVector2i p2 = null)
        {
            GfRect2i rect2i = new GfRect2i();
            if (OsUtils.AllNotNull(p1))
            {
                rect2i.Position = p1;
            }
            if (OsUtils.AllNotNull(p2))
            {
                rect2i.Size = p2;
            }
            return rect2i;
        }

        [ContextMethod("ОкноСообщений", "ConfirmationDialog")]
        public GfConfirmationDialog WiConfirmationDialogndow()
        {
            return new GfConfirmationDialog();
        }

        [ContextMethod("ПолучитьПозициюМыши", "GetMousePosition")]
        public GfVector2 GetMousePosition()
        {
            string res = SendCommand("GetMousePosition");
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            var report = OsUtils.Deserialize(answer["report"].ToString());
            GfVector2 vector2 = null;
            foreach (var item in report)
            {
                var itemValue = (JsonElement)item.Value;
                switch (item.Key)
                {
                    case "position" when itemValue.ValueKind == JsonValueKind.Array:
                        vector2 = new GfVector2(itemValue[0].GetDecimal(), itemValue[1].GetDecimal());
                        break;
                }
            }
            return vector2;
        }

        [ContextMethod("ПереместитьМышь", "WarpMouse")]
        public void WarpMouse(IValue p1, decimal duration = 0.5m)
        {
            Response response = null;
            if (OsUtils.IsType<GfVector2>(p1))
            {
                GfVector2 pos = p1 as GfVector2;
                float[] posArray = { OsUtils.ToFloat(pos.X), OsUtils.ToFloat(pos.Y) };
                response = new Response
                {
                    Properties = new Dictionary<string, object>
                    {
                        { "position", posArray },
                        { "duration", duration / 1000 },
                    }
                };
                OsUtils.GetAnswerSendCommand("WarpMouseToVector", response);
            }
            else
            {
                try
                {
                    string itemKey = ((dynamic)p1).Base_obj.ItemKey;
                    response = new Response
                    {
                        Properties = new Dictionary<string, object>
                        {
                            { "itemKey", itemKey },
                            { "duration", duration / 1000 },
                        }
                    };
                }
                catch { }
                OsUtils.GetAnswerSendCommand("WarpMouseToControl", response);
            }
        }

        [ContextMethod("ПрограммныйКлик", "ProgramClick")]
        public void ProgramClick(int mouseButton)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "mouseButton", mouseButton },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        [ContextMethod("Уведомление", "AcceptDialog")]
        public GfAcceptDialog AcceptDialog()
        {
            return new GfAcceptDialog();
        }

        [ContextMethod("ОдноразовыйТаймер", "SceneTreeTimer")]
        public void SceneTreeTimer(GfAction p1, decimal time)
        {
            OneTimerTriggered = p1;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "time", time },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        [ContextMethod("УдалитьЭлемент", "RemoveElement")]
        public void RemoveElement([ByRef] IVariable obj)
        {
            var element = ((dynamic)obj.Value).Base_obj;
            dictElKey.TryGetValue(element, out string elementItemKey);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  elementItemKey },
                    { "itemKey",  elementItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("RemoveElement", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                dictElKey.TryRemove(element, out string _);
                dictKeyEl.TryRemove(elementItemKey, out _);
                obj.Value = ValueFactory.CreateNullValue();
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод УдалитьЭлемент");
            }
        }

        [ContextMethod("Изображение", "Image")]
        public GfImage Image(string p1 = null)
        {
            return new GfImage(p1);
        }

        [ContextMethod("ТекстураИзИзображения", "ImageTexture")]
        public GfImageTexture ImageTexture(string p1 = null)
        {
            return new GfImageTexture(p1);
        }

        [ContextMethod("Запись", "Entry")]
        public GfEntry Entry(IValue p1 = null, IValue p2 = null)
        {
            return new GfEntry(p1, p2);
        }

        [ContextMethod("Словарь", "Dictionary")]
        public GfDictionary Dictionary()
        {
            return new GfDictionary();
        }

        [ContextMethod("ШрифтВариативный", "FontVariation")]
        public GfFontVariation FontVariation(string p1 = null)
        {
            return new GfFontVariation(p1);
        }

        [ContextMethod("ШрифтИзФайла", "FontFile")]
        public GfFontFile FontFile(string p1 = null)
        {
            return new GfFontFile(p1);
        }

        [ContextMethod("ДобавитьВесьТекст", "AppendAllText")]
        public void AppendAllText(string p1, string p2)
        {
            if (!File.Exists(p1))
            {
                File.Create(p1).Close();
            }
            File.AppendAllText(p1, p2, System.Text.Encoding.UTF8);
        }

        [ContextMethod("ПолучитьКодСценария", "GetScriptCode")]
        public string GetScriptCode(IRuntimeContextInstance p1)
        {
            UserScriptContextInstance scr = (UserScriptContextInstance)p1.GetPropValue(0);
            return scr.Module.Source.GetSourceCode();
        }

        [ContextMethod("ПутьСценария", "PathScenario")]
        public string PathScenario(IRuntimeContextInstance p1)
        {
            UserScriptContextInstance scr = (UserScriptContextInstance)p1.GetPropValue(0);
            return scr.Module.Source.Name;
        }

        [ContextMethod("КаталогСценария", "DirectoryScenario")]
        public string DirectoryScenario(IRuntimeContextInstance p1)
        {
            ScriptEngine.Machine.Contexts.UserScriptContextInstance scr = (ScriptEngine.Machine.Contexts.UserScriptContextInstance)p1.GetPropValue(0);
            return Path.GetDirectoryName(scr.Module.Source.Name);
        }

        [ContextMethod("МассивИменЦветов", "ColorNameArray")]
        public ArrayImpl ColorNameArray()
        {
            ArrayImpl arrayImpl = new ArrayImpl();
            List<string> list = new List<string>();
            System.Type type = typeof(GfColor);
            PropertyInfo[] myPropertyInfo = type.GetProperties();
            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                if (myPropertyInfo[i].CustomAttributes.Count() == 1)
                {
                    string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Name;
                    string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Alias;
                    try
                    {
                        if (NameEn != "Имя" &&
                            NameEn != "Name" &&
                            NameRu != "ЗначениеАльфа" &&
                            NameRu != "ЗначениеЗеленый" &&
                            NameRu != "ЗначениеКрасный" &&
                            NameRu != "ЗначениеСиний")
                        {
                            list.Add(NameRu + " (" + NameEn + ")");
                        }
                    }
                    catch { }
                }
            }
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                arrayImpl.Add(ValueFactory.Create(list[i]));
            }
            return arrayImpl;
        }

        [ContextMethod("Цвет", "Color")]
        public GfColor Color(IValue p1 = null, IValue p2 = null, IValue p3 = null, IValue p4 = null)
        {
            GfColor res = new GfColor();
            if (OsUtils.AllNotNull(p1) && !OsUtils.AllNotNull(p2, p3, p4))
            {
                try
                {
                    if (OsUtils.IsString(p1))
                    {
                        string propName = p1.ToString();
                        if (!propName.Contains("#"))
                        {
                            string resName = System.String.Empty;
                            PropertyInfo[] myPropertyInfo = typeof(GfColor).GetProperties();
                            for (int i = 0; i < myPropertyInfo.Length; i++)
                            {
                                if (myPropertyInfo[i].CustomAttributes.Count() == 1)
                                {
                                    string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Name;
                                    string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Alias;
                                    if (NameRu == propName || NameEn == propName)
                                    {
                                        resName = NameEn;
                                        break;
                                    }
                                }
                            }
                            res = (GfColor)Type.GetType("osgf.GfColor").GetProperty(resName).GetValue(new GfColor());
                        }
                        else
                        {
                            // Удаляем префикс '#'.
                            propName = propName.TrimStart('#');
                            // Извлекаем компоненты RGB и преобразуем их из шестнадцатеричной в десятичную систему.
                            res.R = OsUtils.ToInt32(propName.Substring(0, 2), 16);
                            res.G = OsUtils.ToInt32(propName.Substring(2, 2), 16);
                            res.B = OsUtils.ToInt32(propName.Substring(4, 2), 16);
                            res.A = 255;
                        }
                    }
                    else if (OsUtils.IsNumber(p1))
                    {
                        int decimalValue = OsUtils.ToInt32(p1);

                        res.R = (decimalValue & 0xFF0000) >> 16; // Красная составляющая.
                        res.G = (decimalValue & 0x00FF00) >> 8; // Зелёная составляющая.
                        res.B = (decimalValue & 0x0000FF); // Синяя составляющая.
                        res.A = 255; // Альфа составляющая.
                    }
                }
                catch (Exception)
                {
                    OsUtils.Echo("Ошибка создания цвета: Параметр должен быть строкой с допустимым именем цвета или целым числом в диапазоне от 0 до 16777215.");
                    res = null;
                }
            }
            else if (OsUtils.AllNotNull(p1, p2, p3) && !OsUtils.AllNotNull(p4))
            {
                try
                {
                    res.R = OsUtils.ToInt32(p1);
                    res.G = OsUtils.ToInt32(p2);
                    res.B = OsUtils.ToInt32(p3);
                    res.A = 255;
                }
                catch (Exception)
                {
                    OsUtils.Echo("Ошибка создания цвета: Каждый параметр долен быть целым числом в диапазоне от 0 до 255.");
                    res = null;
                }
            }
            else if (OsUtils.AllNotNull(p1, p2, p3, p4))
            {
                try
                {
                    res.R = OsUtils.ToInt32(p1);
                    res.G = OsUtils.ToInt32(p2);
                    res.B = OsUtils.ToInt32(p3);
                    res.A = OsUtils.ToInt32(p4);
                }
                catch (Exception)
                {
                    OsUtils.Echo("Ошибка создания цвета: Каждый параметр долен быть целым числом в диапазоне от 0 до 255.");
                    res = null;
                }
            }
            return res;
        }

        [ContextMethod("ПутьИсполняемогоФайла", "GetExecutablePath")]
        public string GetExecutablePath()
        {
            string res = SendCommand("GetExecutablePath");
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            return ((JsonElement)answer["report"]).GetString();
        }

        [ContextMethod("Запустить", "Run")]
        public void Run(string path)
        {
            Initialize(path);
        }

        //Завершаем Godot средствами Godot.
        [ContextMethod("Завершить", "Shutdown")]
        public void Shutdown()
        {
            SendCommand("Shutdown");
        }

        [ContextMethod("ОтправитьКоманду", "SendCommand")]
        public static string SendCommand(string command, string parameters = "{}")
        {
            if (godotProcess == null || godotProcess.HasExited)
            {
                throw new InvalidOperationException("Godot процесс не запущен или завершен");
            }

            var commandId = Guid.NewGuid().ToString();
            var tcs = new TaskCompletionSource<string>();

            // Регистрируем ожидающий ответ
            pendingCommands[commandId] = tcs;

            try
            {
                // Формируем JSON команду
                var commandObj = new Dictionary<string, object>
                {
                    ["cmd"] = command,
                    ["id"] = commandId,
                    ["paramsJson"] = OsUtils.Deserialize(parameters)
                };

                string jsonCommand = OsUtils.Serialize(commandObj);

                // Отправляем команду
                godotProcess.StandardInput.WriteLine(jsonCommand);
                godotProcess.StandardInput.Flush();

                if (instance.DisplayServiceMessages)
                {
                    OsUtils.Echo("===============================");
                    OsUtils.Echo($"Отправил: {jsonCommand.Trim()}");
                }

                // Ожидаем ответ с таймаутом 30 секунд
                if (tcs.Task.Wait(TimeSpan.FromSeconds(30)))
                {
                    return tcs.Task.Result;
                }
                else
                {
                    pendingCommands.TryRemove(commandId, out _);
                    throw new TimeoutException($"Команда {command} не получила ответ за 30 секунд");
                }
            }
            catch (Exception ex)
            {
                pendingCommands.TryRemove(commandId, out _);
                OsUtils.Echo($"Ошибка при отправке команды: {ex.Message}");
                throw;
            }
        }

        [ContextMethod("Окно", "Window")]
        public GfWindow Window()
        {
            return new GfWindow();
        }

        [ContextMethod("Кнопка", "Button")]
        public GfButton Button()
        {
            return new GfButton();
        }

        [ContextMethod("Вектор2", "Vector2")]
        public GfVector2 Vector2(decimal x = 0, decimal y = 0)
        {
            return new GfVector2(x, y);
        }

        [ContextMethod("Вектор2ц", "Vector2i")]
        public GfVector2i Vector2i(int x = 0, int y = 0)
        {
            return new GfVector2i(x, y);
        }

        [ContextMethod("Графика", "Graphics")]
        public GfGraphics Graphics()
        {
            return new GfGraphics();
        }

        [ContextMethod("Прямоугольник2", "Rect2")]
        public GfRect2 Rect2(GfVector2 p1 = null, GfVector2 p2 = null)
        {
            GfRect2 rect2 = new GfRect2();
            if (OsUtils.AllNotNull(p1))
            {
                rect2.Position = p1;
            }
            if (OsUtils.AllNotNull(p2))
            {
                rect2.Size = p2;
            }
            return rect2;
        }

        [ContextMethod("Узел2д", "Node2D")]
        public GfNode2D Node2D()
        {
            return new GfNode2D();
        }

        public void Dispose()
        {
            godotReady?.Dispose();
            foreach (var pending in pendingCommands.Values)
            {
                pending.TrySetCanceled();
            }
        }

        [ContextMethod("СвойстваИЗначения", "PropertiesAndValues")]
        public string PropertiesAndValues(IValue p1)
        {
            string str1 = "";
            string transfer = "";
            List<string> p = new List<string>();
            System.Reflection.PropertyInfo[] myPropertyInfo;
            myPropertyInfo = p1.GetType().GetProperties();
            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                if (myPropertyInfo[i].CustomAttributes.Count() == 1)
                {
                    string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Name;
                    string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Alias;
                    p.Add(NameRu + " (" + NameEn + ")");
                }
            }
            p.Sort();
            foreach (string str in p)
            {
                string nameEn = StrFindBetween(str, "(", ")").Get(0).ExplicitString();
                dynamic objVolue = null;
                try
                {
                    objVolue = p1.GetType().GetProperty(nameEn).GetValue(p1);
                }
                catch { }

                str1 = str1 + transfer + str + " = " + objVolue;
                transfer = "\r\n";
            }
            return str1;
        }

        [ContextMethod("КлассыИгровыхФорм", "GameFormsClasses")]
        public string GameFormsClasses()
        {
            string str1 = "";
            string transfer = "";
            List<string> p = new List<string>();

            // Получаем все типы из сборки
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();
            // Фильтруем только классы (не интерфейсы, структуры и т.п.)
            var classes = allTypes.Where(t => t.IsClass && t.IsPublic).ToList();
            // Теперь classes содержит список всех классов в библиотеке
            foreach (var @class in classes)
            {
                if (@class.Name.StartsWith("Gf"))
                {
                    //OsUtils.Echo(@class.Name);
                    p.Add(@class.Name);
                }
            }

            p.Sort();
            foreach (string str in p)
            {
                str1 = str1 + transfer + str;
                transfer = "\r\n";
            }
            return str1;
        }

        [ContextMethod("СтрНайтиМежду", "StrFindBetween")]
        public ArrayImpl StrFindBetween(string p1, string p2 = null, string p3 = null, bool p4 = true, bool p5 = true)
        {
            ArrayImpl array = OsUtils.FindBetweenOptimized(p1, p2, p3, p4, p5);
            return array;
        }

        [ContextMethod("СообщитьЕслиЛожь", "ReportIfFalse")]
        public void ReportIfFalse(bool condition, string message)
        {
            if (!condition)
            {
                ScriptException scriptException = new ScriptException(message);
                throw scriptException;
            }
        }

        [ContextMethod("ПроброситьИсключение", "SkipException")]
        public void SkipException(string message)
        {
            OnTestException?.Invoke(message);
        }

        [ContextMethod("ТекущаяДатаСМиллисекундами", "CurrentDateWithMilliseconds")]
        public string CurrentDateWithMilliseconds()
        {
            return DateTime.Now.ToString(@"dd:MM:yyyy HH:mm:ss.fffffff");
        }

        [ContextMethod("Загрузить", "Load")]
        public IValue Load(string _path)
        {
            string path = OsUtils.ToGodotPath(_path);
            string resourceItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "resourceItemKey",  resourceItemKey },
                    { "resource_path",  path },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("ResourceLoad", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                string typeResource = ((JsonElement)answer["report"]).GetString();
                Type type = Type.GetType("osgf.Gf" + typeResource);
                object[] args1 = { resourceItemKey };
                dynamic obj = (IValue)Activator.CreateInstance(type, args1);
                obj.ResourcePath = path;
                return obj;
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод Загрузить");
                return null;
            }
        }

        [ContextMethod("ОжидатьФайл", "WaitFile")]
        public bool WaitFile(string path, int timeoutMs = 10000)
        {
            int start = System.Environment.TickCount;
            while (true)
            {
                if (File.Exists(path))
                {
                    try
                    {
                        var len = new System.IO.FileInfo(path).Length;
                        if (len > 0) return true; // файл есть и не пустой
                    }
                    catch
                    {
                        // файл есть, но временно недоступен — продолжаем ждать
                    }
                }
                if (timeoutMs > 0 && (System.Environment.TickCount - start) >= timeoutMs)
                {
                    return false;
                }
                System.Threading.Thread.Sleep(100);
            }
        }

        [ContextMethod("Строка", "String")]
        public GfString String(IValue p1)
        {
            return new GfString(p1);
        }

        [ContextProperty("СлучайноеИмя", "TempName")]
        public string TempName
        {
            get { return OsUtils.TempName; }
        }
    }
}
