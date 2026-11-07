using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфСистемныйКаталог", "GfSystemDir")]
    public class GfSystemDir : AutoContext<GfSystemDir>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfSystemDir()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("РабочийСтол"),
                ValueFactory.Create("Камера"),
                ValueFactory.Create("Документы"),
                ValueFactory.Create("Загрузки"),
                ValueFactory.Create("Видео"),
                ValueFactory.Create("Музыка"),
                ValueFactory.Create("Рисунки")
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
                0 => "РабочийСтол",
                1 => "Камера",
                2 => "Документы",
                3 => "Загрузки",
                4 => "Видео",
                5 => "Музыка",
                6 => "Рисунки",
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
                0 => "Desktop",
                1 => "DCIM",
                2 => "Documents",
                3 => "Downloads",
                4 => "Movies",
                5 => "Music",
                6 => "Pictures",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Видео", "Movies")]
        public int Movies
        {
            get { return 4; }
        }

        [ContextProperty("Документы", "Documents")]
        public int Documents
        {
            get { return 2; }
        }

        [ContextProperty("Загрузки", "Downloads")]
        public int Downloads
        {
            get { return 3; }
        }

        [ContextProperty("Камера", "DCIM")]
        public int DCIM
        {
            get { return 1; }
        }

        [ContextProperty("Музыка", "Music")]
        public int Music
        {
            get { return 5; }
        }

        [ContextProperty("РабочийСтол", "Desktop")]
        public int Desktop
        {
            get { return 0; }
        }

        [ContextProperty("Рисунки", "Pictures")]
        public int Pictures
        {
            get { return 6; }
        }
    }
}
