using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class ThemeScene : osgf.Theme
    {
        public GfThemeScene dll_obj;
        private osgf.Theme m_ThemeScene;

        public osgf.Theme M_ThemeScene
        {
            get { return m_ThemeScene; }
            set
            {
                m_ThemeScene = value;
                base.M_Theme = m_ThemeScene;
            }
        }

        public ThemeScene()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "ThemeScene";
        }

        public ThemeScene(string p1)
        {
            ItemKey = p1;
            GameForms.dictKeyEl.TryAdd(ItemKey, this);
            GameForms.dictElKey.TryAdd(this, ItemKey);
            ResourceName = "ThemeScene";
        }

        public GfColor GetColor(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetColor", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            var report = OsUtils.Deserialize(answer["report"].ToString());
            return (GfColor)OsUtils.ConvertValueForGameForms(report);
        }

        public int GetConstant(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetConstant", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            var report = OsUtils.Deserialize(answer["report"].ToString());
            return (int)OsUtils.ConvertValueForGameForms(report);
        }

        public void SetColor(string name, string theme_type, GfColor color)
        {
            object rez = OsUtils.ConvertValueForGodot(color);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                    { "color",  rez },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void SetConstant(string name, string theme_type, int constanta)
        {
            object rez = OsUtils.ConvertValueForGodot(constanta);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                    { "constanta",  rez },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void SetStylebox(string name, string theme_type, IValue stylebox)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                    { "styleboxItemKey",  ((dynamic)stylebox).ItemKey },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void ClearIcon(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void ClearConstant(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void ClearFontSize(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void ClearStylebox(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void ClearColor(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void ClearFont(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public GfImageTexture GetIcon(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetIcon", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            string iconItemKey = ((JsonElement)answer["report"]).GetString();
            // Если находим fontItemKey в словаре  - возвращаем из метода.
            if (GameForms.dictKeyEl.TryGetValue(iconItemKey, out var icon))
            {
                //1.Если icon найдем в словаре, тогда передаем его ItemKey
                return icon.dll_obj;
            }
            // Если не находим - создаем новый экземпляр GfImageTexture.
            return new GfImageTexture(iconItemKey, "");
        }

        public int GetFontSize(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetFontSize", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            var report = OsUtils.Deserialize(answer["report"].ToString());
            return (int)OsUtils.ConvertValueForGameForms(report);
        }

        public IValue GetStylebox(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetStylebox", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            string styleboxItemKey = ((JsonElement)answer["report"]).GetString();
            // Если находим fontItemKey в словаре  - возвращаем из метода.
            if (GameForms.dictKeyEl.TryGetValue(styleboxItemKey, out var stylebox))
            {
                //1.Если stylebox найдем в словаре, тогда передаем его ItemKey
                return stylebox.dll_obj;
            }
            // Если не находим - создаем новый экземпляр GfStyleBoxFlat.
            return new GfStyleBoxFlat(styleboxItemKey, true);
        }

        public IValue GetFont(string name, string theme_type)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetFont", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            string fontItemKey = ((JsonElement)answer["report"]).GetString();
            // Если находим fontItemKey в словаре  - возвращаем из метода.
            if (GameForms.dictKeyEl.TryGetValue(fontItemKey, out var font))
            {
                //1.Если stylebox найдем в словаре, тогда передаем его ItemKey
                return font.dll_obj;
            }
            // Если не находим - создаем новый экземпляр GfFontVariation.
            return new GfFontVariation(fontItemKey, "");
        }

        public void SetFontSize(string name, string theme_type, int fontSize)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                    { "fontSize",  fontSize },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void SetIcon(string name, string theme_type, GfImageTexture icon)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                    { "iconItemKey",  icon.ItemKey },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void SetFont(string name, string theme_type, IValue font)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                    { "theme_type",  theme_type },
                    { "fontItemKey",  ((dynamic)font).ItemKey },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }
    }

    [ContextClass("ИфТемаСцена", "GfThemeScene")]
    public class GfThemeScene : AutoContext<GfThemeScene>
    {
        public osgf.ThemeScene Base_obj;

        public GfThemeScene()
        {
            ThemeScene ThemeScene1 = new ThemeScene();
            ThemeScene1.dll_obj = this;
            Base_obj = ThemeScene1;
        }

        public GfThemeScene(string p1 = null)
        {
            ThemeScene ThemeScene1 = new ThemeScene(p1);
            ThemeScene1.dll_obj = this;
            Base_obj = ThemeScene1;
        }

        [ContextProperty("ИмяРесурса", "ResourceName")]
        public string ResourceName
        {
            get { return Base_obj.ResourceName; }
        }

        [ContextProperty("КлючЭлемента", "ItemKey")]
        public string ItemKey
        {
            get { return Base_obj.ItemKey; }
        }

        [ContextProperty("МасштабПоУмолчанию", "DefaultBaseScale")]
        public decimal DefaultBaseScale
        {
            get { return Base_obj.DefaultBaseScale; }
            set { Base_obj.DefaultBaseScale = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public IValue Tag
        {
            get { return Base_obj.Tag; }
            set { Base_obj.Tag = value; }
        }

        [ContextProperty("ПутьРесурса", "ResourcePath")]
        public string ResourcePath
        {
            get { return Base_obj.ResourcePath; }
            set { Base_obj.ResourcePath = value; }
        }

        [ContextProperty("РазмерШрифтаПоУмолчанию", "DefaultFontSize")]
        public int DefaultFontSize
        {
            get { return Base_obj.DefaultFontSize; }
            set { Base_obj.DefaultFontSize = value; }
        }

        [ContextProperty("ШрифтПоУмолчанию", "DefaultFont")]
        public IValue DefaultFont
        {
            get { return Base_obj.DefaultFont; }
            set { Base_obj.DefaultFont = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfThemeScene" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("Дублировать", "Duplicate")]
        public IValue Duplicate()
        {
            return Base_obj.Duplicate();
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.ClearTheme();
        }

        [ContextMethod("ОчиститьЗначок", "ClearIcon")]
        public void ClearIcon(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.ClearIcon(propertyName, themeType);
        }

        [ContextMethod("ОчиститьКонстанту", "ClearConstant")]
        public void ClearConstant(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.ClearConstant(propertyName, themeType);
        }

        [ContextMethod("ОчиститьРазмерШрифта", "ClearFontSize")]
        public void ClearFontSize(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.ClearFontSize(propertyName, themeType);
        }

        [ContextMethod("ОчиститьСтильПанели", "ClearStylebox")]
        public void ClearStylebox(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.ClearStylebox(propertyName, themeType);
        }

        [ContextMethod("ОчиститьЦвет", "ClearColor")]
        public void ClearColor(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.ClearColor(propertyName, themeType);
        }

        [ContextMethod("ОчиститьШрифт", "ClearFont")]
        public void ClearFont(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.ClearFont(propertyName, themeType);
        }

        [ContextMethod("ПолучитьЗначок", "GetIcon")]
        public GfImageTexture GetIcon(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            return Base_obj.GetIcon(propertyName, themeType);
        }

        [ContextMethod("ПолучитьКонстанту", "GetConstant")]
        public int GetConstant(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            return Base_obj.GetConstant(propertyName, themeType);
        }

        [ContextMethod("ПолучитьРазмерШрифта", "GetFontSize")]
        public int GetFontSize(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            return Base_obj.GetFontSize(propertyName, themeType);
        }

        [ContextMethod("ПолучитьСтильПанели", "GetStylebox")]
        public IValue GetStylebox(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            return Base_obj.GetStylebox(propertyName, themeType);
        }

        [ContextMethod("ПолучитьЦвет", "GetColor")]
        public GfColor GetColor(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            return Base_obj.GetColor(propertyName, themeType);
        }

        [ContextMethod("ПолучитьШрифт", "GetFont")]
        public IValue GetFont(string propertyPath)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            return Base_obj.GetFont(propertyName, themeType);
        }

        [ContextMethod("Сохранить", "Save")]
        public void Save(string path)
        {
            Base_obj.Save(path);
        }

        [ContextMethod("УстановитьЗначок", "SetIcon")]
        public void SetIcon(string propertyPath, GfImageTexture icon)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.SetIcon(propertyName, themeType, icon);
        }

        [ContextMethod("УстановитьКонстанту", "SetConstant")]
        public void SetConstant(string propertyPath, int constanta)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.SetConstant(propertyName, themeType, constanta);
        }

        [ContextMethod("УстановитьРазмерШрифта", "SetFontSize")]
        public void SetFontSize(string propertyPath, int fontSize)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.SetFontSize(propertyName, themeType, fontSize);
        }

        [ContextMethod("УстановитьСтильПанели", "SetStylebox")]
        public void SetStylebox(string propertyPath, IValue stylebox)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.SetStylebox(propertyName, themeType, stylebox);
        }

        [ContextMethod("УстановитьЦвет", "SetColor")]
        public void SetColor(string propertyPath, GfColor color)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.SetColor(propertyName, themeType, color);
        }

        [ContextMethod("УстановитьШрифт", "SetFont")]
        public void SetFont(string propertyPath, IValue font)
        {
            string propertyName = propertyPath.Split(':')[0];
            string themeType = propertyPath.Split(':')[1];
            Base_obj.SetFont(propertyName, themeType, font);
        }
    }
}
