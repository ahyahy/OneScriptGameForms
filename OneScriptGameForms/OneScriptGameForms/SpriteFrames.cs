using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    public class SpriteFrames : osgf.Resource
    {
        public GfSpriteFrames dll_obj;
        private osgf.Resource m_SpriteFrames;

        public osgf.Resource M_SpriteFrames
        {
            get { return m_SpriteFrames; }
            set
            {
                m_SpriteFrames = value;
                base.M_Resource = m_SpriteFrames;
            }
        }
    }

    [ContextClass("ИфБиблиотекаКадров", "GfSpriteFrames")]
    public class GfSpriteFrames : AutoContext<GfSpriteFrames>
    {
        public osgf.SpriteFrames Base_obj;

        public GfSpriteFrames()
        {
            SpriteFrames SpriteFrames1 = new SpriteFrames();
            SpriteFrames1.dll_obj = this;
            Base_obj = SpriteFrames1;
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
            return new GfString("GfSpriteFrames" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
