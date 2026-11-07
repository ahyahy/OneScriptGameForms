using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class ThemeButton : osgf.Theme
    {
        public GfThemeButton dll_obj;
        private osgf.Theme m_ThemeButton;

        public osgf.Theme M_ThemeButton
        {
            get { return m_ThemeButton; }
            set
            {
                m_ThemeButton = value;
                base.M_Theme = m_ThemeButton;
            }
        }

        public ThemeButton()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "ThemeButton";
        }

        public int AlignToLargestStylebox
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int HSeparation
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfImageTexture Icon
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int IconMaxWidth
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int LineSpacing
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue Hover
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue HoverMirrored
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue HoverPressed
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue HoverPressedMirrored
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue Pressed
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue PressedMirrored
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue Disabled
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue DisabledMirrored
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
        public int FontSize
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue Normal
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue NormalMirrored
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor IconHoverColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor IconHoverPressedColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor IconPressedColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor IconDisabledColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor IconFocusColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor IconNormalColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor FontOutlineColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor FontColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor FontHoverColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor FontHoverPressedColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor FontPressedColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor FontDisabledColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor FontFocusColor
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

    [ContextClass("ИфТемаКнопка", "GfThemeButton")]
    public class GfThemeButton : AutoContext<GfThemeButton>
    {
        public osgf.ThemeButton Base_obj;

        public GfThemeButton()
        {
            ThemeButton ThemeButton1 = new ThemeButton();
            ThemeButton1.dll_obj = this;
            Base_obj = ThemeButton1;
        }

        [ContextProperty("ВыровнятьПоНаибольшимПолям", "AlignToLargestStylebox")]
        public int AlignToLargestStylebox
        {
            get { return Base_obj.AlignToLargestStylebox; }
            set { Base_obj.AlignToLargestStylebox = value; }
        }

        [ContextProperty("ГоризонтальноеРазделение", "HSeparation")]
        public int HSeparation
        {
            get { return Base_obj.HSeparation; }
            set { Base_obj.HSeparation = value; }
        }

        [ContextProperty("Значок", "Icon")]
        public GfImageTexture Icon
        {
            get { return Base_obj.Icon; }
            set { Base_obj.Icon = value; }
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

        [ContextProperty("МаксимальнаяШиринаЗначка", "IconMaxWidth")]
        public int IconMaxWidth
        {
            get { return Base_obj.IconMaxWidth; }
            set { Base_obj.IconMaxWidth = value; }
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

        [ContextProperty("ПриНаведении", "Hover")]
        public IValue Hover
        {
            get { return Base_obj.Hover; }
            set { Base_obj.Hover = value; }
        }

        [ContextProperty("ПриНаведенииЗеркальное", "HoverMirrored")]
        public IValue HoverMirrored
        {
            get { return Base_obj.HoverMirrored; }
            set { Base_obj.HoverMirrored = value; }
        }

        [ContextProperty("ПриНаведенииПриНажатии", "HoverPressed")]
        public IValue HoverPressed
        {
            get { return Base_obj.HoverPressed; }
            set { Base_obj.HoverPressed = value; }
        }

        [ContextProperty("ПриНаведенииПриНажатииЗеркальное", "HoverPressedMirrored")]
        public IValue HoverPressedMirrored
        {
            get { return Base_obj.HoverPressedMirrored; }
            set { Base_obj.HoverPressedMirrored = value; }
        }

        [ContextProperty("ПриНажатии", "Pressed")]
        public IValue Pressed
        {
            get { return Base_obj.Pressed; }
            set { Base_obj.Pressed = value; }
        }

        [ContextProperty("ПриНажатииЗеркальное", "PressedMirrored")]
        public IValue PressedMirrored
        {
            get { return Base_obj.PressedMirrored; }
            set { Base_obj.PressedMirrored = value; }
        }

        [ContextProperty("ПриОтключении", "Disabled")]
        public IValue Disabled
        {
            get { return Base_obj.Disabled; }
            set { Base_obj.Disabled = value; }
        }

        [ContextProperty("ПриОтключенииЗеркальное", "DisabledMirrored")]
        public IValue DisabledMirrored
        {
            get { return Base_obj.DisabledMirrored; }
            set { Base_obj.DisabledMirrored = value; }
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

        [ContextProperty("Стандартное", "Normal")]
        public IValue Normal
        {
            get { return Base_obj.Normal; }
            set { Base_obj.Normal = value; }
        }

        [ContextProperty("СтандартноеЗеркальное", "NormalMirrored")]
        public IValue NormalMirrored
        {
            get { return Base_obj.NormalMirrored; }
            set { Base_obj.NormalMirrored = value; }
        }

        [ContextProperty("ЦветЗначкаПриНаведении", "IconHoverColor")]
        public GfColor IconHoverColor
        {
            get { return Base_obj.IconHoverColor; }
            set { Base_obj.IconHoverColor = value; }
        }

        [ContextProperty("ЦветЗначкаПриНаведенииПриНажатии", "IconHoverPressedColor")]
        public GfColor IconHoverPressedColor
        {
            get { return Base_obj.IconHoverPressedColor; }
            set { Base_obj.IconHoverPressedColor = value; }
        }

        [ContextProperty("ЦветЗначкаПриНажатии", "IconPressedColor")]
        public GfColor IconPressedColor
        {
            get { return Base_obj.IconPressedColor; }
            set { Base_obj.IconPressedColor = value; }
        }

        [ContextProperty("ЦветЗначкаПриОтключении", "IconDisabledColor")]
        public GfColor IconDisabledColor
        {
            get { return Base_obj.IconDisabledColor; }
            set { Base_obj.IconDisabledColor = value; }
        }

        [ContextProperty("ЦветЗначкаПриФокусировке", "IconFocusColor")]
        public GfColor IconFocusColor
        {
            get { return Base_obj.IconFocusColor; }
            set { Base_obj.IconFocusColor = value; }
        }

        [ContextProperty("ЦветЗначкаСтандартное", "IconNormalColor")]
        public GfColor IconNormalColor
        {
            get { return Base_obj.IconNormalColor; }
            set { Base_obj.IconNormalColor = value; }
        }

        [ContextProperty("ЦветКонтураШрифта", "FontOutlineColor")]
        public GfColor FontOutlineColor
        {
            get { return Base_obj.FontOutlineColor; }
            set { Base_obj.FontOutlineColor = value; }
        }

        [ContextProperty("ЦветШрифта", "FontColor")]
        public GfColor FontColor
        {
            get { return Base_obj.FontColor; }
            set { Base_obj.FontColor = value; }
        }

        [ContextProperty("ЦветШрифтаПриНаведении", "FontHoverColor")]
        public GfColor FontHoverColor
        {
            get { return Base_obj.FontHoverColor; }
            set { Base_obj.FontHoverColor = value; }
        }

        [ContextProperty("ЦветШрифтаПриНаведенииПриНажатии", "FontHoverPressedColor")]
        public GfColor FontHoverPressedColor
        {
            get { return Base_obj.FontHoverPressedColor; }
            set { Base_obj.FontHoverPressedColor = value; }
        }

        [ContextProperty("ЦветШрифтаПриНажатии", "FontPressedColor")]
        public GfColor FontPressedColor
        {
            get { return Base_obj.FontPressedColor; }
            set { Base_obj.FontPressedColor = value; }
        }

        [ContextProperty("ЦветШрифтаПриОтключении", "FontDisabledColor")]
        public GfColor FontDisabledColor
        {
            get { return Base_obj.FontDisabledColor; }
            set { Base_obj.FontDisabledColor = value; }
        }

        [ContextProperty("ЦветШрифтаПриФокусировке", "FontFocusColor")]
        public GfColor FontFocusColor
        {
            get { return Base_obj.FontFocusColor; }
            set { Base_obj.FontFocusColor = value; }
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
            return new GfString("GfThemeButton" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
