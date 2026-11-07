using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфАвтоперенос", "GfAutowrapMode")]
    public class GfAutowrapMode : AutoContext<GfAutowrapMode>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfAutowrapMode()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Отключено"),
                ValueFactory.Create("Произвольно"),
                ValueFactory.Create("Слово"),
                ValueFactory.Create("Разбивать")
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
                1 => "Произвольно",
                2 => "Слово",
                3 => "Разбивать",
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
                0 => "Off",
                1 => "Arbitrary",
                2 => "Word",
                3 => "WordSmart",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Отключено", "Off")]
        public int Off
        {
            get { return 0; }
        }

        [ContextProperty("Произвольно", "Arbitrary")]
        public int Arbitrary
        {
            get { return 1; }
        }

        [ContextProperty("Разбивать", "WordSmart")]
        public int WordSmart
        {
            get { return 3; }
        }

        [ContextProperty("Слово", "Word")]
        public int Word
        {
            get { return 2; }
        }
    }
}
