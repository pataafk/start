using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_edvin_1
{
    static class GameElements
    {
        static Player player;
        static List<Enemy> enemies;
        static List<GoldCoin> goldCoins;
        static Texture2D goldCoinSprite;
        static PrintText printText;
        static Menu menu;

        public enum State { Menu, Run, Highscore, Quit };
        public static State currentState;


        public static void Initialize()
        {

            goldCoins = new List<GoldCoin>();

        }

        public static void LoadContent(ContentManager content, GameWindow window)
        {

            menu = new Menu((int)State.Menu);
            menu.AddItem(content.Load<Texture2D>("start"), (int)State.Run);
            menu.AddItem(content.Load<Texture2D>("highscore"), (int)State.Highscore);
            menu.AddItem(content.Load<Texture2D>("exit"), (int)State.Quit);

            player = new Player(content.Load<Texture2D>("ship"), 380, 400, 2.5f, 5f, content.Load<Texture2D>("bullet"));
            enemies = new List<Enemy>();
            Random random = new Random();
            Texture2D tmpSprite = content.Load<Texture2D>("mine");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Mine temp = new Mine(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }
            tmpSprite = content.Load<Texture2D>("tripod");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Tripod temp = new Tripod(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }
            printText = new PrintText(content.Load<SpriteFont>("myFont"));
            goldCoinSprite = content.Load<Texture2D>("coin");


        }

        public static State MenuUpdate(GameTime gameTime)
        {
            return (State)menu.Update(gameTime);

        }

        public static void MenuDraw (SpriteBatch spriteBatch)
        {

            menu.Draw(spriteBatch);

        }

        public static State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        {

            player.Update(window, gameTime);
            foreach (Enemy e in enemies.ToList())
            {
                foreach (Bullet b in player.Bullets)
                {
                    if (e.CheckCollision(b))
                    {
                        e.IsAlive = false;
                        player.Points++;
                    }
                }
                if (e.IsAlive)
                {
                    if (e.CheckCollision(player))
                        player.IsAlive = false;
                    e.Update(window);
                }
                else
                    enemies.Remove(e);
            }

                Random random = new Random();
                int newCoin = random.Next(1, 200);
                if (newCoin == 1)
                {
                    int rndX = random.Next(0, window.ClientBounds.Width - goldCoinSprite.Width);
                    int rndY = random.Next(0, window.ClientBounds.Height - goldCoinSprite.Height);

                    goldCoins.Add(new GoldCoin(goldCoinSprite, rndX, rndY, gameTime));
                }
                foreach (GoldCoin gc in goldCoins.ToList())
                {
                    if (gc.IsAlive)
                    {
                        gc.Update(gameTime);

                        if (gc.CheckCollision(player))
                        {
                            goldCoins.Remove(gc);
                            player.Points++;
                        }
                    }
                    else
                        goldCoins.Remove(gc);
                }
            if (!player.IsAlive)
            {

                Reset(window, content);
                return State.Menu;
            }
            return State.Run;

            
        }
        public static void RunDraw (SpriteBatch spriteBatch)
        {

            player.Draw(spriteBatch);
            foreach (Enemy e in enemies)
                e.Draw(spriteBatch);
            printText.Print("antal fiender:" + enemies.Count, spriteBatch, 0, 0);
            foreach (GoldCoin gc in goldCoins)
                gc.Draw(spriteBatch);
            printText.Print("Points:" + player.Points, spriteBatch, 0, 20);

        }

        public static State HighScoreUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                return State.Menu;
            return State.Highscore;


        }

        public static void HighScoreDraw(SpriteBatch spriteBatch)
        {


        }

        private static void Reset (GameWindow window, ContentManager content)
        {
            player.Reset(380, 400, 2.5f, 4.5f);


            enemies.Clear();
            Random random = new Random();
            Texture2D tmpSprite = content.Load<Texture2D>("mine");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Mine temp = new Mine(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }
            tmpSprite = content.Load<Texture2D>("tripod");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Tripod temp = new Tripod(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }
        }
    }
}
