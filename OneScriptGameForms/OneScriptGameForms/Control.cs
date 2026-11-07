using ScriptEngine.Machine;
using System.Reflection;
using System.Text.Json;

namespace osgf
{
    public class Control : osgf.CanvasItem
    {
        private osgf.CanvasItem m_Control;

        public osgf.CanvasItem M_Control
        {
            get { return m_Control; }
            set
            {
                m_Control = value;
                base.M_CanvasItem = m_Control;
            }
        }

        public IValue FocusPrevious
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue FocusNext
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue FocusNeighborTop
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue FocusNeighborLeft
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue FocusNeighborBottom
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public IValue FocusNeighborRight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal AnchorTop
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal AnchorLeft
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal AnchorBottom
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal AnchorRight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int SizeFlagsVertical
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int SizeFlagsHorizontal
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int SizeFlagsStretchRatio
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int OffsetTop
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int OffsetLeft
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int OffsetBottom
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public int OffsetRight
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2 Scale
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public decimal RotationDegrees
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2 Position
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfVector2 Size
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction MouseEntered
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction MouseExited
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction Resized
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction FocusEntered
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public GfAction FocusExited
        {
            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }

        public void AddThemeStyleboxOverride(string styleName, IValue styleBox)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "styleName", styleName.Split(':')[0] },
                    { "styleBoxItemKey", ((dynamic)styleBox).ItemKey },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void RemoveThemeStyleboxOverride(string styleName)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "styleName", styleName },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void WarpMouse(GfVector2 p1, decimal duration = 0.5m)
        {
            float[] position = { OsUtils.ToFloat(p1.X), OsUtils.ToFloat(p1.Y) };
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "position", position },
                    { "duration", duration / 1000 },
                }
            };
            OsUtils.GetAnswerSendCommand("ControlWarpMouse", response);
        }

        public void PlaceTop(IValue p1, int p2)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offset",  p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceBottom(IValue p1, int p2)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offset",  p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceLeft(IValue p1, int p2)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offset",  p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceRight(IValue p1, int p2)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offset",  p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceTopLeft(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetTop",  p2 },
                    { "offsetLeft",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceTopRight(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetTop",  p2 },
                    { "offsetRight",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceLeftTop(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetLeft",  p2 },
                    { "offsetTop",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceLeftBottom(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetLeft",  p2 },
                    { "offsetBottom",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceBottomLeft(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetBottom",  p2 },
                    { "offsetLeft",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceBottomRight(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetBottom",  p2 },
                    { "offsetRight",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceRightTop(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetRight",  p2 },
                    { "offsetTop",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void PlaceRightBottom(IValue p1, int p2, int p3)
        {
            string anchorItemKey = ((dynamic)p1).ItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "anchorItemKey",  anchorItemKey },
                    { "offsetRight",  p2 },
                    { "offsetBottom",  p3 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public IValue GetThemeStyleboxLine(string styleName)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "styleName",  styleName },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetThemeStyleboxLine", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                string styleBoxItemKey = ((JsonElement)answer["report"]).GetString();
                if (!GameForms.dictKeyEl.TryGetValue(styleBoxItemKey, out var styleBoxLine))

                {
                    if (styleBoxItemKey != String.Empty)
                    {
                        return new GfStyleBoxLine(styleBoxItemKey);
                    }
                    else
                    {
                        OsUtils.Echo("Не удалось выполнить метод ПолучитьСтильПанелиЛиния");
                        return null;
                    }
                }
                else
                {
                    return styleBoxLine.dll_obj;
                }
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ПолучитьСтильПанелиЛиния");
                return null;
            }
        }

        public IValue GetThemeStyleboxFlat(string styleName)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "styleName",  styleName },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetThemeStyleboxFlat", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                string styleBoxItemKey = ((JsonElement)answer["report"]).GetString();
                if (!GameForms.dictKeyEl.TryGetValue(styleBoxItemKey, out var styleBoxFlat))
                {
                    if (styleBoxItemKey != String.Empty)
                    {
                        return new GfStyleBoxFlat(styleBoxItemKey);
                    }
                    else
                    {
                        OsUtils.Echo("Не удалось выполнить метод ПолучитьСтильПанелиПлоский");
                        return null;
                    }
                }
                else
                {
                    return styleBoxFlat.dll_obj;
                }
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ПолучитьСтильПанелиПлоский");
                return null;
            }
        }

        public IValue GetThemeStyleboxEmpty(string styleName)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "styleName",  styleName },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetThemeStyleboxEmpty", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                string styleBoxItemKey = ((JsonElement)answer["report"]).GetString();
                if (!GameForms.dictKeyEl.TryGetValue(styleBoxItemKey, out var styleBoxEmpty))
                {
                    if (styleBoxItemKey != String.Empty)
                    {
                        return new GfStyleBoxEmpty(styleBoxItemKey);
                    }
                    else
                    {
                        OsUtils.Echo("Не удалось выполнить метод ПолучитьСтильПанелиПусто");
                        return null;
                    }
                }
                else
                {
                    return styleBoxEmpty.dll_obj;
                }
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ПолучитьСтильПанелиПусто");
                return null;
            }
        }

        public IValue GetThemeStyleboxTexture(string styleName)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "styleName",  styleName },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("GetThemeStyleboxTexture", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                string styleBoxItemKey = ((JsonElement)answer["report"]).GetString();
                if (!GameForms.dictKeyEl.TryGetValue(styleBoxItemKey, out var styleBoxTexture))
                {
                    if (styleBoxItemKey != String.Empty)
                    {
                        return new GfStyleBoxTexture(styleBoxItemKey);
                    }
                    else
                    {
                        OsUtils.Echo("Не удалось выполнить метод ПолучитьСтильПанелиТекстура");
                        return null;
                    }
                }
                else
                {
                    return styleBoxTexture.dll_obj;
                }
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ПолучитьСтильПанелиТекстура");
                return null;
            }
        }

        public void Center(decimal p1 = 0, decimal p2 = 0)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "shiftX",  p1 },
                    { "shiftY",  p2 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void SetCenterToPoint(GfVector2 p1)
        {
            float[] position = { OsUtils.ToFloat(p1.X), OsUtils.ToFloat(p1.Y) };
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                    { "position", position },
                }
            };
            OsUtils.GetAnswerSendCommand("SetCenterToPoint", response);
        }

        public void GrabFocus()
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

        public bool HasFocus()
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  this.ItemKey },
                }
            };
            string jsonResponse = OsUtils.Serialize(response);
            string res = GameForms.SendCommand("HasFocus", jsonResponse);
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            return ((JsonElement)answer["report"]).GetBoolean();
        }

        public int FocusMode
        {
            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
        }
    }
}
