// Скрипт читает файлы справки в C:\444\OneScriptGameForms\docs\OSGForms\ и создает *.cs файлы в каталоге C:\444\OneScriptGameForms\Scripts\ВыгруженныеОбъекты\
// Из каталога C:\444\OneScriptGameForms\Scripts\ВыгруженныеОбъекты\ файлы *.cs можно скопировать в каталог проекта.

Перем Ф, ИОС, КаталогСправки, КаталогВыгрузки;
Перем КодДиректив, КодШапки, КодРазделОбъявленияПеременных, КодКонструктор, КодСвойств, КодМетодов, КодСобытий;
Перем БазовыеКлассы, ДвухУровневыеКлассы, ОдноУровневыеКлассы;

Функция Директивы(ИмяКлассаАнгл)
	Попытка
		Возврат КодДиректив[ИмяКлассаАнгл] + 
		"
		|
		|";
	Исключение
		Возврат 
		"using OneScript.Contexts;
		|using OneScript.Execution;
		|using OneScript.StandardLibrary.Collections;
		|using OneScript.StandardLibrary;
		|using ScriptEngine.HostedScript.Library;
		|using ScriptEngine.HostedScript;
		|using ScriptEngine.Machine;
		|using ScriptEngine.Machine.Contexts;
		|using System.Collections.Concurrent;
		|using System.Collections.Generic;
		|using System.Collections;
		|using System.ComponentModel.Design;
		|using System.Diagnostics;
		|using System.Reflection;
		|using System.Text.Json;
		|using System.Text;
		|using System;
		|
		|";
	КонецПопытки;
КонецФункции//Директивы

Функция ПространствоИмен(ИмяКлассаАнгл)
	Если ИмяКлассаАнгл = "ййййй"  Тогда
		Возврат "";
	Иначе
		Возврат 
		"namespace osgf
		|{
		|";
	КонецЕсли;
КонецФункции//ПространствоИмен

Функция КлассУровня1(ИмяКлассаАнгл)
	Если ИмяКлассаАнгл = "ййййй"  Тогда
		Возврат 
		"    public class HBoxContainer : osgf.BoxContainer


		|";
	// ИначеЕсли ИмяКлассаАнгл = "ййййй"  Тогда
		// Возврат 
		// "    public class HBoxContainer : osgf.BoxContainer


		// |";
		
		
		
		

		
	ИначеЕсли ИмяКлассаАнгл = "SpriteFrames"  Тогда
		Возврат 
		"    public class SpriteFrames : osgf.Resource
		|    {
		|        public GfSpriteFrames dll_obj;
		|        private osgf.Resource m_SpriteFrames;
		|
		|        public osgf.Resource M_SpriteFrames
		|        {
		|            get { return m_SpriteFrames; }
		|            set
		|            {
		|                m_SpriteFrames = value;
		|                base.M_Resource = m_SpriteFrames;
		|            }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "DirectionalLight3D"  Тогда
		Возврат 
		"    public class DirectionalLight3D : osgf.Light3D
		|    {
		|        public GfDirectionalLight3D dll_obj;
		|        private osgf.Light3D m_DirectionalLight3D;
		|
		|        public osgf.Light3D M_DirectionalLight3D
		|        {
		|            get { return m_DirectionalLight3D; }
		|            set
		|            {
		|                m_DirectionalLight3D = value;
		|                base.M_Light3D = m_DirectionalLight3D;
		|            }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Light3D"  Тогда
		Возврат 
		"using System.Reflection;
		|
		|namespace osgf
		|{
		|    public class Light3D : osgf.VisualInstance3D
		|    {
		|        private osgf.VisualInstance3D m_Light3D;
		|
		|        public osgf.VisualInstance3D M_Light3D
		|        {
		|            get { return m_Light3D; }
		|            set
		|            {
		|                m_Light3D = value;
		|                base.M_VisualInstance3D = m_Light3D;
		|            }
		|        }
		|
		|        public int LightEnergy
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int LightColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "VisualInstance3D"  Тогда
		Возврат 
		"namespace osgf
		|{
		|    public class VisualInstance3D : osgf.Node3D
		|    {
		|        private osgf.Node3D m_VisualInstance3D;
		|
		|        public osgf.Node3D M_VisualInstance3D
		|        {
		|            get { return m_VisualInstance3D; }
		|            set
		|            {
		|                m_VisualInstance3D = value;
		|                base.M_Node3D = m_VisualInstance3D;
		|            }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Camera3D"  Тогда
		Возврат 
		"    public class Camera3D : osgf.Node3D
		|    {
		|        public GfCamera3D dll_obj;
		|        private osgf.Node3D m_Camera3D;
		|
		|        public osgf.Node3D M_Camera3D
		|        {
		|            get { return m_Camera3D; }
		|            set
		|            {
		|                m_Camera3D = value;
		|                base.M_Node3D = m_Camera3D;
		|            }
		|        }
		|
		|        public int VOffset
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int HOffset
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2 FrustumOffset
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int Fov
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public void MakeCurrent()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "WorldEnvironment"  Тогда
		Возврат 
		"    public class WorldEnvironment : osgf.Node
		|    {
		|        public GfWorldEnvironment dll_obj;
		|        private osgf.Node m_WorldEnvironment;
		|
		|        public osgf.Node M_WorldEnvironment
		|        {
		|            get { return m_WorldEnvironment; }
		|            set
		|            {
		|                m_WorldEnvironment = value;
		|                base.M_Node = m_WorldEnvironment;
		|            }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Environment"  Тогда
		Возврат 
		"    public class Environment : osgf.Resource
		|    {
		|        public GfEnvironment dll_obj;
		|        private osgf.Resource m_Environment;
		|
		|        public osgf.Resource M_Environment
		|        {
		|            get { return m_Environment; }
		|            set
		|            {
		|                m_Environment = value;
		|                base.M_Resource = m_Environment;
		|            }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Node3D"  Тогда
		Возврат 
		"using System.Reflection;
		|using System.Text.Json;
		|
		|namespace osgf
		|{
		|    public class Node3D : osgf.Node
		|    {
		|        private osgf.Node m_Node3D;
		|
		|        public osgf.Node M_Node3D
		|        {
		|            get { return m_Node3D; }
		|            set
		|            {
		|                m_Node3D = value;
		|                base.M_Node = m_Node3D;
		|            }
		|        }
		|
		|        public GfTransform3D GlobalTransform
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2 ToGlobal(GfVector2 p1)
		|        {
		|            object rez = OsUtils.ConvertValueForGodot(p1);
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""position"",  rez },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""FindCenter"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                var report = OsUtils.Deserialize(answer[""report""].ToString());
		|                return (GfVector2)OsUtils.ConvertValueForGameForms(report);
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ВГлобальные"");
		|                return null;
		|            }
		|        }
		|
		|        public GfVector2 ToLocal(GfVector2 p1)
		|        {
		|            object rez = OsUtils.ConvertValueForGodot(p1);
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""position"",  rez },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""FindCenter"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                var report = OsUtils.Deserialize(answer[""report""].ToString());
		|                return (GfVector2)OsUtils.ConvertValueForGameForms(report);
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ВЛокальные"");
		|                return null;
		|            }
		|        }
		|
		|        public void LookAtFromPosition(GfVector3 p1, GfVector3 p2, GfVector3 p3, bool p4 = false)
		|        {
		|            object vector1 = OsUtils.ConvertValueForGodot(p1);
		|            object vector2 = OsUtils.ConvertValueForGodot(p2);
		|            object vector3 = OsUtils.ConvertValueForGodot(p3);
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""vector1"",  vector1 },
		|                    { ""vector2"",  vector2 },
		|                    { ""vector3"",  vector3 },
		|                    { ""usefront"",  p4 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Material"  Тогда
		Возврат 
		"    public class Material
		|    {
		|        public Material()
		|        {
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "AnimatedSprite2D"  Тогда
		Возврат 
		"    public class AnimatedSprite2D : osgf.Node2D
		|    {
		|        public new GfAnimatedSprite2D dll_obj;
		|        private osgf.Node2D m_AnimatedSprite2D;
		|
		|        public osgf.Node2D M_AnimatedSprite2D
		|        {
		|            get { return m_AnimatedSprite2D; }
		|            set
		|            {
		|                m_AnimatedSprite2D = value;
		|                base.M_Node2D = m_AnimatedSprite2D;
		|            }
		|        }
		|
		|        public AnimatedSprite2D()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "WorldEnvironment"  Тогда
		Возврат 
		"    public class WorldEnvironment : osgf.Node
		|    {
		|        public GfWorldEnvironment dll_obj;
		|        private osgf.Node m_WorldEnvironment;
		|
		|        public osgf.Node M_WorldEnvironment
		|        {
		|            get { return m_WorldEnvironment; }
		|            set
		|            {
		|                m_WorldEnvironment = value;
		|                base.M_Node = m_WorldEnvironment;
		|            }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ThemeVBoxContainer"  Тогда
		Возврат 
		"    public class ThemeVBoxContainer : osgf.Theme
		|    {
		|        public GfThemeVBoxContainer dll_obj;
		|        private osgf.Theme m_ThemeVBoxContainer;
		|
		|        public osgf.Theme M_ThemeVBoxContainer
		|        {
		|            get { return m_ThemeVBoxContainer; }
		|            set
		|            {
		|                m_ThemeVBoxContainer = value;
		|                base.M_Theme = m_ThemeVBoxContainer;
		|            }
		|        }
		|
		|        public ThemeVBoxContainer()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""ThemeVBoxContainer"";
		|        }
		|
		|        public int Separation
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ThemeHBoxContainer"  Тогда
		Возврат 
		"    public class ThemeHBoxContainer : osgf.Theme
		|    {
		|        public GfThemeHBoxContainer dll_obj;
		|        private osgf.Theme m_ThemeHBoxContainer;
		|
		|        public osgf.Theme M_ThemeHBoxContainer
		|        {
		|            get { return m_ThemeHBoxContainer; }
		|            set
		|            {
		|                m_ThemeHBoxContainer = value;
		|                base.M_Theme = m_ThemeHBoxContainer;
		|            }
		|        }
		|
		|        public ThemeHBoxContainer()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""ThemeHBoxContainer"";
		|        }
		|
		|        public int Separation
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ThemeConfirmationDialog"  Тогда
		Возврат 
		"    public class ThemeConfirmationDialog : osgf.Theme
		|    {
		|        public GfThemeConfirmationDialog dll_obj;
		|        private osgf.Theme m_ThemeConfirmationDialog;
		|
		|        public osgf.Theme M_ThemeConfirmationDialog
		|        {
		|            get { return m_ThemeConfirmationDialog; }
		|            set
		|            {
		|                m_ThemeConfirmationDialog = value;
		|                base.M_Theme = m_ThemeConfirmationDialog;
		|            }
		|        }
		|
		|        public ThemeConfirmationDialog()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""ThemeConfirmationDialog"";
		|        }
		|
		|        public int ButtonsMinHeight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int ButtonsMinWidth
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Panel
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int ButtonsSeparation
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ThemeScene"  Тогда
		Возврат 
		"    public class ThemeScene : osgf.Theme
		|    {
		|        public GfThemeScene dll_obj;
		|        private osgf.Theme m_ThemeScene;
		|
		|        public osgf.Theme M_ThemeScene
		|        {
		|            get { return m_ThemeScene; }
		|            set
		|            {
		|                m_ThemeScene = value;
		|                base.M_Theme = m_ThemeScene;
		|            }
		|        }
		|
		|        public ThemeScene()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""ThemeScene"";
		|        }
		|
		|        public ThemeScene(string p1)
		|        {
		|            ItemKey = p1;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|            ResourceName = ""ThemeScene"";
		|        }
		|
		|        public GfColor GetColor(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetColor"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            var report = OsUtils.Deserialize(answer[""report""].ToString());
		|            return (GfColor)OsUtils.ConvertValueForGameForms(report);
		|        }
		|
		|        public int GetConstant(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetConstant"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            var report = OsUtils.Deserialize(answer[""report""].ToString());
		|            return (int)OsUtils.ConvertValueForGameForms(report);
		|        }
		|
		|        public void SetColor(string name, string theme_type, GfColor color)
		|        {
		|            object rez = OsUtils.ConvertValueForGodot(color);
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                    { ""color"",  rez },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void SetConstant(string name, string theme_type, int constanta)
		|        {
		|            object rez = OsUtils.ConvertValueForGodot(constanta);
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                    { ""constanta"",  rez },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void SetStylebox(string name, string theme_type, IValue stylebox)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                    { ""styleboxItemKey"",  ((dynamic)stylebox).ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void ClearIcon(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void ClearConstant(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void ClearFontSize(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void ClearStylebox(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void ClearColor(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void ClearFont(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public GfImageTexture GetIcon(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetIcon"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            string iconItemKey = ((JsonElement)answer[""report""]).GetString();
		|            // Если находим fontItemKey в словаре  - возвращаем из метода.
		|            if (GameForms.dictKeyEl.TryGetValue(iconItemKey, out var icon))
		|            {
		|                //1.Если icon найдем в словаре, тогда передаем его ItemKey
		|                return icon.dll_obj;
		|            }
		|            // Если не находим - создаем новый экземпляр GfImageTexture.
		|            return new GfImageTexture(iconItemKey, """");
		|        }
		|
		|        public int GetFontSize(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetFontSize"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            var report = OsUtils.Deserialize(answer[""report""].ToString());
		|            return (int)OsUtils.ConvertValueForGameForms(report);
		|        }
		|
		|        public IValue GetStylebox(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetStylebox"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            string styleboxItemKey = ((JsonElement)answer[""report""]).GetString();
		|            // Если находим fontItemKey в словаре  - возвращаем из метода.
		|            if (GameForms.dictKeyEl.TryGetValue(styleboxItemKey, out var stylebox))
		|            {
		|                //1.Если stylebox найдем в словаре, тогда передаем его ItemKey
		|                return stylebox.dll_obj;
		|            }
		|            // Если не находим - создаем новый экземпляр GfStyleBoxFlat.
		|            return new GfStyleBoxFlat(styleboxItemKey, true);
		|        }
		|
		|        public IValue GetFont(string name, string theme_type)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetFont"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            string fontItemKey = ((JsonElement)answer[""report""]).GetString();
		|            // Если находим fontItemKey в словаре  - возвращаем из метода.
		|            if (GameForms.dictKeyEl.TryGetValue(fontItemKey, out var font))
		|            {
		|                //1.Если stylebox найдем в словаре, тогда передаем его ItemKey
		|                return font.dll_obj;
		|            }
		|            // Если не находим - создаем новый экземпляр GfFontVariation.
		|            return new GfFontVariation(fontItemKey, """");
		|        }
		|
		|        public void SetFontSize(string name, string theme_type, int fontSize)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                    { ""fontSize"",  fontSize },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void SetIcon(string name, string theme_type, GfImageTexture icon)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                    { ""iconItemKey"",  icon.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void SetFont(string name, string theme_type, IValue font)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                    { ""theme_type"",  theme_type },
		|                    { ""fontItemKey"",  ((dynamic)font).ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ThemeButton"  Тогда
		Возврат 
		"    public class ThemeButton : osgf.Theme
		|    {
		|        public GfThemeButton dll_obj;
		|        private osgf.Theme m_ThemeButton;
		|
		|        public osgf.Theme M_ThemeButton
		|        {
		|            get { return m_ThemeButton; }
		|            set
		|            {
		|                m_ThemeButton = value;
		|                base.M_Theme = m_ThemeButton;
		|            }
		|        }
		|
		|        public ThemeButton()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""ThemeButton"";
		|        }
		|
		|        public int AlignToLargestStylebox
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int HSeparation
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfImageTexture Icon
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int IconMaxWidth
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int LineSpacing
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Hover
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue HoverMirrored
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue HoverPressed
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue HoverPressedMirrored
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Pressed
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue PressedMirrored
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Disabled
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue DisabledMirrored
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Focus
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int OutlineSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|        public int FontSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Normal
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue NormalMirrored
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor IconHoverColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor IconHoverPressedColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor IconPressedColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor IconDisabledColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor IconFocusColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor IconNormalColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor FontOutlineColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor FontColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor FontHoverColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor FontHoverPressedColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor FontPressedColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor FontDisabledColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor FontFocusColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Font
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ThemeLabel"  Тогда
		Возврат 
		"    public class ThemeLabel : osgf.Theme
		|    {
		|        public GfThemeLabel dll_obj;
		|        private osgf.Theme m_ThemeLabel;
		|
		|        public osgf.Theme M_ThemeLabel
		|        {
		|            get { return m_ThemeLabel; }
		|            set
		|            {
		|                m_ThemeLabel = value;
		|                base.M_Theme = m_ThemeLabel;
		|            }
		|        }
		|
		|        public ThemeLabel()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""ThemeLabel"";
		|        }
		|
		|        public int ParagraphSpacing
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int LineSpacing
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Focus
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int OutlineSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int ShadowOutlineSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int FontSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int ShadowOffsetY
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int ShadowOffsetX
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Normal
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor FontOutlineColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor FontShadowColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor FontColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Font
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ThemeWindow"  Тогда
		Возврат 
		"    public class ThemeWindow : osgf.Theme
		|    {
		|        public GfThemeWindow dll_obj;
		|        private osgf.Theme m_ThemeWindow;
		|
		|        public osgf.Theme M_ThemeWindow
		|        {
		|            get { return m_ThemeWindow; }
		|            set
		|            {
		|                m_ThemeWindow = value;
		|                base.M_Theme = m_ThemeWindow;
		|            }
		|        }
		|
		|        public ThemeWindow()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""ThemeWindow"";
		|        }
		|
		|        public IValue EmbeddedBorder
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue EmbeddedUnfocusedBorder
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int TitleHeight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Close
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue ClosePressed
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int TitleOutlineSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int TitleFontSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int ResizeMargin
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int CloseVOffset
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int CloseHOffset
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor TitleColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor TitleOutlineModulate
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue TitleFont
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ThemePanelContainer"  Тогда
		Возврат 
		"    public class ThemePanelContainer : osgf.Theme
		|    {
		|        public GfThemePanelContainer dll_obj;
		|        private osgf.Theme m_ThemePanelContainer;
		|
		|        public osgf.Theme M_ThemePanelContainer
		|        {
		|            get { return m_ThemePanelContainer; }
		|            set
		|            {
		|                m_ThemePanelContainer = value;
		|                base.M_Theme = m_ThemePanelContainer;
		|            }
		|        }
		|
		|        public ThemePanelContainer()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""ThemePanelContainer"";
		|        }
		|
		|        public IValue Panel
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ThemeAcceptDialog"  Тогда
		Возврат 
		"    public class ThemeAcceptDialog : osgf.Theme
		|    {
		|        public GfThemeAcceptDialog dll_obj;
		|        private osgf.Theme m_ThemeAcceptDialog;
		|
		|        public osgf.Theme M_ThemeAcceptDialog
		|        {
		|            get { return m_ThemeAcceptDialog; }
		|            set
		|            {
		|                m_ThemeAcceptDialog = value;
		|                base.M_Theme = m_ThemeAcceptDialog;
		|            }
		|        }
		|
		|        public ThemeAcceptDialog()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""ThemeAcceptDialog"";
		|        }
		|
		|        public int ButtonsMinHeight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int ButtonsMinWidth
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue Panel
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int ButtonsSeparation
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Theme"  Тогда
		Возврат 
		"using ScriptEngine.Machine;
		|using System.Reflection;
		|
		|namespace osgf
		|{
		|    public class Theme : osgf.Resource
		|    {
		|        private osgf.Resource m_Theme;
		|
		|        public osgf.Resource M_Theme
		|        {
		|            get { return m_Theme; }
		|            set
		|            {
		|                m_Theme = value;
		|                base.M_Resource = m_Theme;
		|            }
		|        }
		|
		|        public decimal DefaultBaseScale
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int DefaultFontSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue DefaultFont
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public void ClearTheme()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "StyleBoxTexture"  Тогда
		Возврат 
		"    public class StyleBoxTexture : osgf.StyleBox
		|    {
		|        public GfStyleBoxTexture dll_obj;
		|        private osgf.StyleBox m_StyleBoxTexture;
		|
		|        public osgf.StyleBox M_StyleBoxTexture
		|        {
		|            get { return m_StyleBoxTexture; }
		|            set
		|            {
		|                m_StyleBoxTexture = value;
		|                base.M_StyleBox = m_StyleBoxTexture;
		|            }
		|        }
		|
		|        public StyleBoxTexture()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""StyleBoxTexture"";
		|        }
		|
		|        public StyleBoxTexture(string p1)
		|        {
		|            ItemKey = p1;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|            ResourceName = ""StyleBoxTexture"";
		|        }
		|
		|        public void SetTextureMarginAll(decimal p1)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""textureMargin"",  p1 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void SetExpandMarginAll(decimal p1)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""expandMargin"",  p1 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public int AxisStretchVertical
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ExpandMarginTop
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ExpandMarginLeft
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ExpandMarginBottom
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ExpandMarginRight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal TextureMarginTop
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal TextureMarginLeft
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal TextureMarginBottom
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal TextureMarginRight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int AxisStretchHorizontal
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor ModulateColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfRect2 RegionRect
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool DrawCenter
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfImageTexture Texture
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "StyleBoxLine"  Тогда
		Возврат 
		"    public class StyleBoxLine : osgf.StyleBox
		|    {
		|        public GfStyleBoxLine dll_obj;
		|        private osgf.StyleBox m_StyleBoxLine;
		|
		|        public osgf.StyleBox M_StyleBoxLine
		|        {
		|            get { return m_StyleBoxLine; }
		|            set
		|            {
		|                m_StyleBoxLine = value;
		|                base.M_StyleBox = m_StyleBoxLine;
		|            }
		|        }
		|
		|        public StyleBoxLine()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""StyleBoxLine"";
		|        }
		|
		|        public StyleBoxLine(string p1)
		|        {
		|            ItemKey = p1;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|            ResourceName = ""StyleBoxLine"";
		|        }
		|
		|        public bool Vertical
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal GrowEnd
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal GrowBegin
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal Thickness
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor Color
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "StyleBoxFlat"  Тогда
		Возврат 
		"    public class StyleBoxFlat : osgf.StyleBox
		|    {
		|        public GfStyleBoxFlat dll_obj;
		|        private osgf.StyleBox m_StyleBoxFlat;
		|
		|        public osgf.StyleBox M_StyleBoxFlat
		|        {
		|            get { return m_StyleBoxFlat; }
		|            set
		|            {
		|                m_StyleBoxFlat = value;
		|                base.M_StyleBox = m_StyleBoxFlat;
		|            }
		|        }
		|
		|        public StyleBoxFlat()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""StyleBoxFlat"";
		|        }
		|
		|        public StyleBoxFlat(string p1)
		|        {
		|            ItemKey = p1;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|            ResourceName = ""StyleBoxFlat"";
		|        }
		|
		|        public StyleBoxFlat(string itemKey, bool plug)
		|        {
		|            ItemKey = itemKey;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|            ResourceName = ""StyleBoxFlat"";
		|        }
		|
		|        public decimal ExpandMarginTop
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ExpandMarginLeft
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ExpandMarginBottom
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ExpandMarginRight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal CornerRadiusTopLeft
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal CornerRadiusTopRight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal CornerRadiusBottomLeft
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal CornerRadiusBottomRight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ShadowSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2 ShadowOffset
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor BorderColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor ShadowColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfColor BgColor
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal BorderWidthTop
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal BorderWidthLeft
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal BorderWidthBottom
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal BorderWidthRight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public void SetExpandMarginAll(decimal p1)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""expandMargin"",  p1 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void SetCornerRadiusAll(decimal p1)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  ItemKey },
		|                    { ""cornerRadius"",  p1 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void SetBorderWidthAll(decimal p1)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""borderWidth"",  p1 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "StyleBoxEmpty"  Тогда
		Возврат 
		"    public class StyleBoxEmpty : osgf.StyleBox
		|    {
		|        public GfStyleBoxEmpty dll_obj;
		|        private osgf.StyleBox m_StyleBoxEmpty;
		|
		|        public osgf.StyleBox M_StyleBoxEmpty
		|        {
		|            get { return m_StyleBoxEmpty; }
		|            set
		|            {
		|                m_StyleBoxEmpty = value;
		|                base.M_StyleBox = m_StyleBoxEmpty;
		|            }
		|        }
		|
		|        public StyleBoxEmpty()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourceName = ""StyleBoxEmpty"";
		|        }
		|
		|        public StyleBoxEmpty(string p1)
		|        {
		|            ItemKey = p1;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|            ResourceName = ""StyleBoxEmpty"";
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "StyleBox"  Тогда
		Возврат 
		"using System.Reflection;
		|
		|namespace osgf
		|{
		|    public class StyleBox : osgf.Resource
		|    {
		|        private osgf.Resource m_StyleBox;
		|
		|        public osgf.Resource M_StyleBox
		|        {
		|            get { return m_StyleBox; }
		|            set
		|            {
		|                m_StyleBox = value;
		|                base.M_Resource = m_StyleBox;
		|            }
		|        }
		|
		|        public decimal ContentMarginTop
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ContentMarginLeft
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ContentMarginBottom
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal ContentMarginRight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Label"  Тогда
		Возврат 
		"    public class Label : osgf.Control
		|    {
		|        public GfLabel dll_obj;
		|        private osgf.Control m_Label;
		|
		|        public osgf.Control M_Label
		|        {
		|            get { return m_Label; }
		|            set
		|            {
		|                m_Label = value;
		|                base.M_Control = m_Label;
		|            }
		|        }
		|
		|        public Label(string p1)
		|        {
		|            ItemKey = p1;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|        }
		|
		|        public Label()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|
		|        public string Text
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int AutowrapMode
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int VerticalAlignment
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool Uppercase
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int HorizontalAlignment
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int VisibleCharacters
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int TextDirection
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfThemeLabel Theme
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ConfirmationDialog"  Тогда
		Возврат 
		"    public class ConfirmationDialog : osgf.AcceptDialog
		|    {
		|        public new GfConfirmationDialog dll_obj;
		|        private osgf.AcceptDialog m_ConfirmationDialog;
		|
		|        public osgf.AcceptDialog M_ConfirmationDialog
		|        {
		|            get { return m_ConfirmationDialog; }
		|            set
		|            {
		|                m_ConfirmationDialog = value;
		|                base.M_AcceptDialog = m_ConfirmationDialog;
		|            }
		|        }
		|
		|        public ConfirmationDialog()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            DialogText = ""Сообщение"";
		|            Title = ""Сообщение"";
		|            Exclusive = true;
		|        }
		|
		|        public string CancelButtonText
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public new GfThemeConfirmationDialog Theme
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "AcceptDialog"  Тогда
		Возврат 
		"    public class AcceptDialog : osgf.Window
		|    {
		|        public new GfAcceptDialog dll_obj;
		|        private osgf.Window m_AcceptDialog;
		|
		|        public osgf.Window M_AcceptDialog
		|        {
		|            get { return m_AcceptDialog; }
		|            set
		|            {
		|                m_AcceptDialog = value;
		|                base.M_Window = m_AcceptDialog;
		|            }
		|        }
		|
		|        public AcceptDialog()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            DialogText = ""Уведомление"";
		|            Title = ""Уведомление"";
		|            Exclusive = false;
		|        }
		|
		|        public string Text
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool DialogAutowrap
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool DialogHideOnOK
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool DialogCloseOnEscape
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public string DialogText
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public string OkButtonText
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public void RemoveButton(GfButton p1)
		|        {
		|            string buttonItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""buttonItemKey"", buttonItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public GfButton AddButton(string text, bool right)
		|        {
		|            string addedButtonItemKey = ""d"" + Path.GetRandomFileName().Replace(""."", """");
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""addedButtonItemKey"", addedButtonItemKey },
		|                    { ""text"", text },
		|                    { ""right"", right },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""AddButton"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                GfButton button = new GfButton(addedButtonItemKey);
		|                return button;
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ДобавитьКнопку"");
		|                return null;
		|            }
		|        }
		|
		|        public GfButton AddCancelButton(string text)
		|        {
		|            string addedButtonItemKey = ""d"" + Path.GetRandomFileName().Replace(""."", """");
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""addedButtonItemKey"", addedButtonItemKey },
		|                    { ""text"", text },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""AddCancelButton"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                GfButton button = new GfButton(addedButtonItemKey);
		|                return button;
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ДобавитьКнопкуОтмена"");
		|                return null;
		|            }
		|        }
		|
		|        public GfButton GetOkButton()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetOkButton"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                var report = OsUtils.Deserialize(answer[""report""].ToString());
		|                string okButtonItemKey = String.Empty;
		|                foreach (var item in report)
		|                {
		|                    var itemValue = (JsonElement)item.Value;
		|                    switch (item.Key)
		|                    {
		|                        case ""okButtonItemKey"":
		|                            okButtonItemKey = itemValue.GetString();
		|                            break;
		|                    }
		|                }
		|
		|                if (!GameForms.dictKeyEl.TryGetValue(okButtonItemKey, out var button))
		|                {
		|                    if (okButtonItemKey != String.Empty)
		|                    {
		|                        return new GfButton(okButtonItemKey);
		|                    }
		|                    else
		|                    {
		|                        OsUtils.Echo(""Не удалось выполнить метод ПолучитьКнопкуОК"");
		|                        return null;
		|                    }
		|                }
		|                else
		|                {
		|                    return button.dll_obj;
		|                }
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ПолучитьКнопкуОК"");
		|                return null;
		|            }
		|        }
		|
		|        public GfLabel GetLabel()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetLabel"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                string labelItemKey = ((JsonElement)answer[""report""]).GetString();
		|                if (!GameForms.dictKeyEl.TryGetValue(labelItemKey, out var label))
		|                {
		|                    if (labelItemKey != String.Empty)
		|                    {
		|                        return new GfLabel(labelItemKey);
		|                    }
		|                    else
		|                    {
		|                        OsUtils.Echo(""Не удалось выполнить метод ПолучитьНадпись"");
		|                        return null;
		|                    }
		|                }
		|                else
		|                {
		|                    return label.dll_obj;
		|                }
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ПолучитьНадпись"");
		|                return null;
		|            }
		|        }
		|
		|        public void Popup(string text, string title, GfRect2i p1, decimal p2)
		|        {
		|            int[] position = { OsUtils.ToInt32(p1.Position.X), OsUtils.ToInt32(p1.Position.Y) };
		|            int[] size = { OsUtils.ToInt32(p1.Size.X), OsUtils.ToInt32(p1.Size.Y) };
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""itemKey"",  this.ItemKey },
		|                    { ""dialog_text"", text },
		|                    { ""title"", title },
		|                    { ""position"", position },
		|                    { ""size"", size },
		|                    { ""timeout"", p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(""PopupAcceptDialog"", response);
		|        }
		|
		|        public void PopupCentered(string text, string title, GfVector2i p1, decimal p2)
		|        {
		|            int[] minsize = { OsUtils.ToInt32(p1.X), OsUtils.ToInt32(p1.Y) };
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""itemKey"",  this.ItemKey },
		|                    { ""dialog_text"", text },
		|                    { ""title"", title },
		|                    { ""minsize"", minsize },
		|                    { ""timeout"", p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(""PopupCenteredAcceptDialog"", response);
		|        }
		|
		|        public new GfThemeAcceptDialog Theme
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Balloon"  Тогда
		Возврат 
		"    public class Balloon : osgf.PanelContainer
		|    {
		|        public GfBalloon dll_obj;
		|        private osgf.PanelContainer m_Balloon;
		|
		|        public osgf.PanelContainer M_Balloon
		|        {
		|            get { return m_Balloon; }
		|            set
		|            {
		|                m_Balloon = value;
		|                base.M_PanelContainer = m_Balloon;
		|            }
		|        }
		|
		|        public Balloon()
		|        {
		|            ItemKey = ""d"" + Path.GetRandomFileName().Replace(""."", """");
		|            Response response = new Response
		|            {
		|                ItemKey = ItemKey,
		|                TypeNode = ""Balloon"",
		|                Properties = new Dictionary<string, object>
		|                {
		|                    // Задаем значения по умолчанию и другие значения, если нужно.
		|                    { ""text"", ""Уведомление..."" },
		|                    { ""title"", ""Уведомление"" },
		|                    { ""wait_time"", 5.0m },
		|                    { ""position"", new float[] { 100.0f, 100.0f } },
		|                    { ""size"", new float[] { 300.0f, 100.0f } },
		|                    //////{ ""ignore_time_scale"", true },
		|                    //////{ ""one_shot"", false },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""CreateNode"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                GameForms.dictKeyEl[ItemKey] = this;
		|                GameForms.dictElKey[this] = ItemKey;
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось создать объект Уведомление"");
		|                this.dll_obj = null;
		|            }
		|        }
		|
		|        public string Text
		|        {
		|            get
		|            {
		|                Response response = new Response
		|                {
		|                    ItemKey = ItemKey,
		|                    Properties = new Dictionary<string, object>
		|                    {
		|                        { ""text"",  null },
		|                    }
		|                };
		|                string jsonResponse = OsUtils.Serialize(response);
		|                string res = GameForms.SendCommand(""GetProperty"", jsonResponse);
		|                var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|                if (((JsonElement)answer[""success""]).GetBoolean())
		|                {
		|                    return ((JsonElement)answer[""report""]).GetString();
		|                }
		|                else
		|                {
		|                    OsUtils.Echo(""Не удалось получить свойство Текст"");
		|                    return null;
		|                }
		|            }
		|            set
		|            {
		|                Response response = new Response
		|                {
		|                    ItemKey = ItemKey,
		|                    Properties = new Dictionary<string, object>
		|                    {
		|                        { ""text"",  value },
		|                    }
		|                };
		|                string jsonResponse = OsUtils.Serialize(response);
		|                string res = GameForms.SendCommand(""SetProperty"", jsonResponse);
		|                var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|                if (!((JsonElement)answer[""success""]).GetBoolean())
		|                {
		|                    OsUtils.Echo(""Не удалось установить свойство Текст"");
		|                }
		|            }
		|        }
		|
		|        public string Title
		|        {
		|            get
		|            {
		|                Response response = new Response
		|                {
		|                    ItemKey = ItemKey,
		|                    Properties = new Dictionary<string, object>
		|                    {
		|                        { ""title"",  null },
		|                    }
		|                };
		|                string jsonResponse = OsUtils.Serialize(response);
		|                string res = GameForms.SendCommand(""GetProperty"", jsonResponse);
		|                var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|                if (((JsonElement)answer[""success""]).GetBoolean())
		|                {
		|                    return ((JsonElement)answer[""report""]).GetString();
		|                }
		|                else
		|                {
		|                    OsUtils.Echo(""Не удалось получить свойство Заголовок"");
		|                    return null;
		|                }
		|            }
		|            set
		|            {
		|                Response response = new Response
		|                {
		|                    ItemKey = ItemKey,
		|                    Properties = new Dictionary<string, object>
		|                    {
		|                        { ""title"",  value },
		|                    }
		|                };
		|                string jsonResponse = OsUtils.Serialize(response);
		|                string res = GameForms.SendCommand(""SetProperty"", jsonResponse);
		|                var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|                if (!((JsonElement)answer[""success""]).GetBoolean())
		|                {
		|                    OsUtils.Echo(""Не удалось установить свойство Заголовок"");
		|                }
		|            }
		|        }
		|
		|        public IValue WaitTime
		|        {
		|            get
		|            {
		|                Response response = new Response
		|                {
		|                    ItemKey = ItemKey,
		|                    Properties = new Dictionary<string, object>
		|                    {
		|                        { ""wait_time"",  null },
		|                    }
		|                };
		|                string jsonResponse = OsUtils.Serialize(response);
		|                string res = GameForms.SendCommand(""GetProperty"", jsonResponse);
		|                var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|                if (((JsonElement)answer[""success""]).GetBoolean())
		|                {
		|                    int rez = ((JsonElement)answer[""report""]).GetInt32();
		|                    return ValueFactory.Create(rez);
		|                }
		|                else
		|                {
		|                    OsUtils.Echo(""Не удалось получить свойство Интервал"");
		|                    return null;
		|                }
		|            }
		|            set
		|            {
		|                Response response = new Response
		|                {
		|                    ItemKey = ItemKey,
		|                    Properties = new Dictionary<string, object>
		|                    {
		|                        { ""wait_time"",  value },
		|                    }
		|                };
		|                string jsonResponse = OsUtils.Serialize(response);
		|                string res = GameForms.SendCommand(""SetProperty"", jsonResponse);
		|                var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|                if (!((JsonElement)answer[""success""]).GetBoolean())
		|                {
		|                    OsUtils.Echo(""Не удалось установить свойство Интервал"");
		|                }
		|            }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "PanelContainer"  Тогда
		Возврат 
		"    public class PanelContainer : osgf.Container
		|    {
		|        public GfPanelContainer dll_obj;
		|        private osgf.Container m_PanelContainer;
		|
		|        public osgf.Container M_PanelContainer
		|        {
		|            get { return m_PanelContainer; }
		|            set
		|            {
		|                m_PanelContainer = value;
		|                base.M_Container = m_PanelContainer;
		|            }
		|        }
		|
		|        public PanelContainer()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|
		|        public GfThemePanelContainer Theme
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Timer"  Тогда
		Возврат 
		"    public class Timer : osgf.Node
		|    {
		|        public GfTimer dll_obj;
		|        private osgf.Node m_Timer;
		|
		|        public osgf.Node M_Timer
		|        {
		|            get { return m_Timer; }
		|            set
		|            {
		|                m_Timer = value;
		|                base.M_Node = m_Timer;
		|            }
		|        }
		|
		|        public Timer()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|
		|        public decimal WaitTime
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool Paused
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public void Start(int timeSec = -1)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""time_sec"", timeSec },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void Stop()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public bool IsStopped()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""IsStopped"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            return ((JsonElement)answer[""report""]).GetBoolean();
		|        }
		|
		|        public GfAction Timeout
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Image"  Тогда
		Возврат 
		"    public class Image : osgf.Resource
		|    {
		|        public GfImage dll_obj;
		|        private osgf.Resource m_Image;
		|
		|        public osgf.Resource M_Image
		|        {
		|            get { return m_Image; }
		|            set
		|            {
		|                m_Image = value;
		|                base.M_Resource = m_Image;
		|            }
		|        }
		|
		|        public Image()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourcePath = """";
		|            ResourceName = ""Image"";
		|        }
		|
		|        public Image(string _path)
		|        {
		|            string path = OsUtils.ToGodotPath(_path);
		|            ItemKey = ""d"" + System.IO.Path.GetRandomFileName().Replace(""."", """");
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""itemKey"",  ItemKey },
		|                    { ""typeNode"",  ""Image"" },
		|                    { ""resource_path"", path }
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""CreateNode"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                this.ResourcePath = path;
		|                GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|                GameForms.dictElKey.TryAdd(this, ItemKey);
		|                ResourceName = ""Image"";
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось создать объект Изображение"");
		|                this.dll_obj = null;
		|            }
		|        }
		|
		|        public GfColor GetPixel(int x, int y)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""x"",  x },
		|                    { ""y"",  y },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetPixel"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            var report = OsUtils.Deserialize(answer[""report""].ToString());
		|            return (GfColor)OsUtils.ConvertValueForGameForms(report);
		|        }
		|
		|        public BinaryDataBuffer GetData()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetPixel"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            var report = OsUtils.Deserialize(answer[""report""].ToString());
		|            return (BinaryDataBuffer)OsUtils.ConvertValueForGameForms(report);
		|        }
		|
		|        public void SetPixel(int x, int y, GfColor color)
		|        {
		|            object rez = OsUtils.ConvertValueForGodot(color);
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""x"",  x },
		|                    { ""y"",  y },
		|                    { ""color"",  color },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "ImageTexture"  Тогда
		Возврат 
		"    public class ImageTexture : osgf.Texture2D
		|    {
		|        public GfImageTexture dll_obj;
		|        private osgf.Texture2D m_ImageTexture;
		|
		|        public osgf.Texture2D M_ImageTexture
		|        {
		|            get { return m_ImageTexture; }
		|            set
		|            {
		|                m_ImageTexture = value;
		|                base.M_Texture2D = m_ImageTexture;
		|            }
		|        }
		|
		|        public ImageTexture()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourcePath = """";
		|            ResourceName = ""ImageTexture"";
		|        }
		|
		|        public ImageTexture(string _path)
		|        {
		|            string path = OsUtils.ToGodotPath(_path);
		|            ItemKey = ""d"" + System.IO.Path.GetRandomFileName().Replace(""."", """");
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""itemKey"",  ItemKey },
		|                    { ""typeNode"",  ""ImageTexture"" },
		|                    { ""resource_path"", path }
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""CreateNode"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                this.ResourcePath = path;
		|                GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|                GameForms.dictElKey.TryAdd(this, ItemKey);
		|                ResourceName = ""ImageTexture"";
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось создать объект ТекстураИзИзображения"");
		|                this.dll_obj = null;
		|            }
		|        }
		|
		|        public ImageTexture(string itemKey, string resourcePath)
		|        {
		|            ItemKey = itemKey;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|            ResourcePath = resourcePath;
		|            ResourceName = ""ImageTexture"";
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Dictionary"  Тогда
		Возврат 
		"    public class Dictionary : IEnumerable, IEnumerator
		|    {
		|        public GfDictionary dll_obj;
		|        public System.Collections.IEnumerator Enumerator;
		|        public System.Collections.Generic.Dictionary<object, object> M_Dictionary;
		|
		|        public Dictionary()
		|        {
		|            M_Dictionary = new System.Collections.Generic.Dictionary<object, object>();
		|        }
		|
		|        public Dictionary(Dictionary<object, object> p1)
		|        {
		|            M_Dictionary = p1;
		|        }
		|
		|        public Dictionary(osgf.Dictionary p1)
		|        {
		|            M_Dictionary = p1.M_Dictionary;
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_Dictionary.Count; }
		|        }
		|
		|        public object Current
		|        {
		|            get { return Enumerator.Current; }
		|        }
		|
		|        public IValue get_Item(object key)
		|        {
		|            return (IValue)M_Dictionary[key];
		|        }
		|
		|        public void Reset()
		|        {
		|            Enumerator.Reset();
		|        }
		|
		|        public void Add(object key, object value)
		|        {
		|            M_Dictionary.Add(key, value);
		|        }
		|
		|        public void Clear()
		|        {
		|            M_Dictionary.Clear();
		|        }
		|
		|        public bool ContainsKey(object p1)
		|        {
		|            return M_Dictionary.ContainsKey(p1);
		|        }
		|
		|        public bool ContainsValue(object p1)
		|        {
		|            return M_Dictionary.ContainsValue(p1);
		|        }
		|
		|        public IEnumerator GetEnumerator()
		|        {
		|            Enumerator = M_Dictionary.GetEnumerator();
		|            return (System.Collections.IEnumerator)this;
		|        }
		|
		|        public bool MoveNext()
		|        {
		|            return Enumerator.MoveNext();
		|        }
		|
		|        public void Remove(object key)
		|        {
		|            M_Dictionary.Remove(key);
		|        }
		|
		|        public void Set(object key, object value)
		|        {
		|            M_Dictionary[key] = value;
		|        }
		|
		|        public ArrayImpl Values
		|        {
		|            get
		|            {
		|                Dictionary<object, object> Dictionary1 = M_Dictionary;
		|                ArrayImpl array = new ArrayImpl();
		|                ICollection Values1 = Dictionary1.Values;
		|                foreach (dynamic val1 in Values1)
		|                {
		|                    array.Add(val1);
		|                }
		|                return array;
		|            }
		|        }
		|
		|        public ArrayImpl Keys
		|        {
		|            get
		|            {
		|                Dictionary<object, object> Dictionary1 = M_Dictionary;
		|                ArrayImpl array = new ArrayImpl();
		|                ICollection Keys1 = Dictionary1.Keys;
		|                foreach (dynamic key1 in Keys1)
		|                {
		|                    array.Add(key1);
		|                }
		|                return array;
		|            }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "FontVariation"  Тогда
		Возврат 
		"    public class FontVariation : osgf.Font
		|    {
		|        public GfFontVariation dll_obj;
		|        private osgf.Font m_FontVariation;
		|
		|        public osgf.Font M_FontVariation
		|        {
		|            get { return m_FontVariation; }
		|            set
		|            {
		|                m_FontVariation = value;
		|                base.M_Font = m_FontVariation;
		|            }
		|        }
		|
		|        public FontVariation()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourcePath = """";
		|            ResourceName = ""FontVariation"";
		|        }
		|
		|        public FontVariation(string _path)
		|        {
		|            string path = OsUtils.ToGodotPath(_path);
		|            ItemKey = ""d"" + System.IO.Path.GetRandomFileName().Replace(""."", """");
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""itemKey"",  ItemKey },
		|                    { ""typeNode"",  ""FontVariation"" },
		|                    { ""resource_path"", path }
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""CreateNode"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                this.ResourcePath = path;
		|                GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|                GameForms.dictElKey.TryAdd(this, ItemKey);
		|                ResourceName = ""FontVariation"";
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось создать объект ШрифтВариативный"");
		|                this.dll_obj = null;
		|            }
		|        }
		|
		|        public FontVariation(string itemKey, string resourcePath)
		|        {
		|            ItemKey = itemKey;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|            ResourcePath = resourcePath;
		|            ResourceName = ""FontVariation"";
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "FontFile"  Тогда
		Возврат 
		"    public class FontFile : osgf.Font
		|    {
		|        public GfFontFile dll_obj;
		|        private osgf.Font m_FontFile;
		|
		|        public osgf.Font M_FontFile
		|        {
		|            get { return m_FontFile; }
		|            set
		|            {
		|                m_FontFile = value;
		|                base.M_Font = m_FontFile;
		|            }
		|        }
		|
		|        public FontFile()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|            ResourcePath = """";
		|            ResourceName = ""FontFile"";
		|        }
		|
		|        public FontFile(string _path)
		|        {
		|            string path = OsUtils.ToGodotPath(_path);
		|            ItemKey = ""d"" + System.IO.Path.GetRandomFileName().Replace(""."", """");
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""itemKey"",  ItemKey },
		|                    { ""typeNode"",  ""FontFile"" },
		|                    { ""resource_path"", path }
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""CreateNode"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                this.ResourcePath = path;
		|                GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|                GameForms.dictElKey.TryAdd(this, ItemKey);
		|                ResourceName = ""FontFile"";
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось создать объект ШрифтИзФайла"");
		|                this.dll_obj = null;
		|            }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Sprite2D"  Тогда
		Возврат 
		"    public class Sprite2D : osgf.Node2D
		|    {
		|        public new GfSprite2D dll_obj;
		|        private osgf.Node2D m_Sprite2D;
		|
		|        public osgf.Node2D M_Sprite2D
		|        {
		|            get { return m_Sprite2D; }
		|            set
		|            {
		|                m_Sprite2D = value;
		|                base.M_Node2D = m_Sprite2D;
		|            }
		|        }
		|
		|        public Sprite2D()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|
		|        public bool RegionEnabled
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfRect2 RegionRect
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool Centered
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2 Offset
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Texture2D"  Тогда
		Возврат 
		"namespace osgf
		|{
		|    public class Texture2D : osgf.Texture
		|    {
		|        private osgf.Texture m_Texture2D;
		|
		|        public osgf.Texture M_Texture2D
		|        {
		|            get { return m_Texture2D; }
		|            set
		|            {
		|                m_Texture2D = value;
		|                base.M_Texture = m_Texture2D;
		|            }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Texture"  Тогда
		Возврат 
		"namespace osgf
		|{
		|    public class Texture : osgf.Resource
		|    {
		|        private osgf.Resource m_Texture;
		|
		|        public osgf.Resource M_Texture
		|        {
		|            get { return m_Texture; }
		|            set
		|            {
		|                m_Texture = value;
		|                base.M_Resource = m_Texture;
		|            }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Resource"  Тогда
		Возврат 
		"using ScriptEngine.Machine;
		|using System.Reflection;
		|using System.Text.Json;
		|
		|namespace osgf
		|{
		|    public class Resource : osgf.RefCounted
		|    {
		|        private osgf.RefCounted m_Resource;
		|
		|        public osgf.RefCounted M_Resource
		|        {
		|            get { return m_Resource; }
		|            set
		|            {
		|                m_Resource = value;
		|                base.M_RefCounted = m_Resource;
		|            }
		|        }
		|
		|        public string ResourcePath { get; set; }
		|
		|        public IValue Duplicate()
		|        {
		|            string resourceItemKey = ""d"" + Path.GetRandomFileName().Replace(""."", """");
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""resourceItemKey"",  resourceItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""Duplicate"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                GameForms.dictKeyEl.TryGetValue(ItemKey, out var element);
		|                dynamic obj = element.dll_obj;
		|                object[] args1 = { resourceItemKey };
		|                return Activator.CreateInstance(obj.GetType(), args1);
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод Дублировать"");
		|                return null;
		|            }
		|        }
		|
		|        public void Save(string _path)
		|        {
		|            string path = OsUtils.ToGodotPath(_path);
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""resource_path"",  path },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(""ResourceSave"", response);
		|        }
		|
		|        public string ResourceName
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "RefCounted"  Тогда
		Возврат 
		"namespace osgf
		|{
		|    public class RefCounted : osgf.GObject
		|    {
		|        private osgf.GObject m_RefCounted;
		|
		|        public osgf.GObject M_RefCounted
		|        {
		|            get { return m_RefCounted; }
		|            set
		|            {
		|                m_RefCounted = value;
		|                base.M_GObject = m_RefCounted;
		|            }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Font"  Тогда
		Возврат 
		"namespace osgf
		|{
		|    public class Font : osgf.Resource
		|    {
		|        private osgf.Resource m_Font;
		|
		|        public osgf.Resource M_Font
		|        {
		|            get { return m_Font; }
		|            set
		|            {
		|                m_Font = value;
		|                base.M_Resource = m_Font;
		|            }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "GObject"  Тогда
		Возврат 
		"using ScriptEngine.Machine;
		|
		|namespace osgf
		|{
		|    public class GObject : System.Object
		|    {
		|        public System.Object M_GObject;
		|
		|        public string ItemKey { get; set; }
		|
		|        public override string ToString()
		|        {
		|            return base.ToString();
		|        }
		|
		|        public IValue Tag { get; set; }
		|
		|        public object this[string p1]
		|        {
		|            get { return this.GetType().GetProperty(p1).GetValue(this); }
		|            set { this.GetType().GetProperty(p1).SetValue(this, value); }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "BoxContainer"  Тогда
		Возврат 
		"namespace osgf
		|{
		|    public class BoxContainer : osgf.Container
		|    {
		|        private osgf.Container m_BoxContainer;
		|
		|        public osgf.Container M_BoxContainer
		|        {
		|            get { return m_BoxContainer; }
		|            set
		|            {
		|                m_BoxContainer = value;
		|                base.M_Container = m_BoxContainer;
		|            }
		|        }
		|
		|        public int Alignment { get; set; }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Container"  Тогда
		Возврат 
		"using ScriptEngine.Machine;
		|using System.Reflection;
		|
		|namespace osgf
		|{
		|    public class Container : osgf.Control
		|    {
		|        private osgf.Control m_Container;
		|
		|        public osgf.Control M_Container
		|        {
		|            get { return m_Container; }
		|            set
		|            {
		|                m_Container = value;
		|                base.M_Control = m_Container;
		|            }
		|        }
		|
		|        public void FitChildInRect(IValue p1, GfRect2 p2)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""childKeyItem"", ((dynamic)p1).ItemKey },
		|                    { ""position"", new float[] { OsUtils.ToFloat(p2.Position.X), OsUtils.ToFloat(p2.Position.Y) } },
		|                    { ""size"", new float[] { OsUtils.ToFloat(p2.Size.X), OsUtils.ToFloat(p2.Size.Y) } },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "CanvasItem"  Тогда
		Возврат 
		"using System.Reflection;
		|using System.Text.Json;
		|
		|namespace osgf
		|{
		|    public class CanvasItem : osgf.Node
		|    {
		|        private osgf.Node m_CanvasItem;
		|
		|        public osgf.Node M_CanvasItem
		|        {
		|            get { return m_CanvasItem; }
		|            set
		|            {
		|                m_CanvasItem = value;
		|                base.M_Node = m_CanvasItem;
		|            }
		|        }
		|
		|        public GfVector2 ToGlobal(GfVector2 p1)
		|        {
		|            object rez = OsUtils.ConvertValueForGodot(p1);
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""position"",  rez },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""FindCenter"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                var report = OsUtils.Deserialize(answer[""report""].ToString());
		|                return (GfVector2)OsUtils.ConvertValueForGameForms(report);
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ВГлобальные"");
		|                return null;
		|            }
		|        }
		|
		|        public GfVector2 ToLocal(GfVector2 p1)
		|        {
		|            object rez = OsUtils.ConvertValueForGodot(p1);
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""position"",  rez },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""FindCenter"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                var report = OsUtils.Deserialize(answer[""report""].ToString());
		|                return (GfVector2)OsUtils.ConvertValueForGameForms(report);
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ВЛокальные"");
		|                return null;
		|            }
		|        }
		|
		|        public GfColor Modulate
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfMaterial Material
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool Visible
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction MouseMove
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2 GetLocalMousePosition()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""position"",  null },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetLocalMousePosition"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            var report = OsUtils.Deserialize(answer[""report""].ToString());
		|            return (GfVector2)OsUtils.ConvertValueForGameForms(report);
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "SubViewport"  Тогда
		Возврат 
		"namespace osgf
		|{
		|    public class SubViewport : osgf.Viewport
		|    {
		|        private osgf.Viewport m_SubViewport;
		|
		|        public osgf.Viewport M_SubViewport
		|        {
		|            get { return m_SubViewport; }
		|            set
		|            {
		|                m_SubViewport = value;
		|                base.M_Viewport = m_SubViewport;
		|            }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Viewport"  Тогда
		Возврат 
		"using System.Reflection;
		|
		|namespace osgf
		|{
		|    public class Viewport : osgf.Node
		|    {
		|        private osgf.Node m_Viewport;
		|
		|        public osgf.Node M_Viewport
		|        {
		|            get { return m_Viewport; }
		|            set
		|            {
		|                m_Viewport = value;
		|                base.M_Node = m_Viewport;
		|            }
		|        }
		|
		|        public bool Disable3d
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int Msaa2d
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int Msaa3d
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction Canceled
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction Confirmed
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Graphics"  Тогда
		Возврат 
		"    public class Graphics : osgf.CanvasItem
		|    {
		|        public GfGraphics dll_obj;
		|        private osgf.CanvasItem m_Graphics;
		|
		|        public osgf.CanvasItem M_Graphics
		|        {
		|            get { return m_Graphics; }
		|            set
		|            {
		|                m_Graphics = value;
		|                base.M_CanvasItem = m_Graphics;
		|            }
		|        }
		|
		|        public Graphics()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|
		|        public GfColor OverrideColor(GfColor mod)
		|        {
		|            if (mod == null)
		|            {
		|                mod = new GfColor();
		|                mod.R = 255;
		|                mod.G = 255;
		|                mod.B = 255;
		|                mod.A = 255;
		|            }
		|            return mod;
		|        }
		|
		|        public void Clear()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawCircle(GfVector2 Position, decimal Radius, GfColor Color, bool Filled, decimal Width, bool Antialiased)
		|        {
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Position, Radius, Color, Filled, Width, Antialiased);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawRect(GfRect2 Rect2, GfColor Color, bool Filled, decimal Width, bool Antialiased)
		|        {
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Rect2, Color, Filled, Width, Antialiased);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawEllipse(GfVector2 Position, decimal Major, decimal Minor, GfColor Color, bool Filled, decimal Width, bool Antialiased)
		|        {
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Position, Major, Minor, Color, Filled, Width, Antialiased);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawLine(GfVector2 From, GfVector2 To, GfColor Color, decimal Width, bool Antialiased)
		|        {
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                From, To, Color, Width, Antialiased);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawArc(GfVector2 Center, decimal Radius, decimal StartAngle, decimal EndAngle, int PointCount, GfColor Color, decimal Width, bool Antialiased)
		|        {
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Center, Radius, StartAngle, EndAngle, PointCount, Color, Width, Antialiased);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawChar(string Font, GfVector2 Position, string Char, int FontSize, GfColor Modulate, decimal Oversampling)
		|        {
		|            Modulate = OverrideColor(Modulate);
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Font, Position, Char, FontSize, Modulate, Oversampling);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawCharOutline(string Font, GfVector2 Position, string Char, int FontSize, int OutlineSize, GfColor Modulate, decimal Oversampling)
		|        {
		|            Modulate = OverrideColor(Modulate);
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Font, Position, Char, FontSize, OutlineSize, Modulate, Oversampling);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawPolygon(GfDictionary PointsAndColors, ArrayImpl TexturePoints, Texture Texture)
		|        {
		|            if (!OsUtils.AllNotNull(TexturePoints))
		|            {
		|                TexturePoints = new ArrayImpl();
		|            }
		|            string textureItemKey = String.Empty;
		|            if (OsUtils.AllNotNull(Texture))
		|            {
		|                textureItemKey = Texture.ItemKey;
		|            }
		|            float[][] pointsArray = new float[PointsAndColors.CountProp][];
		|            float[][] colorsArray = new float[PointsAndColors.CountProp][];
		|            for (int i = 0; i < PointsAndColors.CountProp; i++)
		|            {
		|                var item = PointsAndColors.Base_obj.M_Dictionary.ElementAt(i);
		|                GfVector2 point = item.Key as GfVector2;
		|                float[] pointArray = { OsUtils.ToFloat(point.X), OsUtils.ToFloat(point.Y) };
		|                pointsArray[i] = pointArray;
		|                GfColor color = item.Value as GfColor;
		|                float[] colorArray = { OsUtils.ToFloat(color.R) / 255f, OsUtils.ToFloat(color.G) / 255f, OsUtils.ToFloat(color.B) / 255f, OsUtils.ToFloat(color.A) / 255f };
		|                colorsArray[i] = colorArray;
		|            }
		|            Dictionary<string, object> Properties = new Dictionary<string, object>();
		|            Response response = new Response();
		|            Properties.Add(""element"", OsUtils.CastToDataType(ItemKey));
		|            Properties.Add(""Points"", OsUtils.CastToDataType(pointsArray));
		|            Properties.Add(""Colors"", OsUtils.CastToDataType(colorsArray));
		|            Properties.Add(""TexturePoints"", OsUtils.CastToDataType(TexturePoints));
		|            Properties.Add(""Texture"", OsUtils.CastToDataType(textureItemKey));
		|            response.Properties = Properties;
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawColoredPolygon(ArrayImpl Points, GfColor Color, ArrayImpl TexturePoints, Texture Texture)
		|        {
		|            if (!OsUtils.AllNotNull(TexturePoints))
		|            {
		|                TexturePoints = new ArrayImpl();
		|            }
		|            string textureItemKey = String.Empty;
		|            if (OsUtils.AllNotNull(Texture))
		|            {
		|                textureItemKey = Texture.ItemKey;
		|            }
		|            Dictionary<string, object> Properties = new Dictionary<string, object>();
		|            Response response = new Response();
		|            Properties.Add(""element"", OsUtils.CastToDataType(ItemKey));
		|            Properties.Add(""Points"", OsUtils.CastToDataType(Points));
		|            Properties.Add(""Color"", OsUtils.CastToDataType(Color));
		|            Properties.Add(""TexturePoints"", OsUtils.CastToDataType(TexturePoints));
		|            Properties.Add(""Texture"", OsUtils.CastToDataType(textureItemKey));
		|            response.Properties = Properties;
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawDashedLine(GfVector2 From, GfVector2 To, GfColor Color, decimal Width, decimal DashLength, bool Aligned, bool Antialiased)
		|        {
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                From, To, Color, Width, DashLength, Aligned, Antialiased);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawEllipseArc(GfVector2 Center, decimal Major, decimal Minor, decimal StartAngle, decimal EndAngle, int PointCount, GfColor Color, decimal Width, bool Antialiased)
		|        {
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Center, Major, Minor, StartAngle, EndAngle, PointCount, Color, Width, Antialiased);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawMultiline(GfDictionary Points, GfColor Color, decimal Width, bool Antialiased)
		|        {
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Points, Color, Width, Antialiased);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawPolyline(ArrayImpl Points, GfColor Color, decimal Width, bool Antialiased)
		|        {
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Points, Color, Width, Antialiased);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawPolylineColors(GfDictionary PointsAndColors, decimal Width, bool Antialiased)
		|        {
		|            float[][] pointsArray = new float[PointsAndColors.CountProp][];
		|            float[][] colorsArray = new float[PointsAndColors.CountProp][];
		|            for (int i = 0; i < PointsAndColors.CountProp; i++)
		|            {
		|                var item = PointsAndColors.Base_obj.M_Dictionary.ElementAt(i);
		|                GfVector2 point = item.Key as GfVector2;
		|                float[] pointArray = { OsUtils.ToFloat(point.X), OsUtils.ToFloat(point.Y) };
		|                pointsArray[i] = pointArray;
		|                GfColor color = item.Value as GfColor;
		|                float[] colorArray = { OsUtils.ToFloat(color.R) / 255f, OsUtils.ToFloat(color.G) / 255f, OsUtils.ToFloat(color.B) / 255f, OsUtils.ToFloat(color.A) / 255f };
		|                colorsArray[i] = colorArray;
		|            }
		|            Dictionary<string, object> Properties = new Dictionary<string, object>();
		|            Response response = new Response();
		|            Properties.Add(""element"", OsUtils.CastToDataType(ItemKey));
		|            Properties.Add(""Points"", OsUtils.CastToDataType(pointsArray));
		|            Properties.Add(""Colors"", OsUtils.CastToDataType(colorsArray));
		|            Properties.Add(""Width"", OsUtils.CastToDataType(Width));
		|            Properties.Add(""Antialiased"", OsUtils.CastToDataType(Antialiased));
		|            response.Properties = Properties;
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawMultilineColors(GfDictionary LinesAndColorsDict, decimal Width, bool Antialiased)
		|        {
		|            // Создаем массив объектов для сериализации
		|            var pointsAndColorsArray = new List<Dictionary<string, object>>();
		|            foreach (System.Collections.Generic.KeyValuePair<object, object> de in LinesAndColorsDict.Base_obj.M_Dictionary)
		|            {
		|                // Ключ и Значение из словаря OneScript
		|                IValue keyIV = (IValue)de.Key;
		|                IValue valueIV = (IValue)de.Value;
		|                // Преобразуем Ключ (пара точек) в JSON-совместимый формат [[x1,y1], [x2,y2]]
		|                var keyArray = new List<float[]>();
		|                if (keyIV is GfEntry gfEntryKey)
		|                {
		|                    // Ключ - это GfVector2, представляем как [x, y]
		|                    GfVector2 vecStart = gfEntryKey.Key as GfVector2;
		|                    GfVector2 vecEnd = gfEntryKey.ValueProp as GfVector2;
		|                    if (vecStart != null && vecEnd != null)
		|                    {
		|                        keyArray.Add(new float[] { OsUtils.ToFloat(vecStart.X), OsUtils.ToFloat(vecStart.Y) });
		|                        keyArray.Add(new float[] { OsUtils.ToFloat(vecEnd.X), OsUtils.ToFloat(vecEnd.Y) });
		|                    }
		|                }
		|                // Преобразуем Значение (цвет) в JSON-совместимый формат [r,g,b,a]
		|                var valueArray = new List<float>();
		|                if (valueIV is GfColor gfColor)
		|                {
		|                    valueArray.Add(OsUtils.ToFloat(gfColor.R) / 255f);
		|                    valueArray.Add(OsUtils.ToFloat(gfColor.G) / 255f);
		|                    valueArray.Add(OsUtils.ToFloat(gfColor.B) / 255f);
		|                    valueArray.Add(OsUtils.ToFloat(gfColor.A) / 255f);
		|                }
		|                // Создаем объект записи
		|                pointsAndColorsArray.Add(new Dictionary<string, object>
		|                {
		|                    { ""Key"", keyArray },
		|                    { ""Value"", valueArray }
		|                });
		|            }
		|            Dictionary<string, object> Properties = new Dictionary<string, object>();
		|            Response response = new Response();
		|            Properties.Add(""element"", OsUtils.CastToDataType(ItemKey));
		|            Properties.Add(""PointsArray"", OsUtils.CastToDataType(pointsAndColorsArray));
		|            Properties.Add(""ColorsArray"", OsUtils.CastToDataType(pointsAndColorsArray));
		|            Properties.Add(""Width"", OsUtils.CastToDataType(Width));
		|            Properties.Add(""Antialiased"", OsUtils.CastToDataType(Antialiased));
		|            response.Properties = Properties;
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawMultilineString(string Font, GfVector2 Position, string Text, int Alignment, decimal Width, int FontSize, int MaxLines, GfColor Modulate, int BrkFlags, int JustificationFlags, int Direction, int Orientation, decimal Oversampling)
		|        {
		|            Modulate = OverrideColor(Modulate);
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Font, Position, Text, Alignment, Width, FontSize, MaxLines, Modulate, BrkFlags, JustificationFlags, Direction, Orientation, Oversampling);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawMultilineStringOutline(string Font, GfVector2 Position, string Text, int Alignment, decimal Width, int FontSize, int MaxLines, int OutlineSize, GfColor Modulate, int BrkFlags, int JustificationFlags, int Direction, int Orientation, decimal Oversampling)
		|        {
		|            Modulate = OverrideColor(Modulate);
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Font, Position, Text, Alignment, Width, FontSize, MaxLines, OutlineSize, Modulate, BrkFlags, JustificationFlags, Direction, Orientation, Oversampling);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawString(string Font, GfVector2 Position, string Text, int Alignment, decimal Width, int FontSize, GfColor Modulate, int JustificationFlags, int Direction, int Orientation, decimal Oversampling)
		|        {
		|            Modulate = OverrideColor(Modulate);
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Font, Position, Text, Alignment, Width, FontSize, Modulate, JustificationFlags, Direction, Orientation, Oversampling);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawStringOutline(string Font, GfVector2 Position, string Text, int Alignment, decimal Width, int FontSize, int OutlineSize, GfColor Modulate, int JustificationFlags, int Direction, int Orientation, decimal Oversampling)
		|        {
		|            Modulate = OverrideColor(Modulate);
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Font, Position, Text, Alignment, Width, FontSize, OutlineSize, Modulate, JustificationFlags, Direction, Orientation, Oversampling);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawTexture(string Texture, GfVector2 Position, GfColor Modulate)
		|        {
		|            Modulate = OverrideColor(Modulate);
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Texture, Position, Modulate);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawTextureRect(string Texture, GfRect2 Rect2, bool Tile, GfColor Modulate, bool Transpose)
		|        {
		|            Modulate = OverrideColor(Modulate);
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Texture, Rect2, Tile, Modulate, Transpose);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawTextureRectRegion(string Texture, GfRect2 DestRect, GfRect2 SrcRect, GfColor Modulate, bool Transpose, bool ClipUv)
		|        {
		|            Modulate = OverrideColor(Modulate);
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Texture, DestRect, SrcRect, Modulate, Transpose, ClipUv);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void DrawSetTransform(GfVector2 Position, decimal Rotation, GfVector2 Scale)
		|        {
		|            if (Scale == null)
		|            {
		|                Scale = new GfVector2(1, 1);
		|            }
		|            Response response = OsUtils.GetResponse(MethodBase.GetCurrentMethod(), ItemKey,
		|                Position, Rotation, Scale);
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Window"  Тогда
		Возврат 
		"    public class Window : osgf.Viewport
		|    {
		|        public GfWindow dll_obj;
		|        private osgf.Viewport m_Window;
		|
		|        public osgf.Viewport M_Window
		|        {
		|            get { return m_Window; }
		|            set
		|            {
		|                m_Window = value;
		|                base.M_Viewport = m_Window;
		|            }
		|        }
		|
		|        public Window(string p1)
		|        {
		|            ItemKey = p1;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|        }
		|
		|        public Window()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|
		|        public string Title
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2i Position
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2i Size
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool Borderless
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2i MaxSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2i MinSize
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool MaximizeDisabled
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool MinimizeDisabled
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool Exclusive
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool Unresizable
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool Visible
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool AlwaysOnTop
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool KeepTitleVisible
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public void Hide()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void Show()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void Popup(GfRect2i p1, decimal p2 = 0m)
		|        {
		|            int[] position = { OsUtils.ToInt32(p1.Position.X), OsUtils.ToInt32(p1.Position.Y) };
		|            int[] size = { OsUtils.ToInt32(p1.Size.X), OsUtils.ToInt32(p1.Size.Y) };
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""itemKey"",  this.ItemKey },
		|                    { ""position"", position },
		|                    { ""size"", size },
		|                    { ""timeout"", p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PopupCentered(GfVector2i p1 = null, decimal p2 = 0m)
		|        {
		|            GfVector2i vector2i = new GfVector2i();
		|            if (p1 != null)
		|            {
		|                vector2i = p1;
		|            }
		|            int[] minsize = { OsUtils.ToInt32(vector2i.X), OsUtils.ToInt32(vector2i.Y) };
		|
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""itemKey"",  this.ItemKey },
		|                    { ""minsize"", minsize },
		|                    { ""timeout"", p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void Center(int p1 = 0, int p2 = 0)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""shiftX"",  p1 },
		|                    { ""shiftY"",  p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public IValue Theme
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool Transparent
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public void AddThemeStyleboxOverride(string styleName, IValue styleBox)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""styleName"", styleName.Split(':')[0] },
		|                    { ""styleBoxItemKey"", ((dynamic)styleBox).ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceTop(IValue p1, int p2)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offset"",  p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceBottom(IValue p1, int p2)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offset"",  p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceLeft(IValue p1, int p2)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offset"",  p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceRight(IValue p1, int p2)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offset"",  p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceTopLeft(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetTop"",  p2 },
		|                    { ""offsetLeft"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceTopRight(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetTop"",  p2 },
		|                    { ""offsetRight"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceLeftTop(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetLeft"",  p2 },
		|                    { ""offsetTop"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceLeftBottom(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetLeft"",  p2 },
		|                    { ""offsetBottom"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceBottomLeft(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetBottom"",  p2 },
		|                    { ""offsetLeft"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceBottomRight(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetBottom"",  p2 },
		|                    { ""offsetRight"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceRightTop(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetRight"",  p2 },
		|                    { ""offsetTop"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceRightBottom(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetRight"",  p2 },
		|                    { ""offsetBottom"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "VBoxContainer"  Тогда
		Возврат 
		"    public class VBoxContainer : osgf.BoxContainer
		|    {
		|        public GfVBoxContainer dll_obj;
		|        private osgf.BoxContainer m_VBoxContainer;
		|
		|        public osgf.BoxContainer M_VBoxContainer
		|        {
		|            get { return m_VBoxContainer; }
		|            set
		|            {
		|                m_VBoxContainer = value;
		|                base.M_BoxContainer = m_VBoxContainer;
		|            }
		|        }
		|
		|        public VBoxContainer()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|
		|        public GfThemeVBoxContainer Theme
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "HBoxContainer"  Тогда
		Возврат 
		"    public class HBoxContainer : osgf.BoxContainer
		|    {
		|        public GfHBoxContainer dll_obj;
		|        private osgf.BoxContainer m_HBoxContainer;
		|
		|        public osgf.BoxContainer M_HBoxContainer
		|        {
		|            get { return m_HBoxContainer; }
		|            set
		|            {
		|                m_HBoxContainer = value;
		|                base.M_BoxContainer = m_HBoxContainer;
		|            }
		|        }
		|
		|        public HBoxContainer()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|
		|        public GfThemeHBoxContainer Theme
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "Button"  Тогда
		Возврат 
		"    public class Button : osgf.BaseButton
		|    {
		|        public GfButton dll_obj;
		|        private osgf.BaseButton m_Button;
		|
		|        public osgf.BaseButton M_Button
		|        {
		|            get { return m_Button; }
		|            set
		|            {
		|                m_Button = value;
		|                base.M_BaseButton = m_Button;
		|            }
		|        }
		|
		|        public Button(string p1)
		|        {
		|            ItemKey = p1;
		|            GameForms.dictKeyEl.TryAdd(ItemKey, this);
		|            GameForms.dictElKey.TryAdd(this, ItemKey);
		|        }
		|
		|        public Button()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|
		|        public string Text
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int AutowrapMode
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int VerticalIconAlignment
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int Alignment
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int IconAlignment
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfImageTexture Icon
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int TextDirection
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool ClipText
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool Flat
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int TextOverrunBehavior
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool ExpandIcon
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfThemeButton Theme
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
	ИначеЕсли ИмяКлассаАнгл = "BaseButton"  Тогда
		Возврат 
		"using System.Reflection;
		|using System.Text.Json;
		|
		|namespace osgf
		|{
		|    public class BaseButton : osgf.Control
		|    {
		|        private osgf.Control m_BaseButton;
		|
		|        public osgf.Control M_BaseButton
		|        {
		|            get { return m_BaseButton; }
		|            set
		|            {
		|                m_BaseButton = value;
		|                base.M_Control = m_BaseButton;
		|            }
		|        }
		|
		|        public bool Disabled
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public bool ToggleMode
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int GetDrawMode()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetDrawMode"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            string str = ((JsonElement)answer[""report""]).GetString();
		|            return GameForms.instance.DrawModeProp.ValueMethod(str);
		|        }
		|
		|        public GfAction ButtonUp
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction ButtonDown
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction Pressed
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction Toggled
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public void ProgrammPressed()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Control"  Тогда
		Возврат 
		"using ScriptEngine.Machine;
		|using System.Reflection;
		|using System.Text.Json;
		|
		|namespace osgf
		|{
		|    public class Control : osgf.CanvasItem
		|    {
		|        private osgf.CanvasItem m_Control;
		|
		|        public osgf.CanvasItem M_Control
		|        {
		|            get { return m_Control; }
		|            set
		|            {
		|                m_Control = value;
		|                base.M_CanvasItem = m_Control;
		|            }
		|        }
		|
		|        public IValue FocusPrevious
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue FocusNext
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue FocusNeighborTop
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue FocusNeighborLeft
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue FocusNeighborBottom
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue FocusNeighborRight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal AnchorTop
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal AnchorLeft
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal AnchorBottom
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal AnchorRight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int SizeFlagsVertical
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int SizeFlagsHorizontal
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int SizeFlagsStretchRatio
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int OffsetTop
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int OffsetLeft
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int OffsetBottom
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public int OffsetRight
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2 Scale
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public decimal RotationDegrees
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2 Position
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfVector2 Size
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction MouseEntered
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction MouseExited
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction Resized
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction FocusEntered
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public GfAction FocusExited
		|        {
		|            get { return OsUtils.GetGodotAction(MethodBase.GetCurrentMethod(), ItemKey); }
		|            set { OsUtils.SetGodotAction(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public void AddThemeStyleboxOverride(string styleName, IValue styleBox)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""styleName"", styleName.Split(':')[0] },
		|                    { ""styleBoxItemKey"", ((dynamic)styleBox).ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void RemoveThemeStyleboxOverride(string styleName)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""styleName"", styleName },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void WarpMouse(GfVector2 p1, decimal duration = 0.5m)
		|        {
		|            float[] position = { OsUtils.ToFloat(p1.X), OsUtils.ToFloat(p1.Y) };
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""position"", position },
		|                    { ""duration"", duration / 1000 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(""ControlWarpMouse"", response);
		|        }
		|
		|        public void PlaceTop(IValue p1, int p2)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offset"",  p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceBottom(IValue p1, int p2)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offset"",  p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceLeft(IValue p1, int p2)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offset"",  p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceRight(IValue p1, int p2)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offset"",  p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceTopLeft(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetTop"",  p2 },
		|                    { ""offsetLeft"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceTopRight(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetTop"",  p2 },
		|                    { ""offsetRight"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceLeftTop(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetLeft"",  p2 },
		|                    { ""offsetTop"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceLeftBottom(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetLeft"",  p2 },
		|                    { ""offsetBottom"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceBottomLeft(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetBottom"",  p2 },
		|                    { ""offsetLeft"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceBottomRight(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetBottom"",  p2 },
		|                    { ""offsetRight"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceRightTop(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetRight"",  p2 },
		|                    { ""offsetTop"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void PlaceRightBottom(IValue p1, int p2, int p3)
		|        {
		|            string anchorItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""anchorItemKey"",  anchorItemKey },
		|                    { ""offsetRight"",  p2 },
		|                    { ""offsetBottom"",  p3 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public IValue GetThemeStyleboxLine(string styleName)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""styleName"",  styleName },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetThemeStyleboxLine"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                string styleBoxItemKey = ((JsonElement)answer[""report""]).GetString();
		|                if (!GameForms.dictKeyEl.TryGetValue(styleBoxItemKey, out var styleBoxLine))
		|
		|                {
		|                    if (styleBoxItemKey != String.Empty)
		|                    {
		|                        return new GfStyleBoxLine(styleBoxItemKey);
		|                    }
		|                    else
		|                    {
		|                        OsUtils.Echo(""Не удалось выполнить метод ПолучитьСтильПанелиЛиния"");
		|                        return null;
		|                    }
		|                }
		|                else
		|                {
		|                    return styleBoxLine.dll_obj;
		|                }
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ПолучитьСтильПанелиЛиния"");
		|                return null;
		|            }
		|        }
		|
		|        public IValue GetThemeStyleboxFlat(string styleName)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""styleName"",  styleName },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetThemeStyleboxFlat"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                string styleBoxItemKey = ((JsonElement)answer[""report""]).GetString();
		|                if (!GameForms.dictKeyEl.TryGetValue(styleBoxItemKey, out var styleBoxFlat))
		|                {
		|                    if (styleBoxItemKey != String.Empty)
		|                    {
		|                        return new GfStyleBoxFlat(styleBoxItemKey);
		|                    }
		|                    else
		|                    {
		|                        OsUtils.Echo(""Не удалось выполнить метод ПолучитьСтильПанелиПлоский"");
		|                        return null;
		|                    }
		|                }
		|                else
		|                {
		|                    return styleBoxFlat.dll_obj;
		|                }
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ПолучитьСтильПанелиПлоский"");
		|                return null;
		|            }
		|        }
		|
		|        public IValue GetThemeStyleboxEmpty(string styleName)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""styleName"",  styleName },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetThemeStyleboxEmpty"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                string styleBoxItemKey = ((JsonElement)answer[""report""]).GetString();
		|                if (!GameForms.dictKeyEl.TryGetValue(styleBoxItemKey, out var styleBoxEmpty))
		|                {
		|                    if (styleBoxItemKey != String.Empty)
		|                    {
		|                        return new GfStyleBoxEmpty(styleBoxItemKey);
		|                    }
		|                    else
		|                    {
		|                        OsUtils.Echo(""Не удалось выполнить метод ПолучитьСтильПанелиПусто"");
		|                        return null;
		|                    }
		|                }
		|                else
		|                {
		|                    return styleBoxEmpty.dll_obj;
		|                }
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ПолучитьСтильПанелиПусто"");
		|                return null;
		|            }
		|        }
		|
		|        public IValue GetThemeStyleboxTexture(string styleName)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""styleName"",  styleName },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetThemeStyleboxTexture"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                string styleBoxItemKey = ((JsonElement)answer[""report""]).GetString();
		|                if (!GameForms.dictKeyEl.TryGetValue(styleBoxItemKey, out var styleBoxTexture))
		|                {
		|                    if (styleBoxItemKey != String.Empty)
		|                    {
		|                        return new GfStyleBoxTexture(styleBoxItemKey);
		|                    }
		|                    else
		|                    {
		|                        OsUtils.Echo(""Не удалось выполнить метод ПолучитьСтильПанелиТекстура"");
		|                        return null;
		|                    }
		|                }
		|                else
		|                {
		|                    return styleBoxTexture.dll_obj;
		|                }
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ПолучитьСтильПанелиТекстура"");
		|                return null;
		|            }
		|        }
		|
		|        public void Center(decimal p1 = 0, decimal p2 = 0)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""shiftX"",  p1 },
		|                    { ""shiftY"",  p2 },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void SetCenterToPoint(GfVector2 p1)
		|        {
		|            float[] position = { OsUtils.ToFloat(p1.X), OsUtils.ToFloat(p1.Y) };
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""position"", position },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(""SetCenterToPoint"", response);
		|        }
		|
		|        public void GrabFocus()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public bool HasFocus()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""HasFocus"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            return ((JsonElement)answer[""report""]).GetBoolean();
		|        }
		|
		|        public int FocusMode
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Node"  Тогда
		Возврат 
		"using OneScript.StandardLibrary.Collections;
		|using ScriptEngine.Machine;
		|using System.Reflection;
		|using System.Text.Json;
		|
		|namespace osgf
		|{
		|    public class Node : osgf.GObject
		|    {
		|        private osgf.GObject m_Node;
		|
		|        public osgf.GObject M_Node
		|        {
		|            get { return m_Node; }
		|            set
		|            {
		|                m_Node = value;
		|                base.M_GObject = m_Node;
		|            }
		|        }
		|
		|        public string Name
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|        }
		|
		|        public IValue AddChild(IValue p1)
		|        {
		|            string childItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""childItemKey"",  childItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""AddChild"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                if (!GameForms.dictKeyEl.TryGetValue(childItemKey, out var childItem))
		|                {
		|                    if (GameForms.instance.DisplayServiceMessages)
		|                    {
		|                        OsUtils.Echo($""Элемент {childItemKey} не найден (2)"");
		|                    }
		|                    return null;
		|                }
		|                else
		|                {
		|                    return childItem.dll_obj;
		|                }
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ДобавитьДочерний."");
		|                return null;
		|            }
		|        }
		|
		|        public IValue RemoveChild(IValue p1)
		|        {
		|            string childItemKey = ((dynamic)p1).ItemKey;
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""childItemKey"",  childItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""RemoveChild"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                if (!GameForms.dictKeyEl.TryGetValue(childItemKey, out var childItem))
		|                {
		|                    if (GameForms.instance.DisplayServiceMessages)
		|                    {
		|                        OsUtils.Echo($""Элемент {childItemKey} не найден (2)"");
		|                    }
		|                    return null;
		|                }
		|                else
		|                {
		|                    return childItem.dll_obj;
		|                }
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод УдалитьДочерний."");
		|                return null;
		|            }
		|        }
		|
		|        public int ZIndex
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|
		|        public IValue GetWindow()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetWindow"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            string str = ((JsonElement)answer[""report""]).GetString();
		|
		|            if (!GameForms.dictKeyEl.TryGetValue(str, out var window))
		|            {
		|                if (GameForms.instance.DisplayServiceMessages)
		|                {
		|                    OsUtils.Echo($""Элемент {str} не найден (3)"");
		|                }
		|                return null;
		|            }
		|            else
		|            {
		|                return window.dll_obj;
		|            }
		|        }
		|
		|        public IValue GetNode(string name)
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                    { ""name"",  name },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetNode"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            string str = ((JsonElement)answer[""report""]).GetString();
		|            if (!GameForms.dictKeyEl.TryGetValue(str, out var node))
		|            {
		|                if (GameForms.instance.DisplayServiceMessages)
		|                {
		|                    OsUtils.Echo($""Элемент {str} не найден (5)"");
		|                }
		|                return null;
		|            }
		|            else
		|            {
		|                return node.dll_obj;
		|            }
		|        }
		|
		|        public IValue GetParent()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetParent"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            string str = ((JsonElement)answer[""report""]).GetString();
		|            if (!GameForms.dictKeyEl.TryGetValue(str, out var parent))
		|            {
		|                if (GameForms.instance.DisplayServiceMessages)
		|                {
		|                    OsUtils.Echo($""Элемент {str} не найден (4)"");
		|                }
		|                return null;
		|            }
		|            else
		|            {
		|                return parent.dll_obj;
		|            }
		|        }
		|
		|        public void SendToBack()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public void BringToFront()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|
		|        public ArrayImpl GetChildren()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            string jsonResponse = OsUtils.Serialize(response);
		|            string res = GameForms.SendCommand(""GetChildren"", jsonResponse);
		|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|            if (((JsonElement)answer[""success""]).GetBoolean())
		|            {
		|                ArrayImpl array = new ArrayImpl();
		|                var report = OsUtils.Deserialize(answer[""report""].ToString());
		|
		|                foreach (var item in report)
		|                {
		|                    var itemValue = (JsonElement)item.Value;
		|                    switch (item.Key)
		|                    {
		|                        case ""children"" when itemValue.ValueKind == JsonValueKind.Array:
		|                            for (int i = 0; i < itemValue.GetArrayLength(); i++)
		|                            {
		|                                try
		|                                {
		|                                    string _itemKey = itemValue[i].GetString();
		|                                    if (_itemKey == ""<Object#null>"")
		|                                    {
		|                                        array.Add(ValueFactory.CreateNullValue());
		|                                    }
		|                                    else
		|                                    {
		|                                        if (GameForms.dictKeyEl.TryGetValue(_itemKey, out var _item))
		|                                        {
		|                                            if (_item.dll_obj != null)
		|                                            {
		|                                                array.Add((IValue)_item.dll_obj);
		|                                            }
		|                                        }
		|                                    }
		|                                }
		|                                catch { }
		|                            }
		|                            break;
		|                    }
		|                }
		|                return array;
		|            }
		|            else
		|            {
		|                OsUtils.Echo(""Не удалось выполнить метод ПолучитьДочерние."");
		|                return null;
		|            }
		|        }
		|
		|        public void QueueFree()
		|        {
		|            Response response = new Response
		|            {
		|                Properties = new Dictionary<string, object>
		|                {
		|                    { ""element"",  this.ItemKey },
		|                }
		|            };
		|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
		|        }
		|    }
		|}
		|";
	ИначеЕсли ИмяКлассаАнгл = "Node2D"  Тогда
		Возврат 
		"    public class Node2D : osgf.CanvasItem
		|    {
		|        public GfNode2D dll_obj;
		|        private osgf.CanvasItem m_Node2D;
		|
		|        public osgf.CanvasItem M_Node2D
		|        {
		|            get { return m_Node2D; }
		|            set
		|            {
		|                m_Node2D = value;
		|                base.M_CanvasItem = m_Node2D;
		|            }
		|        }
		|
		|        public Node2D()
		|        {
		|            OsUtils.CreateGodotObject(this);
		|        }
		|
		|        private decimal rotationDegrees;
		|        public decimal RotationDegrees
		|        {
		|            get { return rotationDegrees; }
		|            set
		|            {
		|                Response response = new Response
		|                {
		|                    Properties = new Dictionary<string, object>
		|                    {
		|                        { ""element"",  this.ItemKey },
		|                        { ""rotation_degrees"",  OsUtils.ToFloat(value) },
		|                    }
		|                };
		|                string jsonResponse = OsUtils.Serialize(response);
		|                string res = GameForms.SendCommand(""SetProperty"", jsonResponse);
		|                var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|                if (((JsonElement)answer[""success""]).GetBoolean())
		|                {
		|                    rotationDegrees = value;
		|                }
		|                else
		|                {
		|                    OsUtils.Echo(""Не удалось установить свойство Текст"");
		|                }
		|            }
		|        }
		|
		|        private GfVector2 position = new GfVector2(0, 0);
		|        public GfVector2 Position
		|        {
		|            get { return position; }
		|            set
		|            {
		|                Response response = new Response
		|                {
		|                    Properties = new Dictionary<string, object>
		|                    {
		|                        { ""element"",  this.ItemKey },
		|                        { ""position"",  new {value.X, value.Y } },
		|                    }
		|                };
		|                string jsonResponse = OsUtils.Serialize(response);
		|                string res = GameForms.SendCommand(""SetProperty"", jsonResponse);
		|                var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
		|                if (((JsonElement)answer[""success""]).GetBoolean())
		|                {
		|                    position = value;
		|                }
		|                else
		|                {
		|                    OsUtils.Echo(""Не удалось установить свойство Позиция"");
		|                }
		|            }
		|        }
		|
		|        public GfVector2 GlobalPosition
		|        {
		|            get { return OsUtils.GetGodotProperty(MethodBase.GetCurrentMethod(), this); }
		|            set { OsUtils.SetGodotProperty(MethodBase.GetCurrentMethod(), ItemKey, value); }
		|        }
		|    }
		|
		|";
		
		
		
		
		
	Иначе
		Возврат "";
	КонецЕсли;
КонецФункции//КлассУровня1

Функция Шапка(ДанныеОбъекта)
	ИмяКлассаАнгл = ДанныеОбъекта.ИмяКлассаАнгл;
	ИмяКлассаРус = ДанныеОбъекта.ИмяКлассаРус;
	ПолныйПуть = ДанныеОбъекта.ПолныйПуть;
	Попытка
		Возврат КодШапки[ИмяКлассаАнгл] + 
		"
		|";
	Исключение
		Если ИмяКлассаАнгл = "Dictionary" Тогда
			Возврат 
			"    [ContextClass(""Иф" + ИмяКлассаРус + """, ""Gf" + ИмяКлассаАнгл + """)]
			|    public class Gf" + ИмяКлассаАнгл + " : AutoContext<Gf" + ИмяКлассаАнгл + ">, ICollectionContext<IValue>, IEnumerable<IValue>
			|    {
			|";
		Иначе
			Возврат 
			"    [ContextClass(""Иф" + ИмяКлассаРус + """, ""Gf" + ИмяКлассаАнгл + """)]
			|    public class Gf" + ИмяКлассаАнгл + " : AutoContext<Gf" + ИмяКлассаАнгл + ">
			|    {
			|";
		КонецЕсли;
	КонецПопытки;
КонецФункции//Шапка

Функция РазделОбъявленияПеременных(ДанныеОбъекта)
	ИмяКлассаАнгл = ДанныеОбъекта.ИмяКлассаАнгл;
	ИмяКлассаРус = ДанныеОбъекта.ИмяКлассаРус;
	ПолныйПуть = ДанныеОбъекта.ПолныйПуть;
	СтрРазделОбъявленияПеременныхДляПеречислений = 
	"        private List<IValue> _list;
	|        public IEnumerator Enumerator;
	|
	|        [ContextMethod(""Количество"", ""Count"")]
	|        public int Count(IBslProcess p1 = null)
	|        {
	|            return _list.Count;
	|        }
	|
	|        [ContextMethod(""Получить"", ""Get"")]
	|        public IValue Get(int index)
	|        {
	|            return this._list[index];
	|        }
	|
	|        public CollectionEnumerator GetManagedIterator()
	|        {
	|            return new CollectionEnumerator(this);
	|        }
	|
	|        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
	|        {
	|            foreach (var item in _list)
	|            {
	|                yield return (item as IValue);
	|            }
	|        }
	|
	|        public IEnumerator GetEnumerator()
	|        {
	|            Enumerator = _list.GetEnumerator();
	|            return (IEnumerator)this;
	|        }";
	
	ПолныйПуть = ДанныеОбъекта.ПолныйПуть;
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ПолныйПуть);
	СтрДок = ТекстДок.ПолучитьТекст();
	Стр = ИОС.СтрНайтиМежду(СтрДок, "<h1 class=dtH1>", "</h1>", , )[0];
	Если СтрНайти(Стр, "Перечисление") > 0 Тогда
		Возврат СтрРазделОбъявленияПеременныхДляПеречислений + 
		"
		|
		|";
	Иначе
		Если ДвухУровневыеКлассы.НайтиПоЗначению(ИмяКлассаАнгл) <> Неопределено Тогда
			Возврат 
			"        public osgf." + ИмяКлассаАнгл + " Base_obj;
			|
			|";
		Иначе
			Попытка
				Возврат КодРазделОбъявленияПеременных[ИмяКлассаАнгл] + 
				"
				|
				|";
			Исключение
				Если ОдноУровневыеКлассы.НайтиПоЗначению(ИмяКлассаАнгл) <> Неопределено Тогда
					Возврат "";
				Иначе
					Возврат 
					"        public osgf." + ИмяКлассаАнгл + " Base_obj;
					|
					|";
				КонецЕсли;
			КонецПопытки;
		КонецЕсли;
	КонецЕсли;
КонецФункции//РазделОбъявленияПеременных

Функция Конструктор(ДанныеОбъекта)
	ИмяКлассаАнгл = ДанныеОбъекта.ИмяКлассаАнгл;
	ИмяКлассаРус = ДанныеОбъекта.ИмяКлассаРус;
	ПолныйПуть = ДанныеОбъекта.ПолныйПуть;
	Попытка
		Возврат КодКонструктор[ИмяКлассаАнгл] + 
		"
		|
		|";
	Исключение
		Возврат 
		"        public Gf" + ИмяКлассаАнгл + "()
		|        {
		|            " + ИмяКлассаАнгл + " " + ИмяКлассаАнгл + "1 = new " + ИмяКлассаАнгл + "();
		|            " + ИмяКлассаАнгл + "1.dll_obj = this;
		|            Base_obj = " + ИмяКлассаАнгл + "1;
		|        }
		|
		|";
	КонецПопытки;
КонецФункции//Конструктор

Функция СобытияКласса(ДанныеОбъекта)
	Рез = "";
	ИмяКлассаАнгл = ДанныеОбъекта.ИмяКлассаАнгл;
	
	Файл = Новый Файл(ОбъединитьПути(КаталогСправки, "OSGForms." + ИмяКлассаАнгл + "Events.html"));
	Если Не Файл.Существует() Тогда
		// Сообщить("Не найден файл событий " + ОбъединитьПути(КаталогСправки, "OSGForms." + ИмяКлассаАнгл + "Events.html"));
		Возврат Рез;
	КонецЕсли;
	
	// Находим страницу событий.
	// file:///C:/444/OneScriptGameForms/docs/OSGForms/OSGForms.BoxContainerEvents.html
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ОбъединитьПути(КаталогСправки, "OSGForms." + ИмяКлассаАнгл + "Events.html"));
	СтрДок = ТекстДок.ПолучитьТекст();
	//Находим текст таблицы.
	М = ИОС.СтрНайтиМежду(СтрДок, "<tr vAlign=top>", "</tr>", , );
	Если М.Количество() > 0 Тогда
		Для А = 0 По М.ВГраница() Цикл
			// Проверим существует ли файл события.
			ПолныйПуть = ИОС.СтрНайтиМежду(М[А], "<a href=""", """>", , )[0];
			ПолныйПуть = ОбъединитьПути(КаталогСправки, ПолныйПуть);
			ФайлСвойства = Новый Файл(ПолныйПуть);
			Если Не ФайлСвойства.Существует() Тогда
				Сообщить("Не найден файл события " + ПолныйПуть);
				Продолжить;
			КонецЕсли;
			СобытиеРус = ИОС.СтрНайтиМежду(М[А], "Event.html"">", "&nbsp;(", , )[0];
			СобытиеАнгл = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[0];
			
			// Прочитаем файл событий и возьмем из него данные.
			ТекстДок = Новый ТекстовыйДокумент;
			ТекстДок.Прочитать(ПолныйПуть);
			СтрДок1 = ТекстДок.ПолучитьТекст();
			СобытиеТип = "IValue";
			
			Использование = ИОС.СтрНайтиМежду(СтрДок1, "<h4 class=dtH4>Использование</h4>", "<h4 class=dtH4>Значение</h4>", , )[0];
			Использование = ИОС.СтрНайтиМежду(Использование, "<p>", "</p>", , )[0];
			
			Попытка
				Рез = Рез + 
				"        [ContextProperty(""" + СобытиеРус + """, """ + СобытиеАнгл + """)]
				|" + КодСобытий[СобытиеРус + "_" + ИмяКлассаАнгл];
				Рез = Рез + 
				"
				|
				|";
			Исключение
				Рез = Рез + 
				"        [ContextProperty(""" + СобытиеРус + """, """ + СобытиеАнгл + """)]
				|        public " + СобытиеТип + " " + СобытиеАнгл + "
				|        {
				|            get { return Base_obj." + СобытиеАнгл + "; }
				|            set { OsUtils.SetSetter(MethodBase.GetCurrentMethod(), Base_obj, value); }
				|        }
				|
				|";
			КонецПопытки;
		КонецЦикла;
	КонецЕсли;
	Рез = Рез + "
	|";
	Возврат Рез;
КонецФункции//СобытияКласса

Функция СвойстваКласса(ДанныеОбъекта)
	Рез = "";
	ИмяКлассаАнгл = ДанныеОбъекта.ИмяКлассаАнгл;
	
	Файл = Новый Файл(ОбъединитьПути(КаталогСправки, "OSGForms." + ИмяКлассаАнгл + "Properties.html"));
	Если Не Файл.Существует() Тогда
		// Сообщить("Не найден файл свойств " + ОбъединитьПути(КаталогСправки, "OSGForms." + ИмяКлассаАнгл + "Properties.html"));
		Возврат Рез;
	КонецЕсли;
	
	// Находим страницу свойств.
	// file:///C:/444/OneScriptGameForms/docs/OSGForms/OSGForms.ColorProperties.html
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ОбъединитьПути(КаталогСправки, "OSGForms." + ИмяКлассаАнгл + "Properties.html"));
	СтрДок = ТекстДок.ПолучитьТекст();
	//Находим текст таблицы.
	М = ИОС.СтрНайтиМежду(СтрДок, "<tr vAlign=top>", "</tr>", , );
	Если М.Количество() > 0 Тогда
		Для А = 0 По М.ВГраница() Цикл
			// Проверим существует ли файл свойства.
			Если СтрНайти(М[А], "<th width=""43%"">Цвет</th>") > 0 Тогда
				Продолжить;
			КонецЕсли;
			ПолныйПуть = ИОС.СтрНайтиМежду(М[А], "<a href=""", """>", , )[0];
			ПолныйПуть = ОбъединитьПути(КаталогСправки, ПолныйПуть);
			ФайлСвойства = Новый Файл(ПолныйПуть);
			Если Не ФайлСвойства.Существует() Тогда
				Сообщить("Не найден файл свойства " + ПолныйПуть);
				Продолжить;
			КонецЕсли;
			СвойствоРус = ИОС.СтрНайтиМежду(М[А], "Property.html"">", "&nbsp;(", , )[0];
			СвойствоАнгл = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[0];
			
			// Для класса Color таблица свойств отличается от остальных, 
			// поэтому сформируем для него отдельно.
			Если ИмяКлассаАнгл = "Color" Тогда
				Если СвойствоРус = "ЗначениеЗеленый" 
					или СвойствоРус = "ЗначениеКрасный" 
					или СвойствоРус = "ЗначениеСиний" Тогда
					Рез = Рез + "
					|        [ContextProperty(""" + СвойствоРус + """, """ + СвойствоАнгл + """)]
					|        public int " + СвойствоАнгл + " { get; set; } = 0;
					|";
				ИначеЕсли СвойствоРус = "ЗначениеАльфа" Тогда
					Рез = Рез + "
					|        [ContextProperty(""" + СвойствоРус + """, """ + СвойствоАнгл + """)]
					|        public int " + СвойствоАнгл + " { get; set; } = 255;
					|";
				ИначеЕсли СвойствоРус = "Имя" Тогда
					Рез = Рез + "
					|        [ContextProperty(""" + СвойствоРус + """, """ + СвойствоАнгл + """)]
					|        public int " + СвойствоАнгл + " { get; set; }
					|";
				Иначе
					rgb = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[1];
					М2 = РазобратьСтроку(rgb, ", ");
					Фрагмент1 = "" + М2[0] + ", " + М2[1] + ", " + М2[2] + ", " + М2[3];
					Рез = Рез + 
					"
					|        [ContextProperty(""" + СвойствоРус + """, """ + СвойствоАнгл + """)]
					|        public GfColor " + СвойствоАнгл + "
					|        {
					|            get { return MakeColor(" + Фрагмент1 + "); }
					|        }
					|";
					// Сообщить("" + Фрагмент1);
				КонецЕсли;
			Иначе
				// Прочитаем файл свойств и возьмем из него данные.
				ТекстДок = Новый ТекстовыйДокумент;
				ТекстДок.Прочитать(ПолныйПуть);
				СтрДок1 = ТекстДок.ПолучитьТекст();
				СвойствоТип = ИОС.СтрНайтиМежду(СтрДок1, "<p>Тип: ", ".</p>", , )[0];
				Если СвойствоТип = "Строка" Тогда
					СвойствоТип = "string";
				ИначеЕсли СвойствоТип = "Число" И 
					(ИмяКлассаАнгл = "StyleBox" 
					или ИмяКлассаАнгл = "StyleBoxLine" 
					или ИмяКлассаАнгл = "StyleBoxFlat" 
					или ИмяКлассаАнгл = "StyleBoxEmpty" 
					или ИмяКлассаАнгл = "StyleBoxTexture") 
					Тогда
					СвойствоТип = "decimal";
				ИначеЕсли СвойствоТип = "Число" Тогда
					СвойствоТип = "int";
				ИначеЕсли СвойствоТип = "Массив" Тогда
					СвойствоТип = "ArrayImpl";
				ИначеЕсли СвойствоТип = "Булево" Тогда
					СвойствоТип = "bool";
				ИначеЕсли СвойствоТип = "Произвольный" Тогда
					СвойствоТип = "IValue";
				ИначеЕсли СвойствоТип = "<a href=""OSGForms.Action.html"">Действие&nbsp;(Action)</a>." Тогда
					СвойствоТип = "IValue";
				ИначеЕсли СтрНайти(СвойствоТип, "<a href=") > 0 Тогда
					Если СтрНайти(СвойствоТип, "Enumeration.html") > 0 Тогда
						СвойствоТип = "int";
					Иначе
						СвойствоТип = "Gf" + ИОС.СтрНайтиМежду(СвойствоТип, "(", ")", , )[0];
					КонецЕсли;
				КонецЕсли;
				
				Использование = ИОС.СтрНайтиМежду(СтрДок1, "<h4 class=dtH4>Использование</h4>", "<h4 class=dtH4>Значение</h4>", , )[0];
				Использование = ИОС.СтрНайтиМежду(Использование, "<p>", "</p>", , )[0];
				
				Попытка
					Рез = Рез + 
					"        [ContextProperty(""" + СвойствоРус + """, """ + СвойствоАнгл + """)]
					|" + КодСвойств[СвойствоРус + "_" + ИмяКлассаАнгл];
					Рез = Рез + 
					"
					|
					|";
				Исключение
					Если СвойствоРус = "ПоворотНаГрадус" Тогда
						Рез = Рез + 
						"        [ContextProperty(""ПоворотНаГрадус"", ""RotationDegrees"")]
						|        public decimal RotationDegrees
						|        {
						|            get { return Base_obj.RotationDegrees; }
						|            set { Base_obj.RotationDegrees = value; }
						|        }
						|
						|";
					ИначеЕсли СвойствоРус = "Игрек" и ИмяКлассаАнгл = "Vector3" Тогда
						Рез = Рез + 
						"        [ContextProperty(""Игрек"", ""Y"")]
						|        public decimal Y { get; set; } = 0;
						|
						|";
					ИначеЕсли СвойствоРус = "Икс" и ИмяКлассаАнгл = "Vector3" Тогда
						Рез = Рез + 
						"        [ContextProperty(""Икс"", ""X"")]
						|        public decimal X { get; set; } = 0;
						|
						|";
					ИначеЕсли СвойствоРус = "Зет" и ИмяКлассаАнгл = "Vector3" Тогда
						Рез = Рез + 
						"        [ContextProperty(""Зет"", ""Z"")]
						|        public decimal Z { get; set; } = 0;
						|
						|";
					ИначеЕсли СвойствоРус = "Игрек" и ИмяКлассаАнгл = "Vector3i" Тогда
						Рез = Рез + 
						"        [ContextProperty(""Игрек"", ""Y"")]
						|        public int Y { get; set; } = 0;
						|
						|";
					ИначеЕсли СвойствоРус = "Икс" и ИмяКлассаАнгл = "Vector3i" Тогда
						Рез = Рез + 
						"        [ContextProperty(""Икс"", ""X"")]
						|        public int X { get; set; } = 0;
						|
						|";
					ИначеЕсли СвойствоРус = "Зет" и ИмяКлассаАнгл = "Vector3i" Тогда
						Рез = Рез + 
						"        [ContextProperty(""Зет"", ""Z"")]
						|        public int Z { get; set; } = 0;
						|
						|";
					ИначеЕсли СвойствоРус = "МасштабПоУмолчанию" и 
						(	ИмяКлассаАнгл = "ThemeVBoxContainer" 
							или ИмяКлассаАнгл = "Theme" 
							или ИмяКлассаАнгл = "ThemeHBoxContainer" 
							или ИмяКлассаАнгл = "ThemeConfirmationDialog" 
							или ИмяКлассаАнгл = "ThemeButton" 
							или ИмяКлассаАнгл = "ThemeScene" 
							или ИмяКлассаАнгл = "ThemeLabel" 
							или ИмяКлассаАнгл = "ThemeWindow" 
							или ИмяКлассаАнгл = "ThemePanelContainer" 
							или ИмяКлассаАнгл = "ThemeAcceptDialog" 
						) Тогда
						Рез = Рез + 
						"        [ContextProperty(""МасштабПоУмолчанию"", ""DefaultBaseScale"")]
						|        public decimal DefaultBaseScale
						|        {
						|            get { return Base_obj.DefaultBaseScale; }
						|            set { Base_obj.DefaultBaseScale = value; }
						|        }
						|
						|";
					ИначеЕсли СвойствоРус = "ЯкорьВерхний" Тогда
						Рез = Рез + 
						"        [ContextProperty(""ЯкорьВерхний"", ""AnchorTop"")]
						|        public decimal AnchorTop
						|        {
						|            get { return Base_obj.AnchorTop; }
						|            set { Base_obj.AnchorTop = value; }
						|        }
						|
						|";
					ИначеЕсли СвойствоРус = "ЯкорьЛевый" Тогда
						Рез = Рез + 
						"        [ContextProperty(""ЯкорьЛевый"", ""AnchorLeft"")]
						|        public decimal AnchorLeft
						|        {
						|            get { return Base_obj.AnchorLeft; }
						|            set { Base_obj.AnchorLeft = value; }
						|        }
						|
						|";
					ИначеЕсли СвойствоРус = "ЯкорьНижний" Тогда
						Рез = Рез + 
						"        [ContextProperty(""ЯкорьНижний"", ""AnchorBottom"")]
						|        public decimal AnchorBottom
						|        {
						|            get { return Base_obj.AnchorBottom; }
						|            set { Base_obj.AnchorBottom = value; }
						|        }
						|
						|";
					ИначеЕсли СвойствоРус = "ЯкорьПравый" Тогда
						Рез = Рез + 
						"        [ContextProperty(""ЯкорьПравый"", ""AnchorRight"")]
						|        public decimal AnchorRight
						|        {
						|            get { return Base_obj.AnchorRight; }
						|            set { Base_obj.AnchorRight = value; }
						|        }
						|
						|";
					ИначеЕсли СвойствоРус = "Интервал" Тогда
						Рез = Рез + 
						"        public decimal waitTime = 1000;
						|        [ContextProperty(""Интервал"", ""WaitTime"")]
						|        public decimal WaitTime
						|        {
						|            get { return waitTime; }
						|            set
						|            {
						|                waitTime = value;
						|                Base_obj.WaitTime = (value / 1000);
						|            }
						|        }
						|
						|";
					Иначе
						Рез = Рез + 
						"        [ContextProperty(""" + СвойствоРус + """, """ + СвойствоАнгл + """)]
						|        public " + СвойствоТип + " " + СвойствоАнгл + "
						|        {
						|            get { return Base_obj." + СвойствоАнгл + "; }";
						Если Использование = "Чтение и запись." Тогда
							Рез = Рез + 
							"
							|            set { Base_obj." + СвойствоАнгл + " = value; }";
						КонецЕсли;
						Рез = Рез + 
						"
						|        }
						|
						|";
					КонецЕсли;
				КонецПопытки;
			КонецЕсли;
		КонецЦикла;
	КонецЕсли;
	Рез = Рез + "
	|";
	Возврат Рез;
КонецФункции//СвойстваКласса

Функция МетодыКласса(ДанныеОбъекта)
	// ДанныеОбъекта.Вставить("ИмяКлассаАнгл", ИмяКлассаАнгл);
	// ДанныеОбъекта.Вставить("ИмяКлассаРус", ИмяКлассаРус);
	// ДанныеОбъекта.Вставить("ПолныйПуть", ПолныйПуть);

	Рез = "";
	ИмяКлассаАнгл = ДанныеОбъекта.ИмяКлассаАнгл;
	// Находим страницу методов.
	// file:///C:/444/OneScriptGameForms/docs/OSGForms/OSGForms.ColorMethods.html
	
	ФайлМетодов = Новый Файл(ОбъединитьПути(КаталогСправки, "OSGForms." + ИмяКлассаАнгл + "Methods.html"));
	Если Не ФайлМетодов.Существует() Тогда
		// Сообщить("Не найден файл методов " + ОбъединитьПути(КаталогСправки, "OSGForms." + ИмяКлассаАнгл + "Methods.html"));
		Возврат Рез;
	КонецЕсли;
	
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ОбъединитьПути(КаталогСправки, "OSGForms." + ИмяКлассаАнгл + "Methods.html"));
	СтрДок = ТекстДок.ПолучитьТекст();
	//Находим текст таблицы.
	М = ИОС.СтрНайтиМежду(СтрДок, "<tr vAlign=top>", "</tr>", , );
	Если М.Количество() > 0 Тогда
		Для А = 0 По М.ВГраница() Цикл
			// Проверим существует ли файл метода.
			ПолныйПуть = ИОС.СтрНайтиМежду(М[А], "<a href=""", """>", , )[0];
			ПолныйПуть = ОбъединитьПути(КаталогСправки, ПолныйПуть);
			ФайлМетода = Новый Файл(ПолныйПуть);
			Если Не ФайлМетода.Существует() Тогда
				Сообщить("Не найден файл метода " + ПолныйПуть);
				// ЗавершитьРаботу(1);
				Продолжить;
			КонецЕсли;
			
			ДанныеМетода = Новый Структура();
			ДанныеМетода.Вставить("ИмяКлассаАнгл", ИмяКлассаАнгл);
			ДанныеМетода.Вставить("ПолныйПуть", ПолныйПуть);
			// Сообщить("М[А] = " + М[А]);
			МетодРус = ИОС.СтрНайтиМежду(М[А], "Method.html"">", "&nbsp;(", , )[0];
			ДанныеМетода.Вставить("МетодРус", МетодРус);
			МетодАнгл = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[0];
			ДанныеМетода.Вставить("МетодАнгл", МетодАнгл);
			
			Если ИмяКлассаАнгл = "ййййй" Тогда
				Рез = Рез + 
				"
				|        [ContextProperty(""ййййй"", ""ййййй"")]
				|        public GfColor ййййй
				|        {
				|            get { return ййййй(ййййй); }
				|        }
				|";
			Иначе
				Рез = Рез + СформироватьМетод(ДанныеМетода);
			КонецЕсли;
		КонецЦикла;
	КонецЕсли;

	Возврат Рез;
КонецФункции//МетодыКласса

Функция СформироватьМетод(ДанныеОбъекта)
	// ДанныеМетода.Вставить("ИмяКлассаАнгл", ИмяКлассаАнгл);
	// ДанныеМетода.Вставить("ПолныйПуть", ПолныйПуть);
	// ДанныеМетода.Вставить("МетодРус", МетодРус);
	// ДанныеМетода.Вставить("МетодАнгл", МетодАнгл);

	ИмяКлассаАнгл = ДанныеОбъекта.ИмяКлассаАнгл;
	ПолныйПуть = ДанныеОбъекта.ПолныйПуть;
	МетодРус = ДанныеОбъекта.МетодРус;
	МетодАнгл = ДанныеОбъекта.МетодАнгл;
	
	// Прочитаем файл методов и возьмем из него данные.
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ПолныйПуть);
	СтрДок = ТекстДок.ПолучитьТекст();
	
	ВозвращаемоеЗначениеТип = "void";
	ВозвращаемоеЗначение = ИОС.СтрНайтиМежду(СтрДок, "<h4 class=dtH4>Возвращаемое значение</h4>", "<h4 class=dtH4>Описание</h4>", , )[0];
	М = ИОС.СтрНайтиМежду(ВозвращаемоеЗначение, "<p>Тип: ", ".</p>", , );
	Если М.Количество() > 0 Тогда
		ВозвращаемоеЗначениеТип = М[0];
	КонецЕсли;
	Если ВозвращаемоеЗначениеТип = "Строка" Тогда
		ВозвращаемоеЗначениеТип = "string";
	ИначеЕсли ВозвращаемоеЗначениеТип = "Число" Тогда
		ВозвращаемоеЗначениеТип = "int";
	ИначеЕсли ВозвращаемоеЗначениеТип = "Булево" Тогда
		ВозвращаемоеЗначениеТип = "bool";
	ИначеЕсли ВозвращаемоеЗначениеТип = "Массив" Тогда
		ВозвращаемоеЗначениеТип = "ArrayImpl";
	ИначеЕсли ВозвращаемоеЗначениеТип = "Произвольный" Тогда
		ВозвращаемоеЗначениеТип = "IValue";
	ИначеЕсли ВозвращаемоеЗначениеТип = "БуферДвоичныхДанных (BinaryDataBuffer)" Тогда
		ВозвращаемоеЗначениеТип = "BinaryDataBuffer";
	ИначеЕсли СтрНайти(ВозвращаемоеЗначениеТип, "Enumeration.html") > 0 Тогда
		ВозвращаемоеЗначениеТип = "int";
	ИначеЕсли СтрНайти(ВозвращаемоеЗначениеТип, "<a href=") > 0 Тогда
		ВозвращаемоеЗначениеТип = "Gf" + ИОС.СтрНайтиМежду(ВозвращаемоеЗначениеТип, "(", ")", , )[0];
	КонецЕсли;
	
	Параметр1Тип = "";
	Параметр1 = ИОС.СтрНайтиМежду(СтрДок, "<h4 class=dtH4>Синтаксис</h4>", "/p>", , )[0];
	М = ИОС.СтрНайтиМежду(Параметр1, "(&lt;", "&gt;)", , );
	Если М.Количество() > 0 Тогда // Есть по крайней мере один параметр p1.
		Параметр1Тип = ИОС.СтрНайтиМежду(СтрДок, "<h4 class=dtH4>Параметры</h4>", "<h4 class=dtH4>Возвращаемое значение</h4>", , )[0];
		Параметр1Тип = ИОС.СтрНайтиМежду(Параметр1Тип, "<dd>Тип: ", ".</dd>", , )[0];
		Если ВозвращаемоеЗначениеТип = "void" Тогда
			Фрагмент1 = "
			|            Base_obj." + МетодАнгл + "(p1);";
		Иначе
			Фрагмент1 = "
			|            return Base_obj." + МетодАнгл + "(p1);";
		КонецЕсли;

	Иначе
		Если ВозвращаемоеЗначениеТип = "void" Тогда
			Фрагмент1 = "
			|            Base_obj." + МетодАнгл + "();";
		Иначе
			Фрагмент1 = "
			|            return Base_obj." + МетодАнгл + "();";
		КонецЕсли;
	КонецЕсли;
	Если Параметр1Тип = "Строка" Тогда
		Параметр1Тип = "string p1";
	ИначеЕсли Параметр1Тип = "Число" Тогда
		Параметр1Тип = "int p1";
	ИначеЕсли Параметр1Тип = "Произвольный" Тогда
		Параметр1Тип = "IValue p1";
	ИначеЕсли Параметр1Тип = "БуферДвоичныхДанных (BinaryDataBuffer)" Тогда
		Параметр1Тип = "BinaryDataBuffer p1";
	КонецЕсли;
	
	Рез = "";
	Попытка
		Рез = Рез + 
		"        [ContextMethod(""" + МетодРус + """, """ + МетодАнгл + """)]
		|" + КодМетодов[МетодРус + "_" + ИмяКлассаАнгл];
		Рез = Рез + 
		"
		|
		|";
	Исключение
		Если МетодРус = "ВСтроку" Тогда
			Рез = Рез +
			"        [ContextMethod(""ВСтроку"", ""ToString"")]
			|        public new GfString ToString()
			|        {
			|            return new GfString(""Gf" + ИмяКлассаАнгл + """ + System.Environment.NewLine + GameForms.instance.PropertiesAndValues(this));
			|        }
			|
			|";
		ИначеЕсли МетодРус = "Очистить" и 
			(	ИмяКлассаАнгл = "ThemeVBoxContainer" 
				или ИмяКлассаАнгл = "Theme" 
				или ИмяКлассаАнгл = "ThemeHBoxContainer" 
				или ИмяКлассаАнгл = "ThemeConfirmationDialog" 
				или ИмяКлассаАнгл = "ThemeButton" 
				или ИмяКлассаАнгл = "ThemeScene" 
				или ИмяКлассаАнгл = "ThemeLabel" 
				или ИмяКлассаАнгл = "ThemeWindow" 
				или ИмяКлассаАнгл = "ThemePanelContainer" 
				или ИмяКлассаАнгл = "ThemeAcceptDialog" 
			) Тогда
			Рез = Рез +
			"        [ContextMethod(""Очистить"", ""Clear"")]
			|        public void Clear()
			|        {
			|            Base_obj.ClearTheme();
			|        }
			|
			|";
		ИначеЕсли МетодРус = "Вектор3ц" и ИмяКлассаАнгл = "Vector3" Тогда
			Рез = Рез + 
			"        [ContextMethod(""Вектор3ц"", ""Vector3i"")]
			|        public GfVector3i Vector3i(GfVector3 p1)
			|        {
			|            int x = Convert.ToInt32(p1.X);
			|            int y = Convert.ToInt32(p1.Y);
			|            int z = Convert.ToInt32(p1.Z);
			|            return new GfVector3i(x, y, z);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "Вектор3" и ИмяКлассаАнгл = "Vector3i" Тогда
			Рез = Рез + 
			"        [ContextMethod(""Вектор3"", ""Vector3"")]
			|        public GfVector3 Vector3(GfVector3i p1)
			|        {
			|            int x = Convert.ToInt32(p1.X);
			|            int y = Convert.ToInt32(p1.Y);
			|            int z = Convert.ToInt32(p1.Z);
			|            return new GfVector3(x, y, z);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "УстановитьПиксель" Тогда
			Рез = Рез +
			"        [ContextMethod(""УстановитьПиксель"", ""SetPixel"")]
			|        public void SetPixel(int p1, int p2, GfColor p3)
			|        {
			|            Base_obj.SetPixel(p1, p2, p3);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "СмотретьИзПозиции" Тогда
			Рез = Рез +
			"        [ContextMethod(""СмотретьИзПозиции"", ""LookAtFromPosition"")]
			|        public void LookAtFromPosition(GfVector3 p1, GfVector3 p2, GfVector3 p3, bool p4 = false)
			|        {
			|            Base_obj.LookAtFromPosition(p1, p2, p3, p4);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ВГлобальные" Тогда
			Рез = Рез +
			"        [ContextMethod(""ВГлобальные"", ""ToGlobal"")]
			|        public GfVector2 ToGlobal(GfVector2 p1)
			|        {
			|            return Base_obj.ToGlobal(p1);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ВЛокальные" Тогда
			Рез = Рез +
			"        [ContextMethod(""ВЛокальные"", ""ToLocal"")]
			|        public GfVector2 ToLocal(GfVector2 p1)
			|        {
			|            return Base_obj.ToLocal(p1);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "УстановитьСтильПанели" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""УстановитьСтильПанели"", ""SetStylebox"")]
			|        public void SetStylebox(string propertyPath, IValue stylebox)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.SetStylebox(propertyName, themeType, stylebox);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ОчиститьЗначок" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""ОчиститьЗначок"", ""ClearIcon"")]
			|        public void ClearIcon(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.ClearIcon(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ОчиститьКонстанту" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""ОчиститьКонстанту"", ""ClearConstant"")]
			|        public void ClearConstant(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.ClearConstant(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ОчиститьРазмерШрифта" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""ОчиститьРазмерШрифта"", ""ClearFontSize"")]
			|        public void ClearFontSize(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.ClearFontSize(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ОчиститьСтильПанели" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""ОчиститьСтильПанели"", ""ClearStylebox"")]
			|        public void ClearStylebox(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.ClearStylebox(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ОчиститьЦвет" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""ОчиститьЦвет"", ""ClearColor"")]
			|        public void ClearColor(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.ClearColor(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ОчиститьШрифт" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""ОчиститьШрифт"", ""ClearFont"")]
			|        public void ClearFont(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.ClearFont(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьЗначок" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьЗначок"", ""GetIcon"")]
			|        public GfImageTexture GetIcon(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            return Base_obj.GetIcon(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьРазмерШрифта" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьРазмерШрифта"", ""GetFontSize"")]
			|        public int GetFontSize(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            return Base_obj.GetFontSize(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьСтильПанели" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьСтильПанели"", ""GetStylebox"")]
			|        public IValue GetStylebox(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            return Base_obj.GetStylebox(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьШрифт" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьШрифт"", ""GetFont"")]
			|        public IValue GetFont(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            return Base_obj.GetFont(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "УстановитьЗначок" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""УстановитьЗначок"", ""SetIcon"")]
			|        public void SetIcon(string propertyPath, GfImageTexture icon)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.SetIcon(propertyName, themeType, icon);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "УстановитьРазмерШрифта" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""УстановитьРазмерШрифта"", ""SetFontSize"")]
			|        public void SetFontSize(string propertyPath, int fontSize)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.SetFontSize(propertyName, themeType, fontSize);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "УстановитьШрифт" и ИмяКлассаАнгл = "ThemeScene" Тогда
			Рез = Рез +
			"        [ContextMethod(""УстановитьШрифт"", ""SetFont"")]
			|        public void SetFont(string propertyPath, IValue font)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.SetFont(propertyName, themeType, font);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьКонстанту" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьКонстанту"", ""GetConstant"")]
			|        public int GetConstant(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            return Base_obj.GetConstant(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "УстановитьКонстанту" Тогда
			Рез = Рез +
			"        [ContextMethod(""УстановитьКонстанту"", ""SetConstant"")]
			|        public void SetConstant(string propertyPath, int constanta)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.SetConstant(propertyName, themeType, constanta);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьЦвет" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьЦвет"", ""GetColor"")]
			|        public GfColor GetColor(string propertyPath)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            return Base_obj.GetColor(propertyName, themeType);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "УстановитьЦвет" Тогда
			Рез = Рез +
			"        [ContextMethod(""УстановитьЦвет"", ""SetColor"")]
			|        public void SetColor(string propertyPath, GfColor color)
			|        {
			|            string propertyName = propertyPath.Split(':')[0];
			|            string themeType = propertyPath.Split(':')[1];
			|            Base_obj.SetColor(propertyName, themeType, color);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьОкно" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьОкно"", ""GetWindow"")]
			|        public IValue GetWindow()
			|        {
			|            return Base_obj.GetWindow();
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьПиксель" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьПиксель"", ""GetPixel"")]
			|        public GfColor GetPixel(int x, int y)
			|        {
			|            return Base_obj.GetPixel(x, y);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "Сохранить" Тогда
			Рез = Рез +
			"        [ContextMethod(""Сохранить"", ""Save"")]
			|        public void Save(string path)
			|        {
			|            Base_obj.Save(path);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ЦентрНаТочку" Тогда
			Рез = Рез +
			"        [ContextMethod(""ЦентрНаТочку"", ""SetCenterToPoint"")]
			|        public void SetCenterToPoint(GfVector2 p1)
			|        {
			|            Base_obj.SetCenterToPoint(p1);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "Центр" Тогда
			Рез = Рез +
			"        [ContextMethod(""Центр"", ""Center"")]
			|        public void Center(decimal p1 = 0, decimal p2 = 0)
			|        {
			|            Base_obj.Center(p1, p2);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "Выше" Тогда
			Рез = Рез +
			"        [ContextMethod(""Выше"", ""PlaceTop"")]
			|        public void PlaceTop(IValue p1, int p2)
			|        {
			|            Base_obj.PlaceTop(p1, p2);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ВышеЛевее" Тогда
			Рез = Рез +
			"        [ContextMethod(""ВышеЛевее"", ""PlaceTopLeft"")]
			|        public void PlaceTopLeft(IValue p1, int p2, int p3)
			|        {
			|            Base_obj.PlaceTopLeft(p1, p2, p3);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ВышеПравее" Тогда
			Рез = Рез +
			"        [ContextMethod(""ВышеПравее"", ""PlaceTopRight"")]
			|        public void PlaceTopRight(IValue p1, int p2, int p3)
			|        {
			|            Base_obj.PlaceTopRight(p1, p2, p3);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "Левее" Тогда
			Рез = Рез +
			"        [ContextMethod(""Левее"", ""PlaceLeft"")]
			|        public void PlaceLeft(IValue p1, int p2)
			|        {
			|            Base_obj.PlaceLeft(p1, p2);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ЛевееВыше" Тогда
			Рез = Рез +
			"        [ContextMethod(""ЛевееВыше"", ""PlaceLeftTop"")]
			|        public void PlaceLeftTop(IValue p1, int p2, int p3)
			|        {
			|            Base_obj.PlaceLeftTop(p1, p2, p3);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ЛевееНиже" Тогда
			Рез = Рез +
			"        [ContextMethod(""ЛевееНиже"", ""PlaceLeftBottom"")]
			|        public void PlaceLeftBottom(IValue p1, int p2, int p3)
			|        {
			|            Base_obj.PlaceLeftBottom(p1, p2, p3);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "Ниже" Тогда
			Рез = Рез +
			"        [ContextMethod(""Ниже"", ""PlaceBottom"")]
			|        public void PlaceBottom(IValue p1, int p2)
			|        {
			|            Base_obj.PlaceBottom(p1, p2);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "НижеЛевее" Тогда
			Рез = Рез +
			"        [ContextMethod(""НижеЛевее"", ""PlaceBottomLeft"")]
			|        public void PlaceBottomLeft(IValue p1, int p2, int p3)
			|        {
			|            Base_obj.PlaceBottomLeft(p1, p2, p3);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "НижеПравее" Тогда
			Рез = Рез +
			"        [ContextMethod(""НижеПравее"", ""PlaceBottomRight"")]
			|        public void PlaceBottomRight(IValue p1, int p2, int p3)
			|        {
			|            Base_obj.PlaceBottomRight(p1, p2, p3);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "Правее" Тогда
			Рез = Рез +
			"        [ContextMethod(""Правее"", ""PlaceRight"")]
			|        public void PlaceRight(IValue p1, int p2)
			|        {
			|            Base_obj.PlaceRight(p1, p2);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПравееВыше" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПравееВыше"", ""PlaceRightTop"")]
			|        public void PlaceRightTop(IValue p1, int p2, int p3)
			|        {
			|            Base_obj.PlaceRightTop(p1, p2, p3);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПравееНиже" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПравееНиже"", ""PlaceRightBottom"")]
			|        public void PlaceRightBottom(IValue p1, int p2, int p3)
			|        {
			|            Base_obj.PlaceRightBottom(p1, p2, p3);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ДобавитьСтиль" Тогда
			Рез = Рез +
			"        [ContextMethod(""ДобавитьСтиль"", ""AddThemeStyleboxOverride"")]
			|        public void AddThemeStyleboxOverride(string p1, IValue p2)
			|        {
			|            Base_obj.AddThemeStyleboxOverride(p1.Split(':')[0], p2);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "УдалитьСтиль" Тогда
			Рез = Рез +
			"        [ContextMethod(""УдалитьСтиль"", ""RemoveThemeStyleboxOverride"")]
			|        public void RemoveThemeStyleboxOverride(string p1)
			|        {
			|            Base_obj.RemoveThemeStyleboxOverride(p1.Split(':')[0]);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "Дублировать" Тогда
			Рез = Рез +
			"        [ContextMethod(""Дублировать"", ""Duplicate"")]
			|        public IValue Duplicate()
			|        {
			|            return Base_obj.Duplicate();
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьСтильПанелиЛиния" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьСтильПанелиЛиния"", ""GetThemeStyleboxLine"")]
			|        public IValue GetThemeStyleboxLine(string p1)
			|        {
			|            return Base_obj.GetThemeStyleboxLine(p1.Split(':')[0]);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьСтильПанелиПлоский" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьСтильПанелиПлоский"", ""GetThemeStyleboxFlat"")]
			|        public IValue GetThemeStyleboxFlat(string p1)
			|        {
			|            return Base_obj.GetThemeStyleboxFlat(p1.Split(':')[0]);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьСтильПанелиПусто" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьСтильПанелиПусто"", ""GetThemeStyleboxEmpty"")]
			|        public IValue GetThemeStyleboxEmpty(string p1)
			|        {
			|            return Base_obj.GetThemeStyleboxEmpty(p1.Split(':')[0]);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПолучитьСтильПанелиТекстура" Тогда
			Рез = Рез +
			"        [ContextMethod(""ПолучитьСтильПанелиТекстура"", ""GetThemeStyleboxTexture"")]
			|        public IValue GetThemeStyleboxTexture(string p1)
			|        {
			|            return Base_obj.GetThemeStyleboxTexture(p1.Split(':')[0]);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ВписатьДочернийВПрямоугольник" Тогда
			Рез = Рез +
			"        [ContextMethod(""ВписатьДочернийВПрямоугольник"", ""FitChildInRect"")]
			|        public void FitChildInRect(IValue p1, GfRect2 p2)
			|        {
			|            Base_obj.FitChildInRect(p1, p2);
			|        }
			|
			|";
		ИначеЕсли МетодРус = "ПереместитьМышь" Тогда
			Рез = Рез +
			"        [ContextMethod(""" + МетодРус + """, """ + МетодАнгл + """)]
			|        public void " + МетодАнгл + "(GfVector2 p1)
			|        {
			|            Base_obj." + МетодАнгл + "(p1);
			|        }
			|
			|";
		Иначе
			Рез = Рез +
			"        [ContextMethod(""" + МетодРус + """, """ + МетодАнгл + """)]
			|        public " + ВозвращаемоеЗначениеТип + " " + МетодАнгл + "(" + Параметр1Тип + ")
			|        {" + Фрагмент1 + "
			|        }
			|
			|";
		КонецЕсли;
	КонецПопытки;
	
	Возврат Рез;
КонецФункции//СформироватьМетод

Функция ПоследниеИсправления(ДанныеОбъекта, СтрВыгрузки)
	// ДанныеОбъекта.Вставить("ИмяКлассаАнгл", ИмяКлассаАнгл);
	// ДанныеОбъекта.Вставить("ИмяКлассаРус", ИмяКлассаРус);
	// ДанныеОбъекта.Вставить("ПолныйПуть", ПолныйПуть);
	
	ИмяКлассаАнгл = ДанныеОбъекта.ИмяКлассаАнгл;
	Если ИмяКлассаАнгл = "Color" Тогда
		ПодстрокаПоиска = 
		"[ContextProperty(""Имя"", ""Name"")]
		|        public int Name { get; set; }";
		ПодстрокаЗамены = 
		"[ContextProperty(""Имя"", ""Имя"")]
		|        public string NameRu
		|        {
		|            get
		|            {
		|                string name = getNameRu(this);
		|                if (name != """")
		|                {
		|                    return name;
		|                }
		|                else
		|                {
		|                    decimal Dec1 = (A * 16777216) + (R * 65536) + (G * 256) + B;
		|                    if (Dec1 == 0)
		|                    {
		|                        return ""Черный"";
		|                    }
		|                    return ""RGB("" + this.R.ToString() + "", "" + this.G.ToString() + "", "" + this.B.ToString() + "")"";
		|                }
		|            }
		|        }
		|
		|        [ContextProperty(""Name"", ""Name"")]
		|        public string NameEn
		|        {
		|            get
		|            {
		|                string name = getNameEn(this);
		|                if (name != """")
		|                {
		|                    return name;
		|                }
		|                else
		|                {
		|                    decimal Dec1 = (A * 16777216) + (R * 65536) + (G * 256) + B;
		|                    if (Dec1 == 0)
		|                    {
		|                        return ""Black"";
		|                    }
		|                    return ""RGB("" + this.R.ToString() + "", "" + this.G.ToString() + "", "" + this.B.ToString() + "")"";
		|                }
		|            }
		|        }
		|";
		// Откроем файл свойства.
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ОбъединитьПути(КаталогСправки, "OSGForms." + ИмяКлассаАнгл + "Properties.html"));
		СтрДок = ТекстДок.ПолучитьТекст();
		М = ИОС.СтрНайтиМежду(СтрДок, "<tr vAlign=top>", "</tr>", , );
		// Сообщить("М.Количество() = " + М.Количество());
		ПодстрокаЗамены = ПодстрокаЗамены +
		"
		|        public string getNameRu(GfColor p1)
		|        {
		|            string result = p1.ToString() switch
		|            {";
		Если М.Количество() > 1 Тогда
			Для А = 0 По М.ВГраница() Цикл
				Если СтрНайти(М[А], "<th width=""43%"">Цвет</th>") > 0 Тогда
					Продолжить;
				КонецЕсли;
				РусИмя = ИОС.СтрНайтиМежду(М[А], "Property.html"">", "&nbsp;(", , )[0];
				АнглИмя = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[0];
				Если РусИмя = "ЗначениеАльфа" 
					или РусИмя = "ЗначениеЗеленый" 
					или РусИмя = "ЗначениеКрасный" 
					или РусИмя = "ЗначениеСиний" 
					или РусИмя = "Имя" Тогда
				Иначе
					rgb = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[1];
					М2 = РазобратьСтроку(rgb, ", ");
					Фрагмент1 = """{R:" + М2[0] + " G:" + М2[1] + " B:" + М2[2] + " A:" + М2[3] + "}"" => """ + РусИмя + """,";
					// Сообщить("Фрагмент1 = " + Фрагмент1);
					ПодстрокаЗамены = ПодстрокаЗамены + "
					|                " + Фрагмент1;
				КонецЕсли;
			КонецЦикла;
		КонецЕсли;
		ПодстрокаЗамены = ПодстрокаЗамены + 
		"
		|                _ => """" // аналог default
		|            };
		|            return result;
		|        }
		|";
		ПодстрокаЗамены = ПодстрокаЗамены +
		"
		|        public string getNameEn(GfColor p1)
		|        {
		|            string result = p1.ToString() switch
		|            {";
		Если М.Количество() > 1 Тогда
			Для А = 0 По М.ВГраница() Цикл
				Если СтрНайти(М[А], "<th width=""43%"">Цвет</th>") > 0 Тогда
					Продолжить;
				КонецЕсли;
				РусИмя = ИОС.СтрНайтиМежду(М[А], "Property.html"">", "&nbsp;(", , )[0];
				АнглИмя = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[0];
				Если РусИмя = "ЗначениеАльфа" 
					или РусИмя = "ЗначениеЗеленый" 
					или РусИмя = "ЗначениеКрасный" 
					или РусИмя = "ЗначениеСиний" 
					или РусИмя = "Имя" Тогда
				Иначе
					rgb = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[1];
					М2 = РазобратьСтроку(rgb, ", ");
					Фрагмент1 = """{R:" + М2[0] + " G:" + М2[1] + " B:" + М2[2] + " A:" + М2[3] + "}"" => """ + АнглИмя + """,";
					ПодстрокаЗамены = ПодстрокаЗамены + "
					|                " + Фрагмент1;
				КонецЕсли;
			КонецЦикла;
		КонецЕсли;
		ПодстрокаЗамены = ПодстрокаЗамены + 
		"
		|                _ => """" // аналог default
		|            };
		|            return result;
		|        }";
		// Сообщить("ПодстрокаЗамены = " + ПодстрокаЗамены);
		СтрВыгрузки = СтрЗаменить(СтрВыгрузки, ПодстрокаПоиска, ПодстрокаЗамены);
	КонецЕсли;
	
	//заменим две пустые строки подряд на одну пустую
	Стр = СтрВыгрузки;
	СтрКонечная = "";
	Для А1 = 1 По СтрЧислоСтрок(Стр) - 1 Цикл
		Фрагмент1 = СокрЛП(СтрПолучитьСтроку(Стр, А1));
		Фрагмент2 = СокрЛП(СтрПолучитьСтроку(Стр, А1 + 1));
		Если Фрагмент1 = "" И Фрагмент2 = "" Тогда
		Иначе
			СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, А1);
		КонецЕсли;
	КонецЦикла;
	СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, СтрЧислоСтрок(Стр));
	СтрВыгрузки = СокрЛП(СтрКонечная) + Символы.ПС;
	
	Возврат СтрВыгрузки;
КонецФункции//ПоследниеИсправления

Функция Подвал()
	Стр = 
	"    }
	|}
	|";
	Возврат Стр;
КонецФункции//Подвал

Процедура ВыгрузкаДляGForms()
	// Подготовим каталог выгрузки.
	УдалитьФайлы(КаталогВыгрузки, "*.cs");
	УдалитьФайлы(КаталогВыгрузки, "*.os");
	
	// Создадим файлы "*.cs" для перечислений.
	ОтобранныеПеречисления = ОтобратьФайлы("Перечисление");
	Для А = 0 По ОтобранныеПеречисления.ВГраница() Цикл
		// Сообщить("" + ОтобранныеПеречисления[А]);
		ДанныеОбъекта = ДанныеОбъекта(ОтобранныеПеречисления[А]);
		// Для Каждого Элемент Из ДанныеОбъекта Цикл
			// Сообщить(Элемент.Ключ + " = " + Элемент.Значение);
		// КонецЦикла;
		СтрВыгрузки = "";
		СтрВыгрузки = СтрВыгрузки + ДирективыПеречисления(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + ПространствоИмен(ДанныеОбъекта.ИмяКлассаАнгл);
		СтрВыгрузки = СтрВыгрузки + КлассУровня1(ДанныеОбъекта.ИмяКлассаАнгл);
		СтрВыгрузки = СтрВыгрузки + ШапкаПеречисления(ДанныеОбъекта.ИмяКлассаАнгл, ДанныеОбъекта.ИмяКлассаРус);
		СтрВыгрузки = СтрВыгрузки + РазделОбъявленияПеременных(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + КонструкторПеречисления(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + СвойствоПеречисленияИмя(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + СвойствоПеречисленияName(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + СвойстваПеречисления(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + Подвал();
		
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать(ОбъединитьПути(КаталогВыгрузки, ДанныеОбъекта.ИмяКлассаАнгл + ".cs"));
	КонецЦикла;
	
	// Создадим файлы "*.cs" для классов (с методами и свойствами).
	ОтобранныеКлассы = ОтобратьФайлы("Класс");
	Для А = 0 По ОтобранныеКлассы.ВГраница() Цикл
		// Сообщить("" + ОтобранныеКлассы[А]);
		ДанныеОбъекта = ДанныеОбъекта(ОтобранныеКлассы[А]);
		Если БазовыеКлассы.НайтиПоЗначению(ДанныеОбъекта.ИмяКлассаАнгл) <> Неопределено Тогда
			СтрВыгрузки = "";
			СтрВыгрузки = СтрВыгрузки + КлассУровня1(ДанныеОбъекта.ИмяКлассаАнгл);
			ТекстДокХХХ = Новый ТекстовыйДокумент;
			ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
			ТекстДокХХХ.Записать(ОбъединитьПути(КаталогВыгрузки, ДанныеОбъекта.ИмяКлассаАнгл + ".cs"));
			Продолжить;
		КонецЕсли;
		Для Каждого Элемент Из ДанныеОбъекта Цикл
			// Сообщить(Элемент.Ключ + " = " + Элемент.Значение);
		КонецЦикла;
		СтрВыгрузки = "";
		СтрВыгрузки = СтрВыгрузки + Директивы(ДанныеОбъекта.ИмяКлассаАнгл);
		СтрВыгрузки = СтрВыгрузки + ПространствоИмен(ДанныеОбъекта.ИмяКлассаАнгл);
		СтрВыгрузки = СтрВыгрузки + КлассУровня1(ДанныеОбъекта.ИмяКлассаАнгл);
		СтрВыгрузки = СтрВыгрузки + Шапка(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + РазделОбъявленияПеременных(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + Конструктор(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + СвойстваКласса(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + МетодыКласса(ДанныеОбъекта);
		СтрВыгрузки = СтрВыгрузки + СобытияКласса(ДанныеОбъекта);
		СтрВыгрузки = ПоследниеИсправления(ДанныеОбъекта, СтрВыгрузки);
		СтрВыгрузки = СтрВыгрузки + Подвал();
		
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать(ОбъединитьПути(КаталогВыгрузки, ДанныеОбъекта.ИмяКлассаАнгл + ".cs"));
	КонецЦикла;
	
	// Создадим файл GameForms.cs.
	СтрGameForms = 
	"using OneScript.Contexts;
	|using OneScript.Execution;
	|using OneScript.Language;
	|using OneScript.StandardLibrary;
	|using OneScript.StandardLibrary.Collections;
	|using ScriptEngine;
	|using ScriptEngine.HostedScript;
	|using ScriptEngine.HostedScript.Extensions;
	|using ScriptEngine.Hosting;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Collections.Concurrent;
	|using System.Diagnostics;
	|using System.Reflection;
	|using System.Text.Json;
	|
	|namespace osgf
	|{
	|    [ContextClass(""ИгровыеФормы"", ""GameForms"")]
	|    public class GameForms : AutoContext<GameForms>, IDisposable
	|    {
	|        public static GameForms instance;
	|        public static GfAction EventAction = null;
	|        public static ConcurrentQueue<GfEventArgs> EventQueue = new ConcurrentQueue<GfEventArgs>();
	|        private static object syncRoot = new Object();
	|        public static ConcurrentDictionary<string, dynamic> dictKeyEl = new ConcurrentDictionary<string, dynamic>();
	|        public static ConcurrentDictionary<dynamic, string> dictElKey = new ConcurrentDictionary<dynamic, string>();
	|        public static GfWindow rootWindow;
	|        public static string gameFormsItemKey;
	|        public GameForms dll_obj = null;
	|        public static bool displayServiceMessages = false;
	|        private bool godotLaunched = false;
	|        public event Action<string> OnTestException; // Для отлова событий в сценарных обработчиках событий.
	|
	|        // Процесс Godot
	|        private static System.Diagnostics.Process godotProcess;
	|        private static ConcurrentDictionary<string, TaskCompletionSource<string>> pendingCommands
	|            = new ConcurrentDictionary<string, TaskCompletionSource<string>>();
	|
	|        // Для синхронизации запуска, подтверждение запуска Godo.
	|        private static ManualResetEventSlim godotReady = new ManualResetEventSlim(false);
	|
	|        private static ScriptingEngine engine;
	|
	|        // Статический кэш: ""ПанельныйКонтейнер"" → typeof(GfPanelContainer)
	|        private static readonly Dictionary<string, Type> _typeCache = BuildTypeCache();
	|
	|        private static Dictionary<string, Type> BuildTypeCache()
	|        {
	|            var cache = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
	|            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
	|            {
	|                if (!type.IsClass || !type.IsPublic)
	|                {
	|                    continue;
	|                }
	|                var attr = type.GetCustomAttribute<ContextClassAttribute>();
	|                if (attr == null)
	|                {
	|                    continue;
	|                }
	|                // attr.Name выглядит как ""ИфПанельныйКонтейнер""
	|                // убираем префикс ""Иф"" → ""ПанельныйКонтейнер""
	|                var key = attr.Name.Replace(""Иф"", """");
	|                cache[key] = type;
	|                // Добавляем английские имена классов.
	|                // ФлагПереносаСтроки = osgf.GfLineBreakFlag
	|                var key2 = type.ToString().Replace(""osgf.Gf"", """");
	|                cache[key2] = type;
	|            }
	|            return cache;
	|        }
	|
	|        // Подключение к сценарию и запуск Godot =======================================================
	|        public static GameForms getInstance()
	|        {
	|            if (instance == null)
	|            {
	|                lock (syncRoot)
	|                {
	|                    instance = new GameForms();
	|                    instance.OnTestException += GameForms_OnTestException;
	|                }
	|            }
	|            return instance;
	|        }
	|
	|        private static void GameForms_OnTestException(string obj)
	|        {
	|            OsUtils.Echo(obj);
	|            try
	|            {
	|                instance.Shutdown();
	|            }
	|            catch { }
	|            System.Environment.Exit(1);
	|        }
	|
	|        [ScriptConstructor]
	|        public static IRuntimeContextInstance Constructor()
	|        {
	|            // Устанавливаем кодировку для stdin и stdout
	|            Console.InputEncoding = System.Text.Encoding.UTF8;
	|            Console.OutputEncoding = System.Text.Encoding.UTF8;
	|
	|            instance = getInstance();
	|            instance.dll_obj = instance;
	|            StartEventProcessing();
	|            return instance;
	|        }
	|
	|        public static void StartEventProcessing()
	|        {
	|            ScriptingEngine Engine = DefaultEngineBuilder.Create()
	|                .SetupConfiguration(providers => { }) // Здесь можно подключить свои кастомные провайдеры
	|                .SetDefaultOptions() // Подключает Строку, Число, Булево и т.д.
	|                .UseImports() // Позволяет писать ""Импорт *"" внутри скриптов
	|                .UseNativeRuntime() // Доступ к нативным объектам CLR
	|                .UseFileSystemLibraries()
	|                .Build();
	|
	|            engine = Engine;
	|
	|            // Регистрируем сборку по имени любого из стандартных классов движка
	|            Engine.AttachAssembly(System.Reflection.Assembly.GetAssembly(typeof(ArrayImpl)));
	|
	|            HostedScriptEngine Hosted = new HostedScriptEngine(Engine);
	|            Hosted.Initialize();
	|
	|            var cs = Engine.GetCompilerService();
	|            IBslProcess Process = Engine.NewProcess();
	|
	|            string startEventProcessing = @""
	|Процедура ЗапускСобытий(параметр1) Экспорт
	|    Контекст = Новый Структура();
	|    Контекст.Вставить(""""ИФ"""", параметр1);
	|    Стр = """"
	|    |Пока ИФ.Продолжать Цикл
	|    |   Попытка
	|    |       Пока ИФ.Продолжать Цикл
	|    |            ИФ.ПолучитьСобытие().Выполнить();
	|    |       КонецЦикла;
	|    |   Исключение
	|    |       Ошибка = ИнформацияОбОшибке();
	|    |       ИФ.ПроброситьИсключение(""""""""{Модуль """""""" + Ошибка.ИмяМодуля + """""""" / Ошибка в строке: """""""" + Ошибка.НомерСтроки + """""""" / """""""" + Ошибка.Описание);
	|    |   КонецПопытки;
	|    |КонецЦикла;
	|    |"""";
	|    ЗагрузитьСценарийИзСтроки(Стр, Контекст);
	|КонецПроцедуры
	|
	|МассивПараметров = Новый Массив(1);
	|МассивПараметров[0] = ИФ;
	|Задание = ФоновыеЗадания.Выполнить(ЭтотОбъект, """"ЗапускСобытий"""", МассивПараметров);
	|"";
	|            ExternalContextData extContext = new()
	|            {
	|                { ""ИФ"", instance }
	|            };
	|            Engine.AttachedScriptsFactory.LoadFromString(cs, startEventProcessing, Process, extContext);
	|        }
	|
	|        private void Initialize(string godotPath)
	|        {
	|            // Запускаем Godot процесс асинхронно
	|            _ = Task.Run(() => StartGodotProcess(godotPath));
	|
	|            int count = 0;
	|            while (!godotReady.IsSet && count < 100)
	|            {
	|                System.Threading.Thread.Sleep(1000);
	|                count += 1;
	|            }
	|            if (!godotReady.IsSet)
	|            {
	|                OsUtils.Echo(""Ошибка: Godot не ответил в течение 100 секунд"");
	|            }
	|            else
	|            {
	|                godotLaunched = true;
	|            }
	|        }
	|
	|        private void StartGodotProcess(string godotPath)
	|        {
	|            try
	|            {
	|                if (!File.Exists(godotPath))
	|                {
	|                    OsUtils.Echo($""Ошибка: Godot приложение не найдено по пути {godotPath}"");
	|                    return;
	|                }
	|
	|                var process = new System.Diagnostics.Process
	|                {
	|                    StartInfo = new ProcessStartInfo
	|                    {
	|                        FileName = godotPath,
	|                        UseShellExecute = false,
	|                        RedirectStandardInput = true,
	|                        RedirectStandardOutput = true,
	|                        RedirectStandardError = true,
	|                        StandardOutputEncoding = System.Text.Encoding.UTF8,
	|                        StandardErrorEncoding = System.Text.Encoding.UTF8,
	|                    },
	|                    EnableRaisingEvents = true
	|                };
	|
	|                // Подписываемся на события
	|                process.OutputDataReceived += Process_OutputDataReceived;
	|                process.ErrorDataReceived += Process_ErrorDataReceived;
	|                process.Exited += Process_Exited;
	|
	|                godotProcess = process;
	|                process.Start();
	|
	|                // Начинаем асинхронное чтение
	|                process.BeginOutputReadLine();
	|                process.BeginErrorReadLine();
	|            }
	|            catch (Exception ex)
	|            {
	|                OsUtils.Echo($""Ошибка при запуске Godot: {ex.Message}"");
	|            }
	|        }
	|
	|        private void Process_Exited(object sender, EventArgs e)
	|        {
	|            if (DisplayServiceMessages)
	|            {
	|                OsUtils.Echo(""Godot процесс завершен"");
	|            }
	|            GoOn = false;
	|
	|            godotLaunched = false;
	|
	|            // Отменяем все ожидающие команды
	|            foreach (var kvp in pendingCommands)
	|            {
	|                kvp.Value.TrySetCanceled();
	|            }
	|            pendingCommands.Clear();
	|        }
	|
	|        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
	|        {
	|            if (!string.IsNullOrEmpty(e.Data))
	|            {
	|                OsUtils.Echo($""Error: {e.Data}"");
	|            }
	|        }
	|
	|        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
	|        {
	|            if (string.IsNullOrEmpty(e.Data))
	|            {
	|                return;
	|            }
	|
	|            if (DisplayServiceMessages)
	|            {
	|                try
	|                {
	|                    // Подавим вывод некоторых ненужных данных.
	|                    if (e.Data.Length > 7 && e.Data.Substring(0, 7) != ""{\u0022cmd\u0022:"")
	|                    {
	|                        OsUtils.Echo($"">>> {e.Data}"");
	|                    }
	|                }
	|                catch
	|                {
	|                    OsUtils.Echo($"">>> {e.Data}""); // Это для упрощения отладки. Не обработанное, пришедшее от Godot, сообщение.
	|                }
	|            }
	|
	|            Dictionary<string, object> response = null;
	|            // Парсим JSON ответ
	|            try
	|            {
	|                response = OsUtils.Deserialize(e.Data);
	|            }
	|            catch { }
	|            if (response != null)
	|            {
	|                if (DisplayServiceMessages)
	|                {
	|                    OsUtils.Echo($""Получил: {e.Data}"");
	|                }
	|
	|                foreach (var item in response)
	|                {
	|                    if (DisplayServiceMessages)
	|                    {
	|                        OsUtils.Echo($""key: {item.Key} = {item.Value}"");
	|                    }
	|                }
	|                // Проверяем, является ли это ответом на команду
	|                if (response.ContainsKey(""id"") && response.ContainsKey(""result""))
	|                {
	|                    string commandId = ((JsonElement)response[""id""]).GetString();
	|
	|                    // Ищем ожидающую команду
	|                    if (pendingCommands.TryRemove(commandId, out var tcs))
	|                    {
	|                        // Завершаем задачу с результатом
	|                        tcs.SetResult(e.Data);
	|                    }
	|                }
	|                // Проверяем сигнал готовности
	|                try
	|                {
	|                    if (response.ContainsKey(""cmd"") && response[""cmd""].ToString() == ""ready"")
	|                    {
	|                        godotReady.Set();
	|                        if (DisplayServiceMessages)
	|                        {
	|                            OsUtils.Echo(""Godot процесс запущен."");
	|                        }
	|                    }
	|                }
	|                catch { }
	|                // Получаем ключ для игровых форм.
	|                try
	|                {
	|                    if (response.ContainsKey(""cmd"") && response[""cmd""].ToString() == ""GameFormsItemKey"")
	|                    {
	|                        gameFormsItemKey = ((JsonElement)response[""ItemKey""]).GetString();
	|                        dictKeyEl.TryAdd(gameFormsItemKey, this);
	|                        dictElKey.TryAdd(this, gameFormsItemKey);
	|                    }
	|                }
	|                catch { }
	|
	|                try
	|                {
	|                    if (response.ContainsKey(""cmd"") && response[""cmd""].ToString() == ""rootWindow"")
	|                    {
	|                        string itemKey = ((JsonElement)response[""ItemKey""]).GetString();
	|                        rootWindow = new GfWindow(itemKey);
	|                    }
	|                }
	|                catch { }
	|
	|                // Проверяем, является ли это событием от Godot
	|                if (response[""id""].ToString() == ""godotEvent"")
	|                {
	|                    string elementItemKey = response[""ItemKey""].ToString();
	|                    if (!dictKeyEl.TryGetValue(elementItemKey, out var element))
	|                    {
	|                        if (DisplayServiceMessages)
	|                        {
	|                            OsUtils.Echo($""Элемент {elementItemKey} не найден (1)"");
	|                        }
	|                    }
	|                    else
	|                    {
	|                        string nameEvent = response[""nameEvent""].ToString();
	|                        int num = nameEvent.IndexOf(""_"");
	|                        GfAction eventAction = null;
	|                        if (num >= 0)
	|                        {
	|                            nameEvent = element[nameEvent.Substring(num)];
	|                        }
	|
	|                        try
	|                        {
	|                            eventAction = element[nameEvent];
	|                        }
	|                        catch { }
	|
	|                        var dataEvent = OsUtils.Deserialize(response[""dataEvent""].ToString());
	|                        GfVector2 _vector = null;
	|                        bool _pressed = false;
	|                        IValue _modifiersMask = null;
	|                        IValue _keycode = null;
	|                        IValue _mouseButton = null;
	|                        IValue _mouseButtonMask = null;
	|                        bool _toggledOn = false;
	|                        try
	|                        {
	|                            foreach (var item in dataEvent)
	|                            {
	|                                var itemValue = (JsonElement)item.Value;
	|                                switch (item.Key)
	|                                {
	|                                    case ""position"" when itemValue.ValueKind == JsonValueKind.Array:
	|                                        _vector = new GfVector2(itemValue[0].GetDecimal(), itemValue[1].GetDecimal());
	|                                        break;
	|                                    case ""pressed"":
	|                                        _pressed = itemValue.GetBoolean();
	|                                        break;
	|                                    case ""modifiersMask"":
	|                                        _modifiersMask = ValueFactory.Create(itemValue.GetInt32());
	|                                        break;
	|                                    case ""keycode"":
	|                                        _keycode = ValueFactory.Create(itemValue.GetInt32());
	|                                        break;
	|                                    case ""mouseButton"":
	|                                        _mouseButton = ValueFactory.Create(itemValue.GetInt32());
	|                                        break;
	|                                    case ""mouseButtonMask"":
	|                                        _mouseButtonMask = ValueFactory.Create(itemValue.GetInt32());
	|                                        break;
	|                                    case ""toggledOn"":
	|                                        _toggledOn = itemValue.GetBoolean();
	|                                        break;
	|                                }
	|                            }
	|                        }
	|                        catch { }
	|
	|                        if (eventAction != null)
	|                        {
	|                            if (eventAction.MethodName == """")
	|                            {
	|                                return;
	|                            }
	|                            var args = new GfEventArgs
	|                            {
	|                                eventAction = eventAction,
	|                                sender = element.dll_obj,
	|                                position = _vector,
	|                                pressed = _pressed,
	|                                modifiersMask = _modifiersMask,
	|                                keycode = _keycode,
	|                                parameter = eventAction.Parameter,
	|                                mouseButtonMask = _mouseButtonMask,
	|                                mouseButton = _mouseButton,
	|                                toggledOn = _toggledOn,
	|                            };
	|                            EventQueue.Enqueue(args);
	|                        }
	|                    }
	|                }
	|            }
	|        }
	|
	|        // Обеспечение цикла событий =====================================================================
	|        [ContextMethod(""Действие"", ""Action"")]
	|        public GfAction Action(IRuntimeContextInstance script = null, string methodName = null, IValue param = null)
	|        {
	|            return new GfAction(script, methodName, param);
	|        }
	|
	|        public static GfEventArgs Event = null;
	|        [ContextProperty(""АргументыСобытия"", ""EventArgs"")]
	|        public GfEventArgs EventArgsProp
	|        {
	|            get { return Event; }
	|        }
	|
	|        public bool goOn = true;
	|        [ContextProperty(""Продолжать"", ""GoOn"")]
	|        public bool GoOn
	|        {
	|            get { return goOn; }
	|            set { goOn = value; }
	|        }
	|
	|        [ContextMethod(""ПолучитьСобытие"", ""DoEvents"")]
	|        public DelegateAction DoEvents()
	|        {
	|            while (EventQueue.Count == 0)
	|            {
	|                System.Threading.Thread.Sleep(7);
	|            }
	|            if (EventQueue.TryDequeue(out var item))
	|            {
	|                Event = item;
	|                EventAction = item.EventAction;
	|            }
	|            return DelegateAction.Create(item.EventAction.Script, item.EventAction.MethodName);
	|        }
	|
	|        [ContextMethod(""Выполнить"", ""Execute"")]
	|        public void Execute(GfAction action)
	|        {
	|            var args = new GfEventArgs
	|            {
	|                eventAction = action,
	|                parameter = action.Parameter,
	|            };
	|            EventQueue.Enqueue(args);
	|        }
	|
	|        [ContextProperty(""ПриСрабатыванииОдноразовогоТаймера"", ""OneTimerTriggered"")] // Не показываем в справке, но здесь необходимо оставить.
	|        public GfAction OneTimerTriggered { get; set; }
	|
	|        // Свойства =======================================================================================
	|        [ContextProperty(""ОсевоеРастяжение"", ""AxisStretchMode"")]
	|        public GfAxisStretchMode AxisStretchModeProp
	|        {
	|            get { return new GfAxisStretchMode(); }
	|        }
	|
	|        [ContextProperty(""Направление"", ""Direction"")]
	|        public GfDirection DirectionProp
	|        {
	|            get { return new GfDirection(); }
	|        }
	|
	|        [ContextProperty(""ГодоЗапущен"", ""GodotLaunched"")]
	|        public bool GodotLaunched
	|        {
	|            get { return godotLaunched; }
	|            private set { godotLaunched = value; }
	|        }
	|
	|        [ContextProperty(""КорневоеОкно"", ""RootWindow"")]
	|        public GfWindow RootWindow
	|        {
	|            get { return rootWindow; }
	|        }
	|
	|        [ContextProperty(""Цвет"", ""Color"")]
	|        public GfColor ColorProp
	|        {
	|            get { return new GfColor(); }
	|        }
	|
	|        [ContextProperty(""СистемныйКаталог"", ""SystemDir"")]
	|        public GfSystemDir SystemDirProp
	|        {
	|            get { return new GfSystemDir(); }
	|        }
	|
	|        [ContextProperty(""РежимОтрисовки"", ""DrawMode"")]
	|        public GfDrawMode DrawModeProp
	|        {
	|            get { return new GfDrawMode(); }
	|        }
	|
	|        [ContextProperty(""КнопкаМыши"", ""MouseButton"")]
	|        public GfMouseButton MouseButtonProp
	|        {
	|            get { return new GfMouseButton(); }
	|        }
	|
	|        [ContextProperty(""ВыводитьСлужебныеСообщения"", ""DisplayServiceMessages"")]
	|        public bool DisplayServiceMessages
	|        {
	|            get { return displayServiceMessages; }
	|            set { displayServiceMessages = value; }
	|        }
	|
	|        [ContextProperty(""ЛогФайл"", ""PathLog"")]
	|        public string PathLog { get; set; }
	|
	|        [ContextProperty(""КаталогБиблиотеки"", ""AssemblyDirectoryName"")]
	|        public string AssemblyDirectoryName
	|        {
	|            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
	|        }
	|
	|        [ContextProperty(""Ориентация"", ""Orientation"")]
	|        public GfOrientation OrientationProp
	|        {
	|            get { return new GfOrientation(); }
	|        }
	|
	|        [ContextProperty(""ФлагПереносаСтроки"", ""LineBreakFlag"")]
	|        public GfLineBreakFlag LineBreakFlagProp
	|        {
	|            get { return new GfLineBreakFlag(); }
	|        }
	|
	|        [ContextProperty(""ФлагВыравниванияПоШирине"", ""JustificationFlag"")]
	|        public GfJustificationFlag JustificationFlagProp
	|        {
	|            get { return new GfJustificationFlag(); }
	|        }
	|
	|        [ContextProperty(""Клавиши"", ""Keys"")]
	|        public GfKeys KeysProp
	|        {
	|            get { return new GfKeys(); }
	|        }
	|
	|        [ContextProperty(""КлавишаНажата"", ""KeyPress"")]
	|        public GfAction KeyPress { get; set; }
	|
	|        [ContextProperty(""Модификаторы"", ""KeyModifierMask"")]
	|        public GfKeyModifierMask KeyModifierMask
	|        {
	|            get { return new GfKeyModifierMask(); }
	|        }
	|
	|        [ContextProperty(""ФорматИзображения"", ""ImageFormat"")]
	|        public GfImageFormat ImageFormat
	|        {
	|            get { return new GfImageFormat(); }
	|        }
	|
	|        [ContextProperty(""РежимФокусировки"", ""FocusMode"")]
	|        public GfFocusMode FocusModeProp
	|        {
	|            get { return new GfFocusMode(); }
	|        }
	|
	|        [ContextProperty(""Автоперенос"", ""AutowrapMode"")]
	|        public GfAutowrapMode AutowrapModeProp
	|        {
	|            get { return new GfAutowrapMode(); }
	|        }
	|
	|        [ContextProperty(""ТипЭлементаТемы"", ""ThemeDataType"")]
	|        public GfThemeDataType ThemeDataType
	|        {
	|            get { return new GfThemeDataType(); }
	|        }
	|
	|        [ContextProperty(""ИмяСвойстваТемыНадпись"", ""NamePropertyThemeLabel"")]
	|        public GfNamePropertyThemeLabel NamePropertyThemeLabel
	|        {
	|            get { return new GfNamePropertyThemeLabel(); }
	|        }
	|
	|        [ContextProperty(""ИмяСвойстваТемыОкно"", ""NamePropertyThemeWindow"")]
	|        public GfNamePropertyThemeWindow NamePropertyThemeWindow
	|        {
	|            get { return new GfNamePropertyThemeWindow(); }
	|        }
	|
	|        [ContextProperty(""ИмяСвойстваТемыВертикальнаяГруппа"", ""NamePropertyThemeVBoxContainer"")]
	|        public GfNamePropertyThemeVBoxContainer NamePropertyThemeVBoxContainer
	|        {
	|            get { return new GfNamePropertyThemeVBoxContainer(); }
	|        }
	|
	|        [ContextProperty(""ИмяСвойстваТемыГоризонтальнаяГруппа"", ""NamePropertyThemeHBoxContainer"")]
	|        public GfNamePropertyThemeHBoxContainer NamePropertyThemeHBoxContainer
	|        {
	|            get { return new GfNamePropertyThemeHBoxContainer(); }
	|        }
	|
	|        [ContextProperty(""ИмяСвойстваТемыКнопка"", ""NamePropertyThemeButton"")]
	|        public GfNamePropertyThemeButton NamePropertyThemeButton
	|        {
	|            get { return new GfNamePropertyThemeButton(); }
	|        }
	|
	|        [ContextProperty(""ИмяСвойстваТемыОкноСообщений"", ""NamePropertyThemeConfirmationDialog"")]
	|        public GfNamePropertyThemeConfirmationDialog NamePropertyThemeConfirmationDialog
	|        {
	|            get { return new GfNamePropertyThemeConfirmationDialog(); }
	|        }
	|
	|        [ContextProperty(""ИмяСвойстваТемыПанельныйКонтейнер"", ""NamePropertyThemePanelContainer"")]
	|        public GfNamePropertyThemePanelContainer NamePropertyThemePanelContainer
	|        {
	|            get { return new GfNamePropertyThemePanelContainer(); }
	|        }
	|
	|        [ContextProperty(""ИмяСвойстваТемыУведомление"", ""NamePropertyThemeAcceptDialog"")]
	|        public GfNamePropertyThemeAcceptDialog NamePropertyThemeAcceptDialog
	|        {
	|            get { return new GfNamePropertyThemeAcceptDialog(); }
	|        }
	|
	|        // Методы =======================================================================================
	|        [ContextMethod(""ЗагрузитьМодель"", ""LoadModel"")]
	|        public void LoadModel(string _path)
	|        {
	|            string path = OsUtils.ToGodotPath(_path);
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""path"", path },
	|                }
	|            };
	|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
	|        }
	|
	|        [ContextMethod(""ТемаСцена"", ""ThemeScene"")]
	|        public GfThemeScene ThemeScene()
	|        {
	|            return new GfThemeScene();
	|        }
	|
	|        [ContextMethod(""ТемаКнопка"", ""ThemeButton"")]
	|        public GfThemeButton ThemeButton()
	|        {
	|            return new GfThemeButton();
	|        }
	|
	|        [ContextMethod(""ТемаНадпись"", ""ThemeLabel"")]
	|        public GfThemeLabel ThemeLabel()
	|        {
	|            return new GfThemeLabel();
	|        }
	|
	|        [ContextMethod(""ТемаОкно"", ""ThemeWindow"")]
	|        public GfThemeWindow ThemeWindow()
	|        {
	|            return new GfThemeWindow();
	|        }
	|
	|        [ContextMethod(""ТемаПанельныйКонтейнер"", ""ThemePanelContainer"")]
	|        public GfThemePanelContainer ThemePanelContainer()
	|        {
	|            return new GfThemePanelContainer();
	|        }
	|
	|        [ContextMethod(""ТемаУведомление"", ""ThemeAcceptDialog"")]
	|        public GfThemeAcceptDialog ThemeAcceptDialog()
	|        {
	|            return new GfThemeAcceptDialog();
	|        }
	|
	|        [ContextMethod(""ПолучитьТекстБуфераОбмена"", ""ClipboardGet"")]
	|        public string ClipboardGet()
	|        {
	|            return OsUtils.ClipboardGet();
	|        }
	|
	|        [ContextMethod(""УстановитьТекстБуфераОбмена"", ""ClipboardSet"")]
	|        public void ClipboardSet(string p1)
	|        {
	|            OsUtils.ClipboardSet(p1);
	|        }
	|
	|        [ContextMethod(""НотацияЗмеинуюВПаскаля"", ""SnakeCaseToPascalCase"")]
	|        public string SnakeCaseToPascalCase(string path)
	|        {
	|            return OsUtils.GetCSharpName(path);
	|        }
	|
	|        [ContextMethod(""НотацияПаскаляВЗмеиную"", ""PascalCaseToSnakeCase"")]
	|        public string PascalCaseToSnakeCase(string path)
	|        {
	|            return OsUtils.GetGodotName(path);
	|        }
	|
	|        [ContextMethod(""ПолучитьСнимок"", ""GetSnapshot"")]
	|        public GfImage GetSnapshot(IValue node, string path, int imageFormat = 0)
	|        {
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""element"",  ((dynamic)node).ItemKey },
	|                    { ""path"",  path },
	|                    { ""imageFormat"",  imageFormat },
	|                }
	|            };
	|            string jsonResponse = OsUtils.Serialize(response);
	|            string res = GameForms.SendCommand(""GetSnapshot"", jsonResponse);
	|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
	|            if (((JsonElement)answer[""success""]).GetBoolean())
	|            {
	|                string newPath = ((JsonElement)answer[""report""]).GetString();
	|                return new GfImage(newPath);
	|            }
	|            else
	|            {
	|                OsUtils.Echo(""Не удалось выполнить метод ПолучитьСнимок."");
	|                return null;
	|            }
	|        }
	|
	|        [ContextMethod(""НормализоватьПуть"", ""NormalizedPath"")]
	|        public string NormalizedPath(string path)
	|        {
	|            return OsUtils.ToGodotPath(path);
	|        }
	|
	|        [ContextMethod(""НовыйОбъект"", ""NewObject"")]
	|        public IValue NewObject(string p1)
	|        {
	|            if (!_typeCache.TryGetValue(p1, out var type))
	|            {
	|                OsUtils.Echo($""Неизвестный тип: {p1}"");
	|                return null;
	|            }
	|
	|            try
	|            {
	|                return (IValue)Activator.CreateInstance(type);
	|            }
	|            catch (Exception)
	|            {
	|                OsUtils.Echo($""Ошибка создания объекта: {type.Name}"");
	|                return null;
	|            }
	|        }
	|
	|        [ContextMethod(""НайтиЦентр"", ""FindCenter"")]
	|        public GfVector2 FindCenter(IValue p1)
	|        {
	|            string itemKey = ((dynamic)p1).Base_obj.ItemKey;
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""element"",  itemKey },
	|                }
	|            };
	|            string jsonResponse = OsUtils.Serialize(response);
	|            string res = GameForms.SendCommand(""FindCenter"", jsonResponse);
	|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
	|            if (((JsonElement)answer[""success""]).GetBoolean())
	|            {
	|                var report = OsUtils.Deserialize(answer[""report""].ToString());
	|                return (GfVector2)OsUtils.ConvertValueForGameForms(report);
	|            }
	|            else
	|            {
	|                OsUtils.Echo(""Не удалось выполнить метод НайтиЦентр"");
	|                return null;
	|            }
	|        }
	|
	|        [ContextMethod(""ОтправитьКлавишуКонсоли"", ""SendConsoleKey"")]
	|        public void SendConsoleKey(int keyCode, bool shiftModifier = false, bool altModifier = false, bool ctrlModifier = false)
	|        {
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""keyCode"", keyCode },
	|                    { ""shiftModifier"", shiftModifier },
	|                    { ""altModifier"", altModifier },
	|                    { ""ctrlModifier"", ctrlModifier },
	|                }
	|            };
	|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
	|        }
	|
	|        [ContextMethod(""Выравнивание"", ""AlignmentMode"")]
	|        public GfAlignmentMode AlignmentMode()
	|        {
	|            return new GfAlignmentMode();
	|        }
	|
	|        [ContextMethod(""Направление"", ""Direction"")]
	|        public GfDirection Direction()
	|        {
	|            return new GfDirection();
	|        }
	|
	|        [ContextMethod(""РежимОтрисовки"", ""DrawMode"")]
	|        public GfDrawMode DrawMode()
	|        {
	|            return new GfDrawMode();
	|        }
	|
	|        [ContextMethod(""Кодировка"", ""Encoding"")]
	|        public GfEncoding Encoding()
	|        {
	|            return new GfEncoding();
	|        }
	|
	|        [ContextMethod(""ГоризонтальнаяГруппа"", ""HBoxContainer"")]
	|        public GfHBoxContainer HBoxContainer()
	|        {
	|            return new GfHBoxContainer();
	|        }
	|
	|        [ContextMethod(""ГоризонтальноеВыравнивание"", ""HorizontalAlignment"")]
	|        public GfHorizontalAlignment HorizontalAlignment()
	|        {
	|            return new GfHorizontalAlignment();
	|        }
	|
	|        [ContextMethod(""ФлагВыравниванияПоШирине"", ""JustificationFlag"")]
	|        public GfJustificationFlag JustificationFlag()
	|        {
	|            return new GfJustificationFlag();
	|        }
	|
	|        [ContextMethod(""Надпись"", ""Label"")]
	|        public GfLabel Label()
	|        {
	|            return new GfLabel();
	|        }
	|
	|        [ContextMethod(""ФлагПереносаСтроки"", ""LineBreakFlag"")]
	|        public GfLineBreakFlag LineBreakFlag()
	|        {
	|            return new GfLineBreakFlag();
	|        }
	|
	|        [ContextMethod(""КнопкаМыши"", ""MouseButton"")]
	|        public GfMouseButton MouseButton()
	|        {
	|            return new GfMouseButton();
	|        }
	|
	|        [ContextMethod(""Ориентация"", ""Orientation"")]
	|        public GfOrientation Orientation()
	|        {
	|            return new GfOrientation();
	|        }
	|
	|        [ContextMethod(""Спрайт2д"", ""Sprite2D"")]
	|        public GfSprite2D Sprite2D()
	|        {
	|            return new GfSprite2D();
	|        }
	|
	|        [ContextMethod(""СтильПанелиПусто"", ""StyleBoxEmpty"")]
	|        public GfStyleBoxEmpty StyleBoxEmpty()
	|        {
	|            return new GfStyleBoxEmpty();
	|        }
	|
	|        [ContextMethod(""СтильПанелиЛиния"", ""StyleBoxLine"")]
	|        public GfStyleBoxLine StyleBoxLine()
	|        {
	|            return new GfStyleBoxLine();
	|        }
	|
	|        [ContextMethod(""СтильПанелиТекстура"", ""StyleBoxTexture"")]
	|        public GfStyleBoxTexture StyleBoxTexture()
	|        {
	|            return new GfStyleBoxTexture();
	|        }
	|
	|        [ContextMethod(""Таймер"", ""Timer"")]
	|        public GfTimer Timer()
	|        {
	|            return new GfTimer();
	|        }
	|
	|        [ContextMethod(""СистемныйКаталог"", ""SystemDir"")]
	|        public GfSystemDir SystemDir()
	|        {
	|            return new GfSystemDir();
	|        }
	|
	|        [ContextMethod(""ПанельныйКонтейнер"", ""PanelContainer"")]
	|        public GfPanelContainer PanelContainer()
	|        {
	|            return new GfPanelContainer();
	|        }
	|
	|        [ContextMethod(""СтильПанелиПлоский"", ""StyleBoxFlat"")]
	|        public GfStyleBoxFlat StyleBoxFlat()
	|        {
	|            return new GfStyleBoxFlat();
	|        }
	|
	|        [ContextMethod(""ВертикальнаяГруппа"", ""VBoxContainer"")]
	|        public GfVBoxContainer VBoxContainer()
	|        {
	|            return new GfVBoxContainer();
	|        }
	|
	|        [ContextMethod(""Прямоугольник2ц"", ""Rect2i"")]
	|        public GfRect2i Rect2i(GfVector2i p1 = null, GfVector2i p2 = null)
	|        {
	|            GfRect2i rect2i = new GfRect2i();
	|            if (OsUtils.AllNotNull(p1))
	|            {
	|                rect2i.Position = p1;
	|            }
	|            if (OsUtils.AllNotNull(p2))
	|            {
	|                rect2i.Size = p2;
	|            }
	|            return rect2i;
	|        }
	|
	|        [ContextMethod(""ОкноСообщений"", ""ConfirmationDialog"")]
	|        public GfConfirmationDialog WiConfirmationDialogndow()
	|        {
	|            return new GfConfirmationDialog();
	|        }
	|
	|        [ContextMethod(""ПолучитьПозициюМыши"", ""GetMousePosition"")]
	|        public GfVector2 GetMousePosition()
	|        {
	|            string res = SendCommand(""GetMousePosition"");
	|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
	|            var report = OsUtils.Deserialize(answer[""report""].ToString());
	|            GfVector2 vector2 = null;
	|            foreach (var item in report)
	|            {
	|                var itemValue = (JsonElement)item.Value;
	|                switch (item.Key)
	|                {
	|                    case ""position"" when itemValue.ValueKind == JsonValueKind.Array:
	|                        vector2 = new GfVector2(itemValue[0].GetDecimal(), itemValue[1].GetDecimal());
	|                        break;
	|                }
	|            }
	|            return vector2;
	|        }
	|
	|        [ContextMethod(""ПереместитьМышь"", ""WarpMouse"")]
	|        public void WarpMouse(IValue p1, decimal duration = 0.5m)
	|        {
	|            Response response = null;
	|            if (OsUtils.IsType<GfVector2>(p1))
	|            {
	|                GfVector2 pos = p1 as GfVector2;
	|                float[] posArray = { OsUtils.ToFloat(pos.X), OsUtils.ToFloat(pos.Y) };
	|                response = new Response
	|                {
	|                    Properties = new Dictionary<string, object>
	|                    {
	|                        { ""position"", posArray },
	|                        { ""duration"", duration / 1000 },
	|                    }
	|                };
	|                OsUtils.GetAnswerSendCommand(""WarpMouseToVector"", response);
	|            }
	|            else
	|            {
	|                try
	|                {
	|                    string itemKey = ((dynamic)p1).Base_obj.ItemKey;
	|                    response = new Response
	|                    {
	|                        Properties = new Dictionary<string, object>
	|                        {
	|                            { ""itemKey"", itemKey },
	|                            { ""duration"", duration / 1000 },
	|                        }
	|                    };
	|                }
	|                catch { }
	|                OsUtils.GetAnswerSendCommand(""WarpMouseToControl"", response);
	|            }
	|        }
	|
	|        [ContextMethod(""ПрограммныйКлик"", ""ProgramClick"")]
	|        public void ProgramClick(int mouseButton)
	|        {
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""mouseButton"", mouseButton },
	|                }
	|            };
	|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
	|        }
	|
	|        [ContextMethod(""Уведомление"", ""AcceptDialog"")]
	|        public GfAcceptDialog AcceptDialog()
	|        {
	|            return new GfAcceptDialog();
	|        }
	|
	|        [ContextMethod(""ОдноразовыйТаймер"", ""SceneTreeTimer"")]
	|        public void SceneTreeTimer(GfAction p1, decimal time)
	|        {
	|            OneTimerTriggered = p1;
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""time"", time },
	|                }
	|            };
	|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
	|        }
	|
	|        [ContextMethod(""УдалитьЭлемент"", ""RemoveElement"")]
	|        public void RemoveElement([ByRef] IVariable obj)
	|        {
	|            var element = ((dynamic)obj.Value).Base_obj;
	|            dictElKey.TryGetValue(element, out string elementItemKey);
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""element"",  elementItemKey },
	|                    { ""itemKey"",  elementItemKey },
	|                }
	|            };
	|            string jsonResponse = OsUtils.Serialize(response);
	|            string res = GameForms.SendCommand(""RemoveElement"", jsonResponse);
	|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
	|            if (((JsonElement)answer[""success""]).GetBoolean())
	|            {
	|                dictElKey.TryRemove(element, out string _);
	|                dictKeyEl.TryRemove(elementItemKey, out _);
	|                obj.Value = ValueFactory.CreateNullValue();
	|            }
	|            else
	|            {
	|                OsUtils.Echo(""Не удалось выполнить метод УдалитьЭлемент"");
	|            }
	|        }
	|
	|        [ContextMethod(""Изображение"", ""Image"")]
	|        public GfImage Image(string p1 = null)
	|        {
	|            return new GfImage(p1);
	|        }
	|
	|        [ContextMethod(""ТекстураИзИзображения"", ""ImageTexture"")]
	|        public GfImageTexture ImageTexture(string p1 = null)
	|        {
	|            return new GfImageTexture(p1);
	|        }
	|
	|        [ContextMethod(""Запись"", ""Entry"")]
	|        public GfEntry Entry(IValue p1 = null, IValue p2 = null)
	|        {
	|            return new GfEntry(p1, p2);
	|        }
	|
	|        [ContextMethod(""Словарь"", ""Dictionary"")]
	|        public GfDictionary Dictionary()
	|        {
	|            return new GfDictionary();
	|        }
	|
	|        [ContextMethod(""ШрифтВариативный"", ""FontVariation"")]
	|        public GfFontVariation FontVariation(string p1 = null)
	|        {
	|            return new GfFontVariation(p1);
	|        }
	|
	|        [ContextMethod(""ШрифтИзФайла"", ""FontFile"")]
	|        public GfFontFile FontFile(string p1 = null)
	|        {
	|            return new GfFontFile(p1);
	|        }
	|
	|        [ContextMethod(""ДобавитьВесьТекст"", ""AppendAllText"")]
	|        public void AppendAllText(string p1, string p2)
	|        {
	|            if (!File.Exists(p1))
	|            {
	|                File.Create(p1).Close();
	|            }
	|            File.AppendAllText(p1, p2, System.Text.Encoding.UTF8);
	|        }
	|
	|        [ContextMethod(""ПолучитьКодСценария"", ""GetScriptCode"")]
	|        public string GetScriptCode(IRuntimeContextInstance p1)
	|        {
	|            UserScriptContextInstance scr = (UserScriptContextInstance)p1.GetPropValue(0);
	|            return scr.Module.Source.GetSourceCode();
	|        }
	|
	|        [ContextMethod(""ПутьСценария"", ""PathScenario"")]
	|        public string PathScenario(IRuntimeContextInstance p1)
	|        {
	|            UserScriptContextInstance scr = (UserScriptContextInstance)p1.GetPropValue(0);
	|            return scr.Module.Source.Name;
	|        }
	|
	|        [ContextMethod(""КаталогСценария"", ""DirectoryScenario"")]
	|        public string DirectoryScenario(IRuntimeContextInstance p1)
	|        {
	|            ScriptEngine.Machine.Contexts.UserScriptContextInstance scr = (ScriptEngine.Machine.Contexts.UserScriptContextInstance)p1.GetPropValue(0);
	|            return Path.GetDirectoryName(scr.Module.Source.Name);
	|        }
	|
	|        [ContextMethod(""МассивИменЦветов"", ""ColorNameArray"")]
	|        public ArrayImpl ColorNameArray()
	|        {
	|            ArrayImpl arrayImpl = new ArrayImpl();
	|            List<string> list = new List<string>();
	|            System.Type type = typeof(GfColor);
	|            PropertyInfo[] myPropertyInfo = type.GetProperties();
	|            for (int i = 0; i < myPropertyInfo.Length; i++)
	|            {
	|                if (myPropertyInfo[i].CustomAttributes.Count() == 1)
	|                {
	|                    string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Name;
	|                    string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Alias;
	|                    try
	|                    {
	|                        if (NameEn != ""Имя"" &&
	|                            NameEn != ""Name"" &&
	|                            NameRu != ""ЗначениеАльфа"" &&
	|                            NameRu != ""ЗначениеЗеленый"" &&
	|                            NameRu != ""ЗначениеКрасный"" &&
	|                            NameRu != ""ЗначениеСиний"")
	|                        {
	|                            list.Add(NameRu + "" ("" + NameEn + "")"");
	|                        }
	|                    }
	|                    catch { }
	|                }
	|            }
	|            list.Sort();
	|            for (int i = 0; i < list.Count; i++)
	|            {
	|                arrayImpl.Add(ValueFactory.Create(list[i]));
	|            }
	|            return arrayImpl;
	|        }
	|
	|        [ContextMethod(""Цвет"", ""Color"")]
	|        public GfColor Color(IValue p1 = null, IValue p2 = null, IValue p3 = null, IValue p4 = null)
	|        {
	|            GfColor res = new GfColor();
	|            if (OsUtils.AllNotNull(p1) && !OsUtils.AllNotNull(p2, p3, p4))
	|            {
	|                try
	|                {
	|                    if (OsUtils.IsString(p1))
	|                    {
	|                        string propName = p1.ToString();
	|                        if (!propName.Contains(""#""))
	|                        {
	|                            string resName = System.String.Empty;
	|                            PropertyInfo[] myPropertyInfo = typeof(GfColor).GetProperties();
	|                            for (int i = 0; i < myPropertyInfo.Length; i++)
	|                            {
	|                                if (myPropertyInfo[i].CustomAttributes.Count() == 1)
	|                                {
	|                                    string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Name;
	|                                    string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Alias;
	|                                    if (NameRu == propName || NameEn == propName)
	|                                    {
	|                                        resName = NameEn;
	|                                        break;
	|                                    }
	|                                }
	|                            }
	|                            res = (GfColor)Type.GetType(""osgf.GfColor"").GetProperty(resName).GetValue(new GfColor());
	|                        }
	|                        else
	|                        {
	|                            // Удаляем префикс '#'.
	|                            propName = propName.TrimStart('#');
	|                            // Извлекаем компоненты RGB и преобразуем их из шестнадцатеричной в десятичную систему.
	|                            res.R = OsUtils.ToInt32(propName.Substring(0, 2), 16);
	|                            res.G = OsUtils.ToInt32(propName.Substring(2, 2), 16);
	|                            res.B = OsUtils.ToInt32(propName.Substring(4, 2), 16);
	|                            res.A = 255;
	|                        }
	|                    }
	|                    else if (OsUtils.IsNumber(p1))
	|                    {
	|                        int decimalValue = OsUtils.ToInt32(p1);
	|
	|                        res.R = (decimalValue & 0xFF0000) >> 16; // Красная составляющая.
	|                        res.G = (decimalValue & 0x00FF00) >> 8; // Зелёная составляющая.
	|                        res.B = (decimalValue & 0x0000FF); // Синяя составляющая.
	|                        res.A = 255; // Альфа составляющая.
	|                    }
	|                }
	|                catch (Exception)
	|                {
	|                    OsUtils.Echo(""Ошибка создания цвета: Параметр должен быть строкой с допустимым именем цвета или целым числом в диапазоне от 0 до 16777215."");
	|                    res = null;
	|                }
	|            }
	|            else if (OsUtils.AllNotNull(p1, p2, p3) && !OsUtils.AllNotNull(p4))
	|            {
	|                try
	|                {
	|                    res.R = OsUtils.ToInt32(p1);
	|                    res.G = OsUtils.ToInt32(p2);
	|                    res.B = OsUtils.ToInt32(p3);
	|                    res.A = 255;
	|                }
	|                catch (Exception)
	|                {
	|                    OsUtils.Echo(""Ошибка создания цвета: Каждый параметр долен быть целым числом в диапазоне от 0 до 255."");
	|                    res = null;
	|                }
	|            }
	|            else if (OsUtils.AllNotNull(p1, p2, p3, p4))
	|            {
	|                try
	|                {
	|                    res.R = OsUtils.ToInt32(p1);
	|                    res.G = OsUtils.ToInt32(p2);
	|                    res.B = OsUtils.ToInt32(p3);
	|                    res.A = OsUtils.ToInt32(p4);
	|                }
	|                catch (Exception)
	|                {
	|                    OsUtils.Echo(""Ошибка создания цвета: Каждый параметр долен быть целым числом в диапазоне от 0 до 255."");
	|                    res = null;
	|                }
	|            }
	|            return res;
	|        }
	|
	|        [ContextMethod(""ПутьИсполняемогоФайла"", ""GetExecutablePath"")]
	|        public string GetExecutablePath()
	|        {
	|            string res = SendCommand(""GetExecutablePath"");
	|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
	|            return ((JsonElement)answer[""report""]).GetString();
	|        }
	|
	|        [ContextMethod(""Запустить"", ""Run"")]
	|        public void Run(string path)
	|        {
	|            Initialize(path);
	|        }
	|
	|        //Завершаем Godot средствами Godot.
	|        [ContextMethod(""Завершить"", ""Shutdown"")]
	|        public void Shutdown()
	|        {
	|            SendCommand(""Shutdown"");
	|        }
	|
	|        [ContextMethod(""ОтправитьКоманду"", ""SendCommand"")]
	|        public static string SendCommand(string command, string parameters = ""{}"")
	|        {
	|            if (godotProcess == null || godotProcess.HasExited)
	|            {
	|                throw new InvalidOperationException(""Godot процесс не запущен или завершен"");
	|            }
	|
	|            var commandId = Guid.NewGuid().ToString();
	|            var tcs = new TaskCompletionSource<string>();
	|
	|            // Регистрируем ожидающий ответ
	|            pendingCommands[commandId] = tcs;
	|
	|            try
	|            {
	|                // Формируем JSON команду
	|                var commandObj = new Dictionary<string, object>
	|                {
	|                    [""cmd""] = command,
	|                    [""id""] = commandId,
	|                    [""paramsJson""] = OsUtils.Deserialize(parameters)
	|                };
	|
	|                string jsonCommand = OsUtils.Serialize(commandObj);
	|
	|                // Отправляем команду
	|                godotProcess.StandardInput.WriteLine(jsonCommand);
	|                godotProcess.StandardInput.Flush();
	|
	|                if (instance.DisplayServiceMessages)
	|                {
	|                    OsUtils.Echo(""==============================="");
	|                    OsUtils.Echo($""Отправил: {jsonCommand.Trim()}"");
	|                }
	|
	|                // Ожидаем ответ с таймаутом 30 секунд
	|                if (tcs.Task.Wait(TimeSpan.FromSeconds(30)))
	|                {
	|                    return tcs.Task.Result;
	|                }
	|                else
	|                {
	|                    pendingCommands.TryRemove(commandId, out _);
	|                    throw new TimeoutException($""Команда {command} не получила ответ за 30 секунд"");
	|                }
	|            }
	|            catch (Exception ex)
	|            {
	|                pendingCommands.TryRemove(commandId, out _);
	|                OsUtils.Echo($""Ошибка при отправке команды: {ex.Message}"");
	|                throw;
	|            }
	|        }
	|
	|        [ContextMethod(""Окно"", ""Window"")]
	|        public GfWindow Window()
	|        {
	|            return new GfWindow();
	|        }
	|
	|        [ContextMethod(""Кнопка"", ""Button"")]
	|        public GfButton Button()
	|        {
	|            return new GfButton();
	|        }
	|
	|        [ContextMethod(""Вектор2"", ""Vector2"")]
	|        public GfVector2 Vector2(decimal x = 0, decimal y = 0)
	|        {
	|            return new GfVector2(x, y);
	|        }
	|
	|        [ContextMethod(""Вектор2ц"", ""Vector2i"")]
	|        public GfVector2i Vector2i(int x = 0, int y = 0)
	|        {
	|            return new GfVector2i(x, y);
	|        }
	|
	|        [ContextMethod(""Графика"", ""Graphics"")]
	|        public GfGraphics Graphics()
	|        {
	|            return new GfGraphics();
	|        }
	|
	|        [ContextMethod(""Прямоугольник2"", ""Rect2"")]
	|        public GfRect2 Rect2(GfVector2 p1 = null, GfVector2 p2 = null)
	|        {
	|            GfRect2 rect2 = new GfRect2();
	|            if (OsUtils.AllNotNull(p1))
	|            {
	|                rect2.Position = p1;
	|            }
	|            if (OsUtils.AllNotNull(p2))
	|            {
	|                rect2.Size = p2;
	|            }
	|            return rect2;
	|        }
	|
	|        [ContextMethod(""Узел2д"", ""Node2D"")]
	|        public GfNode2D Node2D()
	|        {
	|            return new GfNode2D();
	|        }
	|
	|        public void Dispose()
	|        {
	|            godotReady?.Dispose();
	|            foreach (var pending in pendingCommands.Values)
	|            {
	|                pending.TrySetCanceled();
	|            }
	|        }
	|
	|        [ContextMethod(""СвойстваИЗначения"", ""PropertiesAndValues"")]
	|        public string PropertiesAndValues(IValue p1)
	|        {
	|            string str1 = """";
	|            string transfer = """";
	|            List<string> p = new List<string>();
	|            System.Reflection.PropertyInfo[] myPropertyInfo;
	|            myPropertyInfo = p1.GetType().GetProperties();
	|            for (int i = 0; i < myPropertyInfo.Length; i++)
	|            {
	|                if (myPropertyInfo[i].CustomAttributes.Count() == 1)
	|                {
	|                    string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Name;
	|                    string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().Alias;
	|                    p.Add(NameRu + "" ("" + NameEn + "")"");
	|                }
	|            }
	|            p.Sort();
	|            foreach (string str in p)
	|            {
	|                string nameEn = StrFindBetween(str, ""("", "")"").Get(0).ExplicitString();
	|                dynamic objVolue = null;
	|                try
	|                {
	|                    objVolue = p1.GetType().GetProperty(nameEn).GetValue(p1);
	|                }
	|                catch { }
	|
	|                str1 = str1 + transfer + str + "" = "" + objVolue;
	|                transfer = ""\r\n"";
	|            }
	|            return str1;
	|        }
	|
	|        [ContextMethod(""КлассыИгровыхФорм"", ""GameFormsClasses"")]
	|        public string GameFormsClasses()
	|        {
	|            string str1 = """";
	|            string transfer = """";
	|            List<string> p = new List<string>();
	|
	|            // Получаем все типы из сборки
	|            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();
	|            // Фильтруем только классы (не интерфейсы, структуры и т.п.)
	|            var classes = allTypes.Where(t => t.IsClass && t.IsPublic).ToList();
	|            // Теперь classes содержит список всех классов в библиотеке
	|            foreach (var @class in classes)
	|            {
	|                if (@class.Name.StartsWith(""Gf""))
	|                {
	|                    //OsUtils.Echo(@class.Name);
	|                    p.Add(@class.Name);
	|                }
	|            }
	|
	|            p.Sort();
	|            foreach (string str in p)
	|            {
	|                str1 = str1 + transfer + str;
	|                transfer = ""\r\n"";
	|            }
	|            return str1;
	|        }
	|
	|        [ContextMethod(""СтрНайтиМежду"", ""StrFindBetween"")]
	|        public ArrayImpl StrFindBetween(string p1, string p2 = null, string p3 = null, bool p4 = true, bool p5 = true)
	|        {
	|            ArrayImpl array = OsUtils.FindBetweenOptimized(p1, p2, p3, p4, p5);
	|            return array;
	|        }
	|
	|        [ContextMethod(""СообщитьЕслиЛожь"", ""ReportIfFalse"")]
	|        public void ReportIfFalse(bool condition, string message)
	|        {
	|            if (!condition)
	|            {
	|                ScriptException scriptException = new ScriptException(message);
	|                throw scriptException;
	|            }
	|        }
	|
	|        [ContextMethod(""ПроброситьИсключение"", ""SkipException"")]
	|        public void SkipException(string message)
	|        {
	|            OnTestException?.Invoke(message);
	|        }
	|
	|        [ContextMethod(""ТекущаяДатаСМиллисекундами"", ""CurrentDateWithMilliseconds"")]
	|        public string CurrentDateWithMilliseconds()
	|        {
	|            return DateTime.Now.ToString(@""dd:MM:yyyy HH:mm:ss.fffffff"");
	|        }
	|
	|        [ContextMethod(""Загрузить"", ""Load"")]
	|        public IValue Load(string _path)
	|        {
	|            string path = OsUtils.ToGodotPath(_path);
	|            string resourceItemKey = ""d"" + Path.GetRandomFileName().Replace(""."", """");
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""resourceItemKey"",  resourceItemKey },
	|                    { ""resource_path"",  path },
	|                }
	|            };
	|            string jsonResponse = OsUtils.Serialize(response);
	|            string res = GameForms.SendCommand(""ResourceLoad"", jsonResponse);
	|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
	|            if (((JsonElement)answer[""success""]).GetBoolean())
	|            {
	|                string typeResource = ((JsonElement)answer[""report""]).GetString();
	|                Type type = Type.GetType(""osgf.Gf"" + typeResource);
	|                object[] args1 = { resourceItemKey };
	|                dynamic obj = (IValue)Activator.CreateInstance(type, args1);
	|                obj.ResourcePath = path;
	|                return obj;
	|            }
	|            else
	|            {
	|                OsUtils.Echo(""Не удалось выполнить метод Загрузить"");
	|                return null;
	|            }
	|        }
	|
	|        [ContextMethod(""ОжидатьФайл"", ""WaitFile"")]
	|        public bool WaitFile(string path, int timeoutMs = 10000)
	|        {
	|            int start = System.Environment.TickCount;
	|            while (true)
	|            {
	|                if (File.Exists(path))
	|                {
	|                    try
	|                    {
	|                        var len = new System.IO.FileInfo(path).Length;
	|                        if (len > 0) return true; // файл есть и не пустой
	|                    }
	|                    catch
	|                    {
	|                        // файл есть, но временно недоступен — продолжаем ждать
	|                    }
	|                }
	|                if (timeoutMs > 0 && (System.Environment.TickCount - start) >= timeoutMs)
	|                {
	|                    return false;
	|                }
	|                System.Threading.Thread.Sleep(100);
	|            }
	|        }
	|
	|        [ContextMethod(""Строка"", ""String"")]
	|        public GfString String(IValue p1)
	|        {
	|            return new GfString(p1);
	|        }
	|
	|        [ContextProperty(""СлучайноеИмя"", ""TempName"")]
	|        public string TempName
	|        {
	|            get { return OsUtils.TempName; }
	|        }
	|    }
	|}
	|";
	ТекстДокХХХ = Новый ТекстовыйДокумент;
	ТекстДокХХХ.УстановитьТекст(СтрGameForms);
	ТекстДокХХХ.Записать(ОбъединитьПути(КаталогВыгрузки, "GameForms.cs"));
	
	// Создадим файл Response.cs.
	СтрGameForms = 
	"namespace osgf
	|{
	|    public class Response
	|    {
	|        public Dictionary<string, object> Properties { get; set; } = null; // Свойства элемента.
	|
	|        public object this[string p1]
	|        {
	|            get { return this.GetType().GetProperty(p1).GetValue(this); }
	|            set { this.GetType().GetProperty(p1).SetValue(this, value); }
	|        }
	|    }
	|}
	|";
	ТекстДокХХХ = Новый ТекстовыйДокумент;
	ТекстДокХХХ.УстановитьТекст(СтрGameForms);
	ТекстДокХХХ.Записать(ОбъединитьПути(КаталогВыгрузки, "Response.cs"));
	
	// Создадим файл OsUtils.cs.
	СтрGameForms = 
	"using OneScript.StandardLibrary;
	|using OneScript.StandardLibrary.Collections;
	|using OneScript.Values;
	|using ScriptEngine.Machine;
	|using System.Reflection;
	|using System.Text;
	|using System.Text.Encodings.Web;
	|using System.Text.Json;
	|
	|namespace osgf
	|{
	|    public static class OsUtils
	|    {
	|        //OneScript.Values.BslBooleanValue
	|        //OneScript.Values.BslDateValue
	|        //OneScript.Values.BslNullValue
	|        //OneScript.Values.BslNumericValue
	|        //OneScript.Values.BslObjectValue
	|        //OneScript.Values.BslPrimitiveValue
	|        //OneScript.Values.BslStringValue
	|        //OneScript.Values.BslTypeValue
	|        //OneScript.Values.BslUndefinedValue
	|
	|        public static bool IsString(IValue value) => value?.SystemType.Name == ""Строка"";
	|        public static bool IsNumber(IValue value) => value?.SystemType.Name == ""Число"";
	|        public static bool IsBoolean(IValue value) => value?.SystemType.Name == ""Булево"";
	|        public static bool IsDateTime(IValue value) => value?.SystemType.Name == ""Дата"";
	|        public static bool IsType<T>(IValue value) => value?.GetType() == typeof(T);
	|        public static bool IsType<T>(object value) => value?.GetType() == typeof(T);
	|
	|        public static Dictionary<string, GfAction> ActionAlias = new Dictionary<string, GfAction>();
	|
	|        public static Dictionary<string, object> Deserialize(string obj)
	|        {
	|            Dictionary<string, object> answer = JsonSerializer.Deserialize<Dictionary<string, object>>(obj);
	|            return answer;
	|        }
	|
	|        private static string SerializeWithUnicode(object obj)
	|        {
	|            return JsonSerializer.Serialize(obj, new JsonSerializerOptions
	|            {
	|                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
	|            });
	|        }
	|
	|        public static string Serialize(Dictionary<string, object> obj)
	|        {
	|            return SerializeWithUnicode(obj);
	|        }
	|
	|        public static string Serialize(Response obj)
	|        {
	|            return SerializeWithUnicode(obj);
	|        }
	|
	|        public static string ClipboardGet()
	|        {
	|            string res = GameForms.SendCommand(""ClipboardGet"");
	|            var answer = OsUtils.Deserialize(OsUtils.Deserialize(res)[""result""].ToString());
	|            if (((JsonElement)answer[""success""]).GetBoolean())
	|            {
	|                return ((JsonElement)answer[""report""]).GetString();
	|            }
	|            else
	|            {
	|                OsUtils.Echo(""Не удалось выполнить метод ПолучитьТекстБуфераОбмена."");
	|                return null;
	|            }
	|        }
	|
	|        public static void ClipboardSet(string p1)
	|        {
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""textToClipboard"",  p1 },
	|                }
	|            };
	|            OsUtils.GetAnswerSendCommand(MethodBase.GetCurrentMethod().Name, response);
	|        }
	|
	|        private static string GetGodotPropertyName(MethodBase currentMethod)
	|        {
	|            string methodName = currentMethod.Name.Replace(""set_"", """").Replace(""get_"", """");
	|            var sb = new StringBuilder();
	|            for (int i = 0; i < methodName.Length; i++)
	|            {
	|                char c = methodName[i];
	|                if (char.IsUpper(c) && i > 0)
	|                {
	|                    sb.Append('_');
	|                }
	|                sb.Append(char.ToLower(c));
	|            }
	|            return sb.ToString();
	|        }
	|
	|        public static string GetCSharpName(string godotName)
	|        {
	|            if (string.IsNullOrEmpty(godotName))
	|            {
	|                return godotName;
	|            }
	|
	|            var sb = new StringBuilder(godotName.Length);
	|            bool nextUpper = false;
	|            bool firstCharSet = false;
	|
	|            for (int i = 0; i < godotName.Length; i++)
	|            {
	|                char c = godotName[i];
	|
	|                if (c == '_')
	|                {
	|                    nextUpper = true;
	|                    continue;
	|                }
	|
	|                if (nextUpper)
	|                {
	|                    sb.Append(char.ToUpperInvariant(c));
	|                    nextUpper = false;
	|                    firstCharSet = true;
	|                }
	|                else
	|                {
	|                    // Первую букву делаем заглавной, остальные — как есть
	|                    if (!firstCharSet)
	|                    {
	|                        sb.Append(char.ToUpperInvariant(c));
	|                        firstCharSet = true;
	|                    }
	|                    else
	|                    {
	|                        sb.Append(c);
	|                    }
	|                }
	|            }
	|            return sb.ToString();
	|        }
	|
	|        public static string GetGodotName(string name)
	|        {
	|            var sb = new StringBuilder();
	|            for (int i = 0; i < name.Length; i++)
	|            {
	|                char c = name[i];
	|                if (char.IsUpper(c) && i > 0)
	|                {
	|                    sb.Append('_');
	|                }
	|                sb.Append(char.ToLower(c));
	|            }
	|            return sb.ToString();
	|        }
	|
	|        private static string GetGameFormsPropertyName(MethodBase currentMethod)
	|        {
	|            return currentMethod.Name.Replace(""set_"", """").Replace(""get_"", """");
	|        }
	|
	|        public static object ConvertValueForGameForms(dynamic report)
	|        {
	|            string strPropertyType = ((JsonElement)report[""propertyType""]).GetString();
	|            var itemValue = (JsonElement)report[""propertyValue""];
	|            Type type = Type.GetType(strPropertyType);
	|            if (type == Type.GetType(""osgf.GfColor""))
	|            {
	|                GfColor color = new GfColor()
	|                {
	|                    R = OsUtils.ToInt32(itemValue[0].GetSingle() * 255),
	|                    G = OsUtils.ToInt32(itemValue[1].GetSingle() * 255),
	|                    B = OsUtils.ToInt32(itemValue[2].GetSingle() * 255),
	|                    A = OsUtils.ToInt32(itemValue[3].GetSingle() * 255),
	|                };
	|                return color;
	|            }
	|            else if (type == Type.GetType(""osgf.GfFontVariation""))
	|            {
	|                GameForms.dictKeyEl.TryGetValue(itemValue.GetString(), out var fontVariation);
	|                return fontVariation.dll_obj;
	|            }
	|            else if (type == Type.GetType(""osgf.GfTheme""))
	|            {
	|                GameForms.dictKeyEl.TryGetValue(itemValue.GetString(), out var theme);
	|                return theme.dll_obj;
	|            }
	|            else if (type == Type.GetType(""osgf.GfImageTexture""))
	|            {
	|                GameForms.dictKeyEl.TryGetValue(itemValue.GetString(), out var imageTexture);
	|                return imageTexture.dll_obj;
	|            }
	|            else if (type == Type.GetType(""System.String""))
	|            {
	|                return itemValue.GetString();
	|            }
	|            else if (type == Type.GetType(""System.Decimal""))
	|            {
	|                return itemValue.GetDecimal();
	|            }
	|            else if (type == Type.GetType(""System.Int32""))
	|            {
	|                return itemValue.GetInt32();
	|            }
	|            else if (type == Type.GetType(""System.Boolean""))
	|            {
	|                return itemValue.GetBoolean();
	|            }
	|            else if (type == Type.GetType(""osgf.GfVector2""))
	|            {
	|                return new GfVector2(itemValue[0].GetDecimal(), itemValue[1].GetDecimal());
	|            }
	|            else if (type == Type.GetType(""osgf.GfVector2i""))
	|            {
	|                return new GfVector2i(itemValue[0].GetInt32(), itemValue[1].GetInt32());
	|            }
	|            else if (type == Type.GetType(""osgf.GfRect2""))
	|            {
	|                GfRect2 rect2 = new GfRect2();
	|                rect2.Position = new GfVector2(itemValue[0].GetDecimal(), itemValue[1].GetDecimal());
	|                rect2.Size = new GfVector2(itemValue[2].GetDecimal(), itemValue[3].GetDecimal());
	|                return rect2;
	|            }
	|            else
	|            {
	|                //return $""ConvertValueForGameForms - Не учтено значение для типа: {strPropertyType} - {report?.ToString()}"";
	|                throw new NotSupportedException($""ConvertValueForGameForms - Не учтено значение для типа: {strPropertyType} - {report?.ToString()}"");
	|            }
	|        }
	|
	|        public static object ConvertValueForGodot(dynamic value)
	|        {
	|            if (value is GfVector2 vector2)
	|            {
	|                return new float[] { (float)vector2.X, (float)vector2.Y };
	|            }
	|            else if (value is GfFontVariation fontVariation)
	|            {
	|                return Convert.ToString(((dynamic)fontVariation).ItemKey);
	|            }
	|            else if (value is GfThemeScene themeScene)
	|            {
	|                return Convert.ToString(((dynamic)themeScene).ItemKey);
	|            }
	|            else if (value is GfStyleBoxFlat styleBoxFlat)
	|            {
	|                return Convert.ToString(((dynamic)styleBoxFlat).ItemKey);
	|            }
	|            else if (value is GfImageTexture imageTexture)
	|            {
	|                return Convert.ToString(imageTexture.ItemKey);
	|            }
	|            else if (value is GfVector2i vector2i)
	|            {
	|                return new int[] { vector2i.X, vector2i.Y };
	|            }
	|            else if (value is GfRect2 rect2)
	|            {
	|                return new float[] {
	|                    (float)rect2.Position.X, (float)rect2.Position.Y,
	|                    (float)rect2.Size.X, (float)rect2.Size.Y
	|                };
	|            }
	|            else if (value is GfColor color)
	|            {
	|                return new float[] { ToFloat(color.R) / 255f, ToFloat(color.G) / 255f, ToFloat(color.B) / 255f, ToFloat(color.A) / 255f };
	|            }
	|            else if (value is bool boolValue)
	|            {
	|                return boolValue;
	|            }
	|            else if (value is int || value is float || value is double || value is decimal)
	|            {
	|                return Convert.ToSingle(value);
	|            }
	|            else if (value is string)
	|            {
	|                return Convert.ToString(value);
	|            }
	|            else
	|            {
	|                //return $""ConvertValueForGodot - Не учтено значение для типа: {value.GetType} - {value?.ToString()}"";
	|                throw new NotSupportedException($""ConvertValueForGodot - Не учтено значение для типа: {value.GetType} - {value?.ToString()}"");
	|            }
	|        }
	|
	|        public static void SetGodotProperty(MethodBase currentMethod, string itemKey, dynamic _value)
	|        {
	|            string propName = GetGodotPropertyName(currentMethod);
	|            object rez = ConvertValueForGodot(_value);
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""element"",  itemKey },
	|                    { ""propName"", propName },
	|                    { ""propValue"", rez }
	|                }
	|            };
	|            GetAnswerSendCommand(""SetProperty"", response);
	|        }
	|
	|        public static dynamic GetGodotProperty(MethodBase currentMethod, dynamic element)
	|        {
	|            string propName = GetGodotPropertyName(currentMethod);
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""element"",  element.ItemKey },
	|                    { ""propName"",  propName },
	|                }
	|            };
	|            string jsonResponse = Serialize(response);
	|            string res = GameForms.SendCommand(""GetProperty"", jsonResponse);
	|            var answer = Deserialize(Deserialize(res)[""result""].ToString());
	|            if (answer[""report""].ToString() == ""<Object#null>"")
	|            {
	|                return null;
	|            }
	|            var report = Deserialize(answer[""report""].ToString());
	|            return ConvertValueForGameForms(report);
	|        }
	|
	|        public static void SetGodotAction(MethodBase currentMethod, string itemKey, GfAction action)
	|        {
	|            string actionName = currentMethod.Name.Replace(""set_"", """").Replace(""get_"", """");
	|            string keyActionName = itemKey + ""_"" + actionName;
	|
	|            bool actionIsNull = false;
	|            if (action.MethodName == """")
	|            {
	|                actionIsNull = true;
	|            }
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""element"",  itemKey },
	|                    { ""actionIsNull"",  actionIsNull },
	|                }
	|            };
	|            string jsonResponse = Serialize(response);
	|            string res = GameForms.SendCommand(actionName, jsonResponse);
	|            var answer = Deserialize(Deserialize(res)[""result""].ToString());
	|            if (((JsonElement)answer[""success""]).GetBoolean())
	|            {
	|                if (ActionAlias.ContainsKey(keyActionName))
	|                {
	|                    ActionAlias[keyActionName] = action;
	|                }
	|                else
	|                {
	|                    ActionAlias.Add(keyActionName, action);
	|                }
	|            }
	|            else
	|            {
	|                Echo($""Не удалось установить действие {actionName}"");
	|            }
	|        }
	|
	|        public static GfAction GetGodotAction(MethodBase currentMethod, string itemKey)
	|        {
	|            return ActionAlias[itemKey + ""_"" + currentMethod.Name.Replace(""set_"", """").Replace(""get_"", """")];
	|        }
	|
	|        public static void SetSetter(MethodBase currentMethod, dynamic Base_obj, IValue value)
	|        {
	|            string actionName = currentMethod.Name.Replace(""set_"", """").Replace(""get_"", """");
	|            if (IsType<GfAction>(value))
	|            {
	|                Base_obj[actionName] = value as GfAction;
	|            }
	|            else if (IsType<OneScript.Values.BslUndefinedValue>(value))
	|            {
	|                Base_obj[actionName] = new GfAction(GameForms.instance, """");
	|            }
	|            else
	|            {
	|                Echo($""Свойство {actionName}: Неверный тип аргумента"");
	|            }
	|        }
	|
	|        public static void CreateGodotObject(object obj)
	|        {
	|            string objectType = obj.GetType().Name;
	|            string objItemKey = ""d"" + Path.GetRandomFileName().Replace(""."", """");
	|            ((dynamic)obj).ItemKey = objItemKey;
	|            Response response = new Response
	|            {
	|                Properties = new Dictionary<string, object>
	|                {
	|                    { ""itemKey"",  objItemKey },
	|                    { ""typeNode"",  objectType },
	|                }
	|            };
	|            string jsonResponse = Serialize(response);
	|            string res = GameForms.SendCommand(""CreateNode"", jsonResponse);
	|            var answer = Deserialize(Deserialize(res)[""result""].ToString());
	|            if (((JsonElement)answer[""success""]).GetBoolean())
	|            {
	|                GameForms.dictKeyEl.TryAdd(objItemKey, obj);
	|                GameForms.dictElKey.TryAdd(obj, objItemKey);
	|            }
	|            else
	|            {
	|                Echo($""Не удалось создать объект {objectType}"");
	|                ((dynamic)obj).dll_obj = null;
	|            }
	|        }
	|
	|        public static bool AllNotNull(params IValue[] values)
	|        {
	|            foreach (var value in values)
	|            {
	|                if (value == null) return false;
	|            }
	|            return true;
	|        }
	|
	|        public static bool AllNotNull(params string[] values)
	|        {
	|            foreach (var value in values)
	|            {
	|                if (value == null) return false;
	|            }
	|            return true;
	|        }
	|
	|        public static bool AllNotNull(params object[] values)
	|        {
	|            foreach (var value in values)
	|            {
	|                if (value == null) return false;
	|            }
	|            return true;
	|        }
	|
	|        public static dynamic DefineTypeIValue(dynamic p1)
	|        {
	|            if (p1.GetType() == typeof(OneScript.Values.BslStringValue))
	|            {
	|                return ValueFactory.Create(((BslStringValue)p1).ToString());
	|            }
	|            else if (p1.GetType() == typeof(OneScript.Values.BslNumericValue))
	|            {
	|                return ValueFactory.Create(((BslNumericValue)p1).AsNumber());
	|            }
	|            else if (p1.GetType() == typeof(OneScript.Values.BslBooleanValue))
	|            {
	|                return ValueFactory.Create(((BslBooleanValue)p1).AsBoolean());
	|            }
	|            else if (p1.GetType() == typeof(OneScript.Values.BslDateValue))
	|            {
	|                return ValueFactory.Create(((BslDateValue)p1).AsDate());
	|            }
	|            else
	|            {
	|                return p1;
	|            }
	|        }
	|
	|        public static string[] ArrayImplToStringArray(ArrayImpl array)
	|        {
	|            int count = array.Count();
	|            string[] result = new string[count];
	|            for (int i = 0; i < count; i++)
	|            {
	|                string element = array.Get(i).ToString();
	|                result[i] = element;
	|            }
	|            return result;
	|        }
	|
	|        public static ArrayImpl StringArrayToArrayImpl(string[] stringArray)
	|        {
	|            ArrayImpl array = new ArrayImpl();
	|            foreach (string value in stringArray)
	|            {
	|                array.Add(ValueFactory.Create(value));
	|            }
	|            return array;
	|        }
	|
	|        public static ArrayImpl ListToArray(List<string> listString)
	|        {
	|            ArrayImpl array = new ArrayImpl();
	|            string[] stringArray = listString.ToArray();
	|            foreach (var value in stringArray)
	|            {
	|                array.Add(ValueFactory.Create(value));
	|            }
	|            return array;
	|        }
	|
	|        public static List<string> ArrayImplToListArray(ArrayImpl array)
	|        {
	|            int count = array.Count();
	|            List<string> result = new List<string>();
	|            for (int i = 0; i < count; i++)
	|            {
	|                string element = array.Get(i).ToString();
	|                result.Add(element);
	|            }
	|            return result;
	|        }
	|
	|        public static int[] ArrayImplToInt32Array(ArrayImpl array)
	|        {
	|            int count = array.Count();
	|            int[] result = new int[count];
	|            for (int i = 0; i < count; i++)
	|            {
	|                IValue element = array.Get(i);
	|                result[i] = ToInt32(element);
	|            }
	|            return result;
	|        }
	|
	|        public static ArrayImpl IntArrayToArrayImpl(int[] intArray)
	|        {
	|            ArrayImpl array = new ArrayImpl();
	|            foreach (int value in intArray)
	|            {
	|                array.Add(ValueFactory.Create(value));
	|            }
	|            return array;
	|        }
	|
	|        public static ArrayImpl FloatArrayToArrayImpl(float[] floatArray)
	|        {
	|            ArrayImpl array = new ArrayImpl();
	|            foreach (float value in floatArray)
	|            {
	|                array.Add(ValueFactory.Create(ToDecimal(value)));
	|            }
	|            return array;
	|        }
	|
	|        public static float[] ArrayImplToFloatArray(ArrayImpl array)
	|        {
	|            int count = array.Count();
	|            float[] result = new float[count];
	|            for (int i = 0; i < count; i++)
	|            {
	|                IValue element = array.Get(i);
	|                result[i] = ToFloat(element);
	|            }
	|            return result;
	|        }
	|
	|        public static byte[] ArrayImplToByteArray(ArrayImpl array)
	|        {
	|            int count = array.Count();
	|            byte[] result = new byte[count];
	|            for (int i = 0; i < count; i++)
	|            {
	|                IValue element = array.Get(i);
	|                decimal numberValue = element.AsNumber();
	|                result[i] = (byte)numberValue;
	|            }
	|            return result;
	|        }
	|
	|        public static ArrayImpl ByteArrayToArrayImpl(byte[] byteArray)
	|        {
	|            ArrayImpl array = new ArrayImpl();
	|            foreach (byte value in byteArray)
	|            {
	|                array.Add(ValueFactory.Create((decimal)value));
	|            }
	|            return array;
	|        }
	|
	|        public static float ToFloat(object num)
	|        {
	|            if (num.GetType() == typeof(BslNumericValue))
	|            {
	|                return Convert.ToSingle(((BslNumericValue)num).AsNumber());
	|            }
	|            return Convert.ToSingle(num);
	|        }
	|
	|        public static byte ToByte(object num)
	|        {
	|            if (num.GetType() == typeof(BslNumericValue))
	|            {
	|                return Convert.ToByte(((BslNumericValue)num).AsNumber());
	|            }
	|            return Convert.ToByte(num);
	|        }
	|
	|        public static int ToInt32(object num)
	|        {
	|            if (num.GetType() == typeof(BslNumericValue))
	|            {
	|                return Convert.ToInt32(((BslNumericValue)num).AsNumber());
	|            }
	|            return Convert.ToInt32(num);
	|        }
	|
	|        public static int ToInt32(string str, int basis)
	|        {
	|            return Convert.ToInt32(str, basis);
	|        }
	|
	|        public static int ToInt32(byte _byte)
	|        {
	|            return Convert.ToInt32(_byte);
	|        }
	|
	|        public static decimal ToDecimal(object num)
	|        {
	|            if (num.GetType() == typeof(BslNumericValue))
	|            {
	|                return Convert.ToDecimal(((BslNumericValue)num).AsNumber());
	|            }
	|            return Convert.ToDecimal(num);
	|        }
	|
	|        public static uint ToUInt32(object num)
	|        {
	|            if (num.GetType() == typeof(BslNumericValue))
	|            {
	|                return Convert.ToUInt32(((BslNumericValue)num).AsNumber());
	|            }
	|            return Convert.ToUInt32(num);
	|        }
	|
	|        public static double ToDouble(object num)
	|        {
	|            if (num.GetType() == typeof(BslNumericValue))
	|            {
	|                return Convert.ToDouble(((BslNumericValue)num).AsNumber());
	|            }
	|            return Convert.ToDouble(num);
	|        }
	|
	|        public static bool ToBoolean(object num)
	|        {
	|            if (num.GetType() == typeof(BslBooleanValue))
	|            {
	|                return Convert.ToBoolean(((BslBooleanValue)num).AsBoolean());
	|            }
	|            return Convert.ToBoolean(num);
	|        }
	|
	|        public static string ToString(object obj)
	|        {
	|            return Convert.ToString(obj);
	|        }
	|
	|        public static void WriteToFile(string str)
	|        {
	|            using (StreamWriter writer = new StreamWriter(""C:\\444\\Log.txt"", true, System.Text.Encoding.UTF8))
	|            {
	|                writer.WriteLineAsync("""" + System.Environment.NewLine + DateTime.Now.ToString() + System.Environment.NewLine + str);
	|            }
	|        }
	|
	|        public static void Echo(string p1, MessageStatusEnum status = MessageStatusEnum.Ordinary)
	|        {
	|            Console.WriteLine(p1);
	|        }
	|
	|        public static string ToHex32(int val)
	|        {
	|            return Convert.ToByte(val).HexEncode();
	|        }
	|
	|        public static string HexEncode(this byte b)
	|        {
	|            string text = string.Empty;
	|            for (int i = 0; i < 2; i++)
	|            {
	|                int num = b & 0xF;
	|                char c = ((num >= 10) ? ((char)(97 + num - 10)) : ((char)(48 + num)));
	|                b >>= 4;
	|                text = c + text;
	|            }
	|            return text;
	|        }
	|
	|        public static void GetAnswerSendCommand(string CommandSent, Response response)
	|        {
	|            string jsonResponse = Serialize(response);
	|            string res = GameForms.SendCommand(CommandSent, jsonResponse);
	|            var answer = Deserialize(Deserialize(res)[""result""].ToString());
	|            try
	|            {
	|                if (!((JsonElement)answer[""success""]).GetBoolean())
	|                {
	|                    Echo($""Не удалось выполнить метод {CommandSent}."");
	|                }
	|            }
	|            catch (Exception ex)
	|            {
	|                Echo($""Ошибка в OsUtils.GetResponse: {ex.StackTrace}"");
	|            }
	|        }
	|
	|        public static dynamic CastToDataType(dynamic obj)
	|        {
	|            if (IsType<GfVector2>(obj))
	|            {
	|                return new float[] { ToFloat(obj.X), ToFloat(obj.Y) };
	|            }
	|            else if (IsType<GfDictionary>(obj))
	|            {
	|                float[][] pointsArray = new float[obj.CountProp * 2][];
	|                for (int i = 0; i < obj.CountProp; i++)
	|                {
	|                    var item = ((GfDictionary)obj).Base_obj.M_Dictionary.ElementAt(i);
	|                    GfVector2 pointStart = item.Key as GfVector2;
	|                    float[] startArray = { ToFloat(pointStart.X), ToFloat(pointStart.Y) };
	|                    pointsArray[2 * i] = startArray;
	|                    GfVector2 pointEnd = item.Value as GfVector2;
	|                    float[] endArray = { ToFloat(pointEnd.X), ToFloat(pointEnd.Y) };
	|                    pointsArray[2 * i + 1] = endArray;
	|                }
	|                return pointsArray;
	|            }
	|            else if (IsType<ArrayImpl>(obj))
	|            {
	|                float[][] pointsArray = new float[obj.Count()][];
	|                for (int i = 0; i < obj.Count(); i++)
	|                {
	|                    var item = obj.Get(i);
	|                    GfVector2 point = item as GfVector2;
	|                    float[] pointArray = { ToFloat(point.X), ToFloat(point.Y) };
	|                    pointsArray[i] = pointArray;
	|                }
	|                return pointsArray;
	|            }
	|            else if (IsType<GfRect2>(obj))
	|            {
	|                return new float[] { ToFloat(((GfRect2)obj).Position.X), ToFloat(((GfRect2)obj).Position.Y), ToFloat(((GfRect2)obj).Size.X), ToFloat(((GfRect2)obj).Size.Y) };
	|            }
	|            else if (IsType<GfColor>(obj))
	|            {
	|                return new float[] { ToFloat(obj.R) / 255f, ToFloat(obj.G) / 255f, ToFloat(obj.B) / 255f, ToFloat(obj.A) / 255f };
	|            }
	|            else if (IsType<decimal>(obj))
	|            {
	|                return ToFloat(obj);
	|            }
	|            else if (IsType<int>(obj)
	|                || IsType<string>(obj)
	|                || IsType<bool>(obj)
	|                || IsType<List<Dictionary<string, object>>>(obj)
	|                || IsType<float[][]>(obj))
	|            {
	|                return obj;
	|            }
	|            else
	|            {
	|                Echo($""Ошибка получения значения {obj.ToString()} в методе CastToDataType."");
	|                return null;
	|            }
	|        }
	|
	|        public static Response GetResponse(MethodBase currentMethod, string ItemKey, params object[] args)
	|        {
	|            Response response = new Response();
	|            ParameterInfo[] parameters = currentMethod.GetParameters();
	|            Dictionary<string, object> Properties = new Dictionary<string, object>();
	|            for (int i = 0; i < parameters.Length; i++)
	|            {
	|                Properties.Add(parameters[i].Name, CastToDataType(args[i]));
	|            }
	|            Properties.Add(""element"", ItemKey);
	|            response.Properties = Properties;
	|            return response;
	|        }
	|
	|        public static ArrayImpl FindBetweenOptimized(
	|            string input,
	|            string fragment1 = null,
	|            string fragment2 = null,
	|            bool excludeFragments = true,
	|            bool noOverlap = true)
	|        {
	|            // Если оба фрагмента не заданы — возвращаем пустой массив
	|            if (fragment1 == null && fragment2 == null)
	|            {
	|                return new ArrayImpl();
	|            }
	|            var result = new ArrayImpl();
	|            var positions1 = fragment1 != null ? FindAllPositions(input, fragment1) : new List<int>();
	|            var positions2 = fragment2 != null ? FindAllPositions(input, fragment2) : new List<int>();
	|            // Случай 1: задан только фрагмент1
	|            if (fragment1 != null && fragment2 == null)
	|            {
	|                foreach (var pos in positions1)
	|                {
	|                    string extracted = excludeFragments
	|                        ? input.Substring(pos + fragment1.Length)
	|                        : input.Substring(pos);
	|                    result.Add(ValueFactory.Create(extracted));
	|                }
	|            }
	|            // Случай 2: задан только фрагмент2
	|            else if (fragment1 == null && fragment2 != null)
	|            {
	|                foreach (var pos in positions2)
	|                {
	|                    string extracted = excludeFragments
	|                        ? input.Substring(0, pos)
	|                        : input.Substring(0, pos + fragment2.Length);
	|                    result.Add(ValueFactory.Create(extracted));
	|                }
	|            }
	|            // Случай 3: заданы оба фрагмента
	|            else if (fragment1 != null && fragment2 != null)
	|            {
	|                foreach (var pos1 in positions1)
	|                {
	|                    // Ищем все fragment2, которые идут после fragment1
	|                    var validPos2 = positions2.FindAll(pos2 => pos2 > pos1);
	|                    foreach (var pos2 in validPos2)
	|                    {
	|                        // Проверяем условие отсутствия наложения
	|                        if (noOverlap && HasOverlap(input, pos1, pos2, fragment2))
	|                        {
	|                            continue;
	|                        }
	|                        string extracted = BuildResultSubstring(input, pos1, pos2, fragment1, fragment2, excludeFragments);
	|                        result.Add(ValueFactory.Create(extracted));
	|                    }
	|                }
	|            }
	|            return result;
	|        }
	|
	|        // Вспомогательная функция: находит все позиции вхождения фрагмента в строке
	|        private static List<int> FindAllPositions(string input, string fragment)
	|        {
	|            var positions = new List<int>();
	|            int startIndex = 0;
	|            int pos;
	|            while ((pos = input.IndexOf(fragment, startIndex, StringComparison.Ordinal)) >= 0)
	|            {
	|                positions.Add(pos);
	|                startIndex = pos + 1;
	|            }
	|            return positions;
	|        }
	|
	|        // Проверка на наложение: есть ли в интервале другое вхождение fragment2
	|        private static bool HasOverlap(string input, int start, int end, string fragment2)
	|        {
	|            int fragmentLength = fragment2.Length;
	|            // Ищем вхождение fragment2 внутри интервала (start, end)
	|            for (int i = start + 1; i <= end - fragmentLength; i++)
	|            {
	|                if (input.Substring(i, fragmentLength) == fragment2)
	|                {
	|                    return true;
	|                }
	|            }
	|            return false;
	|        }
	|
	|        // Формирует финальную подстроку по индексам
	|        private static string BuildResultSubstring(string input, int pos1, int pos2, string fragment1, string fragment2, bool excludeFragments)
	|        {
	|            if (excludeFragments)
	|            {
	|                int start = pos1 + fragment1.Length;
	|                int length = pos2 - start;
	|                return input.Substring(start, length);
	|            }
	|            else
	|            {
	|                return input.Substring(pos1, pos2 - pos1 + fragment2.Length);
	|            }
	|        }
	|
	|        public static string TempName
	|        {
	|            get { return $""m{Guid.NewGuid():N}""; }
	|        }
	|
	|        // Разделитель путей.
	|        // Godot поддерживает только / в качестве разделителя путей. Это делается по причинам переносимости.
	|        // Все операционные системы поддерживают это, даже Windows, поэтому путь
	|        // C:\project\project.godot
	|        // должен быть напечатан как
	|        // C:/project/project.godot.
	|        public static string ToGodotPath(string windowsPath)
	|        {
	|            // Нормализуем слеши
	|            string normalized = windowsPath.Replace(@""\\"", @""/"");
	|
	|            normalized = normalized.Replace(@""\"", @""/"");
	|
	|            // Если уже res:// — оставляем как есть
	|            if (normalized.StartsWith(""res://""))
	|            {
	|                return normalized;
	|            }
	|
	|            // Абсолютный путь вне проекта — Godot его не сможет сохранить в .tres корректно
	|            return normalized;
	|        }
	|    }
	|}
	|";
	ТекстДокХХХ = Новый ТекстовыйДокумент;
	ТекстДокХХХ.УстановитьТекст(СтрGameForms);
	ТекстДокХХХ.Записать(ОбъединитьПути(КаталогВыгрузки, "OsUtils.cs"));
КонецПроцедуры//ВыгрузкаДляGForms

Функция ОтобратьФайлы(Фильтр)
	// Фильтр - Строковое значение отбора (Класс Конструктор Свойства Свойство Методы Метод Перечисление)
	М_Фильтр = Новый Массив();
	ВыбранныеФайлы = НайтиФайлы(КаталогСправки, "*.html", Истина);
	Найдено1 = 0;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
		Стр = ТекстДок.ПолучитьТекст();
		М = ИОС.СтрНайтиМежду(Стр, "<h1 class=dtH1", "/h1>", , );
		Если М.Количество() > 0 Тогда
			СтрЗаголовка= М[0];
			Если (СтрНайти(СтрЗаголовка, Фильтр + "<") > 0) Тогда
				Найдено1 = Найдено1 + 1;
				// Сообщить("================================================================================================");
				// Сообщить("" + ВыбранныеФайлы[А].ПолноеИмя + "=" + СтрЗаголовка);
				// Сообщить("" + СтрЗаголовка);
				М_Фильтр.Добавить(ВыбранныеФайлы[А].ПолноеИмя);
			КонецЕсли;
		КонецЕсли;
	КонецЦикла;
	
	Сообщить("Найдено1 (" + Фильтр + ") = " + Найдено1);
	Возврат М_Фильтр;
КонецФункции

Функция ДанныеОбъекта(ПолныйПуть)
	// Сообщить("ПолныйПуть = " + ПолныйПуть);
	Структура1 = Новый Структура();
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ПолныйПуть);
	Стр = ТекстДок.ПолучитьТекст();
	М = ИОС.СтрНайтиМежду(Стр, "<h1 class=dtH1", "/h1>", , );
	Если М.Количество() > 0 Тогда
		СтрЗаголовка= М[0];
		ИмяКлассаАнгл = ИОС.СтрНайтиМежду(СтрЗаголовка, "(", ")", , )[0];
		Структура1.Вставить("ИмяКлассаАнгл", ИмяКлассаАнгл);
		ИмяКлассаРус = ИОС.СтрНайтиМежду(СтрЗаголовка, ">", " (", , )[0];
		Структура1.Вставить("ИмяКлассаРус", ИмяКлассаРус);
		Структура1.Вставить("ПолныйПуть", ПолныйПуть);
	КонецЕсли;
	Возврат Структура1;
КонецФункции

Функция ДирективыПеречисления(ДанныеОбъекта)
	Возврат 
	"using OneScript.Contexts;
	|using OneScript.Execution;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Collections;
	|using System.Reflection;
	|
	|";
КонецФункции//ДирективыПеречисления

Функция ШапкаПеречисления(ИмяКлассаАнгл, ИмяКлассаРус)
	Возврат 
	"    [ContextClass(""Иф" + ИмяКлассаРус + """, ""Gf" + ИмяКлассаАнгл + """)]
	|    public class Gf" + ИмяКлассаАнгл + " : AutoContext<Gf" + ИмяКлассаАнгл + ">, ICollectionContext<IValue>, IEnumerable<IValue>
	|    {
	|";
КонецФункции//ШапкаПеречисления

Функция КонструкторПеречисления(ДанныеОбъекта)
	ИмяКлассаАнгл = ДанныеОбъекта.ИмяКлассаАнгл;
	ПолныйПуть = ДанныеОбъекта.ПолныйПуть;
	Фрагмент1 = "        public Gf" + ИмяКлассаАнгл + "()
	|        {
	|            _list = new List<IValue>()
	|            {";

	// Сформируем Фрагмент2 взяв данные из справки.
	Список = Новый СписокЗначений();
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ДанныеОбъекта.ПолныйПуть);
	СтрДок = ТекстДок.ПолучитьТекст();
	М = ИОС.СтрНайтиМежду(СтрДок, "<tr vAlign=top>", "</tr>", , );
	Если М.Количество() > 1 Тогда
		Для А = 1 По М.ВГраница() Цикл
			РусИмя = ИОС.СтрНайтиМежду(М[А], "<td><b>", " (", , )[0];
			АнглИмя = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[0];
			Значение = ИОС.СтрНайтиМежду(М[А], "<td>", "</td>", , )[2];
			Список.Добавить(Значение, РусИмя); 
		КонецЦикла;
	КонецЕсли;
	Список.СортироватьПоЗначению();
	Фрагмент2 = "";
	Для А = 0 По Список.Количество() - 1 Цикл
		Фрагмент2 = Фрагмент2 + 
		"
		|                ValueFactory.Create(""" + Список.Получить(А).Представление + """),";
	КонецЦикла;
	Фрагмент2 = Лев(Фрагмент2, СтрДлина(Фрагмент2) - 1);
	Фрагмент3 = 
	"
	|            };
	|        }
	|
	|        public PropertyInfo this[int p1]
	|        {
	|            get { return this.GetType().GetProperties()[p1]; }
	|        }
	|
	|        public PropertyInfo this[string p1]
	|        {
	|            get { return this.GetType().GetProperty(p1); }
	|        }
	|
	|        [ContextMethod(""Значение"", ""Value"")]
	|        public int ValueMethod(string p1)
	|        {
	|            return OsUtils.ToInt32(this.GetType().GetProperty(p1).GetValue(this));
	|        }
	|";
	Возврат Фрагмент1 + Фрагмент2 + Фрагмент3;
КонецФункции//КонструкторПеречисления

Функция СвойствоПеречисленияИмя(ДанныеОбъекта)
	Стр = "";
	Фрагмент1 = 
	"                return getNameRu(this);";
	// Сформируем Фрагмент2 взяв данные из справки.
	Фрагмент2 = "";
	Список = Новый СписокЗначений();
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ДанныеОбъекта.ПолныйПуть);
	СтрДок = ТекстДок.ПолучитьТекст();
	М = ИОС.СтрНайтиМежду(СтрДок, "<tr vAlign=top>", "</tr>", , );
	Если М.Количество() > 1 Тогда
		Для А = 1 По М.ВГраница() Цикл
			РусИмя = ИОС.СтрНайтиМежду(М[А], "<td><b>", " (", , )[0];
			АнглИмя = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[0];
			Значение = ИОС.СтрНайтиМежду(М[А], "<td>", "</td>", , )[2];
			Список.Добавить(Значение, РусИмя); 
		КонецЦикла;
	КонецЕсли;
	Список.СортироватьПоЗначению();
	Если ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeLabel" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeWindow" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeAcceptDialog" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeButton" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeConfirmationDialog" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeHBoxContainer" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemePanelContainer" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeVBoxContainer" 
		Тогда
		Для А = 0 По Список.Количество() - 1 Цикл
			Фрагмент2 = Фрагмент2 + 
			"
			|                """ + Список.Получить(А).Значение + """ => """ + Список.Получить(А).Представление + """,";
		КонецЦикла;
	Иначе
		Для А = 0 По Список.Количество() - 1 Цикл
			Фрагмент2 = Фрагмент2 + 
			"
			|                " + Список.Получить(А).Значение + " => """ + Список.Получить(А).Представление + """,";
		КонецЦикла;
	КонецЕсли;
	
	Если ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeLabel" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeWindow" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeAcceptDialog" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeButton" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeConfirmationDialog" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeHBoxContainer" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemePanelContainer" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeVBoxContainer" 
		Тогда
		Стр = Стр + "
		|        [ContextMethod(""Имя"", ""Имя"")]
		|        public string NameRu(string p1)
		|        {
		|            return getNameRu(p1);
		|        }
		|";
		Стр = Стр + 
		"
		|        public string getNameRu(string p1)
		|        {
		|            string result = (string)p1 switch
		|            {" + Фрагмент2 + "
		|                _ => """" // аналог default
		|            };
		|            return result;
		|        }
		|";
	Иначе
		Стр = Стр + "
		|        [ContextMethod(""Имя"", ""Имя"")]
		|        public string NameRu(int p1)
		|        {
		|            return getNameRu(p1);
		|        }
		|";
		Стр = Стр + 
		"
		|        public string getNameRu(int p1)
		|        {
		|            string result = (int)p1 switch
		|            {" + Фрагмент2 + "
		|                _ => """" // аналог default
		|            };
		|            return result;
		|        }
		|";
	КонецЕсли;
	Возврат Стр;
КонецФункции//СвойствоПеречисленияИмя

Функция СвойствоПеречисленияName(ДанныеОбъекта)
	Стр = "";
	Фрагмент1 = 
	"                return getNameEn(this);";
	// Сформируем Фрагмент2 взяв данные из справки.
	Фрагмент2 = "";
	Список = Новый СписокЗначений();
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ДанныеОбъекта.ПолныйПуть);
	СтрДок = ТекстДок.ПолучитьТекст();
	М = ИОС.СтрНайтиМежду(СтрДок, "<tr vAlign=top>", "</tr>", , );
	Если М.Количество() > 1 Тогда
		Для А = 1 По М.ВГраница() Цикл
			РусИмя = ИОС.СтрНайтиМежду(М[А], "<td><b>", " (", , )[0];
			АнглИмя = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[0];
			Значение = ИОС.СтрНайтиМежду(М[А], "<td>", "</td>", , )[2];
			Список.Добавить(Значение, АнглИмя); 
		КонецЦикла;
	КонецЕсли;
	Список.СортироватьПоЗначению();
	Если ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeLabel" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeWindow" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeAcceptDialog" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeButton" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeConfirmationDialog" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeHBoxContainer" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemePanelContainer" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeVBoxContainer" 
		Тогда
		Для А = 0 По Список.Количество() - 1 Цикл
			Фрагмент2 = Фрагмент2 + 
			"
			|                """ + Список.Получить(А).Значение + """ => """ + Список.Получить(А).Представление + """,";
		КонецЦикла;
	Иначе
		Для А = 0 По Список.Количество() - 1 Цикл
			Фрагмент2 = Фрагмент2 + 
			"
			|                " + Список.Получить(А).Значение + " => """ + Список.Получить(А).Представление + """,";
		КонецЦикла;
	КонецЕсли;
	
	Если ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeLabel" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeWindow" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeAcceptDialog" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeButton" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeConfirmationDialog" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeHBoxContainer" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemePanelContainer" 
		или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeVBoxContainer" 
		Тогда
		Стр = Стр + "
		|        [ContextMethod(""Name"", ""Name"")]
		|        public string NameEn(string p1)
		|        {
		|            return getNameEn(p1);
		|        }
		|";
		Стр = Стр + 
		"
		|        public string getNameEn(string p1)
		|        {
		|            string result = (string)p1 switch
		|            {" + Фрагмент2 + "
		|                _ => """" // аналог default
		|            };
		|            return result;
		|        }
		|";
	Иначе
		Стр = Стр + "
		|        [ContextMethod(""Name"", ""Name"")]
		|        public string NameEn(int p1)
		|        {
		|            return getNameEn(p1);
		|        }
		|";
		Стр = Стр + 
		"
		|        public string getNameEn(int p1)
		|        {
		|            string result = (int)p1 switch
		|            {" + Фрагмент2 + "
		|                _ => """" // аналог default
		|            };
		|            return result;
		|        }
		|";
	КонецЕсли;
	Возврат Стр;
КонецФункции//СвойствоПеречисленияName

Функция СвойстваПеречисления(ДанныеОбъекта)
	Стр = "";
	// Сформируем Фрагмент1 взяв данные из справки.
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ДанныеОбъекта.ПолныйПуть);
	СтрДок = ТекстДок.ПолучитьТекст();
	М = ИОС.СтрНайтиМежду(СтрДок, "<tr vAlign=top>", "</tr>", , );
	Если М.Количество() > 1 Тогда
		Для А = 1 По М.ВГраница() Цикл
			РусИмя = ИОС.СтрНайтиМежду(М[А], "<td><b>", " (", , )[0];
			АнглИмя = ИОС.СтрНайтиМежду(М[А], "(", ")", , )[0];
			Значение = ИОС.СтрНайтиМежду(М[А], "<td>", "</td>", , )[2];
			
			Если ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeLabel" 
				или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeWindow" 
				или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeAcceptDialog" 
				или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeButton" 
				или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeConfirmationDialog" 
				или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeHBoxContainer" 
				или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemePanelContainer" 
				или ДанныеОбъекта.ИмяКлассаАнгл = "NamePropertyThemeVBoxContainer" 
				Тогда
				Стр = Стр + 
				"
				|        [ContextProperty(""" + РусИмя + """, """ + АнглИмя + """)]
				|        public string " + АнглИмя + "
				|        {
				|            get { return """ + Значение + """; }
				|        }
				|";
			Иначе
				Стр = Стр + 
				"
				|        [ContextProperty(""" + РусИмя + """, """ + АнглИмя + """)]
				|        public int " + АнглИмя + "
				|        {
				|            get { return " + Значение + "; }
				|        }
				|";
			КонецЕсли;
		КонецЦикла;
	КонецЕсли;
	Возврат Стр;
КонецФункции//СвойстваПеречисления

Функция РазобратьСтроку(Строка, Разделитель)
	Стр = СтрЗаменить(Строка, Разделитель, Символы.ПС);
	М = Новый Массив;
	Если ПустаяСтрока(Стр) Тогда
		Возврат М;
	КонецЕсли;
	Для Ч = 1 По СтрЧислоСтрок(Стр) Цикл
		М.Добавить(СтрПолучитьСтроку(Стр, Ч));
	КонецЦикла;
	Возврат М;
КонецФункции

//===============================================================================================================================================
Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();

БазовыеКлассы = Новый СписокЗначений(); // У этих классов есть только первый уровень.
БазовыеКлассы.Добавить("Control");
БазовыеКлассы.Добавить("BaseButton");
БазовыеКлассы.Добавить("Node");
БазовыеКлассы.Добавить("Viewport");
БазовыеКлассы.Добавить("CanvasItem");
БазовыеКлассы.Добавить("Container");
БазовыеКлассы.Добавить("BoxContainer");
БазовыеКлассы.Добавить("SubViewport");
БазовыеКлассы.Добавить("GObject");
БазовыеКлассы.Добавить("Font");
БазовыеКлассы.Добавить("RefCounted");
БазовыеКлассы.Добавить("Resource");
БазовыеКлассы.Добавить("Texture");
БазовыеКлассы.Добавить("Texture2D");
БазовыеКлассы.Добавить("StyleBox");
БазовыеКлассы.Добавить("Theme");
БазовыеКлассы.Добавить("VisualInstance3D");
БазовыеКлассы.Добавить("Light3D");
БазовыеКлассы.Добавить("Node3D");

ДвухУровневыеКлассы = Новый СписокЗначений(); // У этих классов есть и первый и второй уровень.
ДвухУровневыеКлассы.Добавить("Button");
ДвухУровневыеКлассы.Добавить("Window");
ДвухУровневыеКлассы.Добавить("VBoxContainer");
ДвухУровневыеКлассы.Добавить("HBoxContainer");
ДвухУровневыеКлассы.Добавить("Sprite2D");
ДвухУровневыеКлассы.Добавить("FontFile");
ДвухУровневыеКлассы.Добавить("FontVariation");
ДвухУровневыеКлассы.Добавить("ImageTexture");
ДвухУровневыеКлассы.Добавить("Image");
ДвухУровневыеКлассы.Добавить("Timer");
ДвухУровневыеКлассы.Добавить("AcceptDialog");
ДвухУровневыеКлассы.Добавить("Label");
ДвухУровневыеКлассы.Добавить("PanelContainer");
ДвухУровневыеКлассы.Добавить("StyleBoxLine");
ДвухУровневыеКлассы.Добавить("StyleBoxFlat");
ДвухУровневыеКлассы.Добавить("StyleBoxEmpty");
ДвухУровневыеКлассы.Добавить("StyleBoxTexture");
ДвухУровневыеКлассы.Добавить("ThemeAcceptDialog");
ДвухУровневыеКлассы.Добавить("ThemeButton");
ДвухУровневыеКлассы.Добавить("ThemeScene");
ДвухУровневыеКлассы.Добавить("ThemeLabel");
ДвухУровневыеКлассы.Добавить("ThemePanelContainer");
ДвухУровневыеКлассы.Добавить("ThemeWindow");
ДвухУровневыеКлассы.Добавить("ThemeVBoxContainer");
ДвухУровневыеКлассы.Добавить("ThemeHBoxContainer");
ДвухУровневыеКлассы.Добавить("ThemeConfirmationDialog");
ДвухУровневыеКлассы.Добавить("WorldEnvironment");
ДвухУровневыеКлассы.Добавить("AnimatedSprite2D");
ДвухУровневыеКлассы.Добавить("Material");
ДвухУровневыеКлассы.Добавить("Environment");
ДвухУровневыеКлассы.Добавить("WorldEnvironment");
ДвухУровневыеКлассы.Добавить("Camera3D");
ДвухУровневыеКлассы.Добавить("DirectionalLight3D");
ДвухУровневыеКлассы.Добавить("SpriteFrames");



ОдноУровневыеКлассы = Новый СписокЗначений(); // У этих классов есть только второй уровень.
ОдноУровневыеКлассы.Добавить("Vector2");
ОдноУровневыеКлассы.Добавить("Vector2i");
ОдноУровневыеКлассы.Добавить("Rect2");
ОдноУровневыеКлассы.Добавить("Rect2i");
ОдноУровневыеКлассы.Добавить("Action");
ОдноУровневыеКлассы.Добавить("Color");
ОдноУровневыеКлассы.Добавить("Entry");
ОдноУровневыеКлассы.Добавить("Vector3");
ОдноУровневыеКлассы.Добавить("Vector3i");
ОдноУровневыеКлассы.Добавить("Transform3D");


КодДиректив = Новый Структура();
Стр1 = 
	"using OneScript.Contexts;
	|using ScriptEngine.Machine.Contexts;
	|using System.Reflection;
	|using System.Text.Json;";
Стр2 = 
	"using OneScript.Contexts;
	|using ScriptEngine.Machine.Contexts;
	|using System.Reflection;";
Стр3 = 
	"using OneScript.Contexts;
	|using ScriptEngine.Machine.Contexts;
	|using System.Text.Json;";
Стр4 = 
	"using OneScript.Contexts;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Text.Json;";
Стр5 = 
	"using OneScript.Contexts;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;";
Стр6 = 
	"using OneScript.Contexts;
	|using ScriptEngine.Machine.Contexts;";
Стр7 = 
	"using OneScript.Contexts;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Reflection;";
Стр8 = 
	"using OneScript.Contexts;
	|using OneScript.StandardLibrary.Collections;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Collections;";
Стр9 = 
	"using OneScript.Contexts;
	|using OneScript.StandardLibrary.Collections;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Text.Json;";
Стр10 = 
	"using OneScript.Contexts;
	|using OneScript.StandardLibrary.Binary;
	|using ScriptEngine.Machine.Contexts;";
Стр11 = 
	"using OneScript.Contexts;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Reflection;
	|using System.Text.Json;";
Стр12 = 
	"using OneScript.Contexts;
	|using OneScript.StandardLibrary.Collections;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Reflection;";
Стр13 = 
	"using OneScript.Contexts;
	|using OneScript.StandardLibrary.Collections;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Reflection;
	|using System.Text.Json;";
Стр14 = 
	"using OneScript.StandardLibrary.Collections;
	|using ScriptEngine.Machine;
	|using System.Reflection;
	|using System.Text.Json;";
Стр15 = 
	"using OneScript.Contexts;
	|using OneScript.StandardLibrary.Collections;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;";
Стр16 = 
	"using OneScript.Contexts;
	|using OneScript.Execution;
	|using OneScript.StandardLibrary.Collections;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Collections;";
Стр17 = 
	"using OneScript.Contexts;
	|using OneScript.StandardLibrary.Binary;
	|using ScriptEngine.Machine;
	|using ScriptEngine.Machine.Contexts;
	|using System.Reflection;
	|using System.Text.Json;";

КодДиректив.Вставить("SpriteFrames", Стр5);
КодДиректив.Вставить("DirectionalLight3D", Стр15);
КодДиректив.Вставить("Camera3D", Стр12);
КодДиректив.Вставить("Transform3D", Стр6);
КодДиректив.Вставить("WorldEnvironment", Стр15);
КодДиректив.Вставить("Environment", Стр5);
КодДиректив.Вставить("AcceptDialog", Стр13);
КодДиректив.Вставить("Action", Стр5);
КодДиректив.Вставить("AnimatedSprite2D", Стр15);
КодДиректив.Вставить("Balloon", Стр4);
КодДиректив.Вставить("Button", Стр12);
КодДиректив.Вставить("Color", Стр6);
КодДиректив.Вставить("ConfirmationDialog", Стр12);
КодДиректив.Вставить("Dictionary", Стр16);
КодДиректив.Вставить("Encoding", Стр10);
КодДиректив.Вставить("Entry", Стр5);
КодДиректив.Вставить("EventArgs", Стр5);
КодДиректив.Вставить("FontFile", Стр4);
КодДиректив.Вставить("FontVariation", Стр4);
КодДиректив.Вставить("Graphics", Стр12);
КодДиректив.Вставить("HBoxContainer", Стр12);
КодДиректив.Вставить("Image", Стр17);
КодДиректив.Вставить("ImageTexture", Стр4);
КодДиректив.Вставить("Label", Стр12);
КодДиректив.Вставить("Material", Стр6);
КодДиректив.Вставить("Node2D", Стр13);
КодДиректив.Вставить("PanelContainer", Стр12);
КодДиректив.Вставить("Rect2", Стр6);
КодДиректив.Вставить("Rect2i", Стр6);
КодДиректив.Вставить("Sprite2D", Стр12);
КодДиректив.Вставить("String", Стр5);
КодДиректив.Вставить("StyleBoxEmpty", Стр5);
КодДиректив.Вставить("StyleBoxFlat", Стр11);
КодДиректив.Вставить("StyleBoxLine", Стр7);
КодДиректив.Вставить("StyleBoxTexture", Стр11);
КодДиректив.Вставить("Timer", Стр13);
КодДиректив.Вставить("VBoxContainer", Стр12);
КодДиректив.Вставить("Vector2", Стр6);
КодДиректив.Вставить("Vector2i", Стр6);
КодДиректив.Вставить("Window", Стр12);
КодДиректив.Вставить("Theme", Стр7);
КодДиректив.Вставить("ThemeButton", Стр7);
КодДиректив.Вставить("ThemeScene", Стр11);
КодДиректив.Вставить("ThemeLabel", Стр7);
КодДиректив.Вставить("ThemeWindow", Стр7);
КодДиректив.Вставить("ThemePanelContainer", Стр7);
КодДиректив.Вставить("ThemeAcceptDialog", Стр7);
КодДиректив.Вставить("ThemeVBoxContainer", Стр7);
КодДиректив.Вставить("ThemeHBoxContainer", Стр7);
КодДиректив.Вставить("ThemeConfirmationDialog", Стр7);
КодДиректив.Вставить("Vector3", Стр6);
КодДиректив.Вставить("Vector3i", Стр6);


КодШапки = Новый Структура();



КодРазделОбъявленияПеременных = Новый Структура();
КодРазделОбъявленияПеременных.Вставить("EventArgs", 
	"        public IValue parameter;
	|        public IValue sender = null;
	|        public GfAction eventAction;
	|        public GfVector2 position = null;
	|        public bool pressed;
	|        public IValue modifiersMask = null;
	|        public IValue keycode = null;
	|        public IValue mouseButton = null;
	|        public IValue mouseButtonMask = null;
	|        public bool toggledOn;");
КодРазделОбъявленияПеременных.Вставить("Encoding", 
	"        public System.Text.Encoding Base_obj = System.Text.Encoding.Default;");
КодРазделОбъявленияПеременных.Вставить("String", 
	"        private string Base_obj;");
КодРазделОбъявленияПеременных.Вставить("Dictionary", 
	"        public System.Collections.IEnumerator Enumerator;
	|        public osgf.Dictionary Base_obj;");
	
	
	
	
КодКонструктор = Новый Структура();
КодКонструктор.Вставить("Material", 
	"        public GfMaterial()
	|        {
	|        }");
КодКонструктор.Вставить("Transform3D", 
	"        public GfTransform3D()
	|        {
	|        }");
КодКонструктор.Вставить("Vector3", 
	"        public GfVector3()
	|        {
	|        }
	|
	|        public GfVector3(decimal _x, decimal _y, decimal _z)
	|        {
	|            X = _x;
	|            Y = _y;
	|            Z = _z;
	|        }");
КодКонструктор.Вставить("Vector3i", 
	"        public GfVector3i()
	|        {
	|        }
	|
	|        public GfVector3i(int _x, int _y, int _z)
	|        {
	|            X = _x;
	|            Y = _y;
	|            Z = _z;
	|        }");
КодКонструктор.Вставить("Dictionary", 
	"        public GfDictionary()
	|        {
	|            Dictionary Dictionary1 = new Dictionary();
	|            Dictionary1.dll_obj = this;
	|            Base_obj = Dictionary1;
	|        }
	|
	|        public int Count(IBslProcess p1 = null)
	|        {
	|            return Base_obj.M_Dictionary.Count;
	|        }
	|
	|        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
	|        {
	|            foreach (KeyValuePair<object, object> item in Base_obj.M_Dictionary)
	|            {
	|                IValue keyIV = (IValue)item.Key;
	|                IValue valueIV = (IValue)item.Value;
	|                GfEntry entry = new GfEntry(keyIV, valueIV);
	|                yield return entry;
	|            }
	|        }
	|
	|        public CollectionEnumerator GetManagedIterator()
	|        {
	|            return new CollectionEnumerator(this);
	|        }
	|
	|        public IEnumerator GetEnumerator()
	|        {
	|            Enumerator = Base_obj.M_Dictionary.GetEnumerator();
	|            return (System.Collections.IEnumerator)this;
	|        }");
КодКонструктор.Вставить("StyleBoxEmpty", 
	"        public GfStyleBoxEmpty()
	|        {
	|            StyleBoxEmpty StyleBoxEmpty1 = new StyleBoxEmpty();
	|            StyleBoxEmpty1.dll_obj = this;
	|            Base_obj = StyleBoxEmpty1;
	|        }
	|
	|        public GfStyleBoxEmpty(string p1)
	|        {
	|            StyleBoxEmpty StyleBoxEmpty1 = new StyleBoxEmpty(p1);
	|            StyleBoxEmpty1.dll_obj = this;
	|            Base_obj = StyleBoxEmpty1;
	|        }");
КодКонструктор.Вставить("ThemeScene", 
	"        public GfThemeScene()
	|        {
	|            ThemeScene ThemeScene1 = new ThemeScene();
	|            ThemeScene1.dll_obj = this;
	|            Base_obj = ThemeScene1;
	|        }
	|
	|        public GfThemeScene(string p1 = null)
	|        {
	|            ThemeScene ThemeScene1 = new ThemeScene(p1);
	|            ThemeScene1.dll_obj = this;
	|            Base_obj = ThemeScene1;
	|        }");
КодКонструктор.Вставить("String", 
	"        public GfString()
	|        {
	|            Base_obj = """";
	|        }
	|
	|        public GfString(string p1)
	|        {
	|            Base_obj = p1;
	|        }
	|
	|        public GfString(IValue p1)
	|        {
	|            Base_obj = p1.ToString();
	|        }
	|
	|        public static implicit operator string(GfString str)
	|        {
	|            return str.Base_obj;
	|        }
	|
	|        public static implicit operator GfString(string str)
	|        {
	|            return new GfString(str);
	|        }
	|
	|        public override string ToString()
	|        {
	|            return Base_obj;
	|        }");
КодКонструктор.Вставить("StyleBoxLine", 
	"        public GfStyleBoxLine()
	|        {
	|            StyleBoxLine StyleBoxLine1 = new StyleBoxLine();
	|            StyleBoxLine1.dll_obj = this;
	|            Base_obj = StyleBoxLine1;
	|        }
	|
	|        public GfStyleBoxLine(string p1 = null)
	|        {
	|            StyleBoxLine StyleBoxLine1 = new StyleBoxLine(p1);
	|            StyleBoxLine1.dll_obj = this;
	|            Base_obj = StyleBoxLine1;
	|        }");
КодКонструктор.Вставить("StyleBoxFlat", 
	"        public GfStyleBoxFlat()
	|        {
	|            StyleBoxFlat StyleBoxFlat1 = new StyleBoxFlat();
	|            StyleBoxFlat1.dll_obj = this;
	|            Base_obj = StyleBoxFlat1;
	|        }
	|
	|        public GfStyleBoxFlat(string p1 = null)
	|        {
	|            StyleBoxFlat StyleBoxFlat1 = new StyleBoxFlat(p1);
	|            StyleBoxFlat1.dll_obj = this;
	|            Base_obj = StyleBoxFlat1;
	|        }
	|
	|        public GfStyleBoxFlat(string itemKey, bool plug)
	|        {
	|            StyleBoxFlat StyleBoxFlat1 = new StyleBoxFlat(itemKey, true);
	|            StyleBoxFlat1.dll_obj = this;
	|            Base_obj = StyleBoxFlat1;
	|        }");
КодКонструктор.Вставить("StyleBoxTexture", 
	"        public GfStyleBoxTexture()
	|        {
	|            StyleBoxTexture StyleBoxTexture1 = new StyleBoxTexture();
	|            StyleBoxTexture1.dll_obj = this;
	|            Base_obj = StyleBoxTexture1;
	|        }
	|
	|        public GfStyleBoxTexture(string p1 = null)
	|        {
	|            StyleBoxTexture StyleBoxTexture1 = new StyleBoxTexture(p1);
	|            StyleBoxTexture1.dll_obj = this;
	|            Base_obj = StyleBoxTexture1;
	|        }");
КодКонструктор.Вставить("Image", 
	"        public GfImage()
	|        {
	|            Image Image1 = new Image();
	|            Image1.dll_obj = this;
	|            Base_obj = Image1;
	|        }
	|
	|        public GfImage(string path)
	|        {
	|            Image Image1 = new Image(path);
	|            Image1.dll_obj = this;
	|            Base_obj = Image1;
	|        }");
КодКонструктор.Вставить("Label", 
	"        public GfLabel()
	|        {
	|            Label Label1 = new Label();
	|            Label1.dll_obj = this;
	|            Base_obj = Label1;
	|        }
	|
	|        public GfLabel(string p1 = null)
	|        {
	|            Label Label1 = new Label(p1);
	|            Label1.dll_obj = this;
	|            Base_obj = Label1;
	|        }");
КодКонструктор.Вставить("ImageTexture", 
	"        public GfImageTexture()
	|        {
	|            ImageTexture imgTex = new ImageTexture();
	|            imgTex.dll_obj = this;
	|            Base_obj = imgTex;
	|        }
	|
	|        public GfImageTexture(string path)
	|        {
	|            ImageTexture imgTex = new ImageTexture(path);
	|            imgTex.dll_obj = this;
	|            Base_obj = imgTex;
	|        }
	|
	|        public GfImageTexture(string itemKey, string resourcePath)
	|        {
	|            ImageTexture ImageTexture1 = new ImageTexture(itemKey, resourcePath);
	|            ImageTexture1.dll_obj = this;
	|            Base_obj = ImageTexture1;
	|        }");
КодКонструктор.Вставить("Entry", 
	"        public GfEntry()
	|        {
	|            Key = null;
	|            ValueProp = null;
	|        }
	|
	|        public GfEntry(IValue p1, IValue p2)
	|        {
	|            Key = p1;
	|            ValueProp = p2;
	|        }");
КодКонструктор.Вставить("EventArgs", 
	"        public GfEventArgs()
	|        {
	|        }
	|
	|        public GfEventArgs(GfEventArgs p1)
	|        {
	|            parameter = p1.Parameter;
	|        }
	|
	|        public GfAction EventAction
	|        {
	|            get { return eventAction; }
	|        }");
КодКонструктор.Вставить("FontFile", 
	"        public GfFontFile()
	|        {
	|            FontFile FontFile1 = new FontFile();
	|            FontFile1.dll_obj = this;
	|            Base_obj = FontFile1;
	|        }
	|
	|        public GfFontFile(string path)
	|        {
	|            FontFile FontFile1 = new FontFile(path);
	|            FontFile1.dll_obj = this;
	|            Base_obj = FontFile1;
	|        }");
КодКонструктор.Вставить("FontVariation", 
	"        public GfFontVariation()
	|        {
	|            FontVariation FontVariation1 = new FontVariation();
	|            FontVariation1.dll_obj = this;
	|            Base_obj = FontVariation1;
	|        }
	|
	|        public GfFontVariation(string path)
	|        {
	|            FontVariation FontVariation1 = new FontVariation(path);
	|            FontVariation1.dll_obj = this;
	|            Base_obj = FontVariation1;
	|        }
	|
	|        public GfFontVariation(string itemKey, string resourcePath)
	|        {
	|            FontVariation FontVariation1 = new FontVariation(itemKey, resourcePath);
	|            FontVariation1.dll_obj = this;
	|            Base_obj = FontVariation1;
	|        }");
КодКонструктор.Вставить("Color", 
	"        public GfColor()
	|        {
	|        }
	|
	|        public GfColor MakeColor(int p1, int p2, int p3, int p4)
	|        {
	|            GfColor color = new GfColor();
	|            color.R = p1;
	|            color.G = p2;
	|            color.B = p3;
	|            color.A = p4;
	|            return color;
	|        }");
КодКонструктор.Вставить("Action", 
	"        public GfAction()
	|        {
	|        }
	|
	|        public GfAction(IRuntimeContextInstance script, string methodName, IValue param = null)
	|        {
	|            Script = script;
	|            MethodName = methodName;
	|            Parameter = param;
	|        }");
КодКонструктор.Вставить("Encoding", 
	"        public GfEncoding()
	|        {
	|        }
	|
	|        public GfEncoding(System.Text.Encoding p1)
	|        {
	|            Base_obj = p1;
	|        }");
КодКонструктор.Вставить("Vector2", 
	"        public GfVector2()
	|        {
	|        }
	|
	|        public GfVector2(decimal _x, decimal _y)
	|        {
	|            X = _x;
	|            Y = _y;
	|        }");
КодКонструктор.Вставить("Vector2i", 
	"        public GfVector2i()
	|        {
	|        }
	|
	|        public GfVector2i(int _x, int _y)
	|        {
	|            X = _x;
	|            Y = _y;
	|        }");
КодКонструктор.Вставить("Rect2", 
	"        public GfRect2()
	|        {
	|        }");
КодКонструктор.Вставить("Rect2i", 
	"        public GfRect2i()
	|        {
	|        }");
КодКонструктор.Вставить("Window", 
	"        public GfWindow()
	|        {
	|            Window Window1 = new Window();
	|            Window1.dll_obj = this;
	|            Base_obj = Window1;
	|        }
	|
	|        public GfWindow(string p1 = null)
	|        {
	|            Window Window1 = new Window(p1);
	|            Window1.dll_obj = this;
	|            Base_obj = Window1;
	|        }");
КодКонструктор.Вставить("Button", 
	"        public GfButton()
	|        {
	|            Button Button1 = new Button();
	|            Button1.dll_obj = this;
	|            Base_obj = Button1;
	|        }
	|
	|        public GfButton(string p1)
	|        {
	|            Button Button1 = new Button(p1);
	|            Button1.dll_obj = this;
	|            Base_obj = Button1;
	|        }");
	
	
	
	
	

КодСвойств = Новый Структура();
КодСвойств.Вставить("Количество_Dictionary", 
	"        public int CountProp
	|        {
	|            get { return Base_obj.Count; }
	|        }");
КодСвойств.Вставить("Тема_Window", 
	"        public IValue Theme
	|        {
	|            get { return Base_obj.Theme; }
	|            set { Base_obj.Theme = value; }
	|        }");
КодСвойств.Вставить("Включено_EventArgs", 
	"        public bool ToggledOn
	|        {
	|            get { return toggledOn; }
	|        }");
КодСвойств.Вставить("ЭтоНажатие_EventArgs", 
	"        public bool Pressed
	|        {
	|            get { return pressed; }
	|        }");
КодСвойств.Вставить("КодКлавиши_EventArgs", 
	"        public IValue Keycode
	|        {
	|            get { return keycode; }
	|        }");
КодСвойств.Вставить("Модификаторы_EventArgs", 
	"        public IValue ModifiersMask
	|        {
	|            get { return modifiersMask; }
	|        }");
КодСвойств.Вставить("КнопкаМыши_EventArgs", 
	"        public IValue MouseButton
	|        {
	|            get { return mouseButton; }
	|        }");
КодСвойств.Вставить("МаскаКнопокМыши_EventArgs", 
	"        public IValue MouseButtonMask
	|        {
	|            get { return mouseButtonMask; }
	|        }");
КодСвойств.Вставить("Значение_Entry", 
	"        public IValue ValueProp { get; set; }");
КодСвойств.Вставить("Ключ_Entry", 
	"        public IValue Key { get; set; }");
КодСвойств.Вставить("ASCII_Encoding", 
	"        public GfEncoding ASCII
	|        {
	|            get { return new GfEncoding(System.Text.Encoding.ASCII); }
	|        }");
КодСвойств.Вставить("UTF8_Encoding", 
	"        public GfEncoding UTF8
	|        {
	|            get { return new GfEncoding(System.Text.Encoding.UTF8); }
	|        }");
КодСвойств.Вставить("ОбратнаяUTF16_Encoding", 
	"        public GfEncoding BigEndianUnicode
	|        {
	|            get { return new GfEncoding(System.Text.Encoding.BigEndianUnicode); }
	|        }");
КодСвойств.Вставить("ПоУмолчанию_Encoding", 
	"        public GfEncoding Default
	|        {
	|            get { return new GfEncoding(System.Text.Encoding.Default); }
	|        }");
КодСвойств.Вставить("Юникод_Encoding", 
	"        public GfEncoding Unicode
	|        {
	|            get { return new GfEncoding(System.Text.Encoding.Unicode); }
	|        }");
КодСвойств.Вставить("ИмяМетода_Action", 
	"        public string MethodName { get; set; }");
КодСвойств.Вставить("Параметр_Action", 
	"        public IValue Parameter { get; set; }");
КодСвойств.Вставить("Сценарий_Action", 
	"        public IRuntimeContextInstance Script { get; set; }");
КодСвойств.Вставить("Отправитель_EventArgs", 
	"        public IValue Sender
	|        {
	|            get { return sender; }
	|        }");
КодСвойств.Вставить("Параметр_EventArgs", 
	"        public IValue Parameter
	|        {
	|            get { return parameter; }
	|        }");
КодСвойств.Вставить("Позиция_EventArgs", 
	"        public GfVector2 Position
	|        {
	|            get { return position; }
	|        }");
КодСвойств.Вставить("Икс_Vector2", 
	"        public decimal X { get; set; } = 0;");
КодСвойств.Вставить("Игрек_Vector2", 
	"        public decimal Y { get; set; } = 0;");
КодСвойств.Вставить("Икс_Vector2i", 
	"        public int X { get; set; } = 0;");
КодСвойств.Вставить("Игрек_Vector2i", 
	"        public int Y { get; set; } = 0;");
КодСвойств.Вставить("Конец_Rect2", 
	"        public GfVector2 End
	|        {
	|            get
	|            {
	|                GfVector2 vector2 = new GfVector2();
	|                vector2.X = Position.X + Size.X;
	|                vector2.Y = Position.Y + Size.Y;
	|                return vector2;
	|            }
	|            set
	|            {
	|                decimal newX = value.X;
	|                decimal newY = value.Y;
	|                decimal oldX = Position.X;
	|                decimal oldY = Position.Y;
	|                decimal deltaX = newX - oldX;
	|                decimal deltaY = newY - oldY;
	|                Size.X = Position.X + deltaX;
	|                Size.Y = Position.Y + deltaY;
	|            }
	|        }");
КодСвойств.Вставить("Позиция_Rect2", 
	"        public GfVector2 Position { get; set; } = new GfVector2();");
КодСвойств.Вставить("Размер_Rect2", 
	"        public GfVector2 Size { get; set; } = new GfVector2();");
КодСвойств.Вставить("Конец_Rect2i", 
	"        public GfVector2i End
	|        {
	|            get
	|            {
	|                GfVector2i vector2i = new GfVector2i();
	|                vector2i.X = Position.X + Size.X;
	|                vector2i.Y = Position.Y + Size.Y;
	|                return vector2i;
	|            }
	|            set
	|            {
	|                int newX = value.X;
	|                int newY = value.Y;
	|                int oldX = Position.X;
	|                int oldY = Position.Y;
	|                int deltaX = newX - oldX;
	|                int deltaY = newY - oldY;
	|                Size.X = Position.X + deltaX;
	|                Size.Y = Position.Y + deltaY;
	|            }
	|        }");
КодСвойств.Вставить("Позиция_Rect2i", 
	"        public GfVector2i Position { get; set; } = new GfVector2i();");
КодСвойств.Вставить("Размер_Rect2i", 
	"        public GfVector2i Size { get; set; } = new GfVector2i();");
КодСвойств.Вставить("Текстура_StyleBoxTexture", 
	"        public GfImageTexture Texture
	|        {
	|            get { return Base_obj.Texture; }
	|            set { Base_obj.Texture = value; }
	|        }");
	
	

КодМетодов = Новый Структура();
СтрКодМетодов1 = 
	"        public new string ToString()
	|        {
	|            return ""Base_obj.ToString()"";
	|        }";
КодМетодов.Вставить("Вектор2_Vector2i", 
	"        public GfVector2 Vector2(GfVector2i p1)
	|        {
	|            decimal x = Convert.ToDecimal(p1.X);
	|            decimal y = Convert.ToDecimal(p1.Y);
	|            return new GfVector2(x, y);
	|        }");
КодМетодов.Вставить("Вектор2ц_Vector2", 
	"        public GfVector2i Vector2i(GfVector2 p1)
	|        {
	|            int x = Convert.ToInt32(p1.X);
	|            int y = Convert.ToInt32(p1.Y);
	|            return new GfVector2i(x, y);
	|        }");
КодМетодов.Вставить("УстановитьВылетВсех_StyleBoxTexture", 
	"        public void SetExpandMarginAll(decimal p1)
	|        {
	|            Base_obj.SetExpandMarginAll(p1);
	|        }");
КодМетодов.Вставить("УстановитьВылетТекстурыВсех_StyleBoxTexture", 
	"        public void SetTextureMarginAll(decimal p1)
	|        {
	|            Base_obj.SetTextureMarginAll(p1);
	|        }");
КодМетодов.Вставить("Заменить_String", 
	"        public GfString Replace(string oldValue, string newValue)
	|        {
	|            return new GfString(Base_obj.Replace(oldValue, newValue));
	|        }");
КодМетодов.Вставить("ВСтроку_String", 
	"        public string ToStringMethod()
	|        {
	|            return Base_obj.ToString();
	|        }");
КодМетодов.Вставить("УстановитьВылетВсех_StyleBoxFlat", 
	"        public void SetExpandMarginAll(decimal p1)
	|        {
	|            Base_obj.SetExpandMarginAll(p1);
	|        }");
КодМетодов.Вставить("УстановитьРадиусУглаВсех_StyleBoxFlat", 
	"        public void SetCornerRadiusAll(decimal p1)
	|        {
	|            Base_obj.SetCornerRadiusAll(p1);
	|        }");
КодМетодов.Вставить("УстановитьШиринуГраницыВсех_StyleBoxFlat", 
	"        public void SetBorderWidthAll(decimal p1)
	|        {
	|            Base_obj.SetBorderWidthAll(p1);
	|        }");
КодМетодов.Вставить("Развернуть_AcceptDialog", 
	"        public void Popup(string _text = null, string _title = null, GfRect2i p1 = null, decimal p2 = 0m)
	|        {
	|            GfRect2i rect2i = new GfRect2i();
	|            string text = DialogText;
	|            string title = Title;
	|            if (OsUtils.AllNotNull(p1))
	|            {
	|                rect2i = p1;
	|            }
	|            if (OsUtils.AllNotNull(_text))
	|            {
	|                text = _text;
	|            }
	|            if (OsUtils.AllNotNull(_title))
	|            {
	|                title = _title;
	|            }
	|
	|            Base_obj.Popup(text, title, rect2i, p2);
	|        }");
КодМетодов.Вставить("РазвернутьВЦентре_AcceptDialog", 
	"        public void PopupCentered(string _text = null, string _title = null, GfVector2i p1 = null, decimal p2 = 0m)
	|        {
	|            GfVector2i vector2i = new GfVector2i();
	|            string text = DialogText;
	|            string title = Title;
	|            if (OsUtils.AllNotNull(p1))
	|            {
	|                vector2i = p1;
	|            }
	|            if (OsUtils.AllNotNull(_text))
	|            {
	|                text = _text;
	|            }
	|            if (OsUtils.AllNotNull(_title))
	|            {
	|                title = _title;
	|            }
	|            Base_obj.PopupCentered(text, title, vector2i, p2);
	|        }");
КодМетодов.Вставить("Центр_Window", 
	"        public void Center(int p1 = 0, int p2 = 0)
	|        {
	|            Base_obj.Center(p1, p2);
	|        }");
КодМетодов.Вставить("Центр_AcceptDialog", 
	"        public void Center(int p1 = 0, int p2 = 0)
	|        {
	|            Base_obj.Center(p1, p2);
	|        }");
КодМетодов.Вставить("Центр_ConfirmationDialog", 
	"        public void Center(int p1 = 0, int p2 = 0)
	|        {
	|            Base_obj.Center(p1, p2);
	|        }");
КодМетодов.Вставить("РазвернутьВЦентре_Window", 
	"        public void PopupCentered(GfVector2i p1 = null, decimal p2 = 0m)
	|        {
	|            Base_obj.PopupCentered(p1, p2);
	|        }");
КодМетодов.Вставить("РазвернутьВЦентре_ConfirmationDialog", 
	"        public void PopupCentered(string _text = null, string _title = null, GfVector2i p1 = null, decimal p2 = 0m)
	|        {
	|            GfVector2i vector2i = new GfVector2i();
	|            string text = DialogText;
	|            string title = Title;
	|            if (OsUtils.AllNotNull(p1))
	|            {
	|                vector2i = p1;
	|            }
	|            if (OsUtils.AllNotNull(_text))
	|            {
	|                text = _text;
	|            }
	|            if (OsUtils.AllNotNull(_title))
	|            {
	|                title = _title;
	|            }
	|            Base_obj.PopupCentered(text, title, vector2i, p2);
	|        }");
КодМетодов.Вставить("Развернуть_ConfirmationDialog", 
	"        public void Popup(string _text = null, string _title = null, GfRect2i p1 = null, decimal p2 = 0m)
	|        {
	|            GfRect2i rect2i = new GfRect2i();
	|            string text = DialogText;
	|            string title = Title;
	|            if (OsUtils.AllNotNull(p1))
	|            {
	|                rect2i = p1;
	|            }
	|            if (OsUtils.AllNotNull(_text))
	|            {
	|                text = _text;
	|            }
	|            if (OsUtils.AllNotNull(_title))
	|            {
	|                title = _title;
	|            }
	|
	|            Base_obj.Popup(text, title, rect2i, p2);
	|        }");
КодМетодов.Вставить("ДобавитьКнопку_AcceptDialog", 
	"        public GfButton AddButton(string p1, bool p2)
	|        {
	|            return Base_obj.AddButton(p1, p2);
	|        }");
КодМетодов.Вставить("ДобавитьКнопку_ConfirmationDialog", 
	"        public GfButton AddButton(string p1, bool p2)
	|        {
	|            return Base_obj.AddButton(p1, p2);
	|        }");
КодМетодов.Вставить("УдалитьКнопку_AcceptDialog", 
	"        public void RemoveButton(GfButton p1)
	|        {
	|            Base_obj.RemoveButton(p1);
	|        }");
КодМетодов.Вставить("Развернуть_Window", 
	"        public void Popup(GfRect2i p1, decimal p2 = 0m)
	|        {
	|            Base_obj.Popup(p1, p2);
	|        }");
КодМетодов.Вставить("УдалитьКнопку_ConfirmationDialog", 
	"        public void RemoveButton(GfButton p1)
	|        {
	|            Base_obj.RemoveButton(p1);
	|        }");
КодМетодов.Вставить("Добавить_Dictionary", 
	"        public void Add(IValue p1, IValue p2)
	|        {
	|            Base_obj.Add(OsUtils.DefineTypeIValue(p1), OsUtils.DefineTypeIValue(p2));
	|        }");
КодМетодов.Вставить("Начать_Timer", 
	"        public void Start(int p1 = -1)
	|        {
	|            Base_obj.Start(p1);
	|        }");
КодМетодов.Вставить("Остановлен_Timer", 
	"        public bool IsStopped()
	|        {
	|            return Base_obj.IsStopped();
	|        }");
КодМетодов.Вставить("Получить_Dictionary", 
	"        public IValue Get(IValue p1)
	|        {
	|            return Base_obj.get_Item(OsUtils.DefineTypeIValue(p1));
	|        }");
КодМетодов.Вставить("СодержитЗначение_Dictionary", 
	"        public bool ContainsValue(IValue p1)
	|        {
	|            return Base_obj.ContainsValue(OsUtils.DefineTypeIValue(p1));
	|        }");
КодМетодов.Вставить("СодержитКлюч_Dictionary", 
	"        public bool ContainsKey(IValue p1)
	|        {
	|            return Base_obj.ContainsKey(OsUtils.DefineTypeIValue(p1));
	|        }");
КодМетодов.Вставить("Удалить_Dictionary", 
	"        public void Remove(IValue p1)
	|        {
	|            Base_obj.Remove(OsUtils.DefineTypeIValue(p1));
	|        }");
КодМетодов.Вставить("Установить_Dictionary", 
	"        public void Set(IValue p1, IValue p2)
	|        {
	|            Base_obj.Set(OsUtils.DefineTypeIValue(p1), OsUtils.DefineTypeIValue(p2));
	|        }");
КодМетодов.Вставить("ПолучитьБайты_Encoding", 
	"        public BinaryDataBuffer GetBytes(string p1)
	|        {
	|            byte[] buffer = Base_obj.GetBytes(p1);
	|            BinaryDataBuffer bdb = new BinaryDataBuffer(new byte[0]);
	|            return bdb.Concat((new BinaryDataBuffer(buffer)).Read(0, buffer.Length));
	|        }");
КодМетодов.Вставить("ПолучитьКодировку_Encoding", 
	"        public GfEncoding GetEncoding(int p1)
	|        {
	|            return new GfEncoding(System.Text.Encoding.GetEncoding(p1));
	|        }");
КодМетодов.Вставить("Получить10_Color", 
	"        public uint To10()
	|        {
	|            return ((uint)A << 24) | ((uint)R << 16) | ((uint)G << 8) | (uint)B;
	|        }");
КодМетодов.Вставить("ВСтроку_Color", 
	"        public override string ToString()
	|        {
	|            return $""{{R:{R} G:{G} B:{B} A:{A}}}"";
	|        }");
КодМетодов.Вставить("ПолучитьИз10_Color", 
	"        public GfColor From10(uint p1)
	|        {
	|            byte alpha = (byte)((p1 >> 24) & 0xFF);
	|            byte red = (byte)((p1 >> 16) & 0xFF);
	|            byte green = (byte)((p1 >> 8) & 0xFF);
	|            byte blue = (byte)(p1 & 0xFF);
	|            return MakeColor(red, green, blue, alpha);
	|        }");
КодМетодов.Вставить("Получить16_Color", 
	"        public string To16()
	|        {
	|            string empty = string.Empty;
	|            empty += ""#"";
	|            empty += OsUtils.ToHex32(R);
	|            empty += OsUtils.ToHex32(G);
	|            empty += OsUtils.ToHex32(B);
	|            empty += OsUtils.ToHex32(A);
	|            return empty;
	|        }");
КодМетодов.Вставить("ПолучитьЦентр_Rect2", 
	"        public GfVector2 GetCenter()
	|        {
	|            decimal newX = Position.X + (Size.X / 2);
	|            decimal newY = Position.Y + (Size.Y / 2);
	|            return new GfVector2(newX, newY);
	|        }");
КодМетодов.Вставить("ПереместитьМышь_VBoxContainer", 
	"        public void WarpMouse(GfVector2 p1, decimal p2 = 0.5m)
	|        {
	|            Base_obj.WarpMouse(p1, p2);
	|        }");
КодМетодов.Вставить("ПереместитьМышь_Button", 
	"        public void WarpMouse(GfVector2 p1, decimal p2 = 0.5m)
	|        {
	|            Base_obj.WarpMouse(p1, p2);
	|        }");
КодМетодов.Вставить("ПереместитьМышь_PanelContainer", 
	"        public void WarpMouse(GfVector2 p1, decimal p2 = 0.5m)
	|        {
	|            Base_obj.WarpMouse(p1, p2);
	|        }");
КодМетодов.Вставить("ПереместитьМышь_Label", 
	"        public void WarpMouse(GfVector2 p1, decimal p2 = 0.5m)
	|        {
	|            Base_obj.WarpMouse(p1, p2);
	|        }");
КодМетодов.Вставить("ПереместитьМышь_HBoxContainer", 
	"        public void WarpMouse(GfVector2 p1, decimal p2 = 0.5m)
	|        {
	|            Base_obj.WarpMouse(p1, p2);
	|        }");
КодМетодов.Вставить("Преобразовать_Graphics", 
	"        public void DrawSetTransform(GfVector2 pos, decimal rotation = 0, GfVector2 scale = null)
	|        {
	|            Base_obj.DrawSetTransform(pos, rotation, scale);
	|        }");
КодМетодов.Вставить("РисоватьМногоугольник_Graphics", 
	"        public void DrawPolygon(GfDictionary pointsAndColors, ArrayImpl texturePoints = null, IValue texture = null)
	|        {
	|            Base_obj.DrawPolygon(pointsAndColors, texturePoints, ((dynamic)texture).Base_obj);
	|        }");
КодМетодов.Вставить("РисоватьТекстуру_Graphics", 
	"        public void DrawTexture(IValue texture, GfVector2 pos, GfColor modulate = null)
	|        {
	|            Base_obj.DrawTexture(((dynamic)texture).ItemKey, pos, modulate);
	|        }");
КодМетодов.Вставить("РисоватьТекстуруПоПрямоугольнику_Graphics", 
	"        public void DrawTextureRect(IValue texture, GfRect2 rect2, bool tile, GfColor modulate = null, bool transpose = false)
	|        {
	|            Base_obj.DrawTextureRect(((dynamic)texture).ItemKey, rect2, tile, modulate, transpose);
	|        }");
КодМетодов.Вставить("РисоватьЦветнойМногоугольник_Graphics", 
	"        public void DrawColoredPolygon(ArrayImpl points, GfColor color, ArrayImpl texturePoints = null, IValue texture = null)
	|        {
	|            Base_obj.DrawColoredPolygon(points, color, texturePoints, ((dynamic)texture).Base_obj);
	|        }");
КодМетодов.Вставить("РисоватьЧастьТекстурыПоПрямоугольнику_Graphics", 
	"        public void DrawTextureRectRegion(IValue texture, GfRect2 destRect, GfRect2 srcRect, GfColor modulate = null, bool transpose = false, bool clipUv = true)
	|        {
	|            Base_obj.DrawTextureRectRegion(((dynamic)texture).ItemKey, destRect, srcRect, modulate, transpose, clipUv);
	|        }");
КодМетодов.Вставить("РисоватьКруг_Graphics", 
	"        public void DrawCircle(GfVector2 position, decimal radius, GfColor color, bool filled = true, decimal width = -1.0m, bool antialiased = false)
	|        {
	|            Base_obj.DrawCircle(position, radius, color, filled, width, antialiased);
	|        }");
КодМетодов.Вставить("РисоватьДугу_Graphics", 
	"        public void DrawArc(GfVector2 center, decimal radius, decimal startAngle, decimal endAngle, int pointCount, GfColor color, decimal width = -1.0m, bool antialiased = false)
	|        {
	|            Base_obj.DrawArc(center, radius, startAngle, endAngle, pointCount, color, width, antialiased);
	|        }");
КодМетодов.Вставить("РисоватьЛинию_Graphics", 
	"        public void DrawLine(GfVector2 from, GfVector2 to, GfColor color, decimal width = -1.0m, bool antialiased = false)
	|        {
	|            Base_obj.DrawLine(from, to, color, width, antialiased);
	|        }");
КодМетодов.Вставить("РисоватьПрямоугольник_Graphics", 
	"        public void DrawRect(GfRect2 rect2, GfColor color, bool filled = true, decimal width = -1.0m, bool antialiased = false)
	|        {
	|            Base_obj.DrawRect(rect2, color, filled, width, antialiased);
	|        }");
КодМетодов.Вставить("РисоватьСимвол_Graphics", 
	"        public void DrawChar(IValue font, GfVector2 pos, string character, int fontSize = 16, GfColor modulate = null, decimal oversampling = 0.0m)
	|        {
	|            Base_obj.DrawChar(((dynamic)font).ItemKey, pos, character.Substring(0, 1), fontSize, modulate, oversampling);
	|        }");
КодМетодов.Вставить("РисоватьЭллипс_Graphics", 
	"        public void DrawEllipse(GfVector2 position, decimal major, decimal minor, GfColor color, bool filled = true, decimal width = -1.0m, bool antialiased = false)
	|        {
	|            Base_obj.DrawEllipse(position, major, minor, color, filled, width, antialiased);
	|        }");
КодМетодов.Вставить("РисоватьСимволКонтуром_Graphics", 
	"        public void DrawCharOutline(IValue font, GfVector2 pos, string character, int fontSize = 16, int outlineSize = -1, GfColor modulate = null, decimal oversampling = 0.0m)
	|        {
	|            Base_obj.DrawCharOutline(((dynamic)font).ItemKey, pos, character.Substring(0, 1), fontSize, outlineSize, modulate, oversampling);
	|        }");
КодМетодов.Вставить("РисоватьМногострочныйТекст_Graphics", 
	"        public void DrawMultilineString(IValue font, GfVector2 pos, string text, int alignment = 0, decimal width = -1.0m, int fontSize = 16, int maxLines = -1, GfColor modulate = null, int brkFlags = 3, int justificationFlags = 3, int direction = 0, int orientation = 0, decimal oversampling = 0.0m)
	|        {
	|            Base_obj.DrawMultilineString(((dynamic)font).ItemKey, pos, text, alignment, width, fontSize, maxLines, modulate, brkFlags, justificationFlags, direction, orientation, oversampling);
	|        }");
КодМетодов.Вставить("РисоватьМногострочныйТекстКонтуром_Graphics", 
	"        public void DrawMultilineStringOutline(IValue font, GfVector2 pos, string text, int alignment = 0, decimal width = -1.0m, int fontSize = 16, int maxLines = -1, int outlineSize = 1, GfColor modulate = null, int brkFlags = 3, int justificationFlags = 3, int direction = 0, int orientation = 0, decimal oversampling = 0.0m)
	|        {
	|            Base_obj.DrawMultilineStringOutline(((dynamic)font).ItemKey, pos, text, alignment, width, fontSize, maxLines, outlineSize, modulate, brkFlags, justificationFlags, direction, orientation, oversampling);
	|        }");
КодМетодов.Вставить("РисоватьМультилинию_Graphics", 
	"        public void DrawMultiline(GfDictionary pointsAndColors, GfColor color, decimal width = -1.0m, bool antialiased = false)
	|        {
	|            Base_obj.DrawMultiline(pointsAndColors, color, width, antialiased);
	|        }");
КодМетодов.Вставить("РисоватьПолилинию_Graphics", 
	"        public void DrawPolyline(ArrayImpl pointsLine, GfColor color, decimal width = -1.0m, bool antialiased = false)
	|        {
	|            Base_obj.DrawPolyline(pointsLine, color, width, antialiased);
	|        }");
КодМетодов.Вставить("РисоватьПунктирнуюЛинию_Graphics", 
	"        public void DrawDashedLine(GfVector2 from, GfVector2 to, GfColor color, decimal width = -1.0m, decimal dash_length = 2.0m, bool aligned = true, bool antialiased = false)
	|        {
	|            Base_obj.DrawDashedLine(from, to, color, width, dash_length, aligned, antialiased);
	|        }");
КодМетодов.Вставить("РисоватьСтроку_Graphics", 
	"        public void DrawString(IValue font, GfVector2 pos, string text, int alignment = 0, decimal width = -1.0m, int fontSize = 16, GfColor modulate = null, int justificationFlags = 3, int direction = 0, int orientation = 0, decimal oversampling = 0.0m)
	|        {
	|            Base_obj.DrawString(((dynamic)font).ItemKey, pos, text, alignment, width, fontSize, modulate, justificationFlags, direction, orientation, oversampling);
	|        }");
КодМетодов.Вставить("РисоватьСтрокуКонтуром_Graphics", 
	"        public void DrawStringOutline(IValue font, GfVector2 pos, string text, int alignment = 0, decimal width = -1.0m, int fontSize = 16, int outlineSize = 1, GfColor modulate = null, int justificationFlags = 3, int direction = 0, int orientation = 0, decimal oversampling = 0.0m)
	|        {
	|            Base_obj.DrawStringOutline(((dynamic)font).ItemKey, pos, text, alignment, width, fontSize, outlineSize, modulate, justificationFlags, direction, orientation, oversampling);
	|        }");
КодМетодов.Вставить("РисоватьЦветнуюМультилинию_Graphics", 
	"        public void DrawMultilineColors(GfDictionary linesAndColorsDict, decimal width = -1.0m, bool antialiased = false)
	|        {
	|            Base_obj.DrawMultilineColors(linesAndColorsDict, width, antialiased);
	|        }");
КодМетодов.Вставить("РисоватьЦветнуюПолилинию_Graphics", 
	"        public void DrawPolylineColors(GfDictionary linesAndColorsDict, decimal width = -1.0m, bool antialiased = false)
	|        {
	|            Base_obj.DrawPolylineColors(linesAndColorsDict, width, antialiased);
	|        }");
КодМетодов.Вставить("РисоватьЭллиптическуюДугу_Graphics", 
	"        public void DrawEllipseArc(GfVector2 center, decimal semiMajorAxis, decimal semiMinorAxis, decimal startAngle, decimal endAngle, int pointCount, GfColor color, decimal width = -1.0m, bool antialiased = false)
	|        {
	|            Base_obj.DrawEllipseArc(center, semiMajorAxis, semiMinorAxis, startAngle, endAngle, pointCount, color, width, antialiased);
	|        }");
	
	
КодСобытий = Новый Структура();
КодСобытий.Вставить("ФокусПотерян_ййййй", 
	"        public GfAction FocusExited { get; set; }");


// Зададим все необходимые пути.
КаталогСправки = "C:\444\OneScriptGameForms\docs\OSGForms";
КаталогВыгрузки = "C:\444\OneScriptGameForms\Scripts\ВыгруженныеОбъекты";
ПутьДоOneScriptForms_dll = "C:\444\OneScriptForms\111\OneScriptForms\OneScriptForms\bin\Debug\OneScriptForms.dll";
ПутьДоOneScriptIntegrator_dll = "C:\444\OneScriptIntegrator\111\OneScriptIntegrator\OneScriptIntegrator\bin\Debug\OneScriptIntegrator.dll";

ПодключитьВнешнююКомпоненту(ПутьДоOneScriptIntegrator_dll);
ИОС = Новый ИнтеграторОдноСкрипта();
ПодключитьВнешнююКомпоненту(ПутьДоOneScriptForms_dll);
Ф = Новый ФормыДляОдноСкрипта();

ВыгрузкаДляGForms();
Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60 + " мин.");