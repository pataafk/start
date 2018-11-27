using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_edvin_1
{
    class Bullet : PhysicalObject
    {
        public Bullet(Texture2D texture, float X, float Y) : base(texture, X, Y, 0, 3F)
        {

        }

        public void Update()
        {
            vector.Y -= speed.Y;
            if (vector.Y < 0)
                isAlive = false;
        }
    }
}
