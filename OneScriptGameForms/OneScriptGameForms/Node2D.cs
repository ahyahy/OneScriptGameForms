using OneScript.Contexts;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class Node2D : osgf.CanvasItem
    {
        public GfNode2D dll_obj;
        private osgf.CanvasItem m_Node2D;

        public osgf.CanvasItem M_Node2D
        {
            get { return m_Node2D; }
            set
            {
                m_Node2D = value;
                base.M_CanvasItem = m_Node2D;
            }
        }

        public Node2D()
        {
            OsUtils.CreateGodotObject(this);
        }

        private decimal rotationDegrees;
        public decimal RotationDegrees
        {
            get { return rotationDegrees; }
            set
            {
                Response response = new Response
                {
                    Properties = new Dictionary<string, object>
                    {
                        { "element",  this.ItemKey },
                        { "rotation_degrees",  OsUtils.ToFloat(value) },
                    }
                };
                string jsonResponse = OsUtils.Serialize(response);
                string res = GameForms.SendCommand("SetProperty", jsonResponse);
                var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
                if (((JsonElement)answer["success"]).GetBoolean())
                {
                    rotationDegrees = value;
                }
                else
                {
                    OsUtils.Echo("Не удалось установить свойство Текст");
                }
            }
        }

        private GfVector2 position = new GfVector2(0, 0);
        public GfVector2 Position
        {
            get { return position; }
            set
            {
                Response response = new Response
                {
                    Properties = new Dictionary<string, object>
                    {
                        { "element",  this.ItemKey },
                        { "position",  new {value.X, value.Y } },
                    }
                };
                string jsonResponse = OsUtils.Serialize(response);
                string res = GameForms.SendCommand("SetProperty", jsonResponse);
                var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
                if (((JsonElement)answer["success"]).GetBoolean())
                {
                    position = value;
                }
                else
                {
                    OsUtils.Echo("Не удалось установить свойство Позиция");
                }
            }
        }

        public GfVector2 GlobalPosition
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфУзел2д", "GfNode2D")]
    public class GfNode2D : AutoContext<GfNode2D>
    {
        public osgf.Node2D Base_obj;

        public GfNode2D()
        {
            Node2D Node2D1 = new Node2D();
            Node2D1.dll_obj = this;
            Base_obj = Node2D1;
        }

        [ContextProperty("ГлобальнаяПозиция", "GlobalPosition")]
        public GfVector2 GlobalPosition
        {
            get { return Base_obj.GlobalPosition; }
            set { Base_obj.GlobalPosition = value; }
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

        [ContextProperty("Материал", "Material")]
        public GfMaterial Material
        {
            get { return Base_obj.Material; }
            set { Base_obj.Material = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public IValue Tag
        {
            get { return Base_obj.Tag; }
            set { Base_obj.Tag = value; }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("ПоворотНаГрадус", "RotationDegrees")]
        public decimal RotationDegrees
        {
            get { return Base_obj.RotationDegrees; }
            set { Base_obj.RotationDegrees = value; }
        }

        [ContextProperty("Позиция", "Position")]
        public GfVector2 Position
        {
            get { return Base_obj.Position; }
            set { Base_obj.Position = value; }
        }

        [ContextProperty("ЦветМодуляции", "Modulate")]
        public GfColor Modulate
        {
            get { return Base_obj.Modulate; }
            set { Base_obj.Modulate = value; }
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
            return new GfString("GfNode2D" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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

        [ContextMethod("ПолучитьПозициюМыши", "GetLocalMousePosition")]
        public GfVector2 GetLocalMousePosition()
        {
            return Base_obj.GetLocalMousePosition();
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

        [ContextMethod("УдалитьДочерний", "RemoveChild")]
        public void RemoveChild(IValue p1)
        {
            Base_obj.RemoveChild(p1);
        }
    }
}
