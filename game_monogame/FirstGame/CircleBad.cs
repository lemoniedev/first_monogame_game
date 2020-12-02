using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame
{
    public class CircleBad
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;
        public float rotation;

        public CircleBad(Vector2 p)
        {
            position = p;
        }

        public void Move()
        {
            velocity.Y = 3;

            if (position.Y > 400)
            {
                position.Y = -32;

                System.Random r = new System.Random();
                float n = r.Next(32, 640-32);

                position.X = n;
            }

            position += velocity;
            rotation += velocity.Y / 20;
        }

        public void Hurt(Circle player)
        {
            if (player.position.X - 12 < position.X + 12 && position.X - 12 < player.position.X + 12)
            {
                if (player.position.Y - 12 < position.Y + 12 && position.Y - 12 < player.position.Y + 12)
                {
                    player.position.X = 320;
                }
            }
        }
    }
}