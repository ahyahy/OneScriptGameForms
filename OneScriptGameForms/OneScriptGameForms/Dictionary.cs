using OneScript.Contexts;
using OneScript.Execution;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;

namespace osgf
{
    public class Dictionary : IEnumerable, IEnumerator
    {
        public GfDictionary dll_obj;
        public System.Collections.IEnumerator Enumerator;
        public System.Collections.Generic.Dictionary<object, object> M_Dictionary;

        public Dictionary()
        {
            M_Dictionary = new System.Collections.Generic.Dictionary<object, object>();
        }

        public Dictionary(Dictionary<object, object> p1)
        {
            M_Dictionary = p1;
        }

        public Dictionary(osgf.Dictionary p1)
        {
            M_Dictionary = p1.M_Dictionary;
        }

        public int Count
        {
            get { return M_Dictionary.Count; }
        }

        public object Current
        {
            get { return Enumerator.Current; }
        }

        public IValue get_Item(object key)
        {
            return (IValue)M_Dictionary[key];
        }

        public void Reset()
        {
            Enumerator.Reset();
        }

        public void Add(object key, object value)
        {
            M_Dictionary.Add(key, value);
        }

        public void Clear()
        {
            M_Dictionary.Clear();
        }

        public bool ContainsKey(object p1)
        {
            return M_Dictionary.ContainsKey(p1);
        }

        public bool ContainsValue(object p1)
        {
            return M_Dictionary.ContainsValue(p1);
        }

        public IEnumerator GetEnumerator()
        {
            Enumerator = M_Dictionary.GetEnumerator();
            return (System.Collections.IEnumerator)this;
        }

        public bool MoveNext()
        {
            return Enumerator.MoveNext();
        }

        public void Remove(object key)
        {
            M_Dictionary.Remove(key);
        }

        public void Set(object key, object value)
        {
            M_Dictionary[key] = value;
        }

        public ArrayImpl Values
        {
            get
            {
                Dictionary<object, object> Dictionary1 = M_Dictionary;
                ArrayImpl array = new ArrayImpl();
                ICollection Values1 = Dictionary1.Values;
                foreach (dynamic val1 in Values1)
                {
                    array.Add(val1);
                }
                return array;
            }
        }

        public ArrayImpl Keys
        {
            get
            {
                Dictionary<object, object> Dictionary1 = M_Dictionary;
                ArrayImpl array = new ArrayImpl();
                ICollection Keys1 = Dictionary1.Keys;
                foreach (dynamic key1 in Keys1)
                {
                    array.Add(key1);
                }
                return array;
            }
        }
    }

    [ContextClass("ИфСловарь", "GfDictionary")]
    public class GfDictionary : AutoContext<GfDictionary>, ICollectionContext<IValue>, IEnumerable<IValue>
    {
        public System.Collections.IEnumerator Enumerator;
        public osgf.Dictionary Base_obj;

        public GfDictionary()
        {
            Dictionary Dictionary1 = new Dictionary();
            Dictionary1.dll_obj = this;
            Base_obj = Dictionary1;
        }

        public int Count(IBslProcess p1 = null)
        {
            return Base_obj.M_Dictionary.Count;
        }

        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
        {
            foreach (KeyValuePair<object, object> item in Base_obj.M_Dictionary)
            {
                IValue keyIV = (IValue)item.Key;
                IValue valueIV = (IValue)item.Value;
                GfEntry entry = new GfEntry(keyIV, valueIV);
                yield return entry;
            }
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        public IEnumerator GetEnumerator()
        {
            Enumerator = Base_obj.M_Dictionary.GetEnumerator();
            return (System.Collections.IEnumerator)this;
        }

        [ContextProperty("Значения", "Values")]
        public ArrayImpl Values
        {
            get { return Base_obj.Values; }
        }

        [ContextProperty("Ключи", "Keys")]
        public ArrayImpl Keys
        {
            get { return Base_obj.Keys; }
        }

        [ContextProperty("Количество", "Count")]
        public int CountProp
        {
            get { return Base_obj.Count; }
        }

        [ContextMethod("Добавить", "Add")]
        public void Add(IValue p1, IValue p2)
        {
            Base_obj.Add(OsUtils.DefineTypeIValue(p1), OsUtils.DefineTypeIValue(p2));
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
        }

        [ContextMethod("Получить", "Get")]
        public IValue Get(IValue p1)
        {
            return Base_obj.get_Item(OsUtils.DefineTypeIValue(p1));
        }

        [ContextMethod("СодержитЗначение", "ContainsValue")]
        public bool ContainsValue(IValue p1)
        {
            return Base_obj.ContainsValue(OsUtils.DefineTypeIValue(p1));
        }

        [ContextMethod("СодержитКлюч", "ContainsKey")]
        public bool ContainsKey(IValue p1)
        {
            return Base_obj.ContainsKey(OsUtils.DefineTypeIValue(p1));
        }

        [ContextMethod("Удалить", "Remove")]
        public void Remove(IValue p1)
        {
            Base_obj.Remove(OsUtils.DefineTypeIValue(p1));
        }

        [ContextMethod("Установить", "Set")]
        public void Set(IValue p1, IValue p2)
        {
            Base_obj.Set(OsUtils.DefineTypeIValue(p1), OsUtils.DefineTypeIValue(p2));
        }
    }
}
