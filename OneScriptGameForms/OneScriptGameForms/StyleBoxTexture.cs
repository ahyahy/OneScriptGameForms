using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class StyleBoxTexture : osgf.StyleBox
    {
        public GfStyleBoxTexture dll_obj;
        private osgf.StyleBox m_StyleBoxTexture;

        public osgf.StyleBox M_StyleBoxTexture
        {
            get { return m_StyleBoxTexture; }
            set
            {
                m_StyleBoxTexture = value;
                base.M_StyleBox = m_StyleBoxTexture;
            }
        }

        public StyleBoxTexture()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "StyleBoxTexture";
        }

        public StyleBoxTexture(string p1)
        {
            ItemKey = p1;
            GameForms.dictKeyEl.TryAdd(ItemKey, this);
            GameForms.dictElKey.TryAdd(this, ItemKey);
            ResourceName = "StyleBoxTexture";
        }

        public void SetTextureMarginAll(decimal p1)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "textureMargin",  p1 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
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

        public int AxisStretchVertical
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
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

        public decimal TextureMarginTop
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal TextureMarginLeft
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal TextureMarginBottom
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal TextureMarginRight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int AxisStretchHorizontal
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfColor ModulateColor
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfRect2 RegionRect
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool DrawCenter
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfImageTexture Texture
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфСтильПанелиТекстура", "GfStyleBoxTexture")]
    public class GfStyleBoxTexture : AutoContext<GfStyleBoxTexture>
    {
        public osgf.StyleBoxTexture Base_obj;

        public GfStyleBoxTexture()
        {
            StyleBoxTexture StyleBoxTexture1 = new StyleBoxTexture();
            StyleBoxTexture1.dll_obj = this;
            Base_obj = StyleBoxTexture1;
        }

        public GfStyleBoxTexture(string p1 = null)
        {
            StyleBoxTexture StyleBoxTexture1 = new StyleBoxTexture(p1);
            StyleBoxTexture1.dll_obj = this;
            Base_obj = StyleBoxTexture1;
        }

        [ContextProperty("ВертикальноеРастяжение", "AxisStretchVertical")]
        public int AxisStretchVertical
        {
            get { return Base_obj.AxisStretchVertical; }
            set { Base_obj.AxisStretchVertical = value; }
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

        [ContextProperty("ВылетТекстурыСверху", "TextureMarginTop")]
        public decimal TextureMarginTop
        {
            get { return Base_obj.TextureMarginTop; }
            set { Base_obj.TextureMarginTop = value; }
        }

        [ContextProperty("ВылетТекстурыСлева", "TextureMarginLeft")]
        public decimal TextureMarginLeft
        {
            get { return Base_obj.TextureMarginLeft; }
            set { Base_obj.TextureMarginLeft = value; }
        }

        [ContextProperty("ВылетТекстурыСнизу", "TextureMarginBottom")]
        public decimal TextureMarginBottom
        {
            get { return Base_obj.TextureMarginBottom; }
            set { Base_obj.TextureMarginBottom = value; }
        }

        [ContextProperty("ВылетТекстурыСправа", "TextureMarginRight")]
        public decimal TextureMarginRight
        {
            get { return Base_obj.TextureMarginRight; }
            set { Base_obj.TextureMarginRight = value; }
        }

        [ContextProperty("ГоризонтальноеРастяжение", "AxisStretchHorizontal")]
        public int AxisStretchHorizontal
        {
            get { return Base_obj.AxisStretchHorizontal; }
            set { Base_obj.AxisStretchHorizontal = value; }
        }

        [ContextProperty("ИзменениеЦвета", "ModulateColor")]
        public GfColor ModulateColor
        {
            get { return Base_obj.ModulateColor; }
            set { Base_obj.ModulateColor = value; }
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

        [ContextProperty("Регион", "RegionRect")]
        public GfRect2 RegionRect
        {
            get { return Base_obj.RegionRect; }
            set { Base_obj.RegionRect = value; }
        }

        [ContextProperty("РисоватьЦентр", "DrawCenter")]
        public bool DrawCenter
        {
            get { return Base_obj.DrawCenter; }
            set { Base_obj.DrawCenter = value; }
        }

        [ContextProperty("Текстура", "Texture")]
        public GfImageTexture Texture
        {
            get { return Base_obj.Texture; }
            set { Base_obj.Texture = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfStyleBoxTexture" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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

        [ContextMethod("УстановитьВылетТекстурыВсех", "SetTextureMarginAll")]
        public void SetTextureMarginAll(decimal p1)
        {
            Base_obj.SetTextureMarginAll(p1);
        }
    }
}
