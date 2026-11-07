using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class StyleBoxFlat : osgf.StyleBox
    {
        public GfStyleBoxFlat dll_obj;
        private osgf.StyleBox m_StyleBoxFlat;

        public osgf.StyleBox M_StyleBoxFlat
        {
            get { return m_StyleBoxFlat; }
            set
            {
                m_StyleBoxFlat = value;
                base.M_StyleBox = m_StyleBoxFlat;
            }
        }

        public StyleBoxFlat()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "StyleBoxFlat";
        }

        public StyleBoxFlat(string p1)
        {
            ItemKey = p1;
            GameForms.dictKeyEl.TryAdd(ItemKey, this);
            GameForms.dictElKey.TryAdd(this, ItemKey);
            ResourceName = "StyleBoxFlat";
        }

        public StyleBoxFlat(string itemKey, bool plug)
        {
            ItemKey = itemKey;
            GameForms.dictKeyEl.TryAdd(ItemKey, this);
            GameForms.dictElKey.TryAdd(this, ItemKey);
            ResourceName = "StyleBoxFlat";
        }

        public decimal ExpandMarginTop
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal ExpandMarginLeft
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal ExpandMarginBottom
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal ExpandMarginRight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal CornerRadiusTopLeft
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal CornerRadiusTopRight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal CornerRadiusBottomLeft
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal CornerRadiusBottomRight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal ShadowSize
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2 ShadowOffset
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor BorderColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor ShadowColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor BgColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal BorderWidthTop
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal BorderWidthLeft
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal BorderWidthBottom
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal BorderWidthRight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public void SetExpandMarginAll(decimal p1)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "expandMargin",  p1 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void SetCornerRadiusAll(decimal p1)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  ItemKey },
                    { "cornerRadius",  p1 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void SetBorderWidthAll(decimal p1)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "borderWidth",  p1 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }
    }

    [ContextClass("ИфСтильПанелиПлоский", "GfStyleBoxFlat")]
    public class GfStyleBoxFlat : AutoContext<GfStyleBoxFlat>
    {
        public osgf.StyleBoxFlat Base_obj;

        public GfStyleBoxFlat()
        {
            StyleBoxFlat StyleBoxFlat1 = new StyleBoxFlat();
            StyleBoxFlat1.dll_obj = this;
            Base_obj = StyleBoxFlat1;
        }

        public GfStyleBoxFlat(string p1 = null)
        {
            StyleBoxFlat StyleBoxFlat1 = new StyleBoxFlat(p1);
            StyleBoxFlat1.dll_obj = this;
            Base_obj = StyleBoxFlat1;
        }

        public GfStyleBoxFlat(string itemKey, bool plug)
        {
            StyleBoxFlat StyleBoxFlat1 = new StyleBoxFlat(itemKey, true);
            StyleBoxFlat1.dll_obj = this;
            Base_obj = StyleBoxFlat1;
        }

        [ContextProperty("ВылетСверху", "ExpandMarginTop")]
        public decimal ExpandMarginTop
        {
            get { return Base_obj.ExpandMarginTop; }
            set { Base_obj.ExpandMarginTop = value; }
        }

        [ContextProperty("ВылетСлева", "ExpandMarginLeft")]
        public decimal ExpandMarginLeft
        {
            get { return Base_obj.ExpandMarginLeft; }
            set { Base_obj.ExpandMarginLeft = value; }
        }

        [ContextProperty("ВылетСнизу", "ExpandMarginBottom")]
        public decimal ExpandMarginBottom
        {
            get { return Base_obj.ExpandMarginBottom; }
            set { Base_obj.ExpandMarginBottom = value; }
        }

        [ContextProperty("ВылетСправа", "ExpandMarginRight")]
        public decimal ExpandMarginRight
        {
            get { return Base_obj.ExpandMarginRight; }
            set { Base_obj.ExpandMarginRight = value; }
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

        [ContextProperty("РадиусВерхнегоЛевогоУгла", "CornerRadiusTopLeft")]
        public decimal CornerRadiusTopLeft
        {
            get { return Base_obj.CornerRadiusTopLeft; }
            set { Base_obj.CornerRadiusTopLeft = value; }
        }

        [ContextProperty("РадиусВерхнегоПравогоУгла", "CornerRadiusTopRight")]
        public decimal CornerRadiusTopRight
        {
            get { return Base_obj.CornerRadiusTopRight; }
            set { Base_obj.CornerRadiusTopRight = value; }
        }

        [ContextProperty("РадиусНижнегоЛевогоУгла", "CornerRadiusBottomLeft")]
        public decimal CornerRadiusBottomLeft
        {
            get { return Base_obj.CornerRadiusBottomLeft; }
            set { Base_obj.CornerRadiusBottomLeft = value; }
        }

        [ContextProperty("РадиусНижнегоПравогоУгла", "CornerRadiusBottomRight")]
        public decimal CornerRadiusBottomRight
        {
            get { return Base_obj.CornerRadiusBottomRight; }
            set { Base_obj.CornerRadiusBottomRight = value; }
        }

        [ContextProperty("РазмерТени", "ShadowSize")]
        public decimal ShadowSize
        {
            get { return Base_obj.ShadowSize; }
            set { Base_obj.ShadowSize = value; }
        }

        [ContextProperty("СмещениеТени", "ShadowOffset")]
        public GfVector2 ShadowOffset
        {
            get { return Base_obj.ShadowOffset; }
            set { Base_obj.ShadowOffset = value; }
        }

        [ContextProperty("ЦветГраницы", "BorderColor")]
        public GfColor BorderColor
        {
            get { return Base_obj.BorderColor; }
            set { Base_obj.BorderColor = value; }
        }

        [ContextProperty("ЦветТени", "ShadowColor")]
        public GfColor ShadowColor
        {
            get { return Base_obj.ShadowColor; }
            set { Base_obj.ShadowColor = value; }
        }

        [ContextProperty("ЦветФона", "BgColor")]
        public GfColor BgColor
        {
            get { return Base_obj.BgColor; }
            set { Base_obj.BgColor = value; }
        }

        [ContextProperty("ШиринаВерхнейГраницы", "BorderWidthTop")]
        public decimal BorderWidthTop
        {
            get { return Base_obj.BorderWidthTop; }
            set { Base_obj.BorderWidthTop = value; }
        }

        [ContextProperty("ШиринаЛевойГраницы", "BorderWidthLeft")]
        public decimal BorderWidthLeft
        {
            get { return Base_obj.BorderWidthLeft; }
            set { Base_obj.BorderWidthLeft = value; }
        }

        [ContextProperty("ШиринаНижнейГраницы", "BorderWidthBottom")]
        public decimal BorderWidthBottom
        {
            get { return Base_obj.BorderWidthBottom; }
            set { Base_obj.BorderWidthBottom = value; }
        }

        [ContextProperty("ШиринаПравойГраницы", "BorderWidthRight")]
        public decimal BorderWidthRight
        {
            get { return Base_obj.BorderWidthRight; }
            set { Base_obj.BorderWidthRight = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfStyleBoxFlat" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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

        [ContextMethod("УстановитьВылетВсех", "SetExpandMarginAll")]
        public void SetExpandMarginAll(decimal p1)
        {
            Base_obj.SetExpandMarginAll(p1);
        }

        [ContextMethod("УстановитьРадиусУглаВсех", "SetCornerRadiusAll")]
        public void SetCornerRadiusAll(decimal p1)
        {
            Base_obj.SetCornerRadiusAll(p1);
        }

        [ContextMethod("УстановитьШиринуГраницыВсех", "SetBorderWidthAll")]
        public void SetBorderWidthAll(decimal p1)
        {
            Base_obj.SetBorderWidthAll(p1);
        }
    }
}
