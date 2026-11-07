using OneScript.Contexts;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфПрямоугольник2ц", "GfRect2i")]
    public class GfRect2i : AutoContext<GfRect2i>
    {
        public GfRect2i()
        {
        }

        [ContextProperty("Конец", "End")]
        public GfVector2i End
        {
            get
            {
                GfVector2i vector2i = new GfVector2i();
                vector2i.X = Position.X + Size.X;
                vector2i.Y = Position.Y + Size.Y;
                return vector2i;
            }
            set
            {
                int newX = value.X;
                int newY = value.Y;
                int oldX = Position.X;
                int oldY = Position.Y;
                int deltaX = newX - oldX;
                int deltaY = newY - oldY;
                Size.X = Position.X + deltaX;
                Size.Y = Position.Y + deltaY;
            }
        }

        [ContextProperty("Позиция", "Position")]
        public GfVector2i Position { get; set; } = new GfVector2i();

        [ContextProperty("Размер", "Size")]
        public GfVector2i Size { get; set; } = new GfVector2i();

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfRect2i" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }
    }
}
