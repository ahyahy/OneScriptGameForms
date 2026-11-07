using OneScript.Contexts;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class Camera3D : osgf.Node3D
    {
        public GfCamera3D dll_obj;
        private osgf.Node3D m_Camera3D;

        public osgf.Node3D M_Camera3D
        {
            get { return m_Camera3D; }
            set
            {
                m_Camera3D = value;
                base.M_Node3D = m_Camera3D;
            }
        }

        public int VOffset
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int HOffset
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2 FrustumOffset
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int Fov
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public void MakeCurrent()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }
    }

    [ContextClass("ИфКамера3д", "GfCamera3D")]
    public class GfCamera3D : AutoContext<GfCamera3D>
    {
        public osgf.Camera3D Base_obj;

        public GfCamera3D()
        {
            Camera3D Camera3D1 = new Camera3D();
            Camera3D1.dll_obj = this;
            Base_obj = Camera3D1;
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

        [ContextProperty("СмещениеПоВертикали", "VOffset")]
        public int VOffset
        {
            get { return Base_obj.VOffset; }
            set { Base_obj.VOffset = value; }
        }

        [ContextProperty("СмещениеПоГоризонтали", "HOffset")]
        public int HOffset
        {
            get { return Base_obj.HOffset; }
            set { Base_obj.HOffset = value; }
        }

        [ContextProperty("СмещениеУсеченнойПирамиды", "FrustumOffset")]
        public GfVector2 FrustumOffset
        {
            get { return Base_obj.FrustumOffset; }
            set { Base_obj.FrustumOffset = value; }
        }

        [ContextProperty("УголОбзора", "Fov")]
        public int Fov
        {
            get { return Base_obj.Fov; }
            set { Base_obj.Fov = value; }
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
            return new GfString("GfCamera3D" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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

        [ContextMethod("СделатьТекущей", "MakeCurrent")]
        public void MakeCurrent()
        {
            Base_obj.MakeCurrent();
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
