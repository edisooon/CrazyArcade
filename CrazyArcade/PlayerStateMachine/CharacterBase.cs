using System;

using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.CAFramework;
using CrazyArcade.Blocks;
using CrazyArcade.GameGridSystems;

namespace CrazyArcade.Demo1
{
    public abstract class CharacterBase : CAEntity, IGridable
    {
        public float DefaultSpeed = 5;
        public float ModifiedSpeed;
        public Vector2 CurrentSpeed = new(0, 0);
        public int defaultBlastLength = 1;
        public Vector2 moveInputs = new(0, 0);
        protected Rectangle blockBoundingBox = new Rectangle(0, 0, 30, 30);
        protected Point bboxOffset = new Point(6, 27);
        protected bool blockBboxOn = true;


        //----------IGridable Start------------
        private Vector2 gamePos;
        private Vector2 pos;
        public Vector2 ScreenCoord 
        {
            get => pos;
            set
            {
                pos = value;
                this.UpdateCoord(value);
            }
        }
        public void UpdateCoord(Vector2 value)
        {
            this.X = (int)value.X - bboxOffset.X;
            this.Y = (int)value.Y - bboxOffset.Y;
            blockBoundingBox.X = (int)value.X;
            blockBoundingBox.Y = (int)value.Y;
        }
        public Vector2 GameCoord {
            get => gamePos;
            set {
                gamePos = value;
                ScreenCoord = trans.Trans(value);
            }
        }
        private IGridTransform trans = new NullTransform();
        public IGridTransform Trans { get => trans; set => trans = value; }
        //----------IGridable End------------

        public Rectangle blockCollisionBoundingBox => blockBoundingBox;

        public bool Active { get => blockBboxOn; set { blockBboxOn = value; } }


        public override void Update(GameTime time)
        {
            moveInputs = new(0, 0);
            CurrentSpeed = new(0, 0);
        }

        public void UpdatePosition()
        {
            GameCoord += trans.RevScale(CurrentSpeed);
        }

        public void CalculateMovement()
        {
            CurrentSpeed = moveInputs * ModifiedSpeed;
        }
    }
}
