
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimationJeux
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keys = new KeyboardState();
        KeyboardState previousKeys = new KeyboardState();
        GameObjectAnime Homura;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            this.graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
            this.graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;


            //this.graphics.ToggleFullScreen();
            this.graphics.ApplyChanges();
            this.Window.Position = new Point(0, 0);

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


            Homura = new GameObjectAnime();
            Homura.direction = Vector2.Zero;
            Homura.vitesse.X = 2;
            Homura.objetState = GameObjectAnime.etats.attenteDroite;
            Homura.position = new Rectangle(350, 250, 65, 65);   //Position initiale de Rambo
            Homura.sprite = Content.Load<Texture2D>("Homura.png");


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


            keys = Keyboard.GetState();
            Homura.position.X += (int)(Homura.vitesse.X * Homura.direction.X);


            if (keys.IsKeyDown(Keys.Right))
            {
                Homura.direction.X = 2;
                Homura.objetState = GameObjectAnime.etats.runDroite;
            }

            if (keys.IsKeyUp(Keys.Right) && previousKeys.IsKeyDown(Keys.Right))
            {
                Homura.direction.X = 0;
                Homura.objetState = GameObjectAnime.etats.attenteDroite;
            }

            if (keys.IsKeyDown(Keys.Left))
            {
                Homura.direction.X = 2;
                Homura.objetState = GameObjectAnime.etats.runGauche;
            }

            if (keys.IsKeyUp(Keys.Right) && previousKeys.IsKeyDown(Keys.Left))
            {
                Homura.direction.X = 0;
                Homura.objetState = GameObjectAnime.etats.attenteGauche;
            }

            //On appelle la méthode Update de Rambo qui permet de gérer les états
            Homura.Update(gameTime);
            previousKeys = keys;
            base.Update(gameTime);
                

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        protected void UpdateHeros()
        {
            if (Homura.position.X < Homura.Left)
            {
                Homura.position.X = Homura.Left;
            }
            if (Homura.position.X + Homura.sprite.Bounds.Width > fenetre.Right)
            {
                Homura.position.X = fenetre.Right - Homura.sprite.Bounds.Width;

            }
            if (Homura.position.Y + Homura.sprite.Bounds.Height > fenetre.Bottom)
            {
                Homura.position.Y = fenetre.Bottom - Homura.sprite.Bounds.Height;
            }
            if (Homura.position.Y < fenetre.Top)
            {
                Homura.position.Y = fenetre.Top;
            }

        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Homura.sprite, Homura.position, Homura.spriteAfficher, Color.White);
            spriteBatch.End();
            base.Draw(gameTime); ;        
           
        }
    }
}
