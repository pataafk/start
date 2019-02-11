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
    enum Tiletype
    {
        spikes, wall, exit
    }
    class Tile : GameObject
    {
        public Tiletype type;


        public Tile(Texture2D texture, float X, float Y, Tiletype type) : base(texture, X, Y)
        {

            this.type = type;
        }

    }
    class TileEngine : GameComponent
    {
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int[,] Data { get; set; }
        public static Texture2D TileMap { get; set; }
        public Vector2 CameraPosition { get; set; }
        protected List<Tile> tiles;


        public override void Initialize()
        {

            tiles = new List<Tile>();


            base.Initialize();
        }

        public TileEngine(Game game) : base(game)
        {
            game.Components.Add(this);
                
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Data == null || TileMap == null)
                return;

            Vector2 position = Vector2.Zero;
            int tilesPerLine = TileMap.Width / TileWidth;

            for (int y = 0; y < Data.GetLength(0); y++)
            {
                for (int x = 0; x < Data.GetLength(1); x++)
                {
                    position.X = (x * TileWidth);
                    position.Y = (y * TileHeight);

                    Tiletype type;
                    if (Data[y, x] == 0)
                        type = Tiletype.wall;
                    else if (Data[y, x] == 1)
                        type = Tiletype.spikes;
                    else
                        type = Tiletype.wall;


                    int index = Data[y, x];
                    Rectangle tileGfx = new Rectangle((index % tilesPerLine) * TileWidth,
                        (index / tilesPerLine) * TileHeight, TileWidth, TileHeight);
                    spriteBatch.Draw(TileMap, position, tileGfx, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);

                }
            }


        }

    }


    /*


    int startX = (int)((CameraPosition.X));
    int startY = (int)((CameraPosition.Y));

    int endX = (int)(startX + viewportWidth) + 1;
    int endY = (int)(startY + viewportHeight) + 1;

    if (startX < 0)
        startX = 0;
    if (startY < 0)
        startY = 0;

    Vector2 position = Vector2.Zero;
    int tilesPerLine = TileMap.Width / TileWidth;

    for (int y = startY; y < Data.GetLength(0) && y <= endY; y++)
    {
        for (int x = startX; x < Data.GetLength(1) && x <= endX; x++)
        {
            position.X = (x * TileWidth - CameraPosition.X);
            position.Y = (y * TileHeight - CameraPosition.Y);

            int index = Data[y, x];
            Rectangle tileGfx = new Rectangle((index % tilesPerLine) * TileWidth,
                (index / tilesPerLine) * TileHeight, TileWidth, TileHeight);

            spriteBatch.Draw(TileMap,
               position, tileGfx, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
        }
    }
    */
}
