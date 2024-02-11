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
		bgi_Font Euro;
		bgi_Font Goth;
		bgi_Font Lcom;
		bgi_Font Sans;
		bgi_Font Scri;
		bgi_Font Simp;
		bgi_Font Trip;
		bgi_Font Tscr;

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

			Euro = new bgi_Font() {
				Name = "Euro",
				sizes = Euro_Data.euro_sizes,
				widths = Euro_Data.euro_widths,
				characters = Euro_Data.euro_characters,
				NGLYPHS = Euro_Data.euro_NGLYPHS,
				height = Euro_Data.euro_height,
				desc_height = Euro_Data.euro_desc_height
			};

			Goth = new bgi_Font() {
				Name = "Goth",
				sizes = Goth_Data.goth_sizes,
				widths = Goth_Data.goth_widths,
				characters = Goth_Data.goth_characters,
				NGLYPHS = Goth_Data.goth_NGLYPHS,
				height = Goth_Data.goth_height,
				desc_height = Goth_Data.goth_desc_height
			};
			Lcom = new bgi_Font() {
				Name = "Lcom",
				sizes = Lcom_Data.lcom_sizes,
				widths = Lcom_Data.lcom_widths,
				characters = Lcom_Data.lcom_characters,
				NGLYPHS = Lcom_Data.lcom_NGLYPHS,
				height = Lcom_Data.lcom_height,
				desc_height = Lcom_Data.lcom_desc_height
			};
			Sans = new bgi_Font() {
				Name = "Sans",
				sizes = Sans_Data.sans_sizes,
				widths = Sans_Data.sans_widths,
				characters = Sans_Data.sans_characters,
				NGLYPHS = Sans_Data.sans_NGLYPHS,
				height = Sans_Data.sans_height,
				desc_height = Sans_Data.sans_desc_height
			};
			Scri = new bgi_Font() {
				Name = "Scri",
				sizes = Scri_Data.scri_sizes,
				widths = Scri_Data.scri_widths,
				characters = Scri_Data.scri_characters,
				NGLYPHS = Scri_Data.scri_NGLYPHS,
				height = Scri_Data.scri_height,
				desc_height = Scri_Data.scri_desc_height
			};
			Trip = new bgi_Font() {
				Name = "Trip",
				sizes = Trip_Data.trip_sizes,
				widths = Trip_Data.trip_widths,
				characters = Trip_Data.trip_characters,
				NGLYPHS = Trip_Data.trip_NGLYPHS,
				height = Trip_Data.trip_height,
				desc_height = Trip_Data.trip_desc_height
			};
			Tscr = new bgi_Font() {
				Name = "Tscr",
				sizes = Tscr_Data.tscr_sizes,
				widths = Tscr_Data.tscr_widths,
				characters = Tscr_Data.tscr_characters,
				NGLYPHS = Tscr_Data.tscr_NGLYPHS,
				height = Tscr_Data.tscr_height,
				desc_height = Tscr_Data.tscr_desc_height
			};

			font = Tscr;

			int size = font.NGLYPHS;
			Characters = new bgi_Character[size];
			for (int i = 0; i < size; i++) {
				Characters[i] = new bgi_Character(font, i);
			}
		}

		protected override void Update(GameTime gameTime) {
			float time = (float)gameTime.TotalGameTime.TotalSeconds;

			KeyboardState state = Keyboard.GetState();
			MouseState mouseState = Mouse.GetState();
			Point cursor = new(mouseState.X, mouseState.Y);



			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			
			//scale = MathF.Sin(time * 0.25f) * 16 + 17;
			base.Update(gameTime);
		}


		


		int margin = 8;
		float scale = 3.0f;
		int stroke = 1;
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
