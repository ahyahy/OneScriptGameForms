using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class ThemeVBoxContainer : osgf.Theme
    {
        public GfThemeVBoxContainer dll_obj;
        private osgf.Theme m_ThemeVBoxContainer;

        public osgf.Theme M_ThemeVBoxContainer
        {
            get { return m_ThemeVBoxContainer; }
            set
            {
                m_ThemeVBoxContainer = value;
                base.M_Theme = m_ThemeVBoxContainer;
            }
        }

        public ThemeVBoxContainer()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "ThemeVBoxContainer";
        }

        public int Separation
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфТемаВертикальнаяГруппа", "GfThemeVBoxContainer")]
    public class GfThemeVBoxContainer : AutoContext<GfThemeVBoxContainer>
    {
        public osgf.ThemeVBoxContainer Base_obj;

        public GfThemeVBoxContainer()
        {
            ThemeVBoxContainer ThemeVBoxContainer1 = new ThemeVBoxContainer();
            ThemeVBoxContainer1.dll_obj = this;
            Base_obj = ThemeVBoxContainer1;
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

        [ContextProperty("ПутьРесурса", "ResourcePath")]
        public string ResourcePath
        {
            get { return Base_obj.ResourcePath; }
            set { Base_obj.ResourcePath = value; }
        }

        [ContextProperty("Разделение", "Separation")]
        public int Separation
        {
            get { return Base_obj.Separation; }
            set { Base_obj.Separation = value; }
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
            return new GfString("GfThemeVBoxContainer" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
