using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class Node3D : osgf.Node
    {
        private osgf.Node m_Node3D;

        public osgf.Node M_Node3D
        {
            get { return m_Node3D; }
            set
            {
                m_Node3D = value;
                base.M_Node = m_Node3D;
            }
        }

        public GfTransform3D GlobalTransform
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
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

        public void LookAtFromPosition(GfVector3 p1, GfVector3 p2, GfVector3 p3, bool p4 = false)
        {
            object vector1 = OsUtils.ConvertValueForGodot(p1);
            object vector2 = OsUtils.ConvertValueForGodot(p2);
            object vector3 = OsUtils.ConvertValueForGodot(p3);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "vector1",  vector1 },
                    { "vector2",  vector2 },
                    { "vector3",  vector3 },
                    { "usefront",  p4 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }
    }
}
