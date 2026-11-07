using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    public class Environment : osgf.Resource
    {
        public GfEnvironment dll_obj;
        private osgf.Resource m_Environment;

        public osgf.Resource M_Environment
        {
            get { return m_Environment; }
            set
            {
                m_Environment = value;
                base.M_Resource = m_Environment;
            }
        }
    }

    [ContextClass("ИфОкружение", "GfEnvironment")]
    public class GfEnvironment : AutoContext<GfEnvironment>
    {
        public osgf.Environment Base_obj;

        public GfEnvironment()
        {
            Environment Environment1 = new Environment();
            Environment1.dll_obj = this;
            Base_obj = Environment1;
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

        [ContextProperty("ПутьРесурса", "ResourcePath")]
        public string ResourcePath
        {
            get { return Base_obj.ResourcePath; }
            set { Base_obj.ResourcePath = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfEnvironment" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
    }
}
