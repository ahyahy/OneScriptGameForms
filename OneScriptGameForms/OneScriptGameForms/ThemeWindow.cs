using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class ThemeWindow : osgf.Theme
    {
        public GfThemeWindow dll_obj;
        private osgf.Theme m_ThemeWindow;

        public osgf.Theme M_ThemeWindow
        {
            get { return m_ThemeWindow; }
            set
            {
                m_ThemeWindow = value;
                base.M_Theme = m_ThemeWindow;
            }
        }

        public ThemeWindow()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "ThemeWindow";
        }

        public IValue EmbeddedBorder
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue EmbeddedUnfocusedBorder
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int TitleHeight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue Close
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue ClosePressed
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int TitleOutlineSize
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int TitleFontSize
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int ResizeMargin
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int CloseVOffset
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int CloseHOffset
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor TitleColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor TitleOutlineModulate
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue TitleFont
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфТемаОкно", "GfThemeWindow")]
    public class GfThemeWindow : AutoContext<GfThemeWindow>
    {
        public osgf.ThemeWindow Base_obj;

        public GfThemeWindow()
        {
            ThemeWindow ThemeWindow1 = new ThemeWindow();
            ThemeWindow1.dll_obj = this;
            Base_obj = ThemeWindow1;
        }

        [ContextProperty("ВнедреннаяГраница", "EmbeddedBorder")]
        public IValue EmbeddedBorder
        {
            get { return Base_obj.EmbeddedBorder; }
            set { Base_obj.EmbeddedBorder = value; }
        }

        [ContextProperty("ВнедреннаяНеСфокусированнаяГраница", "EmbeddedUnfocusedBorder")]
        public IValue EmbeddedUnfocusedBorder
        {
            get { return Base_obj.EmbeddedUnfocusedBorder; }
            set { Base_obj.EmbeddedUnfocusedBorder = value; }
        }

        [ContextProperty("ВысотаЗаголовка", "TitleHeight")]
        public int TitleHeight
        {
            get { return Base_obj.TitleHeight; }
            set { Base_obj.TitleHeight = value; }
        }

        [ContextProperty("ЗначокЗакрытия", "Close")]
        public IValue Close
        {
            get { return Base_obj.Close; }
            set { Base_obj.Close = value; }
        }

        [ContextProperty("ЗначокЗакрытияПриНажатии", "ClosePressed")]
        public IValue ClosePressed
        {
            get { return Base_obj.ClosePressed; }
            set { Base_obj.ClosePressed = value; }
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

        [ContextProperty("РазмерКонтураЗаголовка", "TitleOutlineSize")]
        public int TitleOutlineSize
        {
            get { return Base_obj.TitleOutlineSize; }
            set { Base_obj.TitleOutlineSize = value; }
        }

        [ContextProperty("РазмерШрифтаЗаголовка", "TitleFontSize")]
        public int TitleFontSize
        {
            get { return Base_obj.TitleFontSize; }
            set { Base_obj.TitleFontSize = value; }
        }

        [ContextProperty("РазмерШрифтаПоУмолчанию", "DefaultFontSize")]
        public int DefaultFontSize
        {
            get { return Base_obj.DefaultFontSize; }
            set { Base_obj.DefaultFontSize = value; }
        }

        [ContextProperty("СмещениеЗахвата", "ResizeMargin")]
        public int ResizeMargin
        {
            get { return Base_obj.ResizeMargin; }
            set { Base_obj.ResizeMargin = value; }
        }

        [ContextProperty("СмещениеКнопкиЗакрытияИгрек", "CloseVOffset")]
        public int CloseVOffset
        {
            get { return Base_obj.CloseVOffset; }
            set { Base_obj.CloseVOffset = value; }
        }

        [ContextProperty("СмещениеКнопкиЗакрытияИкс", "CloseHOffset")]
        public int CloseHOffset
        {
            get { return Base_obj.CloseHOffset; }
            set { Base_obj.CloseHOffset = value; }
        }

        [ContextProperty("ЦветЗаголовка", "TitleColor")]
        public GfColor TitleColor
        {
            get { return Base_obj.TitleColor; }
            set { Base_obj.TitleColor = value; }
        }

        [ContextProperty("ЦветКонтураЗаголовка", "TitleOutlineModulate")]
        public GfColor TitleOutlineModulate
        {
            get { return Base_obj.TitleOutlineModulate; }
            set { Base_obj.TitleOutlineModulate = value; }
        }

        [ContextProperty("ШрифтЗаголовка", "TitleFont")]
        public IValue TitleFont
        {
            get { return Base_obj.TitleFont; }
            set { Base_obj.TitleFont = value; }
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
            return new GfString("GfThemeWindow" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
