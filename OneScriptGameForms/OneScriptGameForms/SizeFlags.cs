using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфФлагиРазмера", "GfSizeFlags")]
    public class GfSizeFlags : AutoContext<GfSizeFlags>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfSizeFlags()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("УменьшениеНачало"),
                ValueFactory.Create("Заполнение"),
                ValueFactory.Create("Расширение"),
                ValueFactory.Create("РасширениеЗаполнение"),
                ValueFactory.Create("УменьшениеЦентр"),
                ValueFactory.Create("УменьшениеКонец")
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
                0 => "УменьшениеНачало",
                1 => "Заполнение",
                2 => "Расширение",
                3 => "РасширениеЗаполнение",
                4 => "УменьшениеЦентр",
                8 => "УменьшениеКонец",
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
                0 => "ShrinkBegin",
                1 => "Fill",
                2 => "Expand",
                3 => "ExpandFill",
                4 => "ShrinkCenter",
                8 => "ShrinkEnd",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Заполнение", "Fill")]
        public int Fill
        {
            get { return 1; }
        }

        [ContextProperty("Расширение", "Expand")]
        public int Expand
        {
            get { return 2; }
        }

        [ContextProperty("РасширениеЗаполнение", "ExpandFill")]
        public int ExpandFill
        {
            get { return 3; }
        }

        [ContextProperty("УменьшениеКонец", "ShrinkEnd")]
        public int ShrinkEnd
        {
            get { return 8; }
        }

        [ContextProperty("УменьшениеНачало", "ShrinkBegin")]
        public int ShrinkBegin
        {
            get { return 0; }
        }

        [ContextProperty("УменьшениеЦентр", "ShrinkCenter")]
        public int ShrinkCenter
        {
            get { return 4; }
        }
    }
}
