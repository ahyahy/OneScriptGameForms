using System.Reflection;

namespace osgf
{
    public class StyleBox : osgf.Resource
    {
        private osgf.Resource m_StyleBox;

        public osgf.Resource M_StyleBox
        {
            get { return m_StyleBox; }
            set
            {
                m_StyleBox = value;
                base.M_Resource = m_StyleBox;
            }
        }

        public decimal ContentMarginTop
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal ContentMarginLeft
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal ContentMarginBottom
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal ContentMarginRight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }
}
