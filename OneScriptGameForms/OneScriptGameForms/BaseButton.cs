using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class BaseButton : osgf.Control
    {
        private osgf.Control m_BaseButton;

        public osgf.Control M_BaseButton
        {
            get { return m_BaseButton; }
            set
            {
                m_BaseButton = value;
                base.M_Control = m_BaseButton;
            }
        }

        public bool Disabled
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool ToggleMode
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int GetDrawMode()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetDrawMode", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            string str = ((JsonElement)answer["report"]).GetString();
            return GameForms.instance.DrawModeProp.ValueMethod(str);
        }

        public GfAction ButtonUp
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction ButtonDown
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction Pressed
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction Toggled
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public void ProgrammPressed()
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
    }
}
