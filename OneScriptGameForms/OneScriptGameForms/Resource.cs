using ScriptEngine.Machine;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class Resource : osgf.RefCounted
    {
        private osgf.RefCounted m_Resource;

        public osgf.RefCounted M_Resource
        {
            get { return m_Resource; }
            set
            {
                m_Resource = value;
                base.M_RefCounted = m_Resource;
            }
        }

        public string ResourcePath { get; set; }

        public IValue Duplicate()
        {
            string resourceItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "resourceItemKey",  resourceItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("Duplicate", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                GameForms.dictKeyEl.TryGetValue(ItemKey, out var element);
                dynamic obj = element.dll_obj;
                object[] args1 = { resourceItemKey };
                return Activator.CreateInstance(obj.GetType(), args1);
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод Дублировать");
                return null;
            }
        }

        public void Save(string _path)
        {
            string path = OsUtils.ToGodotPath(_path);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "resource_path",  path },
                }
            };
            OsUtils.GetAnswerSendCommand("ResourceSave", response);
        }

        public string ResourceName
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }
}
