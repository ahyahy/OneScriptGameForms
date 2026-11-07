namespace osgf
{
    public class SubViewport : osgf.Viewport
    {
        private osgf.Viewport m_SubViewport;

        public osgf.Viewport M_SubViewport
        {
            get { return m_SubViewport; }
            set
            {
                m_SubViewport = value;
                base.M_Viewport = m_SubViewport;
            }
        }
    }
}
