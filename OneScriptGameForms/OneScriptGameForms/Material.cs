using OneScript.Contexts;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    public class Material
    {
        public Material()
        {
        }
    }

    [ContextClass("ИфМатериал", "GfMaterial")]
    public class GfMaterial : AutoContext<GfMaterial>
    {
        public osgf.Material Base_obj;

        public GfMaterial()
        {
        }
    }
}
