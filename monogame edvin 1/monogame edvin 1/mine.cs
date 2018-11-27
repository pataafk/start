﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_edvin_1
{
    class Mine : Enemy
    {

        public Mine(Texture2D texture, float X, float Y) : base(texture, X, Y, 6f, 0.3f)
        {

        }
        public override void Update(GameWindow window)
        {
            vector.X += speed.X;

            if (vector.X > window.ClientBounds.Width - texture.Width || vector.X < 0)
                speed.X *= -1;

            vector.Y += speed.Y;

            if (vector.Y > window.ClientBounds.Height)
                isAlive = false;
        }
    }
}
