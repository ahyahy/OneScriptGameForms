using OneScript.Contexts;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class PanelContainer : osgf.Container
    {
        public GfPanelContainer dll_obj;
        private osgf.Container m_PanelContainer;

        public osgf.Container M_PanelContainer
        {
            get { return m_PanelContainer; }
            set
            {
                m_PanelContainer = value;
                base.M_Container = m_PanelContainer;
            }
        }

        public PanelContainer()
        {
            OsUtils.CreateGodotObject(this);
        }

        public GfThemePanelContainer Theme
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфПанельныйКонтейнер", "GfPanelContainer")]
    public class GfPanelContainer : AutoContext<GfPanelContainer>
    {
        public osgf.PanelContainer Base_obj;

        public GfPanelContainer()
        {
            PanelContainer PanelContainer1 = new PanelContainer();
            PanelContainer1.dll_obj = this;
            Base_obj = PanelContainer1;
        }

        [ContextProperty("ВертикальныеФлагиРазмера", "SizeFlagsVertical")]
        public int SizeFlagsVertical
        {
            get { return Base_obj.SizeFlagsVertical; }
            set { Base_obj.SizeFlagsVertical = value; }
        }

        [ContextProperty("ГоризонтальныеФлагиРазмера", "SizeFlagsHorizontal")]
        public int SizeFlagsHorizontal
        {
            get { return Base_obj.SizeFlagsHorizontal; }
            set { Base_obj.SizeFlagsHorizontal = value; }
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

        [ContextProperty("КоэффициентРастяженияДляФлаговРазмера", "SizeFlagsStretchRatio")]
        public int SizeFlagsStretchRatio
        {
            get { return Base_obj.SizeFlagsStretchRatio; }
            set { Base_obj.SizeFlagsStretchRatio = value; }
        }

        [ContextProperty("Масштаб", "Scale")]
        public GfVector2 Scale
        {
            get { return Base_obj.Scale; }
            set { Base_obj.Scale = value; }
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

        [ContextProperty("ОтступВерхний", "OffsetTop")]
        public int OffsetTop
        {
            get { return Base_obj.OffsetTop; }
            set { Base_obj.OffsetTop = value; }
        }

        [ContextProperty("ОтступЛевый", "OffsetLeft")]
        public int OffsetLeft
        {
            get { return Base_obj.OffsetLeft; }
            set { Base_obj.OffsetLeft = value; }
        }

        [ContextProperty("ОтступНижний", "OffsetBottom")]
        public int OffsetBottom
        {
            get { return Base_obj.OffsetBottom; }
            set { Base_obj.OffsetBottom = value; }
        }

        [ContextProperty("ОтступПравый", "OffsetRight")]
        public int OffsetRight
        {
            get { return Base_obj.OffsetRight; }
            set { Base_obj.OffsetRight = value; }
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

        [ContextProperty("ПредыдущийФокус", "FocusPrevious")]
        public IValue FocusPrevious
        {
            get { return Base_obj.FocusPrevious; }
            set { Base_obj.FocusPrevious = value; }
        }

        [ContextProperty("Размер", "Size")]
        public GfVector2 Size
        {
            get { return Base_obj.Size; }
            set { Base_obj.Size = value; }
        }

        [ContextProperty("РежимФокусировки", "FocusMode")]
        public int FocusMode
        {
            get { return Base_obj.FocusMode; }
            set { Base_obj.FocusMode = value; }
        }

        [ContextProperty("СледующийФокус", "FocusNext")]
        public IValue FocusNext
        {
            get { return Base_obj.FocusNext; }
            set { Base_obj.FocusNext = value; }
        }

        [ContextProperty("СоседФокусаВерхний", "FocusNeighborTop")]
        public IValue FocusNeighborTop
        {
            get { return Base_obj.FocusNeighborTop; }
            set { Base_obj.FocusNeighborTop = value; }
        }

        [ContextProperty("СоседФокусаЛевый", "FocusNeighborLeft")]
        public IValue FocusNeighborLeft
        {
            get { return Base_obj.FocusNeighborLeft; }
            set { Base_obj.FocusNeighborLeft = value; }
        }

        [ContextProperty("СоседФокусаНижний", "FocusNeighborBottom")]
        public IValue FocusNeighborBottom
        {
            get { return Base_obj.FocusNeighborBottom; }
            set { Base_obj.FocusNeighborBottom = value; }
        }

        [ContextProperty("СоседФокусаПравый", "FocusNeighborRight")]
        public IValue FocusNeighborRight
        {
            get { return Base_obj.FocusNeighborRight; }
            set { Base_obj.FocusNeighborRight = value; }
        }

        [ContextProperty("Тема", "Theme")]
        public GfThemePanelContainer Theme
        {
            get { return Base_obj.Theme; }
            set { Base_obj.Theme = value; }
        }

        [ContextProperty("ЦветМодуляции", "Modulate")]
        public GfColor Modulate
        {
            get { return Base_obj.Modulate; }
            set { Base_obj.Modulate = value; }
        }

        [ContextProperty("ЯкорьВерхний", "AnchorTop")]
        public decimal AnchorTop
        {
            get { return Base_obj.AnchorTop; }
            set { Base_obj.AnchorTop = value; }
        }

        [ContextProperty("ЯкорьЛевый", "AnchorLeft")]
        public decimal AnchorLeft
        {
            get { return Base_obj.AnchorLeft; }
            set { Base_obj.AnchorLeft = value; }
        }

        [ContextProperty("ЯкорьНижний", "AnchorBottom")]
        public decimal AnchorBottom
        {
            get { return Base_obj.AnchorBottom; }
            set { Base_obj.AnchorBottom = value; }
        }

        [ContextProperty("ЯкорьПравый", "AnchorRight")]
        public decimal AnchorRight
        {
            get { return Base_obj.AnchorRight; }
            set { Base_obj.AnchorRight = value; }
        }

        [ContextMethod("ВписатьДочернийВПрямоугольник", "FitChildInRect")]
        public void FitChildInRect(IValue p1, GfRect2 p2)
        {
            Base_obj.FitChildInRect(p1, p2);
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfPanelContainer" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("Выше", "PlaceTop")]
        public void PlaceTop(IValue p1, int p2)
        {
            Base_obj.PlaceTop(p1, p2);
        }

        [ContextMethod("ВышеЛевее", "PlaceTopLeft")]
        public void PlaceTopLeft(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceTopLeft(p1, p2, p3);
        }

        [ContextMethod("ВышеПравее", "PlaceTopRight")]
        public void PlaceTopRight(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceTopRight(p1, p2, p3);
        }

        [ContextMethod("ДобавитьДочерний", "AddChild")]
        public IValue AddChild(IValue p1)
        {
            return Base_obj.AddChild(p1);
        }

        [ContextMethod("ДобавитьСтиль", "AddThemeStyleboxOverride")]
        public void AddThemeStyleboxOverride(string p1, IValue p2)
        {
            Base_obj.AddThemeStyleboxOverride(p1.Split(':')[0], p2);
        }

        [ContextMethod("Левее", "PlaceLeft")]
        public void PlaceLeft(IValue p1, int p2)
        {
            Base_obj.PlaceLeft(p1, p2);
        }

        [ContextMethod("ЛевееВыше", "PlaceLeftTop")]
        public void PlaceLeftTop(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceLeftTop(p1, p2, p3);
        }

        [ContextMethod("ЛевееНиже", "PlaceLeftBottom")]
        public void PlaceLeftBottom(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceLeftBottom(p1, p2, p3);
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

        [ContextMethod("Ниже", "PlaceBottom")]
        public void PlaceBottom(IValue p1, int p2)
        {
            Base_obj.PlaceBottom(p1, p2);
        }

        [ContextMethod("НижеЛевее", "PlaceBottomLeft")]
        public void PlaceBottomLeft(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceBottomLeft(p1, p2, p3);
        }

        [ContextMethod("НижеПравее", "PlaceBottomRight")]
        public void PlaceBottomRight(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceBottomRight(p1, p2, p3);
        }

        [ContextMethod("ПереместитьМышь", "WarpMouse")]
        public void WarpMouse(GfVector2 p1, decimal p2 = 0.5m)
        {
            Base_obj.WarpMouse(p1, p2);
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

        [ContextMethod("ПолучитьСтильПанелиЛиния", "GetThemeStyleboxLine")]
        public IValue GetThemeStyleboxLine(string p1)
        {
            return Base_obj.GetThemeStyleboxLine(p1.Split(':')[0]);
        }

        [ContextMethod("ПолучитьСтильПанелиПлоский", "GetThemeStyleboxFlat")]
        public IValue GetThemeStyleboxFlat(string p1)
        {
            return Base_obj.GetThemeStyleboxFlat(p1.Split(':')[0]);
        }

        [ContextMethod("ПолучитьСтильПанелиПусто", "GetThemeStyleboxEmpty")]
        public IValue GetThemeStyleboxEmpty(string p1)
        {
            return Base_obj.GetThemeStyleboxEmpty(p1.Split(':')[0]);
        }

        [ContextMethod("ПолучитьСтильПанелиТекстура", "GetThemeStyleboxTexture")]
        public IValue GetThemeStyleboxTexture(string p1)
        {
            return Base_obj.GetThemeStyleboxTexture(p1.Split(':')[0]);
        }

        [ContextMethod("ПолучитьУзел", "GetNode")]
        public IValue GetNode(string p1)
        {
            return Base_obj.GetNode(p1);
        }

        [ContextMethod("Правее", "PlaceRight")]
        public void PlaceRight(IValue p1, int p2)
        {
            Base_obj.PlaceRight(p1, p2);
        }

        [ContextMethod("ПравееВыше", "PlaceRightTop")]
        public void PlaceRightTop(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceRightTop(p1, p2, p3);
        }

        [ContextMethod("ПравееНиже", "PlaceRightBottom")]
        public void PlaceRightBottom(IValue p1, int p2, int p3)
        {
            Base_obj.PlaceRightBottom(p1, p2, p3);
        }

        [ContextMethod("Сфокусирован", "HasFocus")]
        public bool HasFocus()
        {
            return Base_obj.HasFocus();
        }

        [ContextMethod("УдалитьДочерний", "RemoveChild")]
        public void RemoveChild(IValue p1)
        {
            Base_obj.RemoveChild(p1);
        }

        [ContextMethod("УдалитьСтиль", "RemoveThemeStyleboxOverride")]
        public void RemoveThemeStyleboxOverride(string p1)
        {
            Base_obj.RemoveThemeStyleboxOverride(p1.Split(':')[0]);
        }

        [ContextMethod("УстановитьФокус", "GrabFocus")]
        public void GrabFocus()
        {
            Base_obj.GrabFocus();
        }

        [ContextMethod("Центр", "Center")]
        public void Center(decimal p1 = 0, decimal p2 = 0)
        {
            Base_obj.Center(p1, p2);
        }

        [ContextMethod("ЦентрНаТочку", "SetCenterToPoint")]
        public void SetCenterToPoint(GfVector2 p1)
        {
            Base_obj.SetCenterToPoint(p1);
        }
    }
}
