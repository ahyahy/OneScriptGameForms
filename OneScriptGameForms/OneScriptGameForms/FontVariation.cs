using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Text.Json;

namespace osgf
{
    public class FontVariation : osgf.Font
    {
        public GfFontVariation dll_obj;
        private osgf.Font m_FontVariation;

        public osgf.Font M_FontVariation
        {
            get { return m_FontVariation; }
            set
            {
                m_FontVariation = value;
                base.M_Font = m_FontVariation;
            }
        }

        public FontVariation()
        {
            OsUtils.CreateGodotObject(this);
            ResourcePath = "";
            ResourceName = "FontVariation";
        }

        public FontVariation(string _path)
        {
            string path = OsUtils.ToGodotPath(_path);
            ItemKey = "d" + System.IO.Path.GetRandomFileName().Replace(".", "");
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "itemKey",  ItemKey },
                    { "typeNode",  "FontVariation" },
                    { "resource_path", path }
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("CreateNode", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                this.ResourcePath = path;
                GameForms.dictKeyEl.TryAdd(ItemKey, this);
                GameForms.dictElKey.TryAdd(this, ItemKey);
                ResourceName = "FontVariation";
            }
            else
            {
                OsUtils.Echo("Не удалось создать объект ШрифтВариативный");
                this.dll_obj = null;
            }
        }

        public FontVariation(string itemKey, string resourcePath)
        {
            ItemKey = itemKey;
            GameForms.dictKeyEl.TryAdd(ItemKey, this);
            GameForms.dictElKey.TryAdd(this, ItemKey);
            ResourcePath = resourcePath;
            ResourceName = "FontVariation";
        }
    }

    [ContextClass("ИфШрифтВариативный", "GfFontVariation")]
    public class GfFontVariation : AutoContext<GfFontVariation>
    {
        public osgf.FontVariation Base_obj;

        public GfFontVariation()
        {
            FontVariation FontVariation1 = new FontVariation();
            FontVariation1.dll_obj = this;
            Base_obj = FontVariation1;
        }

        public GfFontVariation(string path)
        {
            FontVariation FontVariation1 = new FontVariation(path);
            FontVariation1.dll_obj = this;
            Base_obj = FontVariation1;
        }

        public GfFontVariation(string itemKey, string resourcePath)
        {
            FontVariation FontVariation1 = new FontVariation(itemKey, resourcePath);
            FontVariation1.dll_obj = this;
            Base_obj = FontVariation1;
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

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfFontVariation" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("Дублировать", "Duplicate")]
        public IValue Duplicate()
        {
            return Base_obj.Duplicate();
        }

        [ContextMethod("Сохранить", "Save")]
        public void Save(string path)
        {
            Base_obj.Save(path);
        }
    }
}
