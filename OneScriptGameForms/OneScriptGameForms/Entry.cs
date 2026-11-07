using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфЗапись", "GfEntry")]
    public class GfEntry : AutoContext<GfEntry>
    {
        public GfEntry()
        {
            Key = null;
            ValueProp = null;
        }

        public GfEntry(IValue p1, IValue p2)
        {
            Key = p1;
            ValueProp = p2;
        }

        [ContextProperty("Значение", "Value")]
        public IValue ValueProp { get; set; }

        [ContextProperty("Ключ", "Key")]
        public IValue Key { get; set; }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfEntry" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }
    }
}
