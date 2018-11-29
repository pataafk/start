﻿using System;
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
        ground, wall, exit
    }
    class Tile : GameObject
    {
        protected int TileWidth { get; set; }
        protected int TileHeight { get; set; }
        public Tiletype type;

        public Tile(Texture2D texture, float X, float Y, Tiletype type):base(texture, X, Y)
        {
            TileHeight = 32;
            TileWidth = 32;

        }
        /*
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }
        */
    }
    class World : GameComponent
    {
        public int[,] Data { get; set; }
        public Texture2D TileMap { get; set; }
        public Vector2 CameraPosition { get; set; }
        protected List<Tile> tiles;

        private int viewportWidth, viewportHeight;

        public override void Initialize()
        {
            viewportWidth = Game.GraphicsDevice.Viewport.Width;
            viewportHeight = Game.GraphicsDevice.Viewport.Height;

            tiles = new List<Tile>();

            Data = new int[,]
               {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,0,1,1,0,0,1,1,1,1,1,1,0,0},
                {0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,0,0,0,1,0,0,1,0,0,1,1,1,0,0},
                {0,1,0,0,1,1,1,1,1,0,1,0,1,1,1,0,0,0,1,0,0,1,0,0,1,1,1,0,0},
                {0,1,0,0,1,0,0,0,0,0,1,0,1,1,1,0,0,1,1,0,0,1,0,0,1,1,1,0,0},
                {0,1,0,1,1,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,1,0,0,0,1,1,0,0},
                {0,1,0,1,1,1,1,1,0,0,0,0,0,1,0,1,1,1,1,1,1,1,0,1,0,1,1,0,0},
                {0,1,0,0,1,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0,0,0,0,1,0,1,0,0,0},
                {0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,1,1,1,0,1,0,0,0},
                {0,1,1,1,0,1,1,1,1,1,1,0,0,1,0,1,1,1,1,1,1,0,0,1,0,1,1,0,0},
                {0,1,1,1,0,1,0,0,0,0,1,0,0,1,0,1,0,1,1,1,1,0,0,1,0,0,1,0,0},
                {0,1,1,1,0,1,0,1,1,1,1,0,0,1,0,1,0,0,0,0,0,0,1,1,1,0,1,0,0},
                {0,1,1,1,0,1,0,1,0,0,0,0,0,1,0,1,0,1,1,1,0,0,0,1,0,0,1,0,0},
                {0,1,1,1,0,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,0,0,1,0,0,1,0,0},
                {0,1,1,1,0,1,0,0,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,0,1,0,0},
                {0,1,0,0,0,1,0,1,1,1,1,1,0,1,0,1,0,0,0,1,0,1,0,0,0,0,1,0,0},
                {0,1,0,0,0,1,0,1,0,0,0,0,0,1,0,1,0,1,0,1,1,1,1,1,0,0,1,0,0},
                {0,1,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0},
                {0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                {0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};

            for(int i=0; i < Data.GetLength(0); i++)
            {
                for(int j=0; j < Data.GetLength(1); j++)
                {
                    Tiletype type;
                    if (Data[i, j] == 0)
                        type = Tiletype.wall;
                    else if (Data[i, j] == 1)
                        type = Tiletype.ground;

                    Tile temp = new Tile(TileMap, (float)i, (float)j, type);
                        
                }
            }

            base.Initialize();
        }

        public World(Game game) : base(game)
        {
            game.Components.Add(this);
            CameraPosition = Vector2.Zero;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
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
        }
    
    }
}