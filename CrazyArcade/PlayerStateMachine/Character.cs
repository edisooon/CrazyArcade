using System;

using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.CAFramework;
using CrazyArcade.Blocks;
using System.Diagnostics;

namespace CrazyArcade.Demo1
{
    public abstract class Character : CAEntity, IBlockCollidable
    {

        public float DefaultSpeed = 5;
        public float ModifiedSpeed;
        public Vector2 CurrentSpeed = new(0, 0);
        public Dir direction = Dir.Down;
        public int defaultBlastLength = 1;
        public Vector2 moveInputs = new(0, 0);

        public bool Active { get => blockBboxOn; set { blockBboxOn = value; } }


        public override void Update(GameTime time)
        {

            moveInputs = new(0, 0);
            CurrentSpeed = new(0, 0);
            blockBoundingBox.X = bboxOffset.X + X;
            blockBoundingBox.Y = bboxOffset.Y + Y;
        }

        public void UpdatePosition()
        {
            X += (int)CurrentSpeed.X;
            Y += (int)CurrentSpeed.Y;
            hitbox.X = X;
            hitbox.Y = Y;
        }

        public void CalculateMovement()
        {
            CurrentSpeed = moveInputs * ModifiedSpeed;
        }

        public void CollisionHaltLogic(Point move)
        {
            X -= move.X;
            Y -= move.Y;
        }
    }
}
