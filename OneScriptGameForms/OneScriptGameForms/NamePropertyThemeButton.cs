using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфИмяСвойстваТемыКнопка", "GfNamePropertyThemeButton")]
    public class GfNamePropertyThemeButton : AutoContext<GfNamePropertyThemeButton>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfNamePropertyThemeButton()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("ВыровнятьПоНаибольшимПолям"),
                ValueFactory.Create("ПриОтключении"),
                ValueFactory.Create("ПриОтключенииЗеркальное"),
                ValueFactory.Create("ПриФокусировке"),
                ValueFactory.Create("Шрифт"),
                ValueFactory.Create("ЦветШрифта"),
                ValueFactory.Create("ЦветШрифтаПриОтключении"),
                ValueFactory.Create("ЦветШрифтаПриФокусировке"),
                ValueFactory.Create("ЦветШрифтаПриНаведении"),
                ValueFactory.Create("ЦветШрифтаПриНаведенииПриНажатии"),
                ValueFactory.Create("ЦветКонтураШрифта"),
                ValueFactory.Create("ЦветШрифтаПриНажатии"),
                ValueFactory.Create("РазмерШрифта"),
                ValueFactory.Create("ГоризонтальноеРазделение"),
                ValueFactory.Create("ПриНаведении"),
                ValueFactory.Create("ПриНаведенииЗеркальное"),
                ValueFactory.Create("ПриНаведенииПриНажатии"),
                ValueFactory.Create("ПриНаведенииПриНажатииЗеркальное"),
                ValueFactory.Create("Значок"),
                ValueFactory.Create("ЦветЗначкаПриОтключении"),
                ValueFactory.Create("ЦветЗначкаПриФокусировке"),
                ValueFactory.Create("ЦветЗначкаПриНаведении"),
                ValueFactory.Create("ЦветЗначкаПриНаведенииПриНажатии"),
                ValueFactory.Create("МаксимальнаяШиринаЗначка"),
                ValueFactory.Create("ЦветЗначкаСтандартное"),
                ValueFactory.Create("ЦветЗначкаПриНажатии"),
                ValueFactory.Create("МежстрочныйИнтервал"),
                ValueFactory.Create("Стандартное"),
                ValueFactory.Create("СтандартноеЗеркальное"),
                ValueFactory.Create("РазмерКонтура"),
                ValueFactory.Create("ПриНажатии"),
                ValueFactory.Create("ПриНажатииЗеркальное")
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
                "align_to_largest_stylebox:Button" => "ВыровнятьПоНаибольшимПолям",
                "disabled:Button" => "ПриОтключении",
                "disabled_mirrored:Button" => "ПриОтключенииЗеркальное",
                "focus:Button" => "ПриФокусировке",
                "font:Button" => "Шрифт",
                "font_color:Button" => "ЦветШрифта",
                "font_disabled_color:Button" => "ЦветШрифтаПриОтключении",
                "font_focus_color:Button" => "ЦветШрифтаПриФокусировке",
                "font_hover_color:Button" => "ЦветШрифтаПриНаведении",
                "font_hover_pressed_color:Button" => "ЦветШрифтаПриНаведенииПриНажатии",
                "font_outline_color:Button" => "ЦветКонтураШрифта",
                "font_pressed_color:Button" => "ЦветШрифтаПриНажатии",
                "font_size:Button" => "РазмерШрифта",
                "h_separation:Button" => "ГоризонтальноеРазделение",
                "hover:Button" => "ПриНаведении",
                "hover_mirrored:Button" => "ПриНаведенииЗеркальное",
                "hover_pressed:Button" => "ПриНаведенииПриНажатии",
                "hover_pressed_mirrored:Button" => "ПриНаведенииПриНажатииЗеркальное",
                "icon:Button" => "Значок",
                "icon_disabled_color:Button" => "ЦветЗначкаПриОтключении",
                "icon_focus_color:Button" => "ЦветЗначкаПриФокусировке",
                "icon_hover_color:Button" => "ЦветЗначкаПриНаведении",
                "icon_hover_pressed_color:Button" => "ЦветЗначкаПриНаведенииПриНажатии",
                "icon_max_width:Button" => "МаксимальнаяШиринаЗначка",
                "icon_normal_color:Button" => "ЦветЗначкаСтандартное",
                "icon_pressed_color:Button" => "ЦветЗначкаПриНажатии",
                "line_spacing:Button" => "МежстрочныйИнтервал",
                "normal:Button" => "Стандартное",
                "normal_mirrored:Button" => "СтандартноеЗеркальное",
                "outline_size:Button" => "РазмерКонтура",
                "pressed:Button" => "ПриНажатии",
                "pressed_mirrored:Button" => "ПриНажатииЗеркальное",
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
                "align_to_largest_stylebox:Button" => "AlignToLargestStylebox",
                "disabled:Button" => "Disabled",
                "disabled_mirrored:Button" => "DisabledMirrored",
                "focus:Button" => "Focus",
                "font:Button" => "Font",
                "font_color:Button" => "FontColor",
                "font_disabled_color:Button" => "FontDisabledColor",
                "font_focus_color:Button" => "FontFocusColor",
                "font_hover_color:Button" => "FontHoverColor",
                "font_hover_pressed_color:Button" => "FontHoverPressedColor",
                "font_outline_color:Button" => "FontOutlineColor",
                "font_pressed_color:Button" => "FontPressedColor",
                "font_size:Button" => "FontSize",
                "h_separation:Button" => "HSeparation",
                "hover:Button" => "Hover",
                "hover_mirrored:Button" => "HoverMirrored",
                "hover_pressed:Button" => "HoverPressed",
                "hover_pressed_mirrored:Button" => "HoverPressedMirrored",
                "icon:Button" => "Icon",
                "icon_disabled_color:Button" => "IconDisabledColor",
                "icon_focus_color:Button" => "IconFocusColor",
                "icon_hover_color:Button" => "IconHoverColor",
                "icon_hover_pressed_color:Button" => "IconHoverPressedColor",
                "icon_max_width:Button" => "IconMaxWidth",
                "icon_normal_color:Button" => "IconNormalColor",
                "icon_pressed_color:Button" => "IconPressedColor",
                "line_spacing:Button" => "LineSpacing",
                "normal:Button" => "Normal",
                "normal_mirrored:Button" => "NormalMirrored",
                "outline_size:Button" => "OutlineSize",
                "pressed:Button" => "Pressed",
                "pressed_mirrored:Button" => "PressedMirrored",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("ВыровнятьПоНаибольшимПолям", "AlignToLargestStylebox")]
        public string AlignToLargestStylebox
        {
            get { return "align_to_largest_stylebox:Button"; }
        }

        [ContextProperty("ГоризонтальноеРазделение", "HSeparation")]
        public string HSeparation
        {
            get { return "h_separation:Button"; }
        }

        [ContextProperty("Значок", "Icon")]
        public string Icon
        {
            get { return "icon:Button"; }
        }

        [ContextProperty("МаксимальнаяШиринаЗначка", "IconMaxWidth")]
        public string IconMaxWidth
        {
            get { return "icon_max_width:Button"; }
        }

        [ContextProperty("МежстрочныйИнтервал", "LineSpacing")]
        public string LineSpacing
        {
            get { return "line_spacing:Button"; }
        }

        [ContextProperty("ПриНаведении", "Hover")]
        public string Hover
        {
            get { return "hover:Button"; }
        }

        [ContextProperty("ПриНаведенииЗеркальное", "HoverMirrored")]
        public string HoverMirrored
        {
            get { return "hover_mirrored:Button"; }
        }

        [ContextProperty("ПриНаведенииПриНажатии", "HoverPressed")]
        public string HoverPressed
        {
            get { return "hover_pressed:Button"; }
        }

        [ContextProperty("ПриНаведенииПриНажатииЗеркальное", "HoverPressedMirrored")]
        public string HoverPressedMirrored
        {
            get { return "hover_pressed_mirrored:Button"; }
        }

        [ContextProperty("ПриНажатии", "Pressed")]
        public string Pressed
        {
            get { return "pressed:Button"; }
        }

        [ContextProperty("ПриНажатииЗеркальное", "PressedMirrored")]
        public string PressedMirrored
        {
            get { return "pressed_mirrored:Button"; }
        }

        [ContextProperty("ПриОтключении", "Disabled")]
        public string Disabled
        {
            get { return "disabled:Button"; }
        }

        [ContextProperty("ПриОтключенииЗеркальное", "DisabledMirrored")]
        public string DisabledMirrored
        {
            get { return "disabled_mirrored:Button"; }
        }

        [ContextProperty("ПриФокусировке", "Focus")]
        public string Focus
        {
            get { return "focus:Button"; }
        }

        [ContextProperty("РазмерКонтура", "OutlineSize")]
        public string OutlineSize
        {
            get { return "outline_size:Button"; }
        }

        [ContextProperty("РазмерШрифта", "FontSize")]
        public string FontSize
        {
            get { return "font_size:Button"; }
        }

        [ContextProperty("Стандартное", "Normal")]
        public string Normal
        {
            get { return "normal:Button"; }
        }

        [ContextProperty("СтандартноеЗеркальное", "NormalMirrored")]
        public string NormalMirrored
        {
            get { return "normal_mirrored:Button"; }
        }

        [ContextProperty("ЦветЗначкаПриНаведении", "IconHoverColor")]
        public string IconHoverColor
        {
            get { return "icon_hover_color:Button"; }
        }

        [ContextProperty("ЦветЗначкаПриНаведенииПриНажатии", "IconHoverPressedColor")]
        public string IconHoverPressedColor
        {
            get { return "icon_hover_pressed_color:Button"; }
        }

        [ContextProperty("ЦветЗначкаПриНажатии", "IconPressedColor")]
        public string IconPressedColor
        {
            get { return "icon_pressed_color:Button"; }
        }

        [ContextProperty("ЦветЗначкаПриОтключении", "IconDisabledColor")]
        public string IconDisabledColor
        {
            get { return "icon_disabled_color:Button"; }
        }

        [ContextProperty("ЦветЗначкаПриФокусировке", "IconFocusColor")]
        public string IconFocusColor
        {
            get { return "icon_focus_color:Button"; }
        }

        [ContextProperty("ЦветЗначкаСтандартное", "IconNormalColor")]
        public string IconNormalColor
        {
            get { return "icon_normal_color:Button"; }
        }

        [ContextProperty("ЦветКонтураШрифта", "FontOutlineColor")]
        public string FontOutlineColor
        {
            get { return "font_outline_color:Button"; }
        }

        [ContextProperty("ЦветШрифта", "FontColor")]
        public string FontColor
        {
            get { return "font_color:Button"; }
        }

        [ContextProperty("ЦветШрифтаПриНаведении", "FontHoverColor")]
        public string FontHoverColor
        {
            get { return "font_hover_color:Button"; }
        }

        [ContextProperty("ЦветШрифтаПриНаведенииПриНажатии", "FontHoverPressedColor")]
        public string FontHoverPressedColor
        {
            get { return "font_hover_pressed_color:Button"; }
        }

        [ContextProperty("ЦветШрифтаПриНажатии", "FontPressedColor")]
        public string FontPressedColor
        {
            get { return "font_pressed_color:Button"; }
        }

        [ContextProperty("ЦветШрифтаПриОтключении", "FontDisabledColor")]
        public string FontDisabledColor
        {
            get { return "font_disabled_color:Button"; }
        }

        [ContextProperty("ЦветШрифтаПриФокусировке", "FontFocusColor")]
        public string FontFocusColor
        {
            get { return "font_focus_color:Button"; }
        }

        [ContextProperty("Шрифт", "Font")]
        public string Font
        {
            get { return "font:Button"; }
        }
    }
}
