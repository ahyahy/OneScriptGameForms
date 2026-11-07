using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфИмяСвойстваТемыОкно", "GfNamePropertyThemeWindow")]
    public class GfNamePropertyThemeWindow : AutoContext<GfNamePropertyThemeWindow>, ICollectionContext<IValue>, IEnumerable<IValue>
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

        public GfNamePropertyThemeWindow()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("ЗначокЗакрытия"),
                ValueFactory.Create("СмещениеКнопкиЗакрытияИкс"),
                ValueFactory.Create("ЗначокЗакрытияПриНажатии"),
                ValueFactory.Create("СмещениеКнопкиЗакрытияИгрек"),
                ValueFactory.Create("ВнедреннаяГраница"),
                ValueFactory.Create("ВнедреннаяНеСфокусированнаяГраница"),
                ValueFactory.Create("СмещениеЗахвата"),
                ValueFactory.Create("ЦветЗаголовка"),
                ValueFactory.Create("ШрифтЗаголовка"),
                ValueFactory.Create("РазмерШрифтаЗаголовка"),
                ValueFactory.Create("ВысотаЗаголовка"),
                ValueFactory.Create("ЦветКонтураЗаголовка"),
                ValueFactory.Create("РазмерКонтураЗаголовка")
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
                "close:Window" => "ЗначокЗакрытия",
                "close_h_offset:Window" => "СмещениеКнопкиЗакрытияИкс",
                "close_pressed:Window" => "ЗначокЗакрытияПриНажатии",
                "close_v_offset:Window" => "СмещениеКнопкиЗакрытияИгрек",
                "embedded_border:Window" => "ВнедреннаяГраница",
                "embedded_unfocused_border:Window" => "ВнедреннаяНеСфокусированнаяГраница",
                "resize_margin:Window" => "СмещениеЗахвата",
                "title_color:Window" => "ЦветЗаголовка",
                "title_font:Window" => "ШрифтЗаголовка",
                "title_font_size:Window" => "РазмерШрифтаЗаголовка",
                "title_height:Window" => "ВысотаЗаголовка",
                "title_outline_modulate:Window" => "ЦветКонтураЗаголовка",
                "title_outline_size:Window" => "РазмерКонтураЗаголовка",
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
                "close:Window" => "Close",
                "close_h_offset:Window" => "CloseHOffset",
                "close_pressed:Window" => "ClosePressed",
                "close_v_offset:Window" => "CloseVOffset",
                "embedded_border:Window" => "EmbeddedBorder",
                "embedded_unfocused_border:Window" => "EmbeddedUnfocusedBorder",
                "resize_margin:Window" => "ResizeMargin",
                "title_color:Window" => "TitleColor",
                "title_font:Window" => "TitleFont",
                "title_font_size:Window" => "TitleFontSize",
                "title_height:Window" => "TitleHeight",
                "title_outline_modulate:Window" => "TitleOutlineModulate",
                "title_outline_size:Window" => "TitleOutlineSize",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("ВнедреннаяГраница", "EmbeddedBorder")]
        public string EmbeddedBorder
        {
            get { return "embedded_border:Window"; }
        }

        [ContextProperty("ВнедреннаяНеСфокусированнаяГраница", "EmbeddedUnfocusedBorder")]
        public string EmbeddedUnfocusedBorder
        {
            get { return "embedded_unfocused_border:Window"; }
        }

        [ContextProperty("ВысотаЗаголовка", "TitleHeight")]
        public string TitleHeight
        {
            get { return "title_height:Window"; }
        }

        [ContextProperty("ЗначокЗакрытия", "Close")]
        public string Close
        {
            get { return "close:Window"; }
        }

        [ContextProperty("ЗначокЗакрытияПриНажатии", "ClosePressed")]
        public string ClosePressed
        {
            get { return "close_pressed:Window"; }
        }

        [ContextProperty("РазмерКонтураЗаголовка", "TitleOutlineSize")]
        public string TitleOutlineSize
        {
            get { return "title_outline_size:Window"; }
        }

        [ContextProperty("РазмерШрифтаЗаголовка", "TitleFontSize")]
        public string TitleFontSize
        {
            get { return "title_font_size:Window"; }
        }

        [ContextProperty("СмещениеЗахвата", "ResizeMargin")]
        public string ResizeMargin
        {
            get { return "resize_margin:Window"; }
        }

        [ContextProperty("СмещениеКнопкиЗакрытияИгрек", "CloseVOffset")]
        public string CloseVOffset
        {
            get { return "close_v_offset:Window"; }
        }

        [ContextProperty("СмещениеКнопкиЗакрытияИкс", "CloseHOffset")]
        public string CloseHOffset
        {
            get { return "close_h_offset:Window"; }
        }

        [ContextProperty("ЦветЗаголовка", "TitleColor")]
        public string TitleColor
        {
            get { return "title_color:Window"; }
        }

        [ContextProperty("ЦветКонтураЗаголовка", "TitleOutlineModulate")]
        public string TitleOutlineModulate
        {
            get { return "title_outline_modulate:Window"; }
        }

        [ContextProperty("ШрифтЗаголовка", "TitleFont")]
        public string TitleFont
        {
            get { return "title_font:Window"; }
        }
    }
}
