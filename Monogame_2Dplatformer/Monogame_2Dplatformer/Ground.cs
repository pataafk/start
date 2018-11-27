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
    class Ground  : GameObject
    {
        public Ground (Texture2D texture, float X, float Y) : base(texture, X, Y)
        {

        }

        public bool CheckCollisionGround(Ground other)
        {
            Rectangle myRect = new Rectangle(Convert.ToInt32(X),
            Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(Height));
            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X),
            Convert.ToInt32(other.Y), Convert.ToInt32(other.Width), Convert.ToInt32(other.Height));
            return myRect.Intersects(otherRect);

        }
    }
}
