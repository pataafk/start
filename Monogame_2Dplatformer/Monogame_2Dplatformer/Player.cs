using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_2Dplatformer
{
    class Player : PhysicalObject
    {




        public Player(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {

        }

        public void Update(GameWindow window, GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            /*Player kontroller*/
            if (keyboardState.IsKeyDown(Keys.D))
                vector.X += speed.X;
            if (keyboardState.IsKeyDown(Keys.A))
                vector.X -= speed.X;
            if (keyboardState.IsKeyDown(Keys.W))
                vector.Y -= speed.Y;
            if (keyboardState.IsKeyDown(Keys.S))
                vector.Y += speed.Y;


        }

    }
}
