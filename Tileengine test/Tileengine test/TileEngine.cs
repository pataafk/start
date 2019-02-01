using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tileengine_test
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
        Tile tile;
        private int viewportWidth, viewportHeight;

        public override void Initialize()
        {

            tiles = new List<Tile>();

            viewportWidth = Game.GraphicsDevice.Viewport.Width;
            viewportHeight = Game.GraphicsDevice.Viewport.Height;


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

            int startX = (int)((CameraPosition.X) / TileWidth);
            int startY = (int)((CameraPosition.Y) / TileHeight);

            int endX = (int)(startX + viewportWidth / TileWidth) + 1;
            int endY = (int)(startY + viewportHeight / TileHeight) + 1;

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
                    position.X = (x * TileWidth);
                    position.Y = (y * TileHeight);

                    Tiletype type;
                    if (Data[y, x] == 0)
                        type = Tiletype.wall;
                    else if (Data[y, x] == 1)
                        type = Tiletype.spikes;
                    else
                        type = Tiletype.wall;

                    Tile tile = new Tile(TileMap, (float)y, (float)x, type);
                    tiles.Add(tile);

                    int index = Data[y, x];
                    Rectangle tileGfx = new Rectangle((index % tilesPerLine) * TileWidth,
                        (index / tilesPerLine) * TileHeight, TileWidth, TileHeight);
                    spriteBatch.Draw(TileMap, position, tileGfx, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
                }
            }

            foreach (Tile t in tiles)
                t.Draw(spriteBatch);

        }

    }
}
/*                   Tiletype type;
                    if (Data[i, j] == 0)
                        type = Tiletype.wall;
                    else if (Data[i, j] == 1)
                        type = Tiletype.spikes;
                    else
                        type = Tiletype.wall;

                    Tile tile = new Tile(TileMap, (float)i, (float)j, type);
                    tiles.Add(tile);*/

/*public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
{
    if (Data == null || TileMap == null)
        return;
 
    int screenCenterX = viewportWidth / 2;
    int screenCenterY = viewportHeight / 2;
 
    int startX = (int)((CameraPosition.X - screenCenterX) / TileWidth);
    int startY = (int)((CameraPosition.Y - screenCenterY) / TileHeight);
 
    int endX = (int)(startX + viewportWidth / TileWidth) + 1;
    int endY = (int)(startY + viewportHeight / TileHeight) + 1;
 
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
            position.X = (x * TileWidth - CameraPosition.X + screenCenterX);
            position.Y = (y * TileHeight - CameraPosition.Y + screenCenterY);
 
            int index = Data[y, x];
            Rectangle tileGfx = new Rectangle((index % tilesPerLine) * TileWidth, 
                (index / tilesPerLine) * TileHeight, TileWidth, TileHeight);
                         
            spriteBatch.Draw(TileMap,
               position, tileGfx, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
        }
    }
}*/
