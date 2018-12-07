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
        Player player;
        World world;
        Camera cam;
        PhysicalObject collision;
        Tile tile;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            world = new World(this);

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
            cam = new Camera();
 

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

                
            // TODO: use this.Content to load your game content here
            player = new Player(Content.Load<Texture2D>("Mario"), 450, 280, 1f, 1f);
            world.TileMap = Content.Load<Texture2D>("temp");
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
            if (state.IsKeyDown(Keys.Down))
                world.CameraPosition += new Vector2(0, 3.0f);
            if (state.IsKeyDown(Keys.Up))
                world.CameraPosition += new Vector2(0, -3.0f);
            if (state.IsKeyDown(Keys.Left))
                world.CameraPosition += new Vector2(-1.0f, 0);
            if (state.IsKeyDown(Keys.Right))
                world.CameraPosition += new Vector2(1.0f, 0);
            



                

            // TODO: Add your update logic here
            // Positionera vår kamera till mitten av vår tile rendering
            cam.Pos = new Vector2(player.X , player.Y);

            player.Update(Window);

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
            

            spriteBatch.Begin(SpriteSortMode.FrontToBack,
            BlendState.AlphaBlend,
            SamplerState.LinearWrap,
            DepthStencilState.Default,
            RasterizerState.CullNone,
            null,

            cam.get_transformation(GraphicsDevice));

            //spriteBatch.Draw(mario, Vector2.Zero, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            world.Draw(gameTime, spriteBatch);
            player.Draw(spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
     
    }
}
