using System.Reflection;

namespace osgf
{
    public class Viewport : osgf.Node
    {
        private osgf.Node m_Viewport;

        public osgf.Node M_Viewport
        {
            get { return m_Viewport; }
            set
            {
                m_Viewport = value;
                base.M_Node = m_Viewport;
            }
        }

        public bool Disable3d
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int Msaa2d
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int Msaa3d
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction Canceled
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction Confirmed
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }
}
