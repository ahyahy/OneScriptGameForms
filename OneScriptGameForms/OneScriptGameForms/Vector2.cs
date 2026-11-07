using OneScript.Contexts;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфВектор2", "GfVector2")]
    public class GfVector2 : AutoContext<GfVector2>
    {
        public GfVector2()
        {
        }

        public GfVector2(decimal _x, decimal _y)
        {
            X = _x;
            Y = _y;
        }

        [ContextProperty("Игрек", "Y")]
        public decimal Y { get; set; } = 0;

        [ContextProperty("Икс", "X")]
        public decimal X { get; set; } = 0;

        [ContextMethod("Вектор2ц", "Vector2i")]
        public GfVector2i Vector2i(GfVector2 p1)
        {
            int x = Convert.ToInt32(p1.X);
            int y = Convert.ToInt32(p1.Y);
            return new GfVector2i(x, y);
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfVector2" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }
    }
}
