namespace osgf
{
    public class VisualInstance3D : osgf.Node3D
    {
        private osgf.Node3D m_VisualInstance3D;

        public osgf.Node3D M_VisualInstance3D
        {
            get { return m_VisualInstance3D; }
            set
            {
                m_VisualInstance3D = value;
                base.M_Node3D = m_VisualInstance3D;
            }
        }
    }
}
