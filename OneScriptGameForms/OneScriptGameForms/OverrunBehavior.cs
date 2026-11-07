using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфПоведениеПриПереполнении", "GfOverrunBehavior")]
    public class GfOverrunBehavior : AutoContext<GfOverrunBehavior>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfOverrunBehavior()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("БезОбрезки"),
                ValueFactory.Create("ПоСимволам"),
                ValueFactory.Create("ПоСловам"),
                ValueFactory.Create("ПоСимволамМноготочие"),
                ValueFactory.Create("ПоСловамМноготочие"),
                ValueFactory.Create("ПоСимволамМноготочиеСтрого"),
                ValueFactory.Create("ПоСловамМноготочиеСтрого")
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
                0 => "БезОбрезки",
                1 => "ПоСимволам",
                2 => "ПоСловам",
                3 => "ПоСимволамМноготочие",
                4 => "ПоСловамМноготочие",
                5 => "ПоСимволамМноготочиеСтрого",
                6 => "ПоСловамМноготочиеСтрого",
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
                0 => "NoTrimming",
                1 => "TrimChar",
                2 => "TrimWord",
                3 => "TrimEllipsis",
                4 => "TrimWordEllipsis",
                5 => "TrimEllipsisForce",
                6 => "TrimWordEllipsisForce",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("БезОбрезки", "NoTrimming")]
        public int NoTrimming
        {
            get { return 0; }
        }

        [ContextProperty("ПоСимволам", "TrimChar")]
        public int TrimChar
        {
            get { return 1; }
        }

        [ContextProperty("ПоСимволамМноготочие", "TrimEllipsis")]
        public int TrimEllipsis
        {
            get { return 3; }
        }

        [ContextProperty("ПоСимволамМноготочиеСтрого", "TrimEllipsisForce")]
        public int TrimEllipsisForce
        {
            get { return 5; }
        }

        [ContextProperty("ПоСловам", "TrimWord")]
        public int TrimWord
        {
            get { return 2; }
        }

        [ContextProperty("ПоСловамМноготочие", "TrimWordEllipsis")]
        public int TrimWordEllipsis
        {
            get { return 4; }
        }

        [ContextProperty("ПоСловамМноготочиеСтрого", "TrimWordEllipsisForce")]
        public int TrimWordEllipsisForce
        {
            get { return 6; }
        }
    }
}
