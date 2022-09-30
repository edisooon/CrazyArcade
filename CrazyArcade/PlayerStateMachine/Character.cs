using System;
using CrazyArcade.CAFrameWork;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.CAFramework;

namespace CrazyArcade.Demo1
{
    public abstract class Character : CAEntity
    {

        public float DefaultSpeed = 5;
        public float ModifiedSpeed;
        public Vector2 CurrentSpeed = new(0, 0);
        public Dir direction = Dir.Down;
        public int defaultBlastLength = 1;
        public Vector2 moveInputs = new(0, 0);


        public override void Update(GameTime time)
        {

            moveInputs = new(0, 0);
            CurrentSpeed = new(0, 0);
        }

        public void UpdatePosition()
        {
            X += (int)CurrentSpeed.X;
            Y += (int)CurrentSpeed.Y;
        }

        public void CalculateMovement()
        {
            CurrentSpeed = moveInputs * ModifiedSpeed;
        }
    }
}
