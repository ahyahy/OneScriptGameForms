using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class CanvasItem : osgf.Node
    {
        private osgf.Node m_CanvasItem;

        public osgf.Node M_CanvasItem
        {
            get { return m_CanvasItem; }
            set
            {
                m_CanvasItem = value;
                base.M_Node = m_CanvasItem;
            }
        }

        public GfVector2 ToGlobal(GfVector2 p1)
        {
            object rez = OsUtils.ConvertValueForGodot(p1);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "position",  rez },
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
                OsUtils.Echo("Не удалось выполнить метод ВГлобальные");
                return null;
            }
        }

        public GfVector2 ToLocal(GfVector2 p1)
        {
            object rez = OsUtils.ConvertValueForGodot(p1);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "position",  rez },
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
                OsUtils.Echo("Не удалось выполнить метод ВЛокальные");
                return null;
            }
        }

        public GfColor Modulate
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfMaterial Material
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool Visible
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction MouseMove
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2 GetLocalMousePosition()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "position",  null },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetLocalMousePosition", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            var report = OsUtils.Deserialize(answer["report"].ToString());
            return (GfVector2)OsUtils.ConvertValueForGameForms(report);
        }
    }
}
