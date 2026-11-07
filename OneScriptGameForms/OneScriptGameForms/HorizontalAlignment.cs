using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфГоризонтальноеВыравнивание", "GfHorizontalAlignment")]
    public class GfHorizontalAlignment : AutoContext<GfHorizontalAlignment>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfHorizontalAlignment()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Лево"),
                ValueFactory.Create("Центр"),
                ValueFactory.Create("Право"),
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
                0 => "Лево",
                1 => "Центр",
                2 => "Право",
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
                0 => "Left",
                1 => "Center",
                2 => "Right",
                3 => "Fill",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Заполнение", "Fill")]
        public int Fill
        {
            get { return 3; }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
            get { return 0; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
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
