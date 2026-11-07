using OneScript.Contexts;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class Window : osgf.Viewport
    {
        public GfWindow dll_obj;
        private osgf.Viewport m_Window;

        public osgf.Viewport M_Window
        {
            get { return m_Window; }
            set
            {
                m_Window = value;
                base.M_Viewport = m_Window;
            }
        }

        public Window(string p1)
        {
            ItemKey = p1;
            GameForms.dictKeyEl.TryAdd(ItemKey, this);
            GameForms.dictElKey.TryAdd(this, ItemKey);
        }

        public Window()
        {
            OsUtils.CreateGodotObject(this);
        }

        public string Title
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2i Position
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2i Size
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool Borderless
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2i MaxSize
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2i MinSize
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool MaximizeDisabled
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool MinimizeDisabled
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool Exclusive
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool Unresizable
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool Visible
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool AlwaysOnTop
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool KeepTitleVisible
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public void Hide()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void Show()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void Popup(GfRect2i p1, decimal p2 = 0m)
        {
            int[] position = { OsUtils.ToInt32(p1.Position.X), OsUtils.ToInt32(p1.Position.Y) };
            int[] size = { OsUtils.ToInt32(p1.Size.X), OsUtils.ToInt32(p1.Size.Y) };
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "itemKey",  this.ItemKey },
                    { "position", position },
                    { "size", size },
                    { "timeout", p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PopupCentered(GfVector2i p1 = null, decimal p2 = 0m)
        {
            GfVector2i vector2i = new GfVector2i();
            if (p1 != null)
            {
                vector2i = p1;
            }
            int[] minsize = { OsUtils.ToInt32(vector2i.X), OsUtils.ToInt32(vector2i.Y) };

            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "itemKey",  this.ItemKey },
                    { "minsize", minsize },
                    { "timeout", p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void Center(int p1 = 0, int p2 = 0)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "shiftX",  p1 },
                    { "shiftY",  p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public IValue Theme
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool Transparent
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public void AddThemeStyleboxOverride(string styleName, IValue styleBox)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "styleName", styleName.Split(':')[0] },
                    { "styleBoxItemKey", ((dynamic)styleBox).ItemKey },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceTop(IValue p1, int p2)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offset",  p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceBottom(IValue p1, int p2)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offset",  p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceLeft(IValue p1, int p2)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offset",  p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceRight(IValue p1, int p2)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offset",  p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceTopLeft(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetTop",  p2 },
                    { "offsetLeft",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceTopRight(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetTop",  p2 },
                    { "offsetRight",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceLeftTop(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetLeft",  p2 },
                    { "offsetTop",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceLeftBottom(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetLeft",  p2 },
                    { "offsetBottom",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceBottomLeft(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetBottom",  p2 },
                    { "offsetLeft",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceBottomRight(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetBottom",  p2 },
                    { "offsetRight",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceRightTop(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetRight",  p2 },
                    { "offsetTop",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceRightBottom(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetRight",  p2 },
                    { "offsetBottom",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }
    }

    [ContextClass("ИфОкно", "GfWindow")]
    public class GfWindow : AutoContext<GfWindow>
    {
        public osgf.Window Base_obj;

        public GfWindow()
        {
            Window Window1 = new Window();
            Window1.dll_obj = this;
            Base_obj = Window1;
        }

        public GfWindow(string p1 = null)
        {
            Window Window1 = new Window(p1);
            Window1.dll_obj = this;
            Base_obj = Window1;
        }

        [ContextProperty("БезГраниц", "Borderless")]
        public bool Borderless
        {
            get { return Base_obj.Borderless; }
            set { Base_obj.Borderless = value; }
        }

        [ContextProperty("Заголовок", "Title")]
        public string Title
        {
            get { return Base_obj.Title; }
            set { Base_obj.Title = value; }
        }

        [ContextProperty("ЗетИндекс", "ZIndex")]
        public int ZIndex
        {
            get { return Base_obj.ZIndex; }
            set { Base_obj.ZIndex = value; }
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
        }

        [ContextProperty("КлючЭлемента", "ItemKey")]
        public string ItemKey
        {
            get { return Base_obj.ItemKey; }
        }

        [ContextProperty("МаксимальныйРазмер", "MaxSize")]
        public GfVector2i MaxSize
        {
            get { return Base_obj.MaxSize; }
            set { Base_obj.MaxSize = value; }
        }

        [ContextProperty("МаксимизироватьОтключено", "MaximizeDisabled")]
        public bool MaximizeDisabled
        {
            get { return Base_obj.MaximizeDisabled; }
            set { Base_obj.MaximizeDisabled = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public IValue Tag
        {
            get { return Base_obj.Tag; }
            set { Base_obj.Tag = value; }
        }

        [ContextProperty("МинимальныйРазмер", "MinSize")]
        public GfVector2i MinSize
        {
            get { return Base_obj.MinSize; }
            set { Base_obj.MinSize = value; }
        }

        [ContextProperty("МинимизироватьОтключено", "MinimizeDisabled")]
        public bool MinimizeDisabled
        {
            get { return Base_obj.MinimizeDisabled; }
            set { Base_obj.MinimizeDisabled = value; }
        }

        [ContextProperty("Модально", "Exclusive")]
        public bool Exclusive
        {
            get { return Base_obj.Exclusive; }
            set { Base_obj.Exclusive = value; }
        }

        [ContextProperty("НеИзменяемыйРазмер", "Unresizable")]
        public bool Unresizable
        {
            get { return Base_obj.Unresizable; }
            set { Base_obj.Unresizable = value; }
        }

        [ContextProperty("Отключить3д", "Disable3d")]
        public bool Disable3d
        {
            get { return Base_obj.Disable3d; }
            set { Base_obj.Disable3d = value; }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("ПоверхВсех", "AlwaysOnTop")]
        public bool AlwaysOnTop
        {
            get { return Base_obj.AlwaysOnTop; }
            set { Base_obj.AlwaysOnTop = value; }
        }

        [ContextProperty("Позиция", "Position")]
        public GfVector2i Position
        {
            get { return Base_obj.Position; }
            set { Base_obj.Position = value; }
        }

        [ContextProperty("Прозрачный", "Transparent")]
        public bool Transparent
        {
            get { return Base_obj.Transparent; }
            set { Base_obj.Transparent = value; }
        }

        [ContextProperty("Размер", "Size")]
        public GfVector2i Size
        {
            get { return Base_obj.Size; }
            set { Base_obj.Size = value; }
        }

        [ContextProperty("РежимСглаживания2д", "Msaa2d")]
        public int Msaa2d
        {
            get { return Base_obj.Msaa2d; }
            set { Base_obj.Msaa2d = value; }
        }

        [ContextProperty("РежимСглаживания3д", "Msaa3d")]
        public int Msaa3d
        {
            get { return Base_obj.Msaa3d; }
            set { Base_obj.Msaa3d = value; }
        }

        [ContextProperty("СохранитьВидимостьЗаголовка", "KeepTitleVisible")]
        public bool KeepTitleVisible
        {
            get { return Base_obj.KeepTitleVisible; }
            set { Base_obj.KeepTitleVisible = value; }
        }

        [ContextProperty("Тема", "Theme")]
        public IValue Theme
        {
            get { return Base_obj.Theme; }
            set { Base_obj.Theme = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfWindow" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("Выше", "PlaceTop")]
        public void PlaceTop(IValue p1, int p2)
        {
            Base_obj.PlaceTop(p1, p2);
        }

        [ContextMethod("ВышеЛевее", "PlaceTopLeft")]
        public void PlaceTopLeft(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceTopLeft(p1, p2, p3);
        }

        [ContextMethod("ВышеПравее", "PlaceTopRight")]
        public void PlaceTopRight(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceTopRight(p1, p2, p3);
        }

        [ContextMethod("ДобавитьДочерний", "AddChild")]
        public IValue AddChild(IValue p1)
        {
            return Base_obj.AddChild(p1);
        }

        [ContextMethod("ДобавитьСтиль", "AddThemeStyleboxOverride")]
        public void AddThemeStyleboxOverride(string p1, IValue p2)
        {
            Base_obj.AddThemeStyleboxOverride(p1.Split(':')[0], p2);
        }

        [ContextMethod("Левее", "PlaceLeft")]
        public void PlaceLeft(IValue p1, int p2)
        {
            Base_obj.PlaceLeft(p1, p2);
        }

        [ContextMethod("ЛевееВыше", "PlaceLeftTop")]
        public void PlaceLeftTop(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceLeftTop(p1, p2, p3);
        }

        [ContextMethod("ЛевееНиже", "PlaceLeftBottom")]
        public void PlaceLeftBottom(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceLeftBottom(p1, p2, p3);
        }

        [ContextMethod("НаЗаднийПлан", "SendToBack")]
        public void SendToBack()
        {
            Base_obj.SendToBack();
        }

        [ContextMethod("НаПереднийПлан", "BringToFront")]
        public void BringToFront()
        {
            Base_obj.BringToFront();
        }

        [ContextMethod("Ниже", "PlaceBottom")]
        public void PlaceBottom(IValue p1, int p2)
        {
            Base_obj.PlaceBottom(p1, p2);
        }

        [ContextMethod("НижеЛевее", "PlaceBottomLeft")]
        public void PlaceBottomLeft(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceBottomLeft(p1, p2, p3);
        }

        [ContextMethod("НижеПравее", "PlaceBottomRight")]
        public void PlaceBottomRight(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceBottomRight(p1, p2, p3);
        }

        [ContextMethod("Показать", "Show")]
        public void Show()
        {
            Base_obj.Show();
        }

        [ContextMethod("ПолучитьДочерние", "GetChildren")]
        public ArrayImpl GetChildren()
        {
            return Base_obj.GetChildren();
        }

        [ContextMethod("ПолучитьОкно", "GetWindow")]
        public IValue GetWindow()
        {
            return Base_obj.GetWindow();
        }

        [ContextMethod("ПолучитьРодителя", "GetParent")]
        public IValue GetParent()
        {
            return Base_obj.GetParent();
        }

        [ContextMethod("ПолучитьУзел", "GetNode")]
        public IValue GetNode(string p1)
        {
            return Base_obj.GetNode(p1);
        }

        [ContextMethod("Правее", "PlaceRight")]
        public void PlaceRight(IValue p1, int p2)
        {
            Base_obj.PlaceRight(p1, p2);
        }

        [ContextMethod("ПравееВыше", "PlaceRightTop")]
        public void PlaceRightTop(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceRightTop(p1, p2, p3);
        }

        [ContextMethod("ПравееНиже", "PlaceRightBottom")]
        public void PlaceRightBottom(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceRightBottom(p1, p2, p3);
        }

        [ContextMethod("Развернуть", "Popup")]
        public void Popup(GfRect2i p1, decimal p2 = 0m)
        {
            Base_obj.Popup(p1, p2);
        }

        [ContextMethod("РазвернутьВЦентре", "PopupCentered")]
        public void PopupCentered(GfVector2i p1 = null, decimal p2 = 0m)
        {
            Base_obj.PopupCentered(p1, p2);
        }

        [ContextMethod("Скрыть", "Hide")]
        public void Hide()
        {
            Base_obj.Hide();
        }

        [ContextMethod("УдалитьДочерний", "RemoveChild")]
        public void RemoveChild(IValue p1)
        {
            Base_obj.RemoveChild(p1);
        }

        [ContextMethod("Центр", "Center")]
        public void Center(int p1 = 0, int p2 = 0)
        {
            Base_obj.Center(p1, p2);
        }
    }
}
