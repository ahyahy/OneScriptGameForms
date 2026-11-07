using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфИмяСвойстваТемыНадпись", "GfNamePropertyThemeLabel")]
    public class GfNamePropertyThemeLabel : AutoContext<GfNamePropertyThemeLabel>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfNamePropertyThemeLabel()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("ПриФокусировке"),
                ValueFactory.Create("Шрифт"),
                ValueFactory.Create("ЦветШрифта"),
                ValueFactory.Create("ЦветКонтураШрифта"),
                ValueFactory.Create("ЦветТениШрифта"),
                ValueFactory.Create("РазмерШрифта"),
                ValueFactory.Create("МежстрочныйИнтервал"),
                ValueFactory.Create("Стандартное"),
                ValueFactory.Create("РазмерКонтура"),
                ValueFactory.Create("ИнтервалАбзаца"),
                ValueFactory.Create("СмещениеТениИкс"),
                ValueFactory.Create("СмещениеТениИгрек"),
                ValueFactory.Create("РазмерКонтураТени")
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
                "focus:Label" => "ПриФокусировке",
                "font:Label" => "Шрифт",
                "font_color:Label" => "ЦветШрифта",
                "font_outline_color:Label" => "ЦветКонтураШрифта",
                "font_shadow_color:Label" => "ЦветТениШрифта",
                "font_size:Label" => "РазмерШрифта",
                "line_spacing:Label" => "МежстрочныйИнтервал",
                "normal:Label" => "Стандартное",
                "outline_size:Label" => "РазмерКонтура",
                "paragraph_spacing:Label" => "ИнтервалАбзаца",
                "shadow_offset_x:Label" => "СмещениеТениИкс",
                "shadow_offset_y:Label" => "СмещениеТениИгрек",
                "shadow_outline_size:Label" => "РазмерКонтураТени",
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
                "focus:Label" => "Focus",
                "font:Label" => "Font",
                "font_color:Label" => "FontColor",
                "font_outline_color:Label" => "FontOutlineColor",
                "font_shadow_color:Label" => "FontShadowColor",
                "font_size:Label" => "FontSize",
                "line_spacing:Label" => "LineSpacing",
                "normal:Label" => "Normal",
                "outline_size:Label" => "OutlineSize",
                "paragraph_spacing:Label" => "ParagraphSpacing",
                "shadow_offset_x:Label" => "ShadowOffsetX",
                "shadow_offset_y:Label" => "ShadowOffsetY",
                "shadow_outline_size:Label" => "ShadowOutlineSize",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("ИнтервалАбзаца", "ParagraphSpacing")]
        public string ParagraphSpacing
        {
            get { return "paragraph_spacing:Label"; }
        }

        [ContextProperty("МежстрочныйИнтервал", "LineSpacing")]
        public string LineSpacing
        {
            get { return "line_spacing:Label"; }
        }

        [ContextProperty("ПриФокусировке", "Focus")]
        public string Focus
        {
            get { return "focus:Label"; }
        }

        [ContextProperty("РазмерКонтура", "OutlineSize")]
        public string OutlineSize
        {
            get { return "outline_size:Label"; }
        }

        [ContextProperty("РазмерКонтураТени", "ShadowOutlineSize")]
        public string ShadowOutlineSize
        {
            get { return "shadow_outline_size:Label"; }
        }

        [ContextProperty("РазмерШрифта", "FontSize")]
        public string FontSize
        {
            get { return "font_size:Label"; }
        }

        [ContextProperty("СмещениеТениИгрек", "ShadowOffsetY")]
        public string ShadowOffsetY
        {
            get { return "shadow_offset_y:Label"; }
        }

        [ContextProperty("СмещениеТениИкс", "ShadowOffsetX")]
        public string ShadowOffsetX
        {
            get { return "shadow_offset_x:Label"; }
        }

        [ContextProperty("Стандартное", "Normal")]
        public string Normal
        {
            get { return "normal:Label"; }
        }

        [ContextProperty("ЦветКонтураШрифта", "FontOutlineColor")]
        public string FontOutlineColor
        {
            get { return "font_outline_color:Label"; }
        }

        [ContextProperty("ЦветТениШрифта", "FontShadowColor")]
        public string FontShadowColor
        {
            get { return "font_shadow_color:Label"; }
        }

        [ContextProperty("ЦветШрифта", "FontColor")]
        public string FontColor
        {
            get { return "font_color:Label"; }
        }

        [ContextProperty("Шрифт", "Font")]
        public string Font
        {
            get { return "font:Label"; }
        }
    }
}
