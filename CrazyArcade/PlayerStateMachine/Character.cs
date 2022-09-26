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
	public abstract class Character: CAEntity
	{

        protected float DefaultSpeed = 5;
        protected Vector2 CurrentSpeed = new(0,0);
        protected Dir direction = Dir.Down;
        protected int defaultBlastLength = 1;
        protected Vector2 moveInputs = new(0,0);


        public override void Update(GameTime time)
        {
            CalculateMovement();
            UpdatePosition();
            moveInputs = new(0,0);
        }

        public void UpdatePosition()
        {
            X += (int) CurrentSpeed.X;
            Y += (int) CurrentSpeed.Y;
        }

        public void CalculateMovement()
        {
            CurrentSpeed = moveInputs * DefaultSpeed;
        }
    }
}

