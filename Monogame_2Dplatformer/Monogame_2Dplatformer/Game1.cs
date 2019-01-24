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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TileEngine world;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            world = new TileEngine(this);

            //Fix to get rid multiple Draw() calls in a row
            //http://forums.create.msdn.com/forums/t/9934.aspx
            IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = true;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            GameElements.currentState = GameElements.State.Menu;
            GameElements.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameElements.LoadContent(Content, Window);


            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState state = Keyboard.GetState();
            switch (GameElements.currentState)
            {
                case GameElements.State.Run:
                    GameElements.currentState = GameElements.RunUpdate(Content, Window, gameTime);
                    break;
                case GameElements.State.HighScore:
                    GameElements.currentState = GameElements.HighScoreUpdate();
                    break;
                case GameElements.State.Quit:
                    this.Exit();
                    break;
                default:
                    GameElements.currentState = GameElements.MenuUpdate();
                    break;
            }

            // TODO: Add your update logic here
            // Positionera vår kamera till mitten av vår tile rendering
           

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //spriteBatch.Draw(mario, Vector2.Zero, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Begin();
            switch (GameElements.currentState)
            {
                case GameElements.State.Run:
                    GameElements.RunDraw(spriteBatch, gameTime);
                    break;
                case GameElements.State.HighScore:
                    GameElements.HighScoreDraw(spriteBatch);
                    break;
                case GameElements.State.Quit:
                    this.Exit();
                    break;
                default:
                    GameElements.MenuDraw(spriteBatch);
                    break;

            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
     
    }
}
