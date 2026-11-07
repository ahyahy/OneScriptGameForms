using OneScript.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфДействие", "GfAction")]
    public class GfAction : AutoContext<GfAction>
    {
        public GfAction()
        {
        }

        public GfAction(IRuntimeContextInstance script, string methodName, IValue param = null)
        {
            Script = script;
            MethodName = methodName;
            Parameter = param;
        }

        [ContextProperty("ИмяМетода", "MethodName")]
        public string MethodName { get; set; }

        [ContextProperty("Параметр", "Parameter")]
        public IValue Parameter { get; set; }

        [ContextProperty("Сценарий", "Script")]
        public IRuntimeContextInstance Script { get; set; }
    }
}
