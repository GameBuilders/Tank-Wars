using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tank_Wars
{
    /// <summary>
    /// Tank class
    /// </summary>
    public class Tank : GameComponent
    {
        //constants
        const float Speed = 2;
        const float TurnSpeed = .05F;
        const int ReloadTime = 20;
        const float CannonDistanceFromCenter = 27;

        Vector2 position;
        float direction;
        Texture2D sprite;
        TankWars game;

        //Holds keys to check for movement
        //and firing
        Keys forward;
        Keys backward;
        Keys turnLeft;
        Keys turnRight;
        Keys fire;

        //cannon variables
        int reloadTime; //remaining time till reloaded

        /// <summary>
        /// Tank Constructor
        /// <param name="inGame">
        /// Game this tank belongs to
        /// </param> 
        /// <param name="playerNumber">
        /// Sets whether tank is tank 1 or tank 2
        /// </param>
        /// </summary>
        public Tank(TankWars inGame, Byte playerNumber) : base(inGame)
        {
            game = inGame;
            sprite = game.Content.Load<Texture2D>("Tank");
            direction = 0;

            switch (playerNumber)
            {
                case 1:
                    forward = Keys.Up;
                    backward = Keys.Down;
                    turnLeft = Keys.Left;
                    turnRight = Keys.Right;
                    fire = Keys.Space;
                    break;

                case 2:
                    forward = Keys.W;
                    backward = Keys.S;
                    turnLeft = Keys.A;
                    turnRight = Keys.D;
                    fire = Keys.LeftShift;
                    break;

            }
        }

        /// <summary>
        /// Position property
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// Facing direction in radians
        /// </summary>
        public float Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
            }
        } 

        /// <summary>
        /// The location of the end of the cannon
        /// </summary>
        public Vector2 CannonEnd
        {
            get
            {
                float xOffset = (float)Math.Cos(direction) * CannonDistanceFromCenter;
                float yOffset = (float)Math.Sin(direction) * CannonDistanceFromCenter;

                return new Vector2(position.X + xOffset, position.Y + yOffset);
            }
        }

        /// <summary>
        /// Readonly sprite property
        /// </summary>
        public Texture2D Sprite
        {
            get
            {
                return sprite;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(forward))
            {
                position.X += (float)Math.Cos((float)direction) * Speed;
                position.Y += (float)Math.Sin((float)direction) * Speed;
            }

            if (keyState.IsKeyDown(backward))
            {
                position.X -= (float)Math.Cos((float)direction) * Speed;
                position.Y -= (float)Math.Sin((float)direction) * Speed;
            }

            if (keyState.IsKeyDown(turnLeft))
            {
                direction += TurnSpeed;
            }

            if (keyState.IsKeyDown(turnRight))
            {
                direction -= TurnSpeed;
            }

            if(keyState.IsKeyDown(fire))
            {
                FireCannon();
            }

            if(reloadTime != 0)
                reloadTime--;
        }

        /// <summary>
        /// Fires the tank's cannon if possible
        /// </summary>
        private void FireCannon()
        {
            if (reloadTime != 0)
                return;

            Bullet bullet = new Bullet(game, CannonEnd, direction);

            game.Components.Add(bullet);
            game.Bullets.Add(bullet);

            reloadTime = ReloadTime;
        }
    }
}
