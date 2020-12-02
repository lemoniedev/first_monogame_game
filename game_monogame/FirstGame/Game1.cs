using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FirstGame
{
    public class Game1 : Game
    {
        Texture2D backGorund;
        Song happyAlley;

        Circle circle = new Circle(new Vector2(320, 255-12));

        List<CircleBad> enemyList = new List<CircleBad>
        {
            new CircleBad(new Vector2(20, -32)),
            new CircleBad(new Vector2(120, -32)),
            new CircleBad(new Vector2(220, -32)),
            new CircleBad(new Vector2(420, -32)),
            new CircleBad(new Vector2(520, -32)),
            new CircleBad(new Vector2(620, -32)),
        };

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 360;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            happyAlley = Content.Load<Song>("happyAlley");
            MediaPlayer.Play(happyAlley);

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            backGorund = Content.Load<Texture2D>("backGroundHill");

            circle.texture = Content.Load<Texture2D>("circleSprite");

            foreach (CircleBad c in enemyList)
            {
                c.texture = Content.Load<Texture2D>("circleBadSprite");
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Right))
            {
                circle.velocity.X = MathHelper.Lerp(circle.velocity.X, 4, 0.15f);
            }
            else if (kstate.IsKeyDown(Keys.Left))
            {
                circle.velocity.X = MathHelper.Lerp(circle.velocity.X, -4, 0.15f);
            }
            else
            {
                circle.velocity.X = MathHelper.Lerp(circle.velocity.X, 0, 0.15f);
            }

            circle.position += circle.velocity;
            circle.rotation += circle.velocity.X / 20;

            foreach (CircleBad c in enemyList)
            {
                c.Move();
                c.Hurt(circle);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(backGorund, Vector2.Zero, Color.White);

            _spriteBatch.Draw(circle.texture, circle.position, null, Color.White, circle.rotation, new Vector2(16, 16), new Vector2(1, 1), SpriteEffects.None, 0); // Draw my circle
            
            foreach (CircleBad c in enemyList)
            {
                _spriteBatch.Draw(c.texture, c.position, null, Color.White, c.rotation, new Vector2(16, 16), new Vector2(1, 1), SpriteEffects.None, 0); // Draw my circleBad
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
