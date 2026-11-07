using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфРежимСглаживания", "GfMSAA")]
    public class GfMSAA : AutoContext<GfMSAA>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfMSAA()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Отключено"),
                ValueFactory.Create("Двукратно"),
                ValueFactory.Create("Четырехкратно"),
                ValueFactory.Create("Восьмикратно")
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
                0 => "Отключено",
                1 => "Двукратно",
                2 => "Четырехкратно",
                3 => "Восьмикратно",
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
                0 => "Disabled",
                1 => "MSAA2x",
                2 => "MSAA4x",
                3 => "MSAA8x",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Восьмикратно", "MSAA8x")]
        public int MSAA8x
        {
            get { return 3; }
        }

        [ContextProperty("Двукратно", "MSAA2x")]
        public int MSAA2x
        {
            get { return 1; }
        }

        [ContextProperty("Отключено", "Disabled")]
        public int Disabled
        {
            get { return 0; }
        }

        [ContextProperty("Четырехкратно", "MSAA4x")]
        public int MSAA4x
        {
            get { return 2; }
        }
    }
}
