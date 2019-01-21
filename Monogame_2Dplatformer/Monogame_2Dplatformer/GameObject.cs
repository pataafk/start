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
    class GameObject
    {
        protected Vector2 vector;
        protected Texture2D texture;

        public GameObject(Texture2D texture, float X, float Y)
        {
            this.texture = texture;
            this.vector.X = X;
            this.vector.Y = Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Rectangle destRect = new Rectangle(0, 0, Convert.ToInt32(texture.Width), Convert.ToInt32(texture.Height));
            //spriteBatch.Draw(texture, vector, Color.White);
            //spriteBatch.Draw(texture, vector, destRect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public float X { get { return vector.X; } }
        public float Y { get { return vector.Y; } }
        public float Width { get { return texture.Width; } }
        public float Height { get { return texture.Height; } }
    }
}
