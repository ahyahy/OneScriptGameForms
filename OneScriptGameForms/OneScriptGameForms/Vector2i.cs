using OneScript.Contexts;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфВектор2ц", "GfVector2i")]
    public class GfVector2i : AutoContext<GfVector2i>
    {
        public GfVector2i()
        {
        }

        public GfVector2i(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        [ContextProperty("Игрек", "Y")]
        public int Y { get; set; } = 0;

        [ContextProperty("Икс", "X")]
        public int X { get; set; } = 0;

        [ContextMethod("Вектор2", "Vector2")]
        public GfVector2 Vector2(GfVector2i p1)
        {
            decimal x = Convert.ToDecimal(p1.X);
            decimal y = Convert.ToDecimal(p1.Y);
            return new GfVector2(x, y);
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfVector2i" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }
    }
}
