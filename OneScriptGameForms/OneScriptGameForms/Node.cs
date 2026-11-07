using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class Node : osgf.GObject
    {
        private osgf.GObject m_Node;

        public osgf.GObject M_Node
        {
            get { return m_Node; }
            set
            {
                m_Node = value;
                base.M_GObject = m_Node;
            }
        }

        public string Name
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
        }

        public IValue AddChild(IValue p1)
        {
            string childItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "childItemKey",  childItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("AddChild", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                if (!GameForms.dictKeyEl.TryGetValue(childItemKey, out var childItem))
                {
                    if (GameForms.instance.DisplayServiceMessages)
                    {
                        OsUtils.Echo($"Элемент {childItemKey} не найден (2)");
                    }
                    return null;
                }
                else
                {
                    return childItem.dll_obj;
                }
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ДобавитьДочерний.");
                return null;
            }
        }

        public IValue RemoveChild(IValue p1)
        {
            string childItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "childItemKey",  childItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("RemoveChild", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                if (!GameForms.dictKeyEl.TryGetValue(childItemKey, out var childItem))
                {
                    if (GameForms.instance.DisplayServiceMessages)
                    {
                        OsUtils.Echo($"Элемент {childItemKey} не найден (2)");
                    }
                    return null;
                }
                else
                {
                    return childItem.dll_obj;
                }
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод УдалитьДочерний.");
                return null;
            }
        }

        public int ZIndex
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue GetWindow()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetWindow", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            string str = ((JsonElement)answer["report"]).GetString();

            if (!GameForms.dictKeyEl.TryGetValue(str, out var window))
            {
                if (GameForms.instance.DisplayServiceMessages)
                {
                    OsUtils.Echo($"Элемент {str} не найден (3)");
                }
                return null;
            }
            else
            {
                return window.dll_obj;
            }
        }

        public IValue GetNode(string name)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "name",  name },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetNode", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            string str = ((JsonElement)answer["report"]).GetString();
            if (!GameForms.dictKeyEl.TryGetValue(str, out var node))
            {
                if (GameForms.instance.DisplayServiceMessages)
                {
                    OsUtils.Echo($"Элемент {str} не найден (5)");
                }
                return null;
            }
            else
            {
                return node.dll_obj;
            }
        }

        public IValue GetParent()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetParent", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            string str = ((JsonElement)answer["report"]).GetString();
            if (!GameForms.dictKeyEl.TryGetValue(str, out var parent))
            {
                if (GameForms.instance.DisplayServiceMessages)
                {
                    OsUtils.Echo($"Элемент {str} не найден (4)");
                }
                return null;
            }
            else
            {
                return parent.dll_obj;
            }
        }

        public void SendToBack()
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

        public void BringToFront()
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

        public ArrayImpl GetChildren()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetChildren", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                ArrayImpl array = new ArrayImpl();
                var report = OsUtils.Deserialize(answer["report"].ToString());

                foreach (var item in report)
                {
                    var itemValue = (JsonElement)item.Value;
                    switch (item.Key)
                    {
                        case "children" when itemValue.ValueKind == JsonValueKind.Array:
                            for (int i = 0; i < itemValue.GetArrayLength(); i++)
                            {
                                try
                                {
                                    string _itemKey = itemValue[i].GetString();
                                    if (_itemKey == "<Object#null>")
                                    {
                                        array.Add(ValueFactory.CreateNullValue());
                                    }
                                    else
                                    {
                                        if (GameForms.dictKeyEl.TryGetValue(_itemKey, out var _item))
                                        {
                                            if (_item.dll_obj != null)
                                            {
                                                array.Add((IValue)_item.dll_obj);
                                            }
                                        }
                                    }
                                }
                                catch { }
                            }
                            break;
                    }
                }
                return array;
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ПолучитьДочерние.");
                return null;
            }
        }

        public void QueueFree()
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
    }
}
