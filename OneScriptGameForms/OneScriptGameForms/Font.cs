namespace osgf
{
    public class Font : osgf.Resource
    {
        private osgf.Resource m_Font;

        public osgf.Resource M_Font
        {
            get { return m_Font; }
            set
            {
                m_Font = value;
                base.M_Resource = m_Font;
            }
        }
    }
}
