using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class StyleBoxLine : osgf.StyleBox
    {
        public GfStyleBoxLine dll_obj;
        private osgf.StyleBox m_StyleBoxLine;

        public osgf.StyleBox M_StyleBoxLine
        {
            get { return m_StyleBoxLine; }
            set
            {
                m_StyleBoxLine = value;
                base.M_StyleBox = m_StyleBoxLine;
            }
        }

        public StyleBoxLine()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "StyleBoxLine";
        }

        public StyleBoxLine(string p1)
        {
            ItemKey = p1;
            GameForms.dictKeyEl.TryAdd(ItemKey, this);
            GameForms.dictElKey.TryAdd(this, ItemKey);
            ResourceName = "StyleBoxLine";
        }

        public bool Vertical
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal GrowEnd
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal GrowBegin
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal Thickness
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor Color
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфСтильПанелиЛиния", "GfStyleBoxLine")]
    public class GfStyleBoxLine : AutoContext<GfStyleBoxLine>
    {
        public osgf.StyleBoxLine Base_obj;

        public GfStyleBoxLine()
        {
            StyleBoxLine StyleBoxLine1 = new StyleBoxLine();
            StyleBoxLine1.dll_obj = this;
            Base_obj = StyleBoxLine1;
        }

        public GfStyleBoxLine(string p1 = null)
        {
            StyleBoxLine StyleBoxLine1 = new StyleBoxLine(p1);
            StyleBoxLine1.dll_obj = this;
            Base_obj = StyleBoxLine1;
        }

        [ContextProperty("Вертикально", "Vertical")]
        public bool Vertical
        {
            get { return Base_obj.Vertical; }
            set { Base_obj.Vertical = value; }
        }

        [ContextProperty("ВесКонец", "GrowEnd")]
        public decimal GrowEnd
        {
            get { return Base_obj.GrowEnd; }
            set { Base_obj.GrowEnd = value; }
        }

        [ContextProperty("ВесНачало", "GrowBegin")]
        public decimal GrowBegin
        {
            get { return Base_obj.GrowBegin; }
            set { Base_obj.GrowBegin = value; }
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

        [ContextProperty("Толщина", "Thickness")]
        public decimal Thickness
        {
            get { return Base_obj.Thickness; }
            set { Base_obj.Thickness = value; }
        }

        [ContextProperty("Цвет", "Color")]
        public GfColor Color
        {
            get { return Base_obj.Color; }
            set { Base_obj.Color = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfStyleBoxLine" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
