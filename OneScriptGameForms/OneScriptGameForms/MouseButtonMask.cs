using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфМаскаКнопокМыши", "GfMouseButtonMask")]
    public class GfMouseButtonMask : AutoContext<GfMouseButtonMask>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfMouseButtonMask()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Левая"),
                ValueFactory.Create("Дополнительная1"),
                ValueFactory.Create("Правая"),
                ValueFactory.Create("Дополнительная2"),
                ValueFactory.Create("Средняя")
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
                1 => "Левая",
                128 => "Дополнительная1",
                2 => "Правая",
                256 => "Дополнительная2",
                4 => "Средняя",
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
                1 => "Left",
                128 => "Mb_xbutton1",
                2 => "Right",
                256 => "Mb_xbutton2",
                4 => "Middle",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Дополнительная1", "Mb_xbutton1")]
        public int Mb_xbutton1
        {
            get { return 128; }
        }

        [ContextProperty("Дополнительная2", "Mb_xbutton2")]
        public int Mb_xbutton2
        {
            get { return 256; }
        }

        [ContextProperty("Левая", "Left")]
        public int Left
        {
            get { return 1; }
        }

        [ContextProperty("Правая", "Right")]
        public int Right
        {
            get { return 2; }
        }

        [ContextProperty("Средняя", "Middle")]
        public int Middle
        {
            get { return 4; }
        }
    }
}
