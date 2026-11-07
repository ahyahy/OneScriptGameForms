using OneScript.Contexts;
using OneScript.StandardLibrary.Binary;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class Image : osgf.Resource
    {
        public GfImage dll_obj;
        private osgf.Resource m_Image;

        public osgf.Resource M_Image
        {
            get { return m_Image; }
            set
            {
                m_Image = value;
                base.M_Resource = m_Image;
            }
        }

        public Image()
        {
            OsUtils.CreateGodotObject(this);
            ResourcePath = "";
            ResourceName = "Image";
        }

        public Image(string _path)
        {
            string path = OsUtils.ToGodotPath(_path);
            ItemKey = "d" + System.IO.Path.GetRandomFileName().Replace(".", "");
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "itemKey",  ItemKey },
                    { "typeNode",  "Image" },
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
                ResourceName = "Image";
            }
            else
            {
                OsUtils.Echo("Не удалось создать объект Изображение");
                this.dll_obj = null;
            }
        }

        public GfColor GetPixel(int x, int y)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "x",  x },
                    { "y",  y },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetPixel", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            var report = OsUtils.Deserialize(answer["report"].ToString());
            return (GfColor)OsUtils.ConvertValueForGameForms(report);
        }

        public BinaryDataBuffer GetData()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetPixel", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            var report = OsUtils.Deserialize(answer["report"].ToString());
            return (BinaryDataBuffer)OsUtils.ConvertValueForGameForms(report);
        }

        public void SetPixel(int x, int y, GfColor color)
        {
            object rez = OsUtils.ConvertValueForGodot(color);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "x",  x },
                    { "y",  y },
                    { "color",  color },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }
    }

    [ContextClass("ИфИзображение", "GfImage")]
    public class GfImage : AutoContext<GfImage>
    {
        public osgf.Image Base_obj;

        public GfImage()
        {
            Image Image1 = new Image();
            Image1.dll_obj = this;
            Base_obj = Image1;
        }

        public GfImage(string path)
        {
            Image Image1 = new Image(path);
            Image1.dll_obj = this;
            Base_obj = Image1;
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
            return new GfString("GfImage" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("Дублировать", "Duplicate")]
        public IValue Duplicate()
        {
            return Base_obj.Duplicate();
        }

        [ContextMethod("ПолучитьДанные", "GetData")]
        public BinaryDataBuffer GetData()
        {
            return Base_obj.GetData();
        }

        [ContextMethod("ПолучитьПиксель", "GetPixel")]
        public GfColor GetPixel(int x, int y)
        {
            return Base_obj.GetPixel(x, y);
        }

        [ContextMethod("Сохранить", "Save")]
        public void Save(string path)
        {
            Base_obj.Save(path);
        }

        [ContextMethod("УстановитьПиксель", "SetPixel")]
        public void SetPixel(int p1, int p2, GfColor p3)
        {
            Base_obj.SetPixel(p1, p2, p3);
        }
    }
}
