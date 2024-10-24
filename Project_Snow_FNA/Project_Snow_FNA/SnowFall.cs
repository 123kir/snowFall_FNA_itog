﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Project_Snow_FNA
{
    public class SnowFall : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch; 

        private Texture2D flakeTexture;
        private Texture2D flakeTexture_2;
        private Texture2D backgroundTexture;
        private List<Snowflake> Snowflakes;

        private const int WindowHeight = 800;
        private const int WindowWidth = 600;
        private readonly Random random = new Random();

        /// <summary>
        /// Количество снежинок.   
        /// </summary>
        public int kol = 156;

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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            flakeTexture = Content.Load<Texture2D>("flake_n_1"); 
            flakeTexture_2 = Content.Load<Texture2D>("flake_n_2"); 
            backgroundTexture = Content.Load<Texture2D>("background"); 

            Snowflakes = new List<Snowflake>();

            for (var i = 0; i < kol; i++)
            {
                var size = (float)random.Next(10, 25) / 100;
                var speed = (float)random.Next(25,350);
                var startPos = new Vector2(random.Next(0, WindowWidth), random.Next(0, WindowHeight)); 

                Snowflakes.Add(new Snowflake(flakeTexture, startPos, speed, size));
                startPos = new Vector2(random.Next(0, WindowWidth), random.Next(0, WindowHeight)); 
                Snowflakes.Add(new Snowflake(flakeTexture_2, startPos, speed, size)); 
            }
        }

        /// <summary>
        /// Обработка позиции снежинок.
        /// </summary>
        protected override void Update(GameTime gameTime) 
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                for (var i = 0; i < 10; i++)
                {
                    var size = (float)random.Next(10, 25) / 100;
                    var speed = (float)random.Next(25, 350);
                    var startPos = new Vector2(random.Next(0, WindowWidth), random.Next(0, WindowHeight));

                    Snowflakes.Add(new Snowflake(flakeTexture, startPos, speed, size));
                    startPos = new Vector2(random.Next(0, WindowWidth), random.Next(0, WindowHeight));
                    Snowflakes.Add(new Snowflake(flakeTexture_2, startPos, speed, size));
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Snowflakes.RemoveRange(0, Math.Min(Snowflakes.Count, 10));   
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
