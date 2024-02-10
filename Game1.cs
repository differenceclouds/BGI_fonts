using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace bgi_fonts {



	public class Game1 : Game {
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		public Game1() {
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize() {
			Window.AllowUserResizing = true;
			base.Initialize();
		}

		bgi_Character[] Characters;
		bgi_Font Bold;
		bgi_Font Litt;

		bgi_Font font;

		protected override void LoadContent() {
			_spriteBatch = new SpriteBatch(GraphicsDevice);


			Bold = new bgi_Font() {
				Name = "Bold",
				sizes = Bold_Data.bold_sizes,
				widths = Bold_Data.bold_widths,
				characters = Bold_Data.bold_characters,
				NGLYPHS = Bold_Data.bold_NGLYPHS,
				height = Bold_Data.bold_height,
				desc_height = Bold_Data.bold_desc_height
			};

			Litt = new bgi_Font() {
				Name = "Litt",
				sizes = Litt_Data.litt_sizes,
				widths = Litt_Data.litt_widths,
				characters = Litt_Data.litt_characters,
				NGLYPHS = Litt_Data.litt_NGLYPHS,
				height = Litt_Data.litt_height,
				desc_height = Litt_Data.litt_desc_height
			};


			font = Litt;

			int size = font.NGLYPHS;
			Characters = new bgi_Character[size];
			for (int i = 0; i < size; i++) {
				Characters[i] = new bgi_Character(font, i);
			}
		}

		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			float time = (float)gameTime.TotalGameTime.TotalSeconds;
			//scale = MathF.Sin(time * 0.25f) * 16 + 17;
			base.Update(gameTime);
		}


		


		int margin = 8;
		float scale = 12.0f;
		int stroke = 2;
		int spacing = 0;
		int lineSpacing = -2;

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Black);
			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			{
				int x = margin;
				int y = 0;
				for (int i = 0; i < font.NGLYPHS; i++) {
					int width = Characters[i].width;
					if (x > Window.ClientBounds.Width - (width * scale) - margin) {
						x = margin;
						y += (int)((font.height + lineSpacing) * scale);
					}
					Characters[i].Draw(_spriteBatch, new(x, y), scale, stroke);
					x += (int)((width + spacing) * scale);
				}
			}
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
