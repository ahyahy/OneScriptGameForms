using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфТипЭлементаТемы", "GfThemeDataType")]
    public class GfThemeDataType : AutoContext<GfThemeDataType>, ICollectionContext<IValue>, IEnumerable<IValue>
    {
        private List<IValue> _list;
        public IEnumerator Enumerator;

        [ContextMethod("Количество", "Count")]
        public int Count(IBslProcess p1 = null)
        {
            return _list.Count;
        }

        [ContextMethod("Получить", "Get")]
        public IValue Get(int index)
        {
            return this._list[index];
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return (item as IValue);
            }
        }

        public IEnumerator GetEnumerator()
        {
            Enumerator = _list.GetEnumerator();
            return (IEnumerator)this;
        }

        public GfThemeDataType()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Цвет"),
                ValueFactory.Create("Константа"),
                ValueFactory.Create("Шрифт"),
                ValueFactory.Create("РазмерШрифта"),
                ValueFactory.Create("Значок"),
                ValueFactory.Create("СтильПанели")
            };
        }

        public PropertyInfo this[int p1]
        {
            get { return this.GetType().GetProperties()[p1]; }
        }

        public PropertyInfo this[string p1]
        {
            get { return this.GetType().GetProperty(p1); }
        }

        [ContextMethod("Значение", "Value")]
        public int ValueMethod(string p1)
        {
            return OsUtils.ToInt32(this.GetType().GetProperty(p1).GetValue(this));
        }

        [ContextMethod("Имя", "Имя")]
        public string NameRu(int p1)
        {
            return getNameRu(p1);
        }

        public string getNameRu(int p1)
        {
            string result = (int)p1 switch
            {
                0 => "Цвет",
                1 => "Константа",
                2 => "Шрифт",
                3 => "РазмерШрифта",
                4 => "Значок",
                5 => "СтильПанели",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextMethod("Name", "Name")]
        public string NameEn(int p1)
        {
            return getNameEn(p1);
        }

        public string getNameEn(int p1)
        {
            string result = (int)p1 switch
            {
                0 => "Color",
                1 => "Constant",
                2 => "Font",
                3 => "FontSize",
                4 => "Icon",
                5 => "StyleBox",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Значок", "Icon")]
        public int Icon
        {
            get { return 4; }
        }

        [ContextProperty("Константа", "Constant")]
        public int Constant
        {
            get { return 1; }
        }

        [ContextProperty("РазмерШрифта", "FontSize")]
        public int FontSize
        {
            get { return 3; }
        }

        [ContextProperty("СтильПанели", "StyleBox")]
        public int StyleBox
        {
            get { return 5; }
        }

        [ContextProperty("Цвет", "Color")]
        public int Color
        {
            get { return 0; }
        }

        [ContextProperty("Шрифт", "Font")]
        public int Font
        {
            get { return 2; }
        }
    }
}
