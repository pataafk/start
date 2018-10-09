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
    abstract class Enemy : PhysicalObject
    {
 


        public Enemy(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {

        }
        public abstract void Update(GameWindow window);
    }
}
