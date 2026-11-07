namespace osgf
{
    public class Texture : osgf.Resource
    {
        private osgf.Resource m_Texture;

        public osgf.Resource M_Texture
        {
            get { return m_Texture; }
            set
            {
                m_Texture = value;
                base.M_Resource = m_Texture;
            }
        }
    }
}
