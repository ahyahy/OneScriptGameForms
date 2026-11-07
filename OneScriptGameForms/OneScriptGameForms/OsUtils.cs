using OneScript.StandardLibrary;
using OneScript.StandardLibrary.Collections;
using OneScript.Values;
using ScriptEngine.Machine;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace osgf
{
    public static class OsUtils
    {
        //OneScript.Values.BslBooleanValue
        //OneScript.Values.BslDateValue
        //OneScript.Values.BslNullValue
        //OneScript.Values.BslNumericValue
        //OneScript.Values.BslObjectValue
        //OneScript.Values.BslPrimitiveValue
        //OneScript.Values.BslStringValue
        //OneScript.Values.BslTypeValue
        //OneScript.Values.BslUndefinedValue

        public static bool IsString(IValue value) => value?.SystemType.Name == "Строка";
        public static bool IsNumber(IValue value) => value?.SystemType.Name == "Число";
        public static bool IsBoolean(IValue value) => value?.SystemType.Name == "Булево";
        public static bool IsDateTime(IValue value) => value?.SystemType.Name == "Дата";
        public static bool IsType<T>(IValue value) => value?.GetType() == typeof(T);
        public static bool IsType<T>(object value) => value?.GetType() == typeof(T);

        public static Dictionary<string, GfAction> ActionAlias = new Dictionary<string, GfAction>();

        public static Dictionary<string, object> Deserialize(string obj)
        {
            Dictionary<string, object> answer = JsonSerializer.Deserialize<Dictionary<string, object>>(obj);
            return answer;
        }

        private static string SerializeWithUnicode(object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }

        public static string Serialize(Dictionary<string, object> obj)
        {
            return SerializeWithUnicode(obj);
        }

        public static string Serialize(Response obj)
        {
            return SerializeWithUnicode(obj);
        }

        public static string ClipboardGet()
        {
            string res = GameForms.SendCommand("ClipboardGet");
            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                return ((JsonElement)answer["report"]).GetString();
            }
            else
            {
                OsUtils.Echo("Не удалось выполнить метод ПолучитьТекстБуфераОбмена.");
                return null;
            }
        }

        public static void ClipboardSet(string p1)
        {
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "textToClipboard",  p1 },
                }
            };
            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
        }

        private static string GetGodotPropertyName(MethodBase currentMethod)
        {
            string methodName = currentMethod.Name.Replace("set_", "").Replace("get_", "");
            var sb = new StringBuilder();
            for (int i = 0; i < methodName.Length; i++)
            {
                char c = methodName[i];
                if (char.IsUpper(c) && i > 0)
                {
                    sb.Append('_');
                }
                sb.Append(char.ToLower(c));
            }
            return sb.ToString();
        }

        public static string GetCSharpName(string godotName)
        {
            if (string.IsNullOrEmpty(godotName))
            {
                return godotName;
            }

            var sb = new StringBuilder(godotName.Length);
            bool nextUpper = false;
            bool firstCharSet = false;

            for (int i = 0; i < godotName.Length; i++)
            {
                char c = godotName[i];

                if (c == '_')
                {
                    nextUpper = true;
                    continue;
                }

                if (nextUpper)
                {
                    sb.Append(char.ToUpperInvariant(c));
                    nextUpper = false;
                    firstCharSet = true;
                }
                else
                {
                    // Первую букву делаем заглавной, остальные — как есть
                    if (!firstCharSet)
                    {
                        sb.Append(char.ToUpperInvariant(c));
                        firstCharSet = true;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }
            return sb.ToString();
        }

        public static string GetGodotName(string name)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                if (char.IsUpper(c) && i > 0)
                {
                    sb.Append('_');
                }
                sb.Append(char.ToLower(c));
            }
            return sb.ToString();
        }

        private static string GetGameFormsPropertyName(MethodBase currentMethod)
        {
            return currentMethod.Name.Replace("set_", "").Replace("get_", "");
        }

        public static object ConvertValueForGameForms(dynamic report)
        {
            string strPropertyType = ((JsonElement)report["propertyType"]).GetString();
            var itemValue = (JsonElement)report["propertyValue"];
            Type type = Type.GetType(strPropertyType);
            if (type == Type.GetType("osgf.GfColor"))
            {
                GfColor color = new GfColor()
                {
                    R = OsUtils.ToInt32(itemValue[0].GetSingle() * 255),
                    G = OsUtils.ToInt32(itemValue[1].GetSingle() * 255),
                    B = OsUtils.ToInt32(itemValue[2].GetSingle() * 255),
                    A = OsUtils.ToInt32(itemValue[3].GetSingle() * 255),
                };
                return color;
            }
            else if (type == Type.GetType("osgf.GfFontVariation"))
            {
                GameForms.dictKeyEl.TryGetValue(itemValue.GetString(), out var fontVariation);
                return fontVariation.dll_obj;
            }
            else if (type == Type.GetType("osgf.GfTheme"))
            {
                GameForms.dictKeyEl.TryGetValue(itemValue.GetString(), out var theme);
                return theme.dll_obj;
            }
            else if (type == Type.GetType("osgf.GfImageTexture"))
            {
                GameForms.dictKeyEl.TryGetValue(itemValue.GetString(), out var imageTexture);
                return imageTexture.dll_obj;
            }
            else if (type == Type.GetType("System.String"))
            {
                return itemValue.GetString();
            }
            else if (type == Type.GetType("System.Decimal"))
            {
                return itemValue.GetDecimal();
            }
            else if (type == Type.GetType("System.Int32"))
            {
                return itemValue.GetInt32();
            }
            else if (type == Type.GetType("System.Boolean"))
            {
                return itemValue.GetBoolean();
            }
            else if (type == Type.GetType("osgf.GfVector2"))
            {
                return new GfVector2(itemValue[0].GetDecimal(), itemValue[1].GetDecimal());
            }
            else if (type == Type.GetType("osgf.GfVector2i"))
            {
                return new GfVector2i(itemValue[0].GetInt32(), itemValue[1].GetInt32());
            }
            else if (type == Type.GetType("osgf.GfRect2"))
            {
                GfRect2 rect2 = new GfRect2();
                rect2.Position = new GfVector2(itemValue[0].GetDecimal(), itemValue[1].GetDecimal());
                rect2.Size = new GfVector2(itemValue[2].GetDecimal(), itemValue[3].GetDecimal());
                return rect2;
            }
            else
            {
                //return $"ConvertValueForGameForms - Не учтено значение для типа: {strPropertyType} - {report?.ToString()}";
                throw new NotSupportedException($"ConvertValueForGameForms - Не учтено значение для типа: {strPropertyType} - {report?.ToString()}");
            }
        }

        public static object ConvertValueForGodot(dynamic value)
        {
            if (value is GfVector2 vector2)
            {
                return new float[] { (float)vector2.X, (float)vector2.Y };
            }
            else if (value is GfFontVariation fontVariation)
            {
                return Convert.ToString(((dynamic)fontVariation).ItemKey);
            }
            else if (value is GfThemeScene themeScene)
            {
                return Convert.ToString(((dynamic)themeScene).ItemKey);
            }
            else if (value is GfStyleBoxFlat styleBoxFlat)
            {
                return Convert.ToString(((dynamic)styleBoxFlat).ItemKey);
            }
            else if (value is GfImageTexture imageTexture)
            {
                return Convert.ToString(imageTexture.ItemKey);
            }
            else if (value is GfVector2i vector2i)
            {
                return new int[] { vector2i.X, vector2i.Y };
            }
            else if (value is GfRect2 rect2)
            {
                return new float[] {
                    (float)rect2.Position.X, (float)rect2.Position.Y,
                    (float)rect2.Size.X, (float)rect2.Size.Y
                };
            }
            else if (value is GfColor color)
            {
                return new float[] { ToFloat(color.R) / 255f, ToFloat(color.G) / 255f, ToFloat(color.B) / 255f, ToFloat(color.A) / 255f };
            }
            else if (value is bool boolValue)
            {
                return boolValue;
            }
            else if (value is int || value is float || value is double || value is decimal)
            {
                return Convert.ToSingle(value);
            }
            else if (value is string)
            {
                return Convert.ToString(value);
            }
            else
            {
                //return $"ConvertValueForGodot - Не учтено значение для типа: {value.GetType} - {value?.ToString()}";
                throw new NotSupportedException($"ConvertValueForGodot - Не учтено значение для типа: {value.GetType} - {value?.ToString()}");
            }
        }

        public static void SetGodotProperty(MethodBase currentMethod, string itemKey, dynamic _value)
        {
            string propName = GetGodotPropertyName(currentMethod);
            object rez = ConvertValueForGodot(_value);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  itemKey },
                    { "propName", propName },
                    { "propValue", rez }
                }
            };
            GetAnswerSendCommand("SetProperty", response);
        }

        public static dynamic GetGodotProperty(MethodBase currentMethod, dynamic element)
        {
            string propName = GetGodotPropertyName(currentMethod);
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  element.ItemKey },
                    { "propName",  propName },
                }
            };
            string jsonResponse = Serialize(response);
            string res = GameForms.SendCommand("GetProperty", jsonResponse);
            var answer = Deserialize(Deserialize(res)["result"].ToString());
            if (answer["report"].ToString() == "<Object#null>")
            {
                return null;
            }
            var report = Deserialize(answer["report"].ToString());
            return ConvertValueForGameForms(report);
        }

        public static void SetGodotAction(MethodBase currentMethod, string itemKey, GfAction action)
        {
            string actionName = currentMethod.Name.Replace("set_", "").Replace("get_", "");
            string keyActionName = itemKey + "_" + actionName;

            bool actionIsNull = false;
            if (action.MethodName == "")
            {
                actionIsNull = true;
            }
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "element",  itemKey },
                    { "actionIsNull",  actionIsNull },
                }
            };
            string jsonResponse = Serialize(response);
            string res = GameForms.SendCommand(actionName, jsonResponse);
            var answer = Deserialize(Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                if (ActionAlias.ContainsKey(keyActionName))
                {
                    ActionAlias[keyActionName] = action;
                }
                else
                {
                    ActionAlias.Add(keyActionName, action);
                }
            }
            else
            {
                Echo($"Не удалось установить действие {actionName}");
            }
        }

        public static GfAction GetGodotAction(MethodBase currentMethod, string itemKey)
        {
            return ActionAlias[itemKey + "_" + currentMethod.Name.Replace("set_", "").Replace("get_", "")];
        }

        public static void SetSetter(MethodBase currentMethod, dynamic Base_obj, IValue value)
        {
            string actionName = currentMethod.Name.Replace("set_", "").Replace("get_", "");
            if (IsType<GfAction>(value))
            {
                Base_obj[actionName] = value as GfAction;
            }
            else if (IsType<OneScript.Values.BslUndefinedValue>(value))
            {
                Base_obj[actionName] = new GfAction(GameForms.instance, "");
            }
            else
            {
                Echo($"Свойство {actionName}: Неверный тип аргумента");
            }
        }

        public static void CreateGodotObject(object obj)
        {
            string objectType = obj.GetType().Name;
            string objItemKey = "d" + Path.GetRandomFileName().Replace(".", "");
            ((dynamic)obj).ItemKey = objItemKey;
            Response response = new Response
            {
                Properties = new Dictionary<string, object>
                {
                    { "itemKey",  objItemKey },
                    { "typeNode",  objectType },
                }
            };
            string jsonResponse = Serialize(response);
            string res = GameForms.SendCommand("CreateNode", jsonResponse);
            var answer = Deserialize(Deserialize(res)["result"].ToString());
            if (((JsonElement)answer["success"]).GetBoolean())
            {
                GameForms.dictKeyEl.TryAdd(objItemKey, obj);
                GameForms.dictElKey.TryAdd(obj, objItemKey);
            }
            else
            {
                Echo($"Не удалось создать объект {objectType}");
                ((dynamic)obj).dll_obj = null;
            }
        }

        public static bool AllNotNull(params IValue[] values)
        {
            foreach (var value in values)
            {
                if (value == null) return false;
            }
            return true;
        }

        public static bool AllNotNull(params string[] values)
        {
            foreach (var value in values)
            {
                if (value == null) return false;
            }
            return true;
        }

        public static bool AllNotNull(params object[] values)
        {
            foreach (var value in values)
            {
                if (value == null) return false;
            }
            return true;
        }

        public static dynamic DefineTypeIValue(dynamic p1)
        {
            if (p1.GetType() == typeof(OneScript.Values.BslStringValue))
            {
                return ValueFactory.Create(((BslStringValue)p1).ToString());
            }
            else if (p1.GetType() == typeof(OneScript.Values.BslNumericValue))
            {
                return ValueFactory.Create(((BslNumericValue)p1).AsNumber());
            }
            else if (p1.GetType() == typeof(OneScript.Values.BslBooleanValue))
            {
                return ValueFactory.Create(((BslBooleanValue)p1).AsBoolean());
            }
            else if (p1.GetType() == typeof(OneScript.Values.BslDateValue))
            {
                return ValueFactory.Create(((BslDateValue)p1).AsDate());
            }
            else
            {
                return p1;
            }
        }

        public static string[] ArrayImplToStringArray(ArrayImpl array)
        {
            int count = array.Count();
            string[] result = new string[count];
            for (int i = 0; i < count; i++)
            {
                string element = array.Get(i).ToString();
                result[i] = element;
            }
            return result;
        }

        public static ArrayImpl StringArrayToArrayImpl(string[] stringArray)
        {
            ArrayImpl array = new ArrayImpl();
            foreach (string value in stringArray)
            {
                array.Add(ValueFactory.Create(value));
            }
            return array;
        }

        public static ArrayImpl ListToArray(List<string> listString)
        {
            ArrayImpl array = new ArrayImpl();
            string[] stringArray = listString.ToArray();
            foreach (var value in stringArray)
            {
                array.Add(ValueFactory.Create(value));
            }
            return array;
        }

        public static List<string> ArrayImplToListArray(ArrayImpl array)
        {
            int count = array.Count();
            List<string> result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                string element = array.Get(i).ToString();
                result.Add(element);
            }
            return result;
        }

        public static int[] ArrayImplToInt32Array(ArrayImpl array)
        {
            int count = array.Count();
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                IValue element = array.Get(i);
                result[i] = ToInt32(element);
            }
            return result;
        }

        public static ArrayImpl IntArrayToArrayImpl(int[] intArray)
        {
            ArrayImpl array = new ArrayImpl();
            foreach (int value in intArray)
            {
                array.Add(ValueFactory.Create(value));
            }
            return array;
        }

        public static ArrayImpl FloatArrayToArrayImpl(float[] floatArray)
        {
            ArrayImpl array = new ArrayImpl();
            foreach (float value in floatArray)
            {
                array.Add(ValueFactory.Create(ToDecimal(value)));
            }
            return array;
        }

        public static float[] ArrayImplToFloatArray(ArrayImpl array)
        {
            int count = array.Count();
            float[] result = new float[count];
            for (int i = 0; i < count; i++)
            {
                IValue element = array.Get(i);
                result[i] = ToFloat(element);
            }
            return result;
        }

        public static byte[] ArrayImplToByteArray(ArrayImpl array)
        {
            int count = array.Count();
            byte[] result = new byte[count];
            for (int i = 0; i < count; i++)
            {
                IValue element = array.Get(i);
                decimal numberValue = element.AsNumber();
                result[i] = (byte)numberValue;
            }
            return result;
        }

        public static ArrayImpl ByteArrayToArrayImpl(byte[] byteArray)
        {
            ArrayImpl array = new ArrayImpl();
            foreach (byte value in byteArray)
            {
                array.Add(ValueFactory.Create((decimal)value));
            }
            return array;
        }

        public static float ToFloat(object num)
        {
            if (num.GetType() == typeof(BslNumericValue))
            {
                return Convert.ToSingle(((BslNumericValue)num).AsNumber());
            }
            return Convert.ToSingle(num);
        }

        public static byte ToByte(object num)
        {
            if (num.GetType() == typeof(BslNumericValue))
            {
                return Convert.ToByte(((BslNumericValue)num).AsNumber());
            }
            return Convert.ToByte(num);
        }

        public static int ToInt32(object num)
        {
            if (num.GetType() == typeof(BslNumericValue))
            {
                return Convert.ToInt32(((BslNumericValue)num).AsNumber());
            }
            return Convert.ToInt32(num);
        }

        public static int ToInt32(string str, int basis)
        {
            return Convert.ToInt32(str, basis);
        }

        public static int ToInt32(byte _byte)
        {
            return Convert.ToInt32(_byte);
        }

        public static decimal ToDecimal(object num)
        {
            if (num.GetType() == typeof(BslNumericValue))
            {
                return Convert.ToDecimal(((BslNumericValue)num).AsNumber());
            }
            return Convert.ToDecimal(num);
        }

        public static uint ToUInt32(object num)
        {
            if (num.GetType() == typeof(BslNumericValue))
            {
                return Convert.ToUInt32(((BslNumericValue)num).AsNumber());
            }
            return Convert.ToUInt32(num);
        }

        public static double ToDouble(object num)
        {
            if (num.GetType() == typeof(BslNumericValue))
            {
                return Convert.ToDouble(((BslNumericValue)num).AsNumber());
            }
            return Convert.ToDouble(num);
        }

        public static bool ToBoolean(object num)
        {
            if (num.GetType() == typeof(BslBooleanValue))
            {
                return Convert.ToBoolean(((BslBooleanValue)num).AsBoolean());
            }
            return Convert.ToBoolean(num);
        }

        public static string ToString(object obj)
        {
            return Convert.ToString(obj);
        }

        public static void WriteToFile(string str)
        {
            using (StreamWriter writer = new StreamWriter("C:\\444\\Log.txt", true, System.Text.Encoding.UTF8))
            {
                writer.WriteLineAsync("" + System.Environment.NewLine + DateTime.Now.ToString() + System.Environment.NewLine + str);
            }
        }

        public static void Echo(string p1, MessageStatusEnum status = MessageStatusEnum.Ordinary)
        {
            Console.WriteLine(p1);
        }

        public static string ToHex32(int val)
        {
            return Convert.ToByte(val).HexEncode();
        }

        public static string HexEncode(this byte b)
        {
            string text = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                int num = b & 0xF;
                char c = ((num >= 10) ? ((char)(97 + num - 10)) : ((char)(48 + num)));
                b >>= 4;
                text = c + text;
            }
            return text;
        }

        public static void GetAnswerSendCommand(string CommandSent, Response response)
        {
            string jsonResponse = Serialize(response);
            string res = GameForms.SendCommand(CommandSent, jsonResponse);
            var answer = Deserialize(Deserialize(res)["result"].ToString());
            try
            {
                if (!((JsonElement)answer["success"]).GetBoolean())
                {
                    Echo($"Не удалось выполнить метод {CommandSent}.");
                }
            }
            catch (Exception ex)
            {
                Echo($"Ошибка в OsUtils.GetResponse: {ex.StackTrace}");
            }
        }

        public static dynamic CastToDataType(dynamic obj)
        {
            if (IsType<GfVector2>(obj))
            {
                return new float[] { ToFloat(obj.X), ToFloat(obj.Y) };
            }
            else if (IsType<GfDictionary>(obj))
            {
                float[][] pointsArray = new float[obj.CountProp * 2][];
                for (int i = 0; i < obj.CountProp; i++)
                {
                    var item = ((GfDictionary)obj).Base_obj.M_Dictionary.ElementAt(i);
                    GfVector2 pointStart = item.Key as GfVector2;
                    float[] startArray = { ToFloat(pointStart.X), ToFloat(pointStart.Y) };
                    pointsArray[2 * i] = startArray;
                    GfVector2 pointEnd = item.Value as GfVector2;
                    float[] endArray = { ToFloat(pointEnd.X), ToFloat(pointEnd.Y) };
                    pointsArray[2 * i + 1] = endArray;
                }
                return pointsArray;
            }
            else if (IsType<ArrayImpl>(obj))
            {
                float[][] pointsArray = new float[obj.Count()][];
                for (int i = 0; i < obj.Count(); i++)
                {
                    var item = obj.Get(i);
                    GfVector2 point = item as GfVector2;
                    float[] pointArray = { ToFloat(point.X), ToFloat(point.Y) };
                    pointsArray[i] = pointArray;
                }
                return pointsArray;
            }
            else if (IsType<GfRect2>(obj))
            {
                return new float[] { ToFloat(((GfRect2)obj).Position.X), ToFloat(((GfRect2)obj).Position.Y), ToFloat(((GfRect2)obj).Size.X), ToFloat(((GfRect2)obj).Size.Y) };
            }
            else if (IsType<GfColor>(obj))
            {
                return new float[] { ToFloat(obj.R) / 255f, ToFloat(obj.G) / 255f, ToFloat(obj.B) / 255f, ToFloat(obj.A) / 255f };
            }
            else if (IsType<decimal>(obj))
            {
                return ToFloat(obj);
            }
            else if (IsType<int>(obj)
                || IsType<string>(obj)
                || IsType<bool>(obj)
                || IsType<List<Dictionary<string, object>>>(obj)
                || IsType<float[][]>(obj))
            {
                return obj;
            }
            else
            {
                Echo($"Ошибка получения значения {obj.ToString()} в методе CastToDataType.");
                return null;
            }
        }

        public static Response GetResponse(MethodBase currentMethod, string ItemKey, params object[] args)
        {
            Response response = new Response();
            ParameterInfo[] parameters = currentMethod.GetParameters();
            Dictionary<string, object> Properties = new Dictionary<string, object>();
            for (int i = 0; i < parameters.Length; i++)
            {
                Properties.Add(parameters[i].Name, CastToDataType(args[i]));
            }
            Properties.Add("element", ItemKey);
            response.Properties = Properties;
            return response;
        }

        public static ArrayImpl FindBetweenOptimized(
            string input,
            string fragment1 = null,
            string fragment2 = null,
            bool excludeFragments = true,
            bool noOverlap = true)
        {
            // Если оба фрагмента не заданы — возвращаем пустой массив
            if (fragment1 == null && fragment2 == null)
            {
                return new ArrayImpl();
            }
            var result = new ArrayImpl();
            var positions1 = fragment1 != null ? FindAllPositions(input, fragment1) : new List<int>();
            var positions2 = fragment2 != null ? FindAllPositions(input, fragment2) : new List<int>();
            // Случай 1: задан только фрагмент1
            if (fragment1 != null && fragment2 == null)
            {
                foreach (var pos in positions1)
                {
                    string extracted = excludeFragments
                        ? input.Substring(pos + fragment1.Length)
                        : input.Substring(pos);
                    result.Add(ValueFactory.Create(extracted));
                }
            }
            // Случай 2: задан только фрагмент2
            else if (fragment1 == null && fragment2 != null)
            {
                foreach (var pos in positions2)
                {
                    string extracted = excludeFragments
                        ? input.Substring(0, pos)
                        : input.Substring(0, pos + fragment2.Length);
                    result.Add(ValueFactory.Create(extracted));
                }
            }
            // Случай 3: заданы оба фрагмента
            else if (fragment1 != null && fragment2 != null)
            {
                foreach (var pos1 in positions1)
                {
                    // Ищем все fragment2, которые идут после fragment1
                    var validPos2 = positions2.FindAll(pos2 => pos2 > pos1);
                    foreach (var pos2 in validPos2)
                    {
                        // Проверяем условие отсутствия наложения
                        if (noOverlap && HasOverlap(input, pos1, pos2, fragment2))
                        {
                            continue;
                        }
                        string extracted = BuildResultSubstring(input, pos1, pos2, fragment1, fragment2, excludeFragments);
                        result.Add(ValueFactory.Create(extracted));
                    }
                }
            }
            return result;
        }

        // Вспомогательная функция: находит все позиции вхождения фрагмента в строке
        private static List<int> FindAllPositions(string input, string fragment)
        {
            var positions = new List<int>();
            int startIndex = 0;
            int pos;
            while ((pos = input.IndexOf(fragment, startIndex, StringComparison.Ordinal)) >= 0)
            {
                positions.Add(pos);
                startIndex = pos + 1;
            }
            return positions;
        }

        // Проверка на наложение: есть ли в интервале другое вхождение fragment2
        private static bool HasOverlap(string input, int start, int end, string fragment2)
        {
            int fragmentLength = fragment2.Length;
            // Ищем вхождение fragment2 внутри интервала (start, end)
            for (int i = start + 1; i <= end - fragmentLength; i++)
            {
                if (input.Substring(i, fragmentLength) == fragment2)
                {
                    return true;
                }
            }
            return false;
        }

        // Формирует финальную подстроку по индексам
        private static string BuildResultSubstring(string input, int pos1, int pos2, string fragment1, string fragment2, bool excludeFragments)
        {
            if (excludeFragments)
            {
                int start = pos1 + fragment1.Length;
                int length = pos2 - start;
                return input.Substring(start, length);
            }
            else
            {
                return input.Substring(pos1, pos2 - pos1 + fragment2.Length);
            }
        }

        public static string TempName
        {
            get { return $"m{Guid.NewGuid():N}"; }
        }

        // Разделитель путей.
        // Godot поддерживает только / в качестве разделителя путей. Это делается по причинам переносимости.
        // Все операционные системы поддерживают это, даже Windows, поэтому путь
        // C:\project\project.godot
        // должен быть напечатан как
        // C:/project/project.godot.
        public static string ToGodotPath(string windowsPath)
        {
            // Нормализуем слеши
            string normalized = windowsPath.Replace(@"\\", @"/");

            normalized = normalized.Replace(@"\", @"/");

            // Если уже res:// — оставляем как есть
            if (normalized.StartsWith("res://"))
            {
                return normalized;
            }

            // Абсолютный путь вне проекта — Godot его не сможет сохранить в .tres корректно
            return normalized;
        }
    }
}
