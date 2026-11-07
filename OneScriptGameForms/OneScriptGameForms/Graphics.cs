using OneScript.Contexts;
using OneScript.StandardLibrary.Collections;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Reflection;

namespace osgf
{
    public class Graphics : osgf.CanvasItem
    {
        public GfGraphics dll_obj;
        private osgf.CanvasItem m_Graphics;

        public osgf.CanvasItem M_Graphics
        {
            get { return m_Graphics; }
            set
            {
                m_Graphics = value;
                base.M_CanvasItem = m_Graphics;
            }
        }

        public Graphics()
        {
            OsUtils.CreateGodotObject(this);
        }

        public GfColor OverrideColor(GfColor mod)
        {
            if (mod == null)
            {
                mod = new GfColor();
                mod.R = 255;
                mod.G = 255;
                mod.B = 255;
                mod.A = 255;
            }
            return mod;
        }

        public void Clear()
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

        public void DrawCircle(GfVector2 Position, decimal Radius, GfColor Color, bool Filled, decimal Width, bool Antialiased)
        {
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Position, Radius, Color, Filled, Width, Antialiased);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawRect(GfRect2 Rect2, GfColor Color, bool Filled, decimal Width, bool Antialiased)
        {
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Rect2, Color, Filled, Width, Antialiased);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawEllipse(GfVector2 Position, decimal Major, decimal Minor, GfColor Color, bool Filled, decimal Width, bool Antialiased)
        {
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Position, Major, Minor, Color, Filled, Width, Antialiased);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawLine(GfVector2 From, GfVector2 To, GfColor Color, decimal Width, bool Antialiased)
        {
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                From, To, Color, Width, Antialiased);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawArc(GfVector2 Center, decimal Radius, decimal StartAngle, decimal EndAngle, int PointCount, GfColor Color, decimal Width, bool Antialiased)
        {
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Center, Radius, StartAngle, EndAngle, PointCount, Color, Width, Antialiased);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawChar(string Font, GfVector2 Position, string Char, int FontSize, GfColor Modulate, decimal Oversampling)
        {
            Modulate = OverrideColor(Modulate);
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Font, Position, Char, FontSize, Modulate, Oversampling);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawCharOutline(string Font, GfVector2 Position, string Char, int FontSize, int OutlineSize, GfColor Modulate, decimal Oversampling)
        {
            Modulate = OverrideColor(Modulate);
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Font, Position, Char, FontSize, OutlineSize, Modulate, Oversampling);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawPolygon(GfDictionary PointsAndColors, ArrayImpl TexturePoints, Texture Texture)
        {
            if (!OsUtils.AllNotNull(TexturePoints))
            {
                TexturePoints = new ArrayImpl();
            }
            string textureItemKey = String.Empty;
            if (OsUtils.AllNotNull(Texture))
            {
                textureItemKey = Texture.ItemKey;
            }
            float[][] pointsArray = new float[PointsAndColors.CountProp][];
            float[][] colorsArray = new float[PointsAndColors.CountProp][];
            for (int i = 0; i < PointsAndColors.CountProp; i++)
            {
                var item = PointsAndColors.Base_obj.M_Dictionary.ElementAt(i);
                GfVector2 point = item.Key as GfVector2;
                float[] pointArray = { OsUtils.ToFloat(point.X), OsUtils.ToFloat(point.Y) };
                pointsArray[i] = pointArray;
                GfColor color = item.Value as GfColor;
                float[] colorArray = { OsUtils.ToFloat(color.R) / 255f, OsUtils.ToFloat(color.G) / 255f, OsUtils.ToFloat(color.B) / 255f, OsUtils.ToFloat(color.A) / 255f };
                colorsArray[i] = colorArray;
            }
            Dictionary<string, object> Properties = new Dictionary<string, object>();
            Response response = new Response();
            Properties.Add("element", OsUtils.CastToDataType(ItemKey));
            Properties.Add("Points", OsUtils.CastToDataType(pointsArray));
            Properties.Add("Colors", OsUtils.CastToDataType(colorsArray));
            Properties.Add("TexturePoints", OsUtils.CastToDataType(TexturePoints));
            Properties.Add("Texture", OsUtils.CastToDataType(textureItemKey));
            response.Properties = Properties;
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawColoredPolygon(ArrayImpl Points, GfColor Color, ArrayImpl TexturePoints, Texture Texture)
        {
            if (!OsUtils.AllNotNull(TexturePoints))
            {
                TexturePoints = new ArrayImpl();
            }
            string textureItemKey = String.Empty;
            if (OsUtils.AllNotNull(Texture))
            {
                textureItemKey = Texture.ItemKey;
            }
            Dictionary<string, object> Properties = new Dictionary<string, object>();
            Response response = new Response();
            Properties.Add("element", OsUtils.CastToDataType(ItemKey));
            Properties.Add("Points", OsUtils.CastToDataType(Points));
            Properties.Add("Color", OsUtils.CastToDataType(Color));
            Properties.Add("TexturePoints", OsUtils.CastToDataType(TexturePoints));
            Properties.Add("Texture", OsUtils.CastToDataType(textureItemKey));
            response.Properties = Properties;
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawDashedLine(GfVector2 From, GfVector2 To, GfColor Color, decimal Width, decimal DashLength, bool Aligned, bool Antialiased)
        {
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                From, To, Color, Width, DashLength, Aligned, Antialiased);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawEllipseArc(GfVector2 Center, decimal Major, decimal Minor, decimal StartAngle, decimal EndAngle, int PointCount, GfColor Color, decimal Width, bool Antialiased)
        {
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Center, Major, Minor, StartAngle, EndAngle, PointCount, Color, Width, Antialiased);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawMultiline(GfDictionary Points, GfColor Color, decimal Width, bool Antialiased)
        {
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Points, Color, Width, Antialiased);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawPolyline(ArrayImpl Points, GfColor Color, decimal Width, bool Antialiased)
        {
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Points, Color, Width, Antialiased);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawPolylineColors(GfDictionary PointsAndColors, decimal Width, bool Antialiased)
        {
            float[][] pointsArray = new float[PointsAndColors.CountProp][];
            float[][] colorsArray = new float[PointsAndColors.CountProp][];
            for (int i = 0; i < PointsAndColors.CountProp; i++)
            {
                var item = PointsAndColors.Base_obj.M_Dictionary.ElementAt(i);
                GfVector2 point = item.Key as GfVector2;
                float[] pointArray = { OsUtils.ToFloat(point.X), OsUtils.ToFloat(point.Y) };
                pointsArray[i] = pointArray;
                GfColor color = item.Value as GfColor;
                float[] colorArray = { OsUtils.ToFloat(color.R) / 255f, OsUtils.ToFloat(color.G) / 255f, OsUtils.ToFloat(color.B) / 255f, OsUtils.ToFloat(color.A) / 255f };
                colorsArray[i] = colorArray;
            }
            Dictionary<string, object> Properties = new Dictionary<string, object>();
            Response response = new Response();
            Properties.Add("element", OsUtils.CastToDataType(ItemKey));
            Properties.Add("Points", OsUtils.CastToDataType(pointsArray));
            Properties.Add("Colors", OsUtils.CastToDataType(colorsArray));
            Properties.Add("Width", OsUtils.CastToDataType(Width));
            Properties.Add("Antialiased", OsUtils.CastToDataType(Antialiased));
            response.Properties = Properties;
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawMultilineColors(GfDictionary LinesAndColorsDict, decimal Width, bool Antialiased)
        {
            // Создаем массив объектов для сериализации
            var pointsAndColorsArray = new List<Dictionary<string, object>>();
            foreach (System.Collections.Generic.KeyValuePair<object, object> de in LinesAndColorsDict.Base_obj.M_Dictionary)
            {
                // Ключ и Значение из словаря OneScript
                IValue keyIV = (IValue)de.Key;
                IValue valueIV = (IValue)de.Value;
                // Преобразуем Ключ (пара точек) в JSON-совместимый формат [[x1,y1], [x2,y2]]
                var keyArray = new List<float[]>();
                if (keyIV is GfEntry gfEntryKey)
                {
                    // Ключ - это GfVector2, представляем как [x, y]
                    GfVector2 vecStart = gfEntryKey.Key as GfVector2;
                    GfVector2 vecEnd = gfEntryKey.ValueProp as GfVector2;
                    if (vecStart != null && vecEnd != null)
                    {
                        keyArray.Add(new float[] { OsUtils.ToFloat(vecStart.X), OsUtils.ToFloat(vecStart.Y) });
                        keyArray.Add(new float[] { OsUtils.ToFloat(vecEnd.X), OsUtils.ToFloat(vecEnd.Y) });
                    }
                }
                // Преобразуем Значение (цвет) в JSON-совместимый формат [r,g,b,a]
                var valueArray = new List<float>();
                if (valueIV is GfColor gfColor)
                {
                    valueArray.Add(OsUtils.ToFloat(gfColor.R) / 255f);
                    valueArray.Add(OsUtils.ToFloat(gfColor.G) / 255f);
                    valueArray.Add(OsUtils.ToFloat(gfColor.B) / 255f);
                    valueArray.Add(OsUtils.ToFloat(gfColor.A) / 255f);
                }
                // Создаем объект записи
                pointsAndColorsArray.Add(new Dictionary<string, object>
                {
                    { "Key", keyArray },
                    { "Value", valueArray }
                });
            }
            Dictionary<string, object> Properties = new Dictionary<string, object>();
            Response response = new Response();
            Properties.Add("element", OsUtils.CastToDataType(ItemKey));
            Properties.Add("PointsArray", OsUtils.CastToDataType(pointsAndColorsArray));
            Properties.Add("ColorsArray", OsUtils.CastToDataType(pointsAndColorsArray));
            Properties.Add("Width", OsUtils.CastToDataType(Width));
            Properties.Add("Antialiased", OsUtils.CastToDataType(Antialiased));
            response.Properties = Properties;
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawMultilineString(string Font, GfVector2 Position, string Text, int Alignment, decimal Width, int FontSize, int MaxLines, GfColor Modulate, int BrkFlags, int JustificationFlags, int Direction, int Orientation, decimal Oversampling)
        {
            Modulate = OverrideColor(Modulate);
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Font, Position, Text, Alignment, Width, FontSize, MaxLines, Modulate, BrkFlags, JustificationFlags, Direction, Orientation, Oversampling);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawMultilineStringOutline(string Font, GfVector2 Position, string Text, int Alignment, decimal Width, int FontSize, int MaxLines, int OutlineSize, GfColor Modulate, int BrkFlags, int JustificationFlags, int Direction, int Orientation, decimal Oversampling)
        {
            Modulate = OverrideColor(Modulate);
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Font, Position, Text, Alignment, Width, FontSize, MaxLines, OutlineSize, Modulate, BrkFlags, JustificationFlags, Direction, Orientation, Oversampling);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawString(string Font, GfVector2 Position, string Text, int Alignment, decimal Width, int FontSize, GfColor Modulate, int JustificationFlags, int Direction, int Orientation, decimal Oversampling)
        {
            Modulate = OverrideColor(Modulate);
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Font, Position, Text, Alignment, Width, FontSize, Modulate, JustificationFlags, Direction, Orientation, Oversampling);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawStringOutline(string Font, GfVector2 Position, string Text, int Alignment, decimal Width, int FontSize, int OutlineSize, GfColor Modulate, int JustificationFlags, int Direction, int Orientation, decimal Oversampling)
        {
            Modulate = OverrideColor(Modulate);
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Font, Position, Text, Alignment, Width, FontSize, OutlineSize, Modulate, JustificationFlags, Direction, Orientation, Oversampling);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawTexture(string Texture, GfVector2 Position, GfColor Modulate)
        {
            Modulate = OverrideColor(Modulate);
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Texture, Position, Modulate);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawTextureRect(string Texture, GfRect2 Rect2, bool Tile, GfColor Modulate, bool Transpose)
        {
            Modulate = OverrideColor(Modulate);
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Texture, Rect2, Tile, Modulate, Transpose);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawTextureRectRegion(string Texture, GfRect2 DestRect, GfRect2 SrcRect, GfColor Modulate, bool Transpose, bool ClipUv)
        {
            Modulate = OverrideColor(Modulate);
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Texture, DestRect, SrcRect, Modulate, Transpose, ClipUv);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        public void DrawSetTransform(GfVector2 Position, decimal Rotation, GfVector2 Scale)
        {
            if (Scale == null)
            {
                Scale = new GfVector2(1, 1);
            }
            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
                Position, Rotation, Scale);
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }
    }

    [ContextClass("ИфГрафика", "GfGraphics")]
    public class GfGraphics : AutoContext<GfGraphics>
    {
        public osgf.Graphics Base_obj;

        public GfGraphics()
        {
            Graphics Graphics1 = new Graphics();
            Graphics1.dll_obj = this;
            Base_obj = Graphics1;
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

        [ContextProperty("ЦветМодуляции", "Modulate")]
        public GfColor Modulate
        {
            get { return Base_obj.Modulate; }
            set { Base_obj.Modulate = value; }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public new GfString ToString()
        {
            return new GfString("GfGraphics" + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
        }

        [ContextMethod("ДобавитьДочерний", "AddChild")]
        public IValue AddChild(IValue p1)
        {
            return Base_obj.AddChild(p1);
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

        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            Base_obj.Clear();
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

        [ContextMethod("ПолучитьУзел", "GetNode")]
        public IValue GetNode(string p1)
        {
            return Base_obj.GetNode(p1);
        }

        [ContextMethod("Преобразовать", "DrawSetTransform")]
        public void DrawSetTransform(GfVector2 pos, decimal rotation = 0, GfVector2 scale = null)
        {
            Base_obj.DrawSetTransform(pos, rotation, scale);
        }

        [ContextMethod("РисоватьДугу", "DrawArc")]
        public void DrawArc(GfVector2 center, decimal radius, decimal startAngle, decimal endAngle, int pointCount, GfColor color, decimal width = -1.0m, bool antialiased = false)
        {
            Base_obj.DrawArc(center, radius, startAngle, endAngle, pointCount, color, width, antialiased);
        }

        [ContextMethod("РисоватьКруг", "DrawCircle")]
        public void DrawCircle(GfVector2 position, decimal radius, GfColor color, bool filled = true, decimal width = -1.0m, bool antialiased = false)
        {
            Base_obj.DrawCircle(position, radius, color, filled, width, antialiased);
        }

        [ContextMethod("РисоватьЛинию", "DrawLine")]
        public void DrawLine(GfVector2 from, GfVector2 to, GfColor color, decimal width = -1.0m, bool antialiased = false)
        {
            Base_obj.DrawLine(from, to, color, width, antialiased);
        }

        [ContextMethod("РисоватьМногострочныйТекст", "DrawMultilineString")]
        public void DrawMultilineString(IValue font, GfVector2 pos, string text, int alignment = 0, decimal width = -1.0m, int fontSize = 16, int maxLines = -1, GfColor modulate = null, int brkFlags = 3, int justificationFlags = 3, int direction = 0, int orientation = 0, decimal oversampling = 0.0m)
        {
            Base_obj.DrawMultilineString(((dynamic)font).ItemKey, pos, text, alignment, width, fontSize, maxLines, modulate, brkFlags, justificationFlags, direction, orientation, oversampling);
        }

        [ContextMethod("РисоватьМногострочныйТекстКонтуром", "DrawMultilineStringOutline")]
        public void DrawMultilineStringOutline(IValue font, GfVector2 pos, string text, int alignment = 0, decimal width = -1.0m, int fontSize = 16, int maxLines = -1, int outlineSize = 1, GfColor modulate = null, int brkFlags = 3, int justificationFlags = 3, int direction = 0, int orientation = 0, decimal oversampling = 0.0m)
        {
            Base_obj.DrawMultilineStringOutline(((dynamic)font).ItemKey, pos, text, alignment, width, fontSize, maxLines, outlineSize, modulate, brkFlags, justificationFlags, direction, orientation, oversampling);
        }

        [ContextMethod("РисоватьМногоугольник", "DrawPolygon")]
        public void DrawPolygon(GfDictionary pointsAndColors, ArrayImpl texturePoints = null, IValue texture = null)
        {
            Base_obj.DrawPolygon(pointsAndColors, texturePoints, ((dynamic)texture).Base_obj);
        }

        [ContextMethod("РисоватьМультилинию", "DrawMultiline")]
        public void DrawMultiline(GfDictionary pointsAndColors, GfColor color, decimal width = -1.0m, bool antialiased = false)
        {
            Base_obj.DrawMultiline(pointsAndColors, color, width, antialiased);
        }

        [ContextMethod("РисоватьПолилинию", "DrawPolyline")]
        public void DrawPolyline(ArrayImpl pointsLine, GfColor color, decimal width = -1.0m, bool antialiased = false)
        {
            Base_obj.DrawPolyline(pointsLine, color, width, antialiased);
        }

        [ContextMethod("РисоватьПрямоугольник", "DrawRect")]
        public void DrawRect(GfRect2 rect2, GfColor color, bool filled = true, decimal width = -1.0m, bool antialiased = false)
        {
            Base_obj.DrawRect(rect2, color, filled, width, antialiased);
        }

        [ContextMethod("РисоватьПунктирнуюЛинию", "DrawDashedLine")]
        public void DrawDashedLine(GfVector2 from, GfVector2 to, GfColor color, decimal width = -1.0m, decimal dash_length = 2.0m, bool aligned = true, bool antialiased = false)
        {
            Base_obj.DrawDashedLine(from, to, color, width, dash_length, aligned, antialiased);
        }

        [ContextMethod("РисоватьСимвол", "DrawChar")]
        public void DrawChar(IValue font, GfVector2 pos, string character, int fontSize = 16, GfColor modulate = null, decimal oversampling = 0.0m)
        {
            Base_obj.DrawChar(((dynamic)font).ItemKey, pos, character.Substring(0, 1), fontSize, modulate, oversampling);
        }

        [ContextMethod("РисоватьСимволКонтуром", "DrawCharOutline")]
        public void DrawCharOutline(IValue font, GfVector2 pos, string character, int fontSize = 16, int outlineSize = -1, GfColor modulate = null, decimal oversampling = 0.0m)
        {
            Base_obj.DrawCharOutline(((dynamic)font).ItemKey, pos, character.Substring(0, 1), fontSize, outlineSize, modulate, oversampling);
        }

        [ContextMethod("РисоватьСтроку", "DrawString")]
        public void DrawString(IValue font, GfVector2 pos, string text, int alignment = 0, decimal width = -1.0m, int fontSize = 16, GfColor modulate = null, int justificationFlags = 3, int direction = 0, int orientation = 0, decimal oversampling = 0.0m)
        {
            Base_obj.DrawString(((dynamic)font).ItemKey, pos, text, alignment, width, fontSize, modulate, justificationFlags, direction, orientation, oversampling);
        }

        [ContextMethod("РисоватьСтрокуКонтуром", "DrawStringOutline")]
        public void DrawStringOutline(IValue font, GfVector2 pos, string text, int alignment = 0, decimal width = -1.0m, int fontSize = 16, int outlineSize = 1, GfColor modulate = null, int justificationFlags = 3, int direction = 0, int orientation = 0, decimal oversampling = 0.0m)
        {
            Base_obj.DrawStringOutline(((dynamic)font).ItemKey, pos, text, alignment, width, fontSize, outlineSize, modulate, justificationFlags, direction, orientation, oversampling);
        }

        [ContextMethod("РисоватьТекстуру", "DrawTexture")]
        public void DrawTexture(IValue texture, GfVector2 pos, GfColor modulate = null)
        {
            Base_obj.DrawTexture(((dynamic)texture).ItemKey, pos, modulate);
        }

        [ContextMethod("РисоватьТекстуруПоПрямоугольнику", "DrawTextureRect")]
        public void DrawTextureRect(IValue texture, GfRect2 rect2, bool tile, GfColor modulate = null, bool transpose = false)
        {
            Base_obj.DrawTextureRect(((dynamic)texture).ItemKey, rect2, tile, modulate, transpose);
        }

        [ContextMethod("РисоватьЦветнойМногоугольник", "DrawColoredPolygon")]
        public void DrawColoredPolygon(ArrayImpl points, GfColor color, ArrayImpl texturePoints = null, IValue texture = null)
        {
            Base_obj.DrawColoredPolygon(points, color, texturePoints, ((dynamic)texture).Base_obj);
        }

        [ContextMethod("РисоватьЦветнуюМультилинию", "DrawMultilineColors")]
        public void DrawMultilineColors(GfDictionary linesAndColorsDict, decimal width = -1.0m, bool antialiased = false)
        {
            Base_obj.DrawMultilineColors(linesAndColorsDict, width, antialiased);
        }

        [ContextMethod("РисоватьЦветнуюПолилинию", "DrawPolylineColors")]
        public void DrawPolylineColors(GfDictionary linesAndColorsDict, decimal width = -1.0m, bool antialiased = false)
        {
            Base_obj.DrawPolylineColors(linesAndColorsDict, width, antialiased);
        }

        [ContextMethod("РисоватьЧастьТекстурыПоПрямоугольнику", "DrawTextureRectRegion")]
        public void DrawTextureRectRegion(IValue texture, GfRect2 destRect, GfRect2 srcRect, GfColor modulate = null, bool transpose = false, bool clipUv = true)
        {
            Base_obj.DrawTextureRectRegion(((dynamic)texture).ItemKey, destRect, srcRect, modulate, transpose, clipUv);
        }

        [ContextMethod("РисоватьЭллипс", "DrawEllipse")]
        public void DrawEllipse(GfVector2 position, decimal major, decimal minor, GfColor color, bool filled = true, decimal width = -1.0m, bool antialiased = false)
        {
            Base_obj.DrawEllipse(position, major, minor, color, filled, width, antialiased);
        }

        [ContextMethod("РисоватьЭллиптическуюДугу", "DrawEllipseArc")]
        public void DrawEllipseArc(GfVector2 center, decimal semiMajorAxis, decimal semiMinorAxis, decimal startAngle, decimal endAngle, int pointCount, GfColor color, decimal width = -1.0m, bool antialiased = false)
        {
            Base_obj.DrawEllipseArc(center, semiMajorAxis, semiMinorAxis, startAngle, endAngle, pointCount, color, width, antialiased);
        }

        [ContextMethod("УдалитьДочерний", "RemoveChild")]
        public void RemoveChild(IValue p1)
        {
            Base_obj.RemoveChild(p1);
        }
    }
}
