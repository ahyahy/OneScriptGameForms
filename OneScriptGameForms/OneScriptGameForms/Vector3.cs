using OneScript.Contexts;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфВектор3", "GfVector3")]
    public class GfVector3 : AutoContext<GfVector3>
    {
        public GfVector3()
        {
        }

        public GfVector3(decimal _x, decimal _y, decimal _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        [ContextProperty("Зет", "Z")]
        public decimal Z { get; set; } = 0;

        [ContextProperty("Игрек", "Y")]
        public decimal Y { get; set; } = 0;

        [ContextProperty("Икс", "X")]
        public decimal X { get; set; } = 0;

        [ContextMethod("Вектор3ц", "Vector3i")]
        public GfVector3i Vector3i(GfVector3 p1)
        {
            int x = Convert.ToInt32(p1.X);
            int y = Convert.ToInt32(p1.Y);
            int z = Convert.ToInt32(p1.Z);
            return new GfVector3i(x, y, z);
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfVector3" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }
    }
}
