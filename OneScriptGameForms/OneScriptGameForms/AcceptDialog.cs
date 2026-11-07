using OneScript.Contexts;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class AcceptDialog : osgf.Window
    {
        public new GfAcceptDialog dll_obj;
        private osgf.Window m_AcceptDialog;

        public osgf.Window M_AcceptDialog
        {
            get { return m_AcceptDialog; }
            set
            {
                m_AcceptDialog = value;
                base.M_Window = m_AcceptDialog;
            }
        }

        public AcceptDialog()
        {
            OsUtils.CreateGodotObject(this);
            DialogText = "Уведомление";
            Title = "Уведомление";
            Exclusive = false;
        }

        public string Text
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool DialogAutowrap
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool DialogHideOnOK
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool DialogCloseOnEscape
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public string DialogText
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public string OkButtonText
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public void RemoveButton(GfButton p1)
        {
            string buttonItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "buttonItemKey", buttonItemKey },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public GfButton AddButton(string text, bool right)
        {
            string addedButtonItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "addedButtonItemKey", addedButtonItemKey },
                    { "text", text },
                    { "right", right },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("AddButton", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                GfButton button = new GfButton(addedButtonItemKey);
                return button;
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ДобавитьКнопку");
                return null;
            }
        }

        public GfButton AddCancelButton(string text)
        {
            string addedButtonItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "addedButtonItemKey", addedButtonItemKey },
                    { "text", text },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("AddCancelButton", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                GfButton button = new GfButton(addedButtonItemKey);
                return button;
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ДобавитьКнопкуОтмена");
                return null;
            }
        }

        public GfButton GetOkButton()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetOkButton", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                var report = OsUtils.Deserialize(answer["report"].ToString());
                string okButtonItemKey = String.Empty;
                foreach (var item in report)
                {
                    var itemValue = (JsonElement)item.Value;
                    switch (item.Key)
                    {
                        case "okButtonItemKey":
                            okButtonItemKey = itemValue.GetString();
                            break;
                    }
                }

                if (!GameForms.dictKeyEl.TryGetValue(okButtonItemKey, out var button))
                {
                    if (okButtonItemKey != String.Empty)
                    {
                        return new GfButton(okButtonItemKey);
                    }
                    else
                    {
                        OsUtils.Echo("Не удалось выполнить метод ПолучитьКнопкуОК");
                        return null;
                    }
                }
                else
                {
                    return button.dll_obj;
                }
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ПолучитьКнопкуОК");
                return null;
            }
        }

        public GfLabel GetLabel()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetLabel", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                string labelItemKey = ((JsonElement)answer["report"]).GetString();
                if (!GameForms.dictKeyEl.TryGetValue(labelItemKey, out var label))
                {
                    if (labelItemKey != String.Empty)
                    {
                        return new GfLabel(labelItemKey);
                    }
                    else
                    {
                        OsUtils.Echo("Не удалось выполнить метод ПолучитьНадпись");
                        return null;
                    }
                }
                else
                {
                    return label.dll_obj;
                }
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ПолучитьНадпись");
                return null;
            }
        }

        public void Popup(string text, string title, GfRect2i p1, decimal p2)
        {
            int[] position = { OsUtils.ToInt32(p1.Position.X), OsUtils.ToInt32(p1.Position.Y) };
            int[] size = { OsUtils.ToInt32(p1.Size.X), OsUtils.ToInt32(p1.Size.Y) };
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "itemKey",  this.ItemKey },
                    { "dialog_text", text },
                    { "title", title },
                    { "position", position },
                    { "size", size },
                    { "timeout", p2 },
                }
            };
            OsUtils.GetAnswerSendCommand("PopupAcceptDialog", response);
        }

        public void PopupCentered(string text, string title, GfVector2i p1, decimal p2)
        {
            int[] minsize = { OsUtils.ToInt32(p1.X), OsUtils.ToInt32(p1.Y) };
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "itemKey",  this.ItemKey },
                    { "dialog_text", text },
                    { "title", title },
                    { "minsize", minsize },
                    { "timeout", p2 },
                }
            };
            OsUtils.GetAnswerSendCommand("PopupCenteredAcceptDialog", response);
        }

        public new GfThemeAcceptDialog Theme
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфУведомление", "GfAcceptDialog")]
    public class GfAcceptDialog : AutoContext<GfAcceptDialog>
    {
        public osgf.AcceptDialog Base_obj;

        public GfAcceptDialog()
        {
            AcceptDialog AcceptDialog1 = new AcceptDialog();
            AcceptDialog1.dll_obj = this;
            Base_obj = AcceptDialog1;
        }

        [ContextProperty("Автоперенос", "DialogAutowrap")]
        public bool DialogAutowrap
        {
            get { return Base_obj.DialogAutowrap; }
            set { Base_obj.DialogAutowrap = value; }
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

        [ContextProperty("ЗакрытиеПоОК", "DialogHideOnOK")]
        public bool DialogHideOnOK
        {
            get { return Base_obj.DialogHideOnOK; }
            set { Base_obj.DialogHideOnOK = value; }
        }

        [ContextProperty("ЗакрытиеПоЭскейп", "DialogCloseOnEscape")]
        public bool DialogCloseOnEscape
        {
            get { return Base_obj.DialogCloseOnEscape; }
            set { Base_obj.DialogCloseOnEscape = value; }
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

        [ContextProperty("Текст", "DialogText")]
        public string DialogText
        {
            get { return Base_obj.DialogText; }
            set { Base_obj.DialogText = value; }
        }

        [ContextProperty("ТекстКнопкиОК", "OkButtonText")]
        public string OkButtonText
        {
            get { return Base_obj.OkButtonText; }
            set { Base_obj.OkButtonText = value; }
        }

        [ContextProperty("Тема", "Theme")]
        public GfThemeAcceptDialog Theme
        {
            get { return Base_obj.Theme; }
            set { Base_obj.Theme = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfAcceptDialog" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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

        [ContextMethod("ДобавитьКнопку", "AddButton")]
        public GfButton AddButton(string p1, bool p2)
        {
            return Base_obj.AddButton(p1, p2);
        }

        [ContextMethod("ДобавитьКнопкуОтмена", "AddCancelButton")]
        public GfButton AddCancelButton(string p1)
        {
            return Base_obj.AddCancelButton(p1);
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

        [ContextMethod("ПолучитьКнопкуОК", "GetOkButton")]
        public GfButton GetOkButton()
        {
            return Base_obj.GetOkButton();
        }

        [ContextMethod("ПолучитьНадпись", "GetLabel")]
        public GfLabel GetLabel()
        {
            return Base_obj.GetLabel();
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
        public void Popup(string _text = null, string _title = null, GfRect2i p1 = null, decimal p2 = 0m)
        {
            GfRect2i rect2i = new GfRect2i();
            string text = DialogText;
            string title = Title;
            if (OsUtils.AllNotNull(p1))
            {
                rect2i = p1;
            }
            if (OsUtils.AllNotNull(_text))
            {
                text = _text;
            }
            if (OsUtils.AllNotNull(_title))
            {
                title = _title;
            }

            Base_obj.Popup(text, title, rect2i, p2);
        }

        [ContextMethod("РазвернутьВЦентре", "PopupCentered")]
        public void PopupCentered(string _text = null, string _title = null, GfVector2i p1 = null, decimal p2 = 0m)
        {
            GfVector2i vector2i = new GfVector2i();
            string text = DialogText;
            string title = Title;
            if (OsUtils.AllNotNull(p1))
            {
                vector2i = p1;
            }
            if (OsUtils.AllNotNull(_text))
            {
                text = _text;
            }
            if (OsUtils.AllNotNull(_title))
            {
                title = _title;
            }
            Base_obj.PopupCentered(text, title, vector2i, p2);
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

        [ContextMethod("УдалитьКнопку", "RemoveButton")]
        public void RemoveButton(GfButton p1)
        {
            Base_obj.RemoveButton(p1);
        }

        [ContextMethod("Центр", "Center")]
        public void Center(int p1 = 0, int p2 = 0)
        {
            Base_obj.Center(p1, p2);
        }

        [ContextProperty("Отменено", "Canceled")]
        public IValue Canceled
        {
            get { return Base_obj.Canceled; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }

        [ContextProperty("Подтверждено", "Confirmed")]
        public IValue Confirmed
        {
            get { return Base_obj.Confirmed; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }
    }
}
