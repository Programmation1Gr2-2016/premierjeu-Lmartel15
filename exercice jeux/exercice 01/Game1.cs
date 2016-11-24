using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
namespace exercice_01
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        
        GameObject[] ennemis = new GameObject[10];        
        SoundEffect son;
        SoundEffectInstance again;
        SoundEffectInstance NOMA;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle fenetre;
        GameObject heros;       
        GameObject projectile;
        
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

            


            Song song = Content.Load<Song>("songs\\NOMA-BrainPower");           
            MediaPlayer.Play(song);


            spriteBatch = new SpriteBatch(GraphicsDevice);
            fenetre = graphics.GraphicsDevice.Viewport.Bounds;
            fenetre.Width = graphics.GraphicsDevice.DisplayMode.Width;
            fenetre.Height = graphics.GraphicsDevice.DisplayMode.Height;

            for (int i = 0; i < ennemis.Length; i++)
            {
                ennemis[i] = new GameObject();
                ennemis[i].estVivant = true;
                ennemis[i].vitesse = 10;
                ennemis[i].sprite = Content.Load<Texture2D>("bowser.png");
                ennemis[i].position = ennemis[i].sprite.Bounds;
                ennemis[i].position.X = ennemis[i].sprite.Bounds.Width * i;

                //ennemis[i].direction.X = r.Next(-4, 5);
                //ennemis[i].direction.Y = r.Next(-4, 5);

            }

            projectile = new GameObject();
            projectile.estVivant = false;
            projectile.vitesse =10;
            projectile.sprite = Content.Load<Texture2D>("trumpface.png");
            projectile.position = projectile.sprite.Bounds;

            

            heros = new GameObject();
            heros.estVivant = true;
            heros.vitesse = 15;
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
            Updateprojectile();
            Updateennemis();
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

        protected void Updateennemis()
        {



            for (int i = 0; i < ennemis.Length; i++)
            {

                
                if (ennemis[i].position.X < fenetre.Left)
                {
                    ennemis[i].position.X = fenetre.Left;
                }
                else if (ennemis[i].position.X + ennemis[i].sprite.Bounds.Width > fenetre.Right)
                {
                    ennemis[i].position.X = fenetre.Right - ennemis[i].sprite.Bounds.Width;

                }
                else if (ennemis[i].position.Y + ennemis[i].sprite.Bounds.Height > fenetre.Bottom)
                {
                    ennemis[i].position.Y = fenetre.Bottom - ennemis[i].sprite.Bounds.Height;
                }
                else if (ennemis[i].position.Y < fenetre.Top)
                {
                    ennemis[i].position.Y = fenetre.Top;
                }
                ennemis[i].position.X += (int)ennemis[i].direction.X;
                ennemis[i].position.Y += (int)ennemis[i].direction.Y;

            }


        }      
            protected void Updateprojectile()
        {

            for (int i = 0; i < ennemis.Length; i++)
            {


                
                if (projectile.position.Y > fenetre.Bottom)
                {
                    projectile.estVivant = false;
                }
                if (projectile.estVivant)
                {
                    projectile.position.Y += projectile.vitesse;
                }
                if (!projectile.estVivant)
                {
                    projectile.position = ennemis[i].position;
                    projectile.estVivant = true;

                }
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

            for (int i = 0; i < ennemis.Length; i++)
            {
                
                spriteBatch.Draw(ennemis[i].sprite, ennemis[i].position, Color.White);
            }

            
            if (projectile.estVivant)
            {
                spriteBatch.Draw(projectile.sprite, projectile.position, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
