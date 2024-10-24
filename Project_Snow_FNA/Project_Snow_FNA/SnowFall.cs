using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Project_Snow_FNA
{
    public class SnowFall : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics; // оставить
        SpriteBatch spriteBatch; // спрайт партия

        private Texture2D flakeTexture;
        private Texture2D flakeTexture_2; // эксперемент
        private Texture2D backgroundTexture;
        private List<Snowflake> Snowflakes;

        private const int WindowHeight = 800;
        private const int WindowWidth = 600;
        private readonly Random random = new Random();

        /// <summary>
        /// Инициализация графики в конструкторе снегопада.   
        /// </summary>
        public SnowFall()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Инициализация игры.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Загрузка контента.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice); // оставить

            
            flakeTexture = Content.Load<Texture2D>("flake_n_1"); // фото снежинки
            flakeTexture_2 = Content.Load<Texture2D>("flake_n_2"); // фото снежинки
            backgroundTexture = Content.Load<Texture2D>("background"); // фото зада

            Snowflakes = new List<Snowflake>();

            for (var i = 0; i < 156; i++)
            {
                var size = (float)random.Next(10, 25) / 100;
                var speed = (float)random.Next(25,350);
                var startPos = new Vector2(random.Next(0, WindowWidth), random.Next(0, WindowHeight)); // оставить

                Snowflakes.Add(new Snowflake(flakeTexture, startPos, speed, size));
                startPos = new Vector2(random.Next(0, WindowWidth), random.Next(0, WindowHeight)); // оставить
                Snowflakes.Add(new Snowflake(flakeTexture_2, startPos, speed, size)); // эксперемент
            }
        }

        /// <summary>
        /// Обработка позиции снежинок.
        /// </summary>
        protected override void Update(GameTime gameTime) // оставить
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var Snowflake in Snowflakes)
            {
                Snowflake.Fall(gameTime);

                if (Snowflake.position.Y > WindowHeight)
                {
                    Snowflake.position = new Vector2(random.Next(0, WindowWidth), -50);
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Отрисовка снежинок.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, WindowWidth, WindowHeight), Color.White);

            foreach (var Snowflake in Snowflakes)
            {
                Snowflake.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
