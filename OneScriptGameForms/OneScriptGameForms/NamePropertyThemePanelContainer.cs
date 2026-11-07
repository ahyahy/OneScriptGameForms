using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфИмяСвойстваТемыПанельныйКонтейнер", "GfNamePropertyThemePanelContainer")]
    public class GfNamePropertyThemePanelContainer : AutoContext<GfNamePropertyThemePanelContainer>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfNamePropertyThemePanelContainer()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("Панель")
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
        public string NameRu(string p1)
        {
            return getNameRu(p1);
        }

        public string getNameRu(string p1)
        {
            string result = (string)p1 switch
            {
                "panel:PanelContainer" => "Панель",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextMethod("Name", "Name")]
        public string NameEn(string p1)
        {
            return getNameEn(p1);
        }

        public string getNameEn(string p1)
        {
            string result = (string)p1 switch
            {
                "panel:PanelContainer" => "Panel",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Панель", "Panel")]
        public string Panel
        {
            get { return "panel:PanelContainer"; }
        }
    }
}
