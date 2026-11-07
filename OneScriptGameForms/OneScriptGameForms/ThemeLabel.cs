using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class ThemeLabel : osgf.Theme
    {
        public GfThemeLabel dll_obj;
        private osgf.Theme m_ThemeLabel;

        public osgf.Theme M_ThemeLabel
        {
            get { return m_ThemeLabel; }
            set
            {
                m_ThemeLabel = value;
                base.M_Theme = m_ThemeLabel;
            }
        }

        public ThemeLabel()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "ThemeLabel";
        }

        public int ParagraphSpacing
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int LineSpacing
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue Focus
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int OutlineSize
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int ShadowOutlineSize
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int FontSize
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int ShadowOffsetY
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int ShadowOffsetX
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue Normal
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor FontOutlineColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor FontShadowColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor FontColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue Font
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфТемаНадпись", "GfThemeLabel")]
    public class GfThemeLabel : AutoContext<GfThemeLabel>
    {
        public osgf.ThemeLabel Base_obj;

        public GfThemeLabel()
        {
            ThemeLabel ThemeLabel1 = new ThemeLabel();
            ThemeLabel1.dll_obj = this;
            Base_obj = ThemeLabel1;
        }

        [ContextProperty("ИмяРесурса", "ResourceName")]
        public string ResourceName
        {
            get { return Base_obj.ResourceName; }
        }

        [ContextProperty("ИнтервалАбзаца", "ParagraphSpacing")]
        public int ParagraphSpacing
        {
            get { return Base_obj.ParagraphSpacing; }
            set { Base_obj.ParagraphSpacing = value; }
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

        [ContextProperty("МежстрочныйИнтервал", "LineSpacing")]
        public int LineSpacing
        {
            get { return Base_obj.LineSpacing; }
            set { Base_obj.LineSpacing = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public IValue Tag
        {
            get { return Base_obj.Tag; }
            set { Base_obj.Tag = value; }
        }

        [ContextProperty("ПриФокусировке", "Focus")]
        public IValue Focus
        {
            get { return Base_obj.Focus; }
            set { Base_obj.Focus = value; }
        }

        [ContextProperty("ПутьРесурса", "ResourcePath")]
        public string ResourcePath
        {
            get { return Base_obj.ResourcePath; }
            set { Base_obj.ResourcePath = value; }
        }

        [ContextProperty("РазмерКонтура", "OutlineSize")]
        public int OutlineSize
        {
            get { return Base_obj.OutlineSize; }
            set { Base_obj.OutlineSize = value; }
        }

        [ContextProperty("РазмерКонтураТени", "ShadowOutlineSize")]
        public int ShadowOutlineSize
        {
            get { return Base_obj.ShadowOutlineSize; }
            set { Base_obj.ShadowOutlineSize = value; }
        }

        [ContextProperty("РазмерШрифта", "FontSize")]
        public int FontSize
        {
            get { return Base_obj.FontSize; }
            set { Base_obj.FontSize = value; }
        }

        [ContextProperty("РазмерШрифтаПоУмолчанию", "DefaultFontSize")]
        public int DefaultFontSize
        {
            get { return Base_obj.DefaultFontSize; }
            set { Base_obj.DefaultFontSize = value; }
        }

        [ContextProperty("СмещениеТениИгрек", "ShadowOffsetY")]
        public int ShadowOffsetY
        {
            get { return Base_obj.ShadowOffsetY; }
            set { Base_obj.ShadowOffsetY = value; }
        }

        [ContextProperty("СмещениеТениИкс", "ShadowOffsetX")]
        public int ShadowOffsetX
        {
            get { return Base_obj.ShadowOffsetX; }
            set { Base_obj.ShadowOffsetX = value; }
        }

        [ContextProperty("Стандартное", "Normal")]
        public IValue Normal
        {
            get { return Base_obj.Normal; }
            set { Base_obj.Normal = value; }
        }

        [ContextProperty("ЦветКонтураШрифта", "FontOutlineColor")]
        public GfColor FontOutlineColor
        {
            get { return Base_obj.FontOutlineColor; }
            set { Base_obj.FontOutlineColor = value; }
        }

        [ContextProperty("ЦветТениШрифта", "FontShadowColor")]
        public GfColor FontShadowColor
        {
            get { return Base_obj.FontShadowColor; }
            set { Base_obj.FontShadowColor = value; }
        }

        [ContextProperty("ЦветШрифта", "FontColor")]
        public GfColor FontColor
        {
            get { return Base_obj.FontColor; }
            set { Base_obj.FontColor = value; }
        }

        [ContextProperty("Шрифт", "Font")]
        public IValue Font
        {
            get { return Base_obj.Font; }
            set { Base_obj.Font = value; }
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
            return new GfString("GfThemeLabel" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
