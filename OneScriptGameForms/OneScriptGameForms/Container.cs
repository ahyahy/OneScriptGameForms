using ScriptEngine.Machine;
using System.Reflection;

namespace osgf
{
    public class Container : osgf.Control
    {
        private osgf.Control m_Container;

        public osgf.Control M_Container
        {
            get { return m_Container; }
            set
            {
                m_Container = value;
                base.M_Control = m_Container;
            }
        }

        public void FitChildInRect(IValue p1, GfRect2 p2)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "childKeyItem", ((dynamic)p1).ItemKey },
                    { "position", new float[] { OsUtils.ToFloat(p2.Position.X), OsUtils.ToFloat(p2.Position.Y) } },
                    { "size", new float[] { OsUtils.ToFloat(p2.Size.X), OsUtils.ToFloat(p2.Size.Y) } },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }
    }
}
