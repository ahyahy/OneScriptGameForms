using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфНаправление", "GfDirection")]
    public class GfDirection : AutoContext<GfDirection>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfDirection()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Автоматически"),
                ValueFactory.Create("СлеваНаправо"),
                ValueFactory.Create("СправаНалево"),
                ValueFactory.Create("Унаследованно")
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
                0 => "Автоматически",
                1 => "СлеваНаправо",
                2 => "СправаНалево",
                3 => "Унаследованно",
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
                0 => "Auto",
                1 => "LeftToRight",
                2 => "RightToLeft",
                3 => "Inherited",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Автоматически", "Auto")]
        public int Auto
        {
            get { return 0; }
        }

        [ContextProperty("СлеваНаправо", "LeftToRight")]
        public int LeftToRight
        {
            get { return 1; }
        }

        [ContextProperty("СправаНалево", "RightToLeft")]
        public int RightToLeft
        {
            get { return 2; }
        }

        [ContextProperty("Унаследованно", "Inherited")]
        public int Inherited
        {
            get { return 3; }
        }
    }
}
