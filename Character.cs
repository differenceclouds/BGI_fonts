using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace bgi_fonts {


	public struct bgi_Font {
		public string Name;
		public int[] sizes;
		public int[] widths;
		public sbyte[][] characters;
		public int NGLYPHS;
		public int height;
		public int desc_height;
	}

	public struct bgi_Character {
		bgi_Font font;
		public readonly int entry;
		int size;
		public int width;

		Point[] Points;

		public bgi_Character(bgi_Font _font, int _entry) {
			font = _font;
			entry = _entry;
			size = font.sizes[entry];
			width = font.widths[entry];
			sbyte[] _points = font.characters[entry];
			Points = new Point[size / 2];

			for (int i = 0; i < size; i+=2) {
				int x = _points[i];
				int y = _points[i + 1];
				Points[i / 2] = new(x, y);
			}
		}

		public void Draw(SpriteBatch spriteBatch, Vector2 position, float scale, int stroke) {
			for(int i = 0; i < Points.Length; i += 2) {
				Vector2 point1 = (Points[i].ToVector2()) * scale;
				Vector2 point2 = (Points[i + 1].ToVector2()) * scale;
				//Primitives2D.DrawLine(spriteBatch, point1 + position, point2 + position, Color.White);
				//Primitives2D.DrawLine(spriteBatch, point1 + position, point2 + position, Color.White, thickness: stroke);
				Drawing.DrawLineBresenham(spriteBatch, point1 + position, point2 + position, Color.White, stroke: stroke);
			}
		}

	}
}
