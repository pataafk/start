﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tileengine_test
{
    class GameElements
    {
        static Texture2D menuSprite;
        static Vector2 menuPos;
        static TileEngine world;
        static GameObject mySprite;


        //Olika gamestates
        public enum State { Menu, Run, HighScore, Quit };
        public static State currentState;

        public void Gameelements()
        {
            
        }

        public static void Initialize()
        {
            // TODO: Add your initialization logic here



        }

        public static void LoadContent(ContentManager content, GameWindow window)
        {
            // loadable content like sprite, maps and menu
            menuSprite = content.Load<Texture2D>("menu");
            menuPos.X = window.ClientBounds.Width / 2 - menuSprite.Width / 2;
            menuPos.Y = window.ClientBounds.Height / 2 - menuSprite.Height / 2;
            TileEngine.TileMap = content.Load<Texture2D>("temp");


            GameObject mySprite = new GameObject { Texture = content.Load("temp"), Position = new Vector2(100, 50) };
        }

        public static State MenuUpdate()
        {
            //menu
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.S))
                return State.Run;
            if (keyboardState.IsKeyDown(Keys.H))
                return State.HighScore;
            if (keyboardState.IsKeyDown(Keys.A))
                return State.Quit;

            return State.Menu;

        }

        public static void MenuDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuSprite, menuPos, Color.White);
        }

        public static State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        {
            //Updatera spelarens position
            world.TileHeight = 32;
            world.TileWidth = 32;
            world.Data = new int[,]
               {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,0},
                {0,1,0,0,1,0,0,0,0,0,1,0,1,1,1,0,0,0,1,0,0,1,0,0,1,1,1,0},
                {0,1,0,0,1,1,1,1,1,0,1,0,1,1,1,0,0,0,1,0,0,1,0,0,1,1,1,0},
                {0,1,0,0,1,0,0,0,0,0,1,0,1,1,1,0,0,1,1,0,0,1,0,0,1,1,1,0},
                {0,1,0,1,1,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,1,0,0,0,1,1,0},
                {0,1,0,1,1,1,1,1,0,0,0,0,0,1,0,1,1,1,1,1,1,1,0,1,0,1,1,0},
                {0,1,0,0,1,0,0,1,1,1,1,0,0,1,0,0,0,0,1,0,0,0,0,1,0,1,0,0},
                {0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,1,1,1,0,1,0,0},
                {0,1,1,1,0,1,1,1,1,1,1,0,0,1,0,1,1,1,1,1,1,0,0,1,0,1,1,0},
                {0,1,1,1,0,1,0,0,0,0,1,0,0,1,0,1,0,1,1,1,1,0,0,1,0,0,1,0},
                {0,1,1,1,0,1,0,1,1,1,1,0,0,1,0,1,0,0,0,0,0,0,1,1,1,0,1,0},
                {0,1,1,1,0,1,0,1,0,0,0,0,0,1,0,1,0,1,1,1,0,0,0,1,0,0,1,0},
                {0,1,1,1,0,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,0,0,1,0,0,1,0},
                {0,1,1,1,0,1,0,0,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,0,1,0},
                {0,1,0,0,0,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0,0,0,0,1,0},
                {0,1,0,0,0,1,0,1,0,0,0,0,0,1,0,1,0,1,0,1,1,1,1,1,0,0,1,0},
                {0,1,0,0,0,1,0,1,1,1,1,1,1,1,0,0,0,1,0,0,1,1,0,1,0,1,1,0},
                {0,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,1,1,0,1,1,1,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
            return State.Run;
        }

        public static void RunDraw(SpriteBatch spriteBatch, GameTime gameTime)
        {


        }

        public static State HighScoreUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            // Återgå till menyn
            if (keyboardState.IsKeyDown(Keys.Escape))
                return State.Menu;
            return State.HighScore;
        }

        public static void HighScoreDraw(SpriteBatch spriteBatch)
        {

        }
    }
}