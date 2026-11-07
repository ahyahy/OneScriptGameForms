namespace osgf
{
    public class BoxContainer : osgf.Container
    {
        private osgf.Container m_BoxContainer;

        public osgf.Container M_BoxContainer
        {
            get { return m_BoxContainer; }
            set
            {
                m_BoxContainer = value;
                base.M_Container = m_BoxContainer;
            }
        }

        public int Alignment { get; set; }
    }
}
