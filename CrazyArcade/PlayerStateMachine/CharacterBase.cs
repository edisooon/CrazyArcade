using System;

using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.CAFramework;
using CrazyArcade.Blocks;
using CrazyArcade.GameGridSystems;
using CrazyArcade.CAFrameWork.GridBoxSystem;

namespace CrazyArcade.Demo1
{
    public abstract class CharacterBase : CAEntity, IGridable, IGridBoxReciever
    {
        public float DefaultSpeed = 5;
        public float ModifiedSpeed;
        public Vector2 CurrentSpeed = new(0, 0);
        public int defaultBlastLength = 1;
        public Vector2 moveInputs = new(0, 0);
        private int blockLength = CAGameGridSystems.BlockLength;
        protected Rectangle blockBoundingBox = new Rectangle(0, 0, CAGameGridSystems.BlockLength, CAGameGridSystems.BlockLength);
        protected Point bboxOffset = new Point(2, 27);
        protected bool blockBboxOn = true;
        public Dir direction = Dir.Down;
        public IGridBoxManager manager;
        public IGridBoxManager Manager { get => manager; set => manager = value; }


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
            Vector2 newGameCoord = new Vector2(GameCoord.X, GameCoord.Y);
            newGameCoord += trans.RevScale(CurrentSpeed);

            bool verticallyMove = direction == Dir.Up || direction == Dir.Down, horizontallyMove = direction == Dir.Left || direction == Dir.Right;

            Vector2 center = new Vector2(newGameCoord.X+0.5f, newGameCoord.Y+0.5f);
            Vector2 border1 = new Vector2(direction == Dir.Right ? newGameCoord.X + 1 : newGameCoord.X, direction == Dir.Down ? newGameCoord.Y + 1 : newGameCoord.Y);
            Vector2 border2 = new Vector2(verticallyMove ? border1.X+1 : border1.X, horizontallyMove ? border1.Y+1 : border1.Y);

            bool slideToUpOrLeft = manager.CheckAvailable(new GridBoxPosition(border1, (int)GridObjectDepth.Box));
            bool slideToDownOrRight = manager.CheckAvailable(new GridBoxPosition(border2, (int)GridObjectDepth.Box));
            bool couldMoveFree = slideToUpOrLeft && slideToDownOrRight;
            bool couldMoveThrough = slideToUpOrLeft && (verticallyMove ? border1.X==(int)border1.X : border1.Y==(int)border1.Y);

            float slidingSpeed = 1.0f * ModifiedSpeed / blockLength;

            if (couldMoveFree || couldMoveThrough) GameCoord = newGameCoord;
            else if (slideToUpOrLeft)
            {
                if (verticallyMove)
                {
                    if(GameCoord.X-(int)GameCoord.X>=slidingSpeed)   GameCoord = new Vector2(GameCoord.X - slidingSpeed, GameCoord.Y);
                    else GameCoord = new Vector2((int)GameCoord.X, GameCoord.Y);
                }
                else
                {
                    if (GameCoord.Y - (int)GameCoord.Y >= slidingSpeed) GameCoord = new Vector2(GameCoord.X, GameCoord.Y - slidingSpeed);
                    else GameCoord = new Vector2(GameCoord.X, (int)GameCoord.Y);
                }
            }
            else if (slideToDownOrRight)
            {
                if (verticallyMove)
                {
                    if ((int)GameCoord.X + 1 - GameCoord.X >= slidingSpeed) GameCoord = new Vector2(GameCoord.X + slidingSpeed, GameCoord.Y);
                    else GameCoord = new Vector2((int)GameCoord.X + 1, GameCoord.Y);
                }
                else
                {
                    if ((int)GameCoord.Y + 1 - GameCoord.Y >= slidingSpeed) GameCoord = new Vector2(GameCoord.X, GameCoord.Y + slidingSpeed);
                    else GameCoord = new Vector2(GameCoord.X, (int)GameCoord.Y + 1);
                }
            }

            //switch (direction)
            //{
            //    case Dir.Up:
            //        i
            //        break;
            //    case Dir.Down:
            //        //newGameCoord.X += CAGameGridSystems.BlockLength / 2;
            //        center.Y += 1;
            //        break;
            //    case Dir.Left:
            //        //newGameCoord.Y += CAGameGridSystems.BlockLength / 2;
            //        break;
            //    case Dir.Right:
            //        center.X += 1;
            //        //newGameCoord.Y += CAGameGridSystems.BlockLength / 2;
            //        break;
            //}
            //switch (direction)
            //{
            //    case Dir.Up:
            //        //newGameCoord.X += CAGameGridSystems.BlockLength / 2;
            //        break;
            //    case Dir.Down:
            //        //newGameCoord.X += CAGameGridSystems.BlockLength / 2;
            //        center.Y += 1;
            //        break;
            //    case Dir.Left:
            //        //newGameCoord.Y += CAGameGridSystems.BlockLength / 2;
            //        break;
            //    case Dir.Right:
            //        center.X += 1;
            //        //newGameCoord.Y += CAGameGridSystems.BlockLength / 2;
            //        break;
            //}
            //else
            //if(direction == Dir.Down)   newGameCoord.
            //manager.CheckAvailable(new GridBoxPosition();
            //GameCoord += trans.RevScale(CurrentSpeed);
        }

        public void CalculateMovement()
        {
            CurrentSpeed = moveInputs * ModifiedSpeed;
        }
    }
}
