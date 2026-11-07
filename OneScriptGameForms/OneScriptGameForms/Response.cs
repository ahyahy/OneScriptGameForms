namespace osgf
{
    public class Response
    {
        public Dictionary<string, object> Properties { get; set; } = null; // Свойства элемента.

        public object this[string p1]
        {
            get { return this.GetType().GetProperty(p1).GetValue(this); }
            set { this.GetType().GetProperty(p1).SetValue(this, value); }
        }
    }
}
