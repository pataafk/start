using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_2Dplatformer
{
    class GameElements : Game1
    {
        static Texture2D menuSprite;
        static Vector2 menuPos;
        static Player player;
        static TileEngine world;

        //Olika gamestates
        public enum State { Menu, Run, HighScore, Quit };
        public static State currentState;


        public void Gameelements()
        {

            world = new TileEngine(this);
        }

        private static void Initialize()
        {
            // TODO: Add your initialization logic here

            world.TileHeight = 27;
            world.TileWidth = 27;
            world.Data = new int[,]
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

            Initialize();


        }

        public static void LoadContent(ContentManager content, GameWindow window)
        {
            // loadable content like sprite, maps and menu
            menuSprite = content.Load<Texture2D>("menu");
            menuPos.X = window.ClientBounds.Width / 2 - menuSprite.Width / 2;
            menuPos.Y = window.ClientBounds.Height / 2 - menuSprite.Height / 2;
            player = new Player(content.Load<Texture2D>("Mario"), 380, 400, 1f, 1f);
            world.TileMap = content.Load<Texture2D>("temp");

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
         
        public static void MenuDraw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuSprite, menuPos, Color.White);
        }

        public static State RunUpdate (ContentManager content, GameWindow window, GameTime gameTime)
        {
            //Updatera spelarens position
            player.Update(window, gameTime);

            return State.Run;
        }

        public static void RunDraw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            player.Draw(spriteBatch);
            world.Draw(gameTime, spriteBatch);

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
