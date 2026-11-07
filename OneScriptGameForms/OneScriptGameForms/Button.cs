using OneScript.Contexts;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class Button : osgf.BaseButton
    {
        public GfButton dll_obj;
        private osgf.BaseButton m_Button;

        public osgf.BaseButton M_Button
        {
            get { return m_Button; }
            set
            {
                m_Button = value;
                base.M_BaseButton = m_Button;
            }
        }

        public Button(string p1)
        {
            ItemKey = p1;
            GameForms.dictKeyEl.TryAdd(ItemKey, this);
            GameForms.dictElKey.TryAdd(this, ItemKey);
        }

        public Button()
        {
            OsUtils.CreateGodotObject(this);
        }

        public string Text
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int AutowrapMode
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int VerticalIconAlignment
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int Alignment
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int IconAlignment
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfImageTexture Icon
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int TextDirection
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool ClipText
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool Flat
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int TextOverrunBehavior
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool ExpandIcon
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfThemeButton Theme
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфКнопка", "GfButton")]
    public class GfButton : AutoContext<GfButton>
    {
        public osgf.Button Base_obj;

        public GfButton()
        {
            Button Button1 = new Button();
            Button1.dll_obj = this;
            Base_obj = Button1;
        }

        public GfButton(string p1)
        {
            Button Button1 = new Button(p1);
            Button1.dll_obj = this;
            Base_obj = Button1;
        }

        [ContextProperty("Автоперенос", "AutowrapMode")]
        public int AutowrapMode
        {
            get { return Base_obj.AutowrapMode; }
            set { Base_obj.AutowrapMode = value; }
        }

        [ContextProperty("ВертикальноеВыравнивание", "VerticalIconAlignment")]
        public int VerticalIconAlignment
        {
            get { return Base_obj.VerticalIconAlignment; }
            set { Base_obj.VerticalIconAlignment = value; }
        }

        [ContextProperty("ВертикальныеФлагиРазмера", "SizeFlagsVertical")]
        public int SizeFlagsVertical
        {
            get { return Base_obj.SizeFlagsVertical; }
            set { Base_obj.SizeFlagsVertical = value; }
        }

        [ContextProperty("Выравнивание", "Alignment")]
        public int Alignment
        {
            get { return Base_obj.Alignment; }
            set { Base_obj.Alignment = value; }
        }

        [ContextProperty("ГоризонтальноеВыравнивание", "IconAlignment")]
        public int IconAlignment
        {
            get { return Base_obj.IconAlignment; }
            set { Base_obj.IconAlignment = value; }
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

        [ContextProperty("Значок", "Icon")]
        public GfImageTexture Icon
        {
            get { return Base_obj.Icon; }
            set { Base_obj.Icon = value; }
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

        [ContextProperty("НаправлениеТекста", "TextDirection")]
        public int TextDirection
        {
            get { return Base_obj.TextDirection; }
            set { Base_obj.TextDirection = value; }
        }

        [ContextProperty("ОбрезкаТекста", "ClipText")]
        public bool ClipText
        {
            get { return Base_obj.ClipText; }
            set { Base_obj.ClipText = value; }
        }

        [ContextProperty("Отключено", "Disabled")]
        public bool Disabled
        {
            get { return Base_obj.Disabled; }
            set { Base_obj.Disabled = value; }
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

        [ContextProperty("Плоский", "Flat")]
        public bool Flat
        {
            get { return Base_obj.Flat; }
            set { Base_obj.Flat = value; }
        }

        [ContextProperty("ПоведениеПриПереполнении", "TextOverrunBehavior")]
        public int TextOverrunBehavior
        {
            get { return Base_obj.TextOverrunBehavior; }
            set { Base_obj.TextOverrunBehavior = value; }
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

        [ContextProperty("РазвернутьЗначок", "ExpandIcon")]
        public bool ExpandIcon
        {
            get { return Base_obj.ExpandIcon; }
            set { Base_obj.ExpandIcon = value; }
        }

        [ContextProperty("Размер", "Size")]
        public GfVector2 Size
        {
            get { return Base_obj.Size; }
            set { Base_obj.Size = value; }
        }

        [ContextProperty("РежимПереключателя", "ToggleMode")]
        public bool ToggleMode
        {
            get { return Base_obj.ToggleMode; }
            set { Base_obj.ToggleMode = value; }
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

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("Тема", "Theme")]
        public GfThemeButton Theme
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

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfButton" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
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

        [ContextMethod("ПолучитьРежимОтрисовки", "GetDrawMode")]
        public int GetDrawMode()
        {
            return Base_obj.GetDrawMode();
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

        [ContextMethod("ПрограммноНажать", "ProgrammPressed")]
        public void ProgrammPressed()
        {
            Base_obj.ProgrammPressed();
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

        [ContextProperty("КнопкаВверх", "ButtonUp")]
        public IValue ButtonUp
        {
            get { return Base_obj.ButtonUp; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }

        [ContextProperty("КнопкаВниз", "ButtonDown")]
        public IValue ButtonDown
        {
            get { return Base_obj.ButtonDown; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }

        [ContextProperty("МышьНадЭлементом", "MouseEntered")]
        public IValue MouseEntered
        {
            get { return Base_obj.MouseEntered; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }

        [ContextProperty("МышьПокинулаЭлемент", "MouseExited")]
        public IValue MouseExited
        {
            get { return Base_obj.MouseExited; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }

        [ContextProperty("Нажатие", "Pressed")]
        public IValue Pressed
        {
            get { return Base_obj.Pressed; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }

        [ContextProperty("ПриПереключении", "Toggled")]
        public IValue Toggled
        {
            get { return Base_obj.Toggled; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }

        [ContextProperty("ПриПеремещенииМыши", "MouseMove")]
        public IValue MouseMove
        {
            get { return Base_obj.MouseMove; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }

        [ContextProperty("РазмерИзменен", "Resized")]
        public IValue Resized
        {
            get { return Base_obj.Resized; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }

        [ContextProperty("ФокусПолучен", "FocusEntered")]
        public IValue FocusEntered
        {
            get { return Base_obj.FocusEntered; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }

        [ContextProperty("ФокусПотерян", "FocusExited")]
        public IValue FocusExited
        {
            get { return Base_obj.FocusExited; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }
    }
}
