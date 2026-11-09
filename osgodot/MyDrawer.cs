using Godot;
using System.Collections.Generic;

public partial class MyDrawer : Node2D
{
	// Словарь для хранения параметров рисования.
	public Dictionary<string, DrawerConfig> DrawParams = new Dictionary<string, DrawerConfig>();
	private bool _dirty = false;

	public void MarkDirty() => _dirty = true;

	public void MyDraw()
	{
		foreach (var item in DrawParams)
		{
			DrawerConfig param;
			switch (item.Key)
			{
				case "DrawCircle":
					param = DrawParams["DrawCircle"];
					DrawCircle(
						param.Position, 
						param.Radius, 
						param.Color, 
						param.Filled, 
						param.Width, 
						param.Antialiased);
					break;
				case "DrawRect":
					param = DrawParams["DrawRect"];
					DrawRect(
						param.Rect2, 
						param.Color, 
						param.Filled, 
						param.Width, 
						param.Antialiased);
					break;
				case "DrawEllipse":
					param = DrawParams["DrawEllipse"];
					DrawEllipse(
						param.Position, 
						param.Major, 
						param.Minor, 
						param.Color, 
						param.Filled, 
						param.Width, 
						param.Antialiased);
					break;
				case "DrawLine":
					param = DrawParams["DrawLine"];
					DrawLine(
						param.From, 
						param.To, 
						param.Color, 
						param.Width, 
						param.Antialiased);
					break;
				case "DrawArc":
					param = DrawParams["DrawArc"];
					DrawArc(
						param.Center,
						param.Radius,
						param.StartAngle,
						param.EndAngle,
						param.PointCount,
						param.Color,
						param.Width,
						param.Antialiased);
					break;
				case "DrawChar":
					param = DrawParams["DrawChar"];
					DrawChar(
						param.Font,
						param.Position,
						param.Char,
						param.FontSize,
						param.Modulate,
						param.Oversampling);
					break;
				case "DrawCharOutline":
					param = DrawParams["DrawCharOutline"];
					DrawCharOutline(
						param.Font,
						param.Position,
						param.Char,
						param.FontSize,
						param.OutlineSize,
						param.Modulate,
						param.Oversampling);
					break;
				case "DrawPolygon":
					param = DrawParams["DrawPolygon"];
					int heightPolygonTexture = param.Texture.GetImage().GetHeight();
					int widthPolygonTexture = param.Texture.GetImage().GetWidth();
					Godot.Vector2[] texturePoints = new Vector2[param.TexturePoints.Length];
					for (int i = 0; i < param.TexturePoints.Length; i++)
					{
						float x = param.TexturePoints[i].X;
						float y = param.TexturePoints[i].Y;
						Vector2 vector2 = new Vector2(x / widthPolygonTexture, y / heightPolygonTexture);
						texturePoints[i] = vector2;
					}
					DrawPolygon(
						param.Points, 
						param.Colors,
						texturePoints, 
						param.Texture);
					break;
				case "DrawColoredPolygon":
					param = DrawParams["DrawColoredPolygon"];
					int heightColoredPolygonTexture = param.Texture.GetImage().GetHeight();
					int widthColoredPolygonTexture = param.Texture.GetImage().GetWidth();
					Godot.Vector2[] texturePointsColoredPolygon = new Vector2[param.TexturePoints.Length];
					for (int i = 0; i < param.TexturePoints.Length; i++)
					{
						float x = param.TexturePoints[i].X;
						float y = param.TexturePoints[i].Y;
						Vector2 vector2 = new Vector2(x / widthColoredPolygonTexture, y / heightColoredPolygonTexture);
						texturePointsColoredPolygon[i] = vector2;
					}
					DrawColoredPolygon(
						param.Points, 
						param.Color,
						texturePointsColoredPolygon, 
						param.Texture);
					break;
				case "DrawDashedLine":
					param = DrawParams["DrawDashedLine"];
					DrawDashedLine(
						param.From,
						param.To,
						param.Color,
						param.Width,
						param.DashLength,
						param.Antialiased,
						param.Aligned);
					break;
				case "DrawEllipseArc":
					param = DrawParams["DrawEllipseArc"];
					DrawEllipseArc(
						param.Center,
						param.Major,
						param.Minor,
						param.StartAngle,
						param.EndAngle,
						param.PointCount,
						param.Color,
						param.Width,
						param.Antialiased);
					break;
				case "DrawMultiline":
					param = DrawParams["DrawMultiline"];
					DrawMultiline(
						param.Points,
						param.Color,
						param.Width,
						param.Antialiased);
					break;
				case "DrawPolyline":
					param = DrawParams["DrawPolyline"];
					DrawPolyline(
						param.Points,
						param.Color,
						param.Width,
						param.Antialiased);
					break;
				case "DrawMultilineColors":
					param = DrawParams["DrawMultilineColors"];
					DrawMultilineColors(
						param.PointsArray,
						param.ColorsArray,
						param.Width,
						param.Antialiased);
					break;
				case "DrawMultilineString":
					param = DrawParams["DrawMultilineString"];
					DrawMultilineString(
						param.Font,
						param.Position,
						param.Text,
						param.Alignment,
						param.Width,
						param.FontSize,
						param.MaxLines,
						param.Modulate,
						param.BrkFlags,
						param.JustificationFlags,
						param.Direction,
						param.Orientation,
						param.Oversampling);
					break;
				case "DrawMultilineStringOutline":
					param = DrawParams["DrawMultilineStringOutline"];
					DrawMultilineStringOutline(
						param.Font,
						param.Position,
						param.Text,
						param.Alignment,
						param.Width,
						param.FontSize,
						param.MaxLines,
						param.OutlineSize,
						param.Modulate,
						param.BrkFlags,
						param.JustificationFlags,
						param.Direction,
						param.Orientation,
						param.Oversampling);
					break;
				case "DrawPolylineColors":
					param = DrawParams["DrawPolylineColors"];
					DrawPolylineColors(
						param.Points, 
						param.Colors,
						param.Width,
						param.Antialiased);
					break;
				case "DrawString":
					param = DrawParams["DrawString"];
					DrawString(
						param.Font,
						param.Position,
						param.Text,
						param.Alignment,
						param.Width,
						param.FontSize,
						param.Modulate,
						param.JustificationFlags,
						param.Direction,
						param.Orientation,
						param.Oversampling);
					break;
				case "DrawStringOutline":
					param = DrawParams["DrawStringOutline"];
					DrawStringOutline(
						param.Font,
						param.Position,
						param.Text,
						param.Alignment,
						param.Width,
						param.FontSize,
						param.OutlineSize,
						param.Modulate,
						param.JustificationFlags,
						param.Direction,
						param.Orientation,
						param.Oversampling);
					break;
				case "DrawTexture":
					param = DrawParams["DrawTexture"];
					DrawTexture(
						param.Texture,
						param.Position,
						param.Modulate);
					break;
				case "DrawTextureRect":
					param = DrawParams["DrawTextureRect"];
					DrawTextureRect(
						param.Texture,
						param.Rect2,
						param.Tile,
						param.Modulate,
						param.Transpose);
					break;
				case "DrawTextureRectRegion":
					param = DrawParams["DrawTextureRectRegion"];
					DrawTextureRectRegion(
						param.Texture,
						param.DestRect,
						param.SrcRect,
						param.Modulate,
						param.Transpose,
						param.ClipUv);
					break;
				case "DrawSetTransform":
					param = DrawParams["DrawSetTransform"];
					DrawSetTransform(
						param.Position, 
						param.Rotation, 
						param.Scale);
					break;
			}
		}
	}

	public override void _Ready()
	{
	}

	public override void _Draw()
	{
		MyDraw();
	}

	public override void _Process(double delta)
	{
		if (_dirty)
		{
			QueueRedraw();
			_dirty = false;
		}
	}

	public class DrawerConfig
	{
		public bool Aligned { get; set; }
		public Rect2 Rect2 { get; set; }
		public HorizontalAlignment Alignment { get; set; }
		public bool Antialiased { get; set; }
		public Godot.TextServer.LineBreakFlag BrkFlags { get; set; }
		public Vector2 Center { get; set; }
		public string Char { get; set; }
		public bool ClipUv { get; set; }
		public Color Color { get; set; }
		public Godot.Color[] Colors { get; set; }
		public float DashLength { get; set; }
		public Godot.TextServer.Direction Direction { get; set; }
		public float EndAngle { get; set; }
		public bool Filled { get; set; }
		public Font Font { get; set; }
		public int FontSize { get; set; }
		public Vector2 From { get; set; }
		public Godot.TextServer.JustificationFlag JustificationFlags { get; set; }
		public float Major { get; set; }
		public int MaxLines { get; set; }
		public float Minor { get; set; }
		public Color Modulate { get; set; }
		public Godot.TextServer.Orientation Orientation { get; set; }
		public float Oversampling { get; set; }
		public int PointCount { get; set; }
		public Godot.Vector2[] Points { get; set; }
		public Vector2 Position { get; set; }
		public float Radius { get; set; }
		public float Rotation { get; set; }
		public Vector2 Scale { get; set; }
		public int OutlineSize { get; set; }
		public Rect2 SrcRect { get; set; }
		public float StartAngle { get; set; }
		public string Text { get; set; }
		public Texture2D Texture { get; set; }
		public bool Tile { get; set; }
		public Vector2 To { get; set; }
		public bool Transpose { get; set; }
		public Godot.Collections.Array Uvs { get; set; }
		public float Width { get; set; }
		public Vector2[] PointsArray { get; set; }
		public Godot.Color[] ColorsArray { get; set; }
		public Rect2 DestRect { get; set; }
		public Vector2[] TexturePoints { get; set; }

		public object this[string p1]
		{
			get { return this.GetType().GetProperty(p1).GetValue(this); }
			set { this.GetType().GetProperty(p1).SetValue(this, value); }
		}
	}
}
