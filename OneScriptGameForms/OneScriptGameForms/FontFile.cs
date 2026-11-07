using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Text.Json;

namespace osgf
{
    public class FontFile : osgf.Font
    {
        public GfFontFile dll_obj;
        private osgf.Font m_FontFile;

        public osgf.Font M_FontFile
        {
            get { return m_FontFile; }
            set
            {
                m_FontFile = value;
                base.M_Font = m_FontFile;
            }
        }

        public FontFile()
        {
            OsUtils.CreateGodotObject(this);
            ResourcePath = "";
            ResourceName = "FontFile";
        }

        public FontFile(string _path)
        {
            string path = OsUtils.ToGodotPath(_path);
            ItemKey = "d" + System.IO.Path.GetRandomFileName().Replace(".", "");
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "itemKey",  ItemKey },
                    { "typeNode",  "FontFile" },
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
                ResourceName = "FontFile";
            }
            else
            {
                OsUtils.Echo("Не удалось создать объект ШрифтИзФайла");
                this.dll_obj = null;
            }
        }
    }

    [ContextClass("ИфШрифтИзФайла", "GfFontFile")]
    public class GfFontFile : AutoContext<GfFontFile>
    {
        public osgf.FontFile Base_obj;

        public GfFontFile()
        {
            FontFile FontFile1 = new FontFile();
            FontFile1.dll_obj = this;
            Base_obj = FontFile1;
        }

        public GfFontFile(string path)
        {
            FontFile FontFile1 = new FontFile(path);
            FontFile1.dll_obj = this;
            Base_obj = FontFile1;
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
            return new GfString("GfFontFile" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
