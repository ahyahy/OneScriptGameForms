using OneScript.Contexts;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    public class DirectionalLight3D : osgf.Light3D
    {
        public GfDirectionalLight3D dll_obj;
        private osgf.Light3D m_DirectionalLight3D;

        public osgf.Light3D M_DirectionalLight3D
        {
            get { return m_DirectionalLight3D; }
            set
            {
                m_DirectionalLight3D = value;
                base.M_Light3D = m_DirectionalLight3D;
            }
        }
    }

    [ContextClass("ИфНаправленныйСвет3д", "GfDirectionalLight3D")]
    public class GfDirectionalLight3D : AutoContext<GfDirectionalLight3D>
    {
        public osgf.DirectionalLight3D Base_obj;

        public GfDirectionalLight3D()
        {
            DirectionalLight3D DirectionalLight3D1 = new DirectionalLight3D();
            DirectionalLight3D1.dll_obj = this;
            Base_obj = DirectionalLight3D1;
        }

        [ContextProperty("ГлобальнаяТрансформация", "GlobalTransform")]
        public GfTransform3D GlobalTransform
        {
            get { return Base_obj.GlobalTransform; }
            set { Base_obj.GlobalTransform = value; }
        }

        [ContextProperty("ЗетИндекс", "ZIndex")]
        public int ZIndex
        {
            get { return Base_obj.ZIndex; }
            set { Base_obj.ZIndex = value; }
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
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

        [ContextProperty("СилаСвета", "LightEnergy")]
        public int LightEnergy
        {
            get { return Base_obj.LightEnergy; }
            set { Base_obj.LightEnergy = value; }
        }

        [ContextProperty("ЦветСвета", "LightColor")]
        public int LightColor
        {
            get { return Base_obj.LightColor; }
            set { Base_obj.LightColor = value; }
        }

        [ContextMethod("ВГлобальные", "ToGlobal")]
        public GfVector2 ToGlobal(GfVector2 p1)
        {
            return Base_obj.ToGlobal(p1);
        }

        [ContextMethod("ВЛокальные", "ToLocal")]
        public GfVector2 ToLocal(GfVector2 p1)
        {
            return Base_obj.ToLocal(p1);
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfDirectionalLight3D" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("ДобавитьДочерний", "AddChild")]
        public IValue AddChild(IValue p1)
        {
            return Base_obj.AddChild(p1);
        }

        [ContextMethod("НаЗаднийПлан", "SendToBack")]
        public void SendToBack()
        {
            Base_obj.SendToBack();
        }

        [ContextMethod("НаПереднийПлан", "BringToFront")]
        public void BringToFront()
        {
            Base_obj.BringToFront();
        }

        [ContextMethod("ПолучитьДочерние", "GetChildren")]
        public ArrayImpl GetChildren()
        {
            return Base_obj.GetChildren();
        }

        [ContextMethod("ПолучитьОкно", "GetWindow")]
        public IValue GetWindow()
        {
            return Base_obj.GetWindow();
        }

        [ContextMethod("ПолучитьРодителя", "GetParent")]
        public IValue GetParent()
        {
            return Base_obj.GetParent();
        }

        [ContextMethod("ПолучитьУзел", "GetNode")]
        public IValue GetNode(string p1)
        {
            return Base_obj.GetNode(p1);
        }

        [ContextMethod("СмотретьИзПозиции", "LookAtFromPosition")]
        public void LookAtFromPosition(GfVector3 p1, GfVector3 p2, GfVector3 p3, bool p4 = false)
        {
            Base_obj.LookAtFromPosition(p1, p2, p3, p4);
        }

        [ContextMethod("УдалитьДочерний", "RemoveChild")]
        public void RemoveChild(IValue p1)
        {
            Base_obj.RemoveChild(p1);
        }
    }
}
