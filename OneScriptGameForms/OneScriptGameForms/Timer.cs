using OneScript.Contexts;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class Timer : osgf.Node
    {
        public GfTimer dll_obj;
        private osgf.Node m_Timer;

        public osgf.Node M_Timer
        {
            get { return m_Timer; }
            set
            {
                m_Timer = value;
                base.M_Node = m_Timer;
            }
        }

        public Timer()
        {
            OsUtils.CreateGodotObject(this);
        }

        public decimal WaitTime
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public bool Paused
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public void Start(int timeSec = -1)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "time_sec", timeSec },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void Stop()
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

        public bool IsStopped()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("IsStopped", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            return ((JsonElement)answer["report"]).GetBoolean();
        }

        public GfAction Timeout
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }

    [ContextClass("ИфТаймер", "GfTimer")]
    public class GfTimer : AutoContext<GfTimer>
    {
        public osgf.Timer Base_obj;

        public GfTimer()
        {
            Timer Timer1 = new Timer();
            Timer1.dll_obj = this;
            Base_obj = Timer1;
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
        }

        public decimal waitTime = 1000;
        [ContextProperty("Интервал", "WaitTime")]
        public decimal WaitTime
        {
            get { return waitTime; }
            set
            {
                waitTime = value;
                Base_obj.WaitTime = (value / 1000);
            }
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

        [ContextProperty("Приостановлен", "Paused")]
        public bool Paused
        {
            get { return Base_obj.Paused; }
            set { Base_obj.Paused = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfTimer" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("Начать", "Start")]
        public void Start(int p1 = -1)
        {
            Base_obj.Start(p1);
        }

        [ContextMethod("Остановить", "Stop")]
        public void Stop()
        {
            Base_obj.Stop();
        }

        [ContextMethod("Остановлен", "IsStopped")]
        public bool IsStopped()
        {
            return Base_obj.IsStopped();
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

        [ContextProperty("ПриСрабатыванииТаймера", "Timeout")]
        public IValue Timeout
        {
            get { return Base_obj.Timeout; }
            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
        }
    }
}
