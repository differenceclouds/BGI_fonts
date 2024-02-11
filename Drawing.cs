using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace bgi_fonts {
	public static class Drawing {
        public static void DrawLineBresenham(this SpriteBatch spriteBatch, Vector2 _point1, Vector2 _point2, Color color, int stroke = 1, float layerDepth = 0) {

            if (_point1 == _point2) {
                drawPixel(spriteBatch, _point1, stroke, Color.White);
            } else if (_point1.X == _point2.X && _point1.Y != _point2.Y) {
                //draw top to bottom
                if (_point1.Y > _point2.Y) {
                    (_point1, _point2) = (_point2, _point1);
                }
                int height = (int)(_point2.Y - _point1.Y);
                for (int y = 0; y <= height; y++) {
                    drawPixel(spriteBatch, new Vector2(0, y) + _point1, stroke, Color.White);
                }
                return;
            }
              //draw left to right
              else if (_point1.X > _point2.X) {
                (_point1, _point2) = (_point2, _point1);
            }


            Vector2 position = _point1;
            Vector2 point2 = _point2 - _point1;

            float X1 = point2.X;
            float Y1 = point2.Y;


            for (float x = 0; x < X1; x += 0.0625f) {
                int y = (int)MathF.Round(((Y1 / X1) * x) + 0.5f);
                drawPixel(spriteBatch, new Vector2(x, y) + position, stroke, color);
            }
        }

        static void drawPixel(SpriteBatch spriteBatch, Vector2 point, int stroke, Color color) {
            if (stroke == 1) {
                PutPixel(spriteBatch, point, color);
            } else {
                float x = point.X;
                float y = point.Y;
                for (int i = 0; i < stroke; i++) {
                    PutPixel(spriteBatch, new Vector2(x, y), color);
                    PutPixel(spriteBatch, new Vector2(x + i, y), color);
                    PutPixel(spriteBatch, new Vector2(x, y + i), color);
                    PutPixel(spriteBatch, new Vector2(x + i, y + i), color);
                }
            }
        }

        private static Texture2D pixel;

        public static void PutPixel(this SpriteBatch spriteBatch, Vector2 position, Color color) {
            if (pixel == null) {
                CreateThePixel(spriteBatch);
            }

            spriteBatch.Draw(pixel, position, color);
        }

        private static void CreateThePixel(SpriteBatch spriteBatch) {
            pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
        }

    }
}
