using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфРежимОтрисовки", "GfDrawMode")]
    public class GfDrawMode : AutoContext<GfDrawMode>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfDrawMode()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Стандартный"),
                ValueFactory.Create("Нажато"),
                ValueFactory.Create("Наведено"),
                ValueFactory.Create("Отключено"),
                ValueFactory.Create("НаведеноНажато")
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
                0 => "Стандартный",
                1 => "Нажато",
                2 => "Наведено",
                3 => "Отключено",
                4 => "НаведеноНажато",
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
                0 => "Normal",
                1 => "Pressed",
                2 => "Hover",
                3 => "Disabled",
                4 => "HoverPressed",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Наведено", "Hover")]
        public int Hover
        {
            get { return 2; }
        }

        [ContextProperty("НаведеноНажато", "HoverPressed")]
        public int HoverPressed
        {
            get { return 4; }
        }

        [ContextProperty("Нажато", "Pressed")]
        public int Pressed
        {
            get { return 1; }
        }

        [ContextProperty("Отключено", "Disabled")]
        public int Disabled
        {
            get { return 3; }
        }

        [ContextProperty("Стандартный", "Normal")]
        public int Normal
        {
            get { return 0; }
        }
    }
}
