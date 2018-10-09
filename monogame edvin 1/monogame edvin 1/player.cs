﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_edvin_1
{
    class Player : PhysicalObject
    {

        List<Bullet> bullets;
        Texture2D bulletTexture;
        double timeSinceLastBullet = 0;

        int points = 0;

        public int Points { get { return points; } set { points = value; } }

        public Player(Texture2D texture, float X, float Y, float speedX, float speedY, Texture2D bulletTexture) : base(texture, X, Y, speedX, speedY)
        {
            bullets = new List<Bullet>();
            this.bulletTexture = bulletTexture;
        }

        public List<Bullet> Bullets { get { return bullets; } }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, Color.White);
            foreach (Bullet b in bullets)
                b.Draw(spriteBatch);
        }

        public void Update(GameWindow window, GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (vector.X <= window.ClientBounds.Width - texture.Width && vector.X >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Right))
                    vector.X += speed.X;
                if (keyboardState.IsKeyDown(Keys.Left))
                    vector.X -= speed.X;
            }

            if (vector.Y <= window.ClientBounds.Height - texture.Height && vector.Y >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Down))
                    vector.Y += speed.Y;
                if (keyboardState.IsKeyDown(Keys.Up))
                    vector.Y -= speed.Y;
            }

            if (vector.X < 0)
                vector.X = 0;

            if (vector.X > window.ClientBounds.Width - texture.Width)
            {
                vector.X = window.ClientBounds.Width - texture.Width;
            }

            if (vector.Y < 0)
                vector.Y = 0;

            if (vector.Y > window.ClientBounds.Height - texture.Height)
            {
                vector.Y = window.ClientBounds.Height - texture.Height;
            }

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (gameTime.TotalGameTime.TotalMilliseconds > timeSinceLastBullet + 200)
                {
                    Bullet temp = new Bullet(bulletTexture, vector.X + texture.Width / 2, vector.X);

                    bullets.Add(temp);
                    timeSinceLastBullet = gameTime.TotalGameTime.TotalMilliseconds;

                }
            }
            foreach(Bullet b in bullets.ToList())
            {
                b.Update();

                if (!b.IsAlive)
                    bullets.Remove(b);
            }
            if (keyboardState.IsKeyDown(Keys.Escape))
                isAlive = false;
        }

        public void Reset (float X, float Y, float speedX, float speedY)
        {
            vector.X = X;
            vector.Y = Y;
            speed.X = speedX;
            vector.Y = speedY;

            bullets.Clear();
            timeSinceLastBullet = 0;

            points = 0;

            isAlive = true;
        }
    }
}
