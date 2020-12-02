using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame
{
    public class Circle
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;
        public float rotation;


        public Circle(Vector2 p)
        {
            position = p;
        }
    }
}