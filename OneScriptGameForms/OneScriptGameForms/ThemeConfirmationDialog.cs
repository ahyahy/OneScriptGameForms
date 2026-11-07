using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class ThemeConfirmationDialog : osgf.Theme
    {
        public GfThemeConfirmationDialog dll_obj;
        private osgf.Theme m_ThemeConfirmationDialog;

        public osgf.Theme M_ThemeConfirmationDialog
        {
            get { return m_ThemeConfirmationDialog; }
            set
            {
                m_ThemeConfirmationDialog = value;
                base.M_Theme = m_ThemeConfirmationDialog;
            }
        }

        public ThemeConfirmationDialog()
        {
            OsUtils.CreateGodotObject(this);
            ResourceName = "ThemeConfirmationDialog";
        }

        public int ButtonsMinHeight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int ButtonsMinWidth
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue Panel
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int ButtonsSeparation
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфТемаОкноСообщений", "GfThemeConfirmationDialog")]
    public class GfThemeConfirmationDialog : AutoContext<GfThemeConfirmationDialog>
    {
        public osgf.ThemeConfirmationDialog Base_obj;

        public GfThemeConfirmationDialog()
        {
            ThemeConfirmationDialog ThemeConfirmationDialog1 = new ThemeConfirmationDialog();
            ThemeConfirmationDialog1.dll_obj = this;
            Base_obj = ThemeConfirmationDialog1;
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

        [ContextProperty("МинимальнаяВысотаКнопки", "ButtonsMinHeight")]
        public int ButtonsMinHeight
        {
            get { return Base_obj.ButtonsMinHeight; }
            set { Base_obj.ButtonsMinHeight = value; }
        }

        [ContextProperty("МинимальнаяШиринаКнопки", "ButtonsMinWidth")]
        public int ButtonsMinWidth
        {
            get { return Base_obj.ButtonsMinWidth; }
            set { Base_obj.ButtonsMinWidth = value; }
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

        [ContextProperty("РазделениеКнопок", "ButtonsSeparation")]
        public int ButtonsSeparation
        {
            get { return Base_obj.ButtonsSeparation; }
            set { Base_obj.ButtonsSeparation = value; }
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
            return new GfString("GfThemeConfirmationDialog" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
