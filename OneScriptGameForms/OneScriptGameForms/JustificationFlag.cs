using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфФлагВыравниванияПоШирине", "GfJustificationFlag")]
    public class GfJustificationFlag : AutoContext<GfJustificationFlag>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfJustificationFlag()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Отсутствие"),
                ValueFactory.Create("Кашида"),
                ValueFactory.Create("Однострочная"),
                ValueFactory.Create("Многоточие"),
                ValueFactory.Create("ГраницаСлов"),
                ValueFactory.Create("НеДляПоследнейСтроки"),
                ValueFactory.Create("ОбрезатьСначалаИСконца"),
                ValueFactory.Create("НеДляПоследнейСтрокиСВидимымиСимволами"),
                ValueFactory.Create("ПослеТабуляции")
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
                1 => "Кашида",
                128 => "Однострочная",
                16 => "Многоточие",
                2 => "ГраницаСлов",
                32 => "НеДляПоследнейСтроки",
                4 => "ОбрезатьСначалаИСконца",
                64 => "НеДляПоследнейСтрокиСВидимымиСимволами",
                8 => "ПослеТабуляции",
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
                1 => "Kashida",
                128 => "DoNotSkipSingleLine",
                16 => "ConstrainEllipsis",
                2 => "WordBound",
                32 => "SkipLastLine",
                4 => "TrimEdgeSpaces",
                64 => "SkipLastLineWithVisibleChars",
                8 => "AfterLastTab",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("ГраницаСлов", "WordBound")]
        public int WordBound
        {
            get { return 2; }
        }

        [ContextProperty("Кашида", "Kashida")]
        public int Kashida
        {
            get { return 1; }
        }

        [ContextProperty("Многоточие", "ConstrainEllipsis")]
        public int ConstrainEllipsis
        {
            get { return 16; }
        }

        [ContextProperty("НеДляПоследнейСтроки", "SkipLastLine")]
        public int SkipLastLine
        {
            get { return 32; }
        }

        [ContextProperty("НеДляПоследнейСтрокиСВидимымиСимволами", "SkipLastLineWithVisibleChars")]
        public int SkipLastLineWithVisibleChars
        {
            get { return 64; }
        }

        [ContextProperty("ОбрезатьСначалаИСконца", "TrimEdgeSpaces")]
        public int TrimEdgeSpaces
        {
            get { return 4; }
        }

        [ContextProperty("Однострочная", "DoNotSkipSingleLine")]
        public int DoNotSkipSingleLine
        {
            get { return 128; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return 0; }
        }

        [ContextProperty("ПослеТабуляции", "AfterLastTab")]
        public int AfterLastTab
        {
            get { return 8; }
        }
    }
}
