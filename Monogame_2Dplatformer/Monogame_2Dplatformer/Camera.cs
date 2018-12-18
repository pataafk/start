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
    class Camera
    {
        public Matrix transform; // Matrix Transform
        public Vector2 pos; // Camera Position
        protected float rotation; // Camera Rotation

        public Camera()
        {

            rotation = 0.0f;
            pos = Vector2.Zero;
        }


        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }


        public void Move(Vector2 amount)
        {
            pos += amount;
        }

        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            transform = Matrix.CreateTranslation(new Vector3(-pos.X, -pos.Y, 0)) *
                        Matrix.CreateRotationZ(Rotation) *
                        Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width *
                0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));
            return transform;
        }
    }
}
