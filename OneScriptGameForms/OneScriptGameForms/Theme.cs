using ScriptEngine.Machine;
using System.Reflection;

namespace osgf
{
    public class Theme : osgf.Resource
    {
        private osgf.Resource m_Theme;

        public osgf.Resource M_Theme
        {
            get { return m_Theme; }
            set
            {
                m_Theme = value;
                base.M_Resource = m_Theme;
            }
        }

        public decimal DefaultBaseScale
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int DefaultFontSize
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue DefaultFont
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public void ClearTheme()
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
