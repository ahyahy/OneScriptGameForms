using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфФлагПереносаСтроки", "GfLineBreakFlag")]
    public class GfLineBreakFlag : AutoContext<GfLineBreakFlag>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfLineBreakFlag()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Отсутствие"),
                ValueFactory.Create("Обязательно"),
                ValueFactory.Create("ОбрезатьСконца"),
                ValueFactory.Create("ГраницаСлов"),
                ValueFactory.Create("ОбрезатьОтступ"),
                ValueFactory.Create("Графемы"),
                ValueFactory.Create("ОбрезатьСначала"),
                ValueFactory.Create("Адаптивный")
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
                0 => "Отсутствие",
                1 => "Обязательно",
                128 => "ОбрезатьСконца",
                2 => "ГраницаСлов",
                32 => "ОбрезатьОтступ",
                4 => "Графемы",
                64 => "ОбрезатьСначала",
                8 => "Адаптивный",
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
                0 => "None",
                1 => "Mandatory",
                128 => "TrimEndEdgeSpaces",
                2 => "WordBound",
                32 => "TrimIndent",
                4 => "GraphemeBound",
                64 => "TrimStartEdgeSpaces",
                8 => "Adaptive",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Адаптивный", "Adaptive")]
        public int Adaptive
        {
            get { return 8; }
        }

        [ContextProperty("ГраницаСлов", "WordBound")]
        public int WordBound
        {
            get { return 2; }
        }

        [ContextProperty("Графемы", "GraphemeBound")]
        public int GraphemeBound
        {
            get { return 4; }
        }

        [ContextProperty("ОбрезатьОтступ", "TrimIndent")]
        public int TrimIndent
        {
            get { return 32; }
        }

        [ContextProperty("ОбрезатьСконца", "TrimEndEdgeSpaces")]
        public int TrimEndEdgeSpaces
        {
            get { return 128; }
        }

        [ContextProperty("ОбрезатьСначала", "TrimStartEdgeSpaces")]
        public int TrimStartEdgeSpaces
        {
            get { return 64; }
        }

        [ContextProperty("Обязательно", "Mandatory")]
        public int Mandatory
        {
            get { return 1; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return 0; }
        }
    }
}
