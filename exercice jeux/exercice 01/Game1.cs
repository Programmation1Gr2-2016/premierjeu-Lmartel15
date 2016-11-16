using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace exercice_01
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle fenetre;
        GameObject heros;
        GameObject mechant;
        GameObject projectile;

        public Game1()
        {
            SoundEffect son;

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
            fenetre = graphics.GraphicsDevice.Viewport.Bounds;
            fenetre.Width = graphics.GraphicsDevice.DisplayMode.Width;
            fenetre.Height = graphics.GraphicsDevice.DisplayMode.Height;

            Song = Content.Load<Song>("Sounds\\Musique");
            MediaPlayer.Play(song);

            mechant = new GameObject();
            mechant.estVivant = true;
            mechant.vitesse = 5;
            mechant.sprite = Content.Load<Texture2D>("trump.png");
            mechant.position = mechant.sprite.Bounds;

            projectile = new GameObject();
            projectile.estVivant = false;
            projectile.vitesse = 12;
            projectile.sprite = Content.Load<Texture2D>("trumpface.png");
            projectile.position = projectile.sprite.Bounds;
            

            heros = new GameObject();
            heros.estVivant = true;
            heros.vitesse = 8;
            heros.sprite = Content.Load<Texture2D>("mario.png");
            heros.position = heros.sprite.Bounds;

            


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
        public static int dir { get; set; }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                heros.position.X += heros.vitesse;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                heros.position.X -= heros.vitesse;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                heros.position.Y -= heros.vitesse;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                heros.position.Y += heros.vitesse;
            }

            base.Update(gameTime);
            UpdateHeros();
            updatemechant();
            Updateprojectile();
        }
        protected void UpdateHeros()
        {
            if (heros.position.X < fenetre.Left)
            {
                heros.position.X = fenetre.Left;
            }
            if (heros.position.X+heros.sprite.Bounds.Width > fenetre.Right)
            {
                heros.position.X = fenetre.Right - heros.sprite.Bounds.Width;
                
            }
            if (heros.position.Y + heros.sprite.Bounds.Height > fenetre.Bottom)
            {
                heros.position.Y = fenetre.Bottom- heros.sprite.Bounds.Height;
            }
            if (heros.position.Y < fenetre.Top)
            {
                heros.position.Y = fenetre.Top;
            }
            
        }


        protected void updatemechant()
        {
            if (mechant.position.X < fenetre.Left)
            {
                mechant.position.X += mechant.vitesse;
                dir = 0;
            }
            else if (mechant.position.X + mechant.sprite.Bounds.Width > fenetre.Right)
            {
                mechant.position.X -= mechant.vitesse;
                dir = 1;
            }
            else if (dir == 0)
            {
                mechant.position.X += mechant.vitesse;
            }
            else if (dir == 1)
            {
                mechant.position.X -= mechant.vitesse;
            }

        }
        
            protected void Updateprojectile()
        {



            if (projectile.position.Y  > fenetre.Bottom)
            {
                projectile.estVivant=false;
            }
             if (projectile.estVivant)
            {
                projectile.position.Y += projectile.vitesse;
            }
            if (!projectile.estVivant)
            {
                projectile.estVivant = true;
                projectile.position = mechant.position;
            }
        }
          
        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(heros.sprite, heros.position, Color.White);
         
            spriteBatch.Draw(mechant.sprite, mechant.position, Color.White);
            if (projectile.estVivant)
            {
                spriteBatch.Draw(projectile.sprite, projectile.position, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
