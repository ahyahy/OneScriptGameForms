using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class ThemePanelContainer : osgf.Theme
    {
        public GfThemePanelContainer dll_obj;
        private osgf.Theme m_ThemePanelContainer;

        public osgf.Theme M_ThemePanelContainer
        {
            get { return m_ThemePanelContainer; }
            set
            {
                m_ThemePanelContainer = value;
                base.M_Theme = m_ThemePanelContainer;
            }
        }

        public ThemePanelContainer()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "ThemePanelContainer";
        }

        public IValue Panel
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфТемаПанельныйКонтейнер", "GfThemePanelContainer")]
    public class GfThemePanelContainer : AutoContext<GfThemePanelContainer>
    {
        public osgf.ThemePanelContainer Base_obj;

        public GfThemePanelContainer()
        {
            ThemePanelContainer ThemePanelContainer1 = new ThemePanelContainer();
            ThemePanelContainer1.dll_obj = this;
            Base_obj = ThemePanelContainer1;
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

        [ContextProperty("МасштабПоУмолчанию", "DefaultBaseScale")]
        public decimal DefaultBaseScale
        {
            get { return Base_obj.DefaultBaseScale; }
            set { Base_obj.DefaultBaseScale = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public IValue Tag
        {
            get { return Base_obj.Tag; }
            set { Base_obj.Tag = value; }
        }

        [ContextProperty("Панель", "Panel")]
        public IValue Panel
        {
            get { return Base_obj.Panel; }
            set { Base_obj.Panel = value; }
        }

        [ContextProperty("ПутьРесурса", "ResourcePath")]
        public string ResourcePath
        {
            get { return Base_obj.ResourcePath; }
            set { Base_obj.ResourcePath = value; }
        }

        [ContextProperty("РазмерШрифтаПоУмолчанию", "DefaultFontSize")]
        public int DefaultFontSize
        {
            get { return Base_obj.DefaultFontSize; }
            set { Base_obj.DefaultFontSize = value; }
        }

        [ContextProperty("ШрифтПоУмолчанию", "DefaultFont")]
        public IValue DefaultFont
        {
            get { return Base_obj.DefaultFont; }
            set { Base_obj.DefaultFont = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfThemePanelContainer" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("Дублировать", "Duplicate")]
        public IValue Duplicate()
        {
            return Base_obj.Duplicate();
        }

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.ClearTheme();
        }

        [ContextMethod("Сохранить", "Save")]
        public void Save(string path)
        {
            Base_obj.Save(path);
        }
    }
}
