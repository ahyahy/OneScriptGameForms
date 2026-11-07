using OneScript.Contexts;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class Sprite2D : osgf.Node2D
    {
        public new GfSprite2D dll_obj;
        private osgf.Node2D m_Sprite2D;

        public osgf.Node2D M_Sprite2D
        {
            get { return m_Sprite2D; }
            set
            {
                m_Sprite2D = value;
                base.M_Node2D = m_Sprite2D;
            }
        }

        public Sprite2D()
        {
            OsUtils.CreateGodotObject(this);
        }

        public bool RegionEnabled
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfRect2 RegionRect
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool Centered
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2 Offset
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфСпрайт2д", "GfSprite2D")]
    public class GfSprite2D : AutoContext<GfSprite2D>
    {
        public osgf.Sprite2D Base_obj;

        public GfSprite2D()
        {
            Sprite2D Sprite2D1 = new Sprite2D();
            Sprite2D1.dll_obj = this;
            Base_obj = Sprite2D1;
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

        [ContextProperty("ОбластьВключена", "RegionEnabled")]
        public bool RegionEnabled
        {
            get { return Base_obj.RegionEnabled; }
            set { Base_obj.RegionEnabled = value; }
        }

        [ContextProperty("ОбластьВырезки", "RegionRect")]
        public GfRect2 RegionRect
        {
            get { return Base_obj.RegionRect; }
            set { Base_obj.RegionRect = value; }
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

        [ContextProperty("ПоЦентру", "Centered")]
        public bool Centered
        {
            get { return Base_obj.Centered; }
            set { Base_obj.Centered = value; }
        }

        [ContextProperty("Смещение", "Offset")]
        public GfVector2 Offset
        {
            get { return Base_obj.Offset; }
            set { Base_obj.Offset = value; }
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
            return new GfString("GfSprite2D" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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
