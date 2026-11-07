using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Text.Json;

namespace osgf
{
    public class ImageTexture : osgf.Texture2D
    {
        public GfImageTexture dll_obj;
        private osgf.Texture2D m_ImageTexture;

        public osgf.Texture2D M_ImageTexture
        {
            get { return m_ImageTexture; }
            set
            {
                m_ImageTexture = value;
                base.M_Texture2D = m_ImageTexture;
            }
        }

        public ImageTexture()
        {
            OsUtils.CreateGodotObject(this);
            ResourcePath = "";
            ResourceName = "ImageTexture";
        }

        public ImageTexture(string _path)
        {
            string path = OsUtils.ToGodotPath(_path);
            ItemKey = "d" + System.IO.Path.GetRandomFileName().Replace(".", "");
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "itemKey",  ItemKey },
                    { "typeNode",  "ImageTexture" },
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
                ResourceName = "ImageTexture";
            }
            else
            {
                OsUtils.Echo("Не удалось создать объект ТекстураИзИзображения");
                this.dll_obj = null;
            }
        }

        public ImageTexture(string itemKey, string resourcePath)
        {
            ItemKey = itemKey;
            GameForms.dictKeyEl.TryAdd(ItemKey, this);
            GameForms.dictElKey.TryAdd(this, ItemKey);
            ResourcePath = resourcePath;
            ResourceName = "ImageTexture";
        }
    }

    [ContextClass("ИфТекстураИзИзображения", "GfImageTexture")]
    public class GfImageTexture : AutoContext<GfImageTexture>
    {
        public osgf.ImageTexture Base_obj;

        public GfImageTexture()
        {
            ImageTexture imgTex = new ImageTexture();
            imgTex.dll_obj = this;
            Base_obj = imgTex;
        }

        public GfImageTexture(string path)
        {
            ImageTexture imgTex = new ImageTexture(path);
            imgTex.dll_obj = this;
            Base_obj = imgTex;
        }

        public GfImageTexture(string itemKey, string resourcePath)
        {
            ImageTexture ImageTexture1 = new ImageTexture(itemKey, resourcePath);
            ImageTexture1.dll_obj = this;
            Base_obj = ImageTexture1;
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
            return new GfString("GfImageTexture" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
