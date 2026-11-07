using ScriptEngine.Machine;

namespace osgf
{
    public class GObject : System.Object
    {
        public System.Object M_GObject;

        public string ItemKey { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public IValue Tag { get; set; }

        public object this[string p1]
        {
            get { return this.GetType().GetProperty(p1).GetValue(this); }
            set { this.GetType().GetProperty(p1).SetValue(this, value); }
        }
    }
}
