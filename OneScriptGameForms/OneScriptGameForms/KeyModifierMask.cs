using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфМодификаторы", "GfKeyModifierMask")]
    public class GfKeyModifierMask : AutoContext<GfKeyModifierMask>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfKeyModifierMask()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("None"),
                ValueFactory.Create("GroupSwitch"),
                ValueFactory.Create("Meta"),
                ValueFactory.Create("Modifier"),
                ValueFactory.Create("Ctrl"),
                ValueFactory.Create("Shift"),
                ValueFactory.Create("Kpad"),
                ValueFactory.Create("Alt"),
                ValueFactory.Create("Code")
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
                0 => "None",
                1073741824 => "GroupSwitch",
                134217728 => "Meta",
                2130706432 => "Modifier",
                268435456 => "Ctrl",
                33554432 => "Shift",
                536870912 => "Kpad",
                67108864 => "Alt",
                8388607 => "Code",
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
                1073741824 => "GroupSwitch",
                134217728 => "Meta",
                2130706432 => "Modifier",
                268435456 => "Ctrl",
                33554432 => "Shift",
                536870912 => "Kpad",
                67108864 => "Alt",
                8388607 => "Code",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Alt", "Alt")]
        public int Alt
        {
            get { return 67108864; }
        }

        [ContextProperty("Code", "Code")]
        public int Code
        {
            get { return 8388607; }
        }

        [ContextProperty("Ctrl", "Ctrl")]
        public int Ctrl
        {
            get { return 268435456; }
        }

        [ContextProperty("GroupSwitch", "GroupSwitch")]
        public int GroupSwitch
        {
            get { return 1073741824; }
        }

        [ContextProperty("Kpad", "Kpad")]
        public int Kpad
        {
            get { return 536870912; }
        }

        [ContextProperty("Modifier", "Modifier")]
        public int Modifier
        {
            get { return 2130706432; }
        }

        [ContextProperty("None", "None")]
        public int None
        {
            get { return 0; }
        }

        [ContextProperty("Shift", "Shift")]
        public int Shift
        {
            get { return 33554432; }
        }

        [ContextProperty("Meta", "Meta")]
        public int Meta
        {
            get { return 134217728; }
        }
    }
}
