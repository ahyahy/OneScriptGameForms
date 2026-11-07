namespace osgf
{
    public class Texture2D : osgf.Texture
    {
        private osgf.Texture m_Texture2D;

        public osgf.Texture M_Texture2D
        {
            get { return m_Texture2D; }
            set
            {
                m_Texture2D = value;
                base.M_Texture = m_Texture2D;
            }
        }
    }
}
