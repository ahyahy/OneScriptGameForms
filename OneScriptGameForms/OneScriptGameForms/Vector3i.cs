using OneScript.Contexts;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфВектор3ц", "GfVector3i")]
    public class GfVector3i : AutoContext<GfVector3i>
    {
        public GfVector3i()
        {
        }

        public GfVector3i(int _x, int _y, int _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        [ContextProperty("Зет", "Z")]
        public int Z { get; set; } = 0;

        [ContextProperty("Игрек", "Y")]
        public int Y { get; set; } = 0;

        [ContextProperty("Икс", "X")]
        public int X { get; set; } = 0;

        [ContextMethod("Вектор3", "Vector3")]
        public GfVector3 Vector3(GfVector3i p1)
        {
            int x = Convert.ToInt32(p1.X);
            int y = Convert.ToInt32(p1.Y);
            int z = Convert.ToInt32(p1.Z);
            return new GfVector3(x, y, z);
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfVector3i" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }
    }
}
