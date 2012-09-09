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
    public class Bullet : GameComponent
    {
        const float Speed = 6;

        Vector2 position;
        float direction;
        Texture2D sprite;

        /// <summary>
        /// Bullet Constructor
        /// </summary>
        /// <param name="game">
        /// Game this bullet belongs to
        /// </param>
        /// <param name="inPosition">
        /// Starting position
        /// </param>
        /// <param name="inDirection">
        /// Starting direction
        /// </param>
        public Bullet(TankWars game, Vector2 inPosition, float inDirection) : base(game)
        {
            sprite = game.Content.Load<Texture2D>("Bullet");

            direction = inDirection;
            position = inPosition;
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
            position.X += (float)Math.Cos((float)direction) * Speed;
            position.Y += (float)Math.Sin((float)direction) * Speed;
        }
    }
}
