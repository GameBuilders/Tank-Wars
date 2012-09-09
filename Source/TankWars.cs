using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tank_Wars
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TankWars : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Tank[] tanks = new Tank[2];
        List<Bullet> bullets = new List<Bullet>();
        

        public TankWars()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Bullets property
        /// </summary>
        public List<Bullet> Bullets
        {
            get
            {
                return bullets;
            }
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

            base.Initialize();

            //set timestep
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 60.0);

            //create initial objects
            tanks[0] = new Tank(this, 1);
            tanks[1] = new Tank(this, 2);

            tanks[0].Position = new Vector2(128, 128);
            tanks[1].Position = new Vector2(512, 128);

            Components.Add(tanks[0]);
            Components.Add(tanks[1]);
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
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            spriteBatch.Begin();

            // Draw Tanks
            foreach(Tank tank in tanks)
            {
                spriteBatch.Draw(tank.Sprite, tank.Position, null, Color.White, tank.Direction, new Vector2(tank.Sprite.Width/2.0F, tank.Sprite.Height/2.0F), 1.0F, SpriteEffects.None, 0);
            }

            //Draw Bullets
            foreach (Bullet bullet in bullets)
            {
                spriteBatch.Draw(bullet.Sprite, bullet.Position, null, Color.White, bullet.Direction, new Vector2(bullet.Sprite.Width / 2.0F, bullet.Sprite.Height / 2.0F), 1.0F, SpriteEffects.None, 0);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
