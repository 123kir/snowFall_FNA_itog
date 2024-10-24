using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project_Snow_FNA
{
    internal class Snowflake
    {
        public Vector2 position;
        public readonly float speed;
        public readonly float size;
        public readonly Texture2D texture;

        /// <summary>
        /// Инициализация позиции, скорости, размера и текстуры в конструкторе снежинки.
        /// </summary>
        public Snowflake(Texture2D texture, Vector2 startPosition, float speed, float size)
        {
            position = startPosition;
            this.speed = speed;
            this.size = size;
            this.texture = texture;
        }
        /// <summary>
        /// Перемещение снежинки вниз.
        /// </summary>
        public void Fall(GameTime gameTime)
        {
            position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// Отрисовка снежинки.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, size, SpriteEffects.None, 0f); // посмотреть эффекты
        }

    }
}
