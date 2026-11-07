using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфКнопкаМыши", "GfMouseButton")]
    public class GfMouseButton : AutoContext<GfMouseButton>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfMouseButton()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Отсутствие"),
                ValueFactory.Create("Левая"),
                ValueFactory.Create("Правая"),
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
                0 => "Отсутствие",
                1 => "Левая",
                2 => "Правая",
                3 => "Средняя",
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
                1 => "Left",
                2 => "Right",
                3 => "Middle",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Левая", "Left")]
        public int Left
        {
            get { return 1; }
        }

        [ContextProperty("Отсутствие", "None")]
        public int None
        {
            get { return 0; }
        }

        [ContextProperty("Правая", "Right")]
        public int Right
        {
            get { return 2; }
        }

        [ContextProperty("Средняя", "Middle")]
        public int Middle
        {
            get { return 3; }
        }
    }
}
