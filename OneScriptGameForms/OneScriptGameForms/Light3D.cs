using System.Reflection;

namespace osgf
{
    public class Light3D : osgf.VisualInstance3D
    {
        private osgf.VisualInstance3D m_Light3D;

        public osgf.VisualInstance3D M_Light3D
        {
            get { return m_Light3D; }
            set
            {
                m_Light3D = value;
                base.M_VisualInstance3D = m_Light3D;
            }
        }

        public int LightEnergy
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int LightColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }
}
