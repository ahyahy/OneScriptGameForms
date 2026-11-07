using OneScript.Contexts;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфПрямоугольник2", "GfRect2")]
    public class GfRect2 : AutoContext<GfRect2>
    {
        public GfRect2()
        {
        }

        [ContextProperty("Конец", "End")]
        public GfVector2 End
        {
            get
            {
                GfVector2 vector2 = new GfVector2();
                vector2.X = Position.X + Size.X;
                vector2.Y = Position.Y + Size.Y;
                return vector2;
            }
            set
            {
                decimal newX = value.X;
                decimal newY = value.Y;
                decimal oldX = Position.X;
                decimal oldY = Position.Y;
                decimal deltaX = newX - oldX;
                decimal deltaY = newY - oldY;
                Size.X = Position.X + deltaX;
                Size.Y = Position.Y + deltaY;
            }
        }

        [ContextProperty("Позиция", "Position")]
        public GfVector2 Position { get; set; } = new GfVector2();

        [ContextProperty("Размер", "Size")]
        public GfVector2 Size { get; set; } = new GfVector2();

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfRect2" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("ПолучитьЦентр", "GetCenter")]
        public GfVector2 GetCenter()
        {
            decimal newX = Position.X + (Size.X / 2);
            decimal newY = Position.Y + (Size.Y / 2);
            return new GfVector2(newX, newY);
        }
    }
}
