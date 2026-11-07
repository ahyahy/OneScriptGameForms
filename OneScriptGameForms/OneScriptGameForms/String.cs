using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфСтрока", "GfString")]
    public class GfString : AutoContext<GfString>
    {
        private string Base_obj;

        public GfString()
        {
            Base_obj = "";
        }

        public GfString(string p1)
        {
            Base_obj = p1;
        }

        public GfString(IValue p1)
        {
            Base_obj = p1.ToString();
        }

        public static implicit operator string(GfString str)
        {
            return str.Base_obj;
        }

        public static implicit operator GfString(string str)
        {
            return new GfString(str);
        }

        public override string ToString()
        {
            return Base_obj;
        }

        [ContextMethod("ВСтроку", "ToString")]
        public string ToStringMethod()
        {
            return Base_obj.ToString();
        }

        [ContextMethod("Заменить", "Replace")]
        public GfString Replace(string oldValue, string newValue)
        {
            return new GfString(Base_obj.Replace(oldValue, newValue));
        }

        [ContextMethod("ПервоеВхождение", "IndexOf")]
        public int IndexOf(string p1)
        {
            return Base_obj.IndexOf(p1);
        }

        [ContextMethod("ПоследнееВхождение", "LastIndexOf")]
        public int LastIndexOf(string p1)
        {
            return Base_obj.LastIndexOf(p1);
        }

        [ContextMethod("Содержит", "Contains")]
        public bool Contains(string p1)
        {
            return Base_obj.Contains(p1);
        }
    }
}
