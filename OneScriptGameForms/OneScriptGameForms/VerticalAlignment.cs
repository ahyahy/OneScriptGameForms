using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфВертикальноеВыравнивание", "GfVerticalAlignment")]
    public class GfVerticalAlignment : AutoContext<GfVerticalAlignment>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfVerticalAlignment()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Верх"),
                ValueFactory.Create("Центр"),
                ValueFactory.Create("Низ"),
                ValueFactory.Create("Заполнение")
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
                0 => "Верх",
                1 => "Центр",
                2 => "Низ",
                3 => "Заполнение",
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
                0 => "Top",
                1 => "Center",
                2 => "Bottom",
                3 => "Fill",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Верх", "Top")]
        public int Top
        {
            get { return 0; }
        }

        [ContextProperty("Заполнение", "Fill")]
        public int Fill
        {
            get { return 3; }
        }

        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
            get { return 2; }
        }

        [ContextProperty("Центр", "Center")]
        public int Center
        {
            get { return 1; }
        }
    }
}
