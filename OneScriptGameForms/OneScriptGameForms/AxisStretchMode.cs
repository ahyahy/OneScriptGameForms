using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфОсевоеРастяжение", "GfAxisStretchMode")]
    public class GfAxisStretchMode : AutoContext<GfAxisStretchMode>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfAxisStretchMode()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Растянуть"),
                ValueFactory.Create("Плитка"),
                ValueFactory.Create("Вписать")
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
                0 => "Растянуть",
                1 => "Плитка",
                2 => "Вписать",
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
                0 => "Stretch",
                1 => "Tile",
                2 => "Fit",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Вписать", "Fit")]
        public int Fit
        {
            get { return 2; }
        }

        [ContextProperty("Плитка", "Tile")]
        public int Tile
        {
            get { return 1; }
        }

        [ContextProperty("Растянуть", "Stretch")]
        public int Stretch
        {
            get { return 0; }
        }
    }
}
