using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфАргументыСобытия", "GfEventArgs")]
    public class GfEventArgs : AutoContext<GfEventArgs>
    {
        public IValue parameter;
        public IValue sender = null;
        public GfAction eventAction;
        public GfVector2 position = null;
        public bool pressed;
        public IValue modifiersMask = null;
        public IValue keycode = null;
        public IValue mouseButton = null;
        public IValue mouseButtonMask = null;
        public bool toggledOn;

        public GfEventArgs()
        {
        }

        public GfEventArgs(GfEventArgs p1)
        {
            parameter = p1.Parameter;
        }

        public GfAction EventAction
        {
            get { return eventAction; }
        }

        [ContextProperty("Включено", "ToggledOn")]
        public bool ToggledOn
        {
            get { return toggledOn; }
        }

        [ContextProperty("КнопкаМыши", "MouseButton")]
        public IValue MouseButton
        {
            get { return mouseButton; }
        }

        [ContextProperty("КодКлавиши", "Keycode")]
        public IValue Keycode
        {
            get { return keycode; }
        }

        [ContextProperty("МаскаКнопокМыши", "MouseButtonMask")]
        public IValue MouseButtonMask
        {
            get { return mouseButtonMask; }
        }

        [ContextProperty("Модификаторы", "ModifiersMask")]
        public IValue ModifiersMask
        {
            get { return modifiersMask; }
        }

        [ContextProperty("Отправитель", "Sender")]
        public IValue Sender
        {
            get { return sender; }
        }

        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter
        {
            get { return parameter; }
        }

        [ContextProperty("Позиция", "Position")]
        public GfVector2 Position
        {
            get { return position; }
        }

        [ContextProperty("ЭтоНажатие", "Pressed")]
        public bool Pressed
        {
            get { return pressed; }
        }
    }
}
