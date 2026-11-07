using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    public class StyleBoxEmpty : osgf.StyleBox
    {
        public GfStyleBoxEmpty dll_obj;
        private osgf.StyleBox m_StyleBoxEmpty;

        public osgf.StyleBox M_StyleBoxEmpty
        {
            get { return m_StyleBoxEmpty; }
            set
            {
                m_StyleBoxEmpty = value;
                base.M_StyleBox = m_StyleBoxEmpty;
            }
        }

        public StyleBoxEmpty()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "StyleBoxEmpty";
        }

        public StyleBoxEmpty(string p1)
        {
            ItemKey = p1;
            GameForms.dictKeyEl.TryAdd(ItemKey, this);
            GameForms.dictElKey.TryAdd(this, ItemKey);
            ResourceName = "StyleBoxEmpty";
        }
    }

    [ContextClass("ИфСтильПанелиПусто", "GfStyleBoxEmpty")]
    public class GfStyleBoxEmpty : AutoContext<GfStyleBoxEmpty>
    {
        public osgf.StyleBoxEmpty Base_obj;

        public GfStyleBoxEmpty()
        {
            StyleBoxEmpty StyleBoxEmpty1 = new StyleBoxEmpty();
            StyleBoxEmpty1.dll_obj = this;
            Base_obj = StyleBoxEmpty1;
        }

        public GfStyleBoxEmpty(string p1)
        {
            StyleBoxEmpty StyleBoxEmpty1 = new StyleBoxEmpty(p1);
            StyleBoxEmpty1.dll_obj = this;
            Base_obj = StyleBoxEmpty1;
        }

        [ContextProperty("ИмяРесурса", "ResourceName")]
        public string ResourceName
        {
            get { return Base_obj.ResourceName; }
        }

        [ContextProperty("КлючЭлемента", "ItemKey")]
        public string ItemKey
        {
            get { return Base_obj.ItemKey; }
        }

        [ContextProperty("Метка", "Tag")]
        public IValue Tag
        {
            get { return Base_obj.Tag; }
            set { Base_obj.Tag = value; }
        }

        [ContextProperty("ОтступСверху", "ContentMarginTop")]
        public decimal ContentMarginTop
        {
            get { return Base_obj.ContentMarginTop; }
            set { Base_obj.ContentMarginTop = value; }
        }

        [ContextProperty("ОтступСлева", "ContentMarginLeft")]
        public decimal ContentMarginLeft
        {
            get { return Base_obj.ContentMarginLeft; }
            set { Base_obj.ContentMarginLeft = value; }
        }

        [ContextProperty("ОтступСнизу", "ContentMarginBottom")]
        public decimal ContentMarginBottom
        {
            get { return Base_obj.ContentMarginBottom; }
            set { Base_obj.ContentMarginBottom = value; }
        }

        [ContextProperty("ОтступСправа", "ContentMarginRight")]
        public decimal ContentMarginRight
        {
            get { return Base_obj.ContentMarginRight; }
            set { Base_obj.ContentMarginRight = value; }
        }

        [ContextProperty("ПутьРесурса", "ResourcePath")]
        public string ResourcePath
        {
            get { return Base_obj.ResourcePath; }
            set { Base_obj.ResourcePath = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfStyleBoxEmpty" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("Дублировать", "Duplicate")]
        public IValue Duplicate()
        {
            return Base_obj.Duplicate();
        }

        [ContextMethod("Сохранить", "Save")]
        public void Save(string path)
        {
            Base_obj.Save(path);
        }
    }
}
