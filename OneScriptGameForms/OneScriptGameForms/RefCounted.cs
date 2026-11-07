namespace osgf
{
    public class RefCounted : osgf.GObject
    {
        private osgf.GObject m_RefCounted;

        public osgf.GObject M_RefCounted
        {
            get { return m_RefCounted; }
            set
            {
                m_RefCounted = value;
                base.M_GObject = m_RefCounted;
            }
        }
    }
}
