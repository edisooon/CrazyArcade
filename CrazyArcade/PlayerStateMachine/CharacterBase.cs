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
using CrazyArcade.PlayerStateMachine.PlayerItemInteractions;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.PlayerStateMachine;

namespace CrazyArcade.Demo1
{
    public abstract class CharacterBase : CAEntity, IGridable, IGridBoxReciever, IBombCollectable
    {
        public float DefaultSpeed = 5;
        public float ModifiedSpeed;
        public Vector2 CurrentSpeed = new(0, 0);
        public int CurrentBlastLength { get => playerItems.BlastModifier; set { playerItems.BlastModifier = value; } }
        public int BombCapacity { get => playerItems.BombModifier; set { playerItems.BombModifier = value; } }
        public int FreeModifiedSpeed { get => playerItems.SpeedModifier; }
        private int bombOut = 0;
        public int BombsOut => bombOut;
        public ItemContainer playerItems = new();
        public bool CouldKick { get => playerItems.CanKick; }
        public int defaultBlastLength = 1;
        public Vector2 moveInputs = new(0, 0);
        private int blockLength = CAGameGridSystems.BlockLength;
        protected Rectangle blockBoundingBox = new Rectangle(0, 0, CAGameGridSystems.BlockLength, CAGameGridSystems.BlockLength);
        protected Point bboxOffset = new Point(3, 20);
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

        //@Implement IBombCollectable
        public void RecollectBomb()
        {
            bombOut = bombOut-- >= 0 ? bombOut-- : 0;
            Console.WriteLine("Recollect: " + BombsOut);
        }

        public void SpendBomb()
        {
            bombOut++;
            Console.WriteLine("Spend: " + BombsOut);
        }

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
            bool toNewBlock = isToNewBlock(newGameCoord, GameCoord, verticallyMove);
            float slideTriggerPoint = 0.3f;

            Vector2 upLeftBorder = new Vector2(direction == Dir.Right ? newGameCoord.X + 1 : newGameCoord.X, direction == Dir.Down ? newGameCoord.Y + 1 : newGameCoord.Y);
            Vector2 bottomRightBorder = new Vector2(verticallyMove ? upLeftBorder.X+1 : upLeftBorder.X, horizontallyMove ? upLeftBorder.Y+1 : upLeftBorder.Y);

            IGridBox upLeftObstacle = manager.CheckAvailable(new GridBoxPosition(upLeftBorder, (int)GridObjectDepth.Box));
            bool slideToUpOrLeft = upLeftObstacle == null;
            IGridBox downRightObstacle = manager.CheckAvailable(new GridBoxPosition(bottomRightBorder, (int)GridObjectDepth.Box));
            bool slideToDownOrRight = downRightObstacle == null;
            if (toNewBlock)
            {
                // handle the special case of obstacles' behaviors
                // 1) water bomb
                if (CouldKick)
                {
                    if (upLeftObstacle is WaterBomb) characterKickBomb(upLeftObstacle as WaterBomb);
                    if (downRightObstacle is WaterBomb) characterKickBomb(downRightObstacle as WaterBomb);
                }
                // 2) door
                if (upLeftObstacle is Door) characterToNextLevel(upLeftObstacle as Door);
                if (downRightObstacle is Door) characterToNextLevel(downRightObstacle as Door);

            }


            bool couldMoveFree = slideToUpOrLeft && slideToDownOrRight;
            bool couldMoveThrough = slideToUpOrLeft && (verticallyMove ? upLeftBorder.X==(int)upLeftBorder.X : upLeftBorder.Y==(int)upLeftBorder.Y);

            float slidingSpeed = 1.0f * ModifiedSpeed / blockLength;

            // the player would move with CurrentSpeed if 1.is moving inside a block(handling the case when player hasn't left the bomb) 2. is going to a new block but not obstacles ahead 3.edge case of 2
            if (!toNewBlock || couldMoveFree || couldMoveThrough) GameCoord = newGameCoord;
            else if (!slideToDownOrRight && !slideToUpOrLeft)
            {
                // PLAYER has been blocked
                if (horizontallyMove) GameCoord = new Vector2((float)Math.Round(GameCoord.X), GameCoord.Y);
                else GameCoord = new Vector2(GameCoord.X, (float)Math.Round(GameCoord.Y));
            }
            else if (slideToUpOrLeft)
            {
                if (verticallyMove)
                {
                    if ((int)GameCoord.X + 1 - GameCoord.X < slideTriggerPoint) return;
                    if (GameCoord.X - (int)GameCoord.X >= slidingSpeed) GameCoord = new Vector2(GameCoord.X - slidingSpeed, GameCoord.Y);
                    else GameCoord = new Vector2((int)GameCoord.X, GameCoord.Y);
                }
                else if(horizontallyMove)
                {
                    if ((int)GameCoord.Y + 1 - GameCoord.Y < slideTriggerPoint) return;
                    if (GameCoord.Y - (int)GameCoord.Y >= slidingSpeed) GameCoord = new Vector2(GameCoord.X, GameCoord.Y - slidingSpeed);
                    else GameCoord = new Vector2(GameCoord.X, (int)GameCoord.Y);
                }
            }
            else if (slideToDownOrRight)
            {
                if (verticallyMove)
                {
                    if (GameCoord.X - (int)GameCoord.X < slideTriggerPoint) return;
                    if ((int)GameCoord.X + 1 - GameCoord.X >= slidingSpeed) GameCoord = new Vector2(GameCoord.X + slidingSpeed, GameCoord.Y);
                    else GameCoord = new Vector2((int)GameCoord.X + 1, GameCoord.Y);
                }
                else if (horizontallyMove)
                {
                    if (GameCoord.Y - (int)GameCoord.Y < slideTriggerPoint) return;
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

        private void characterToNextLevel(Door door)
        {
            door.toNextLevel();
        }

        private void characterKickBomb(WaterBomb waterBomb)
        {
            waterBomb.kick(direction);
        }

        protected bool putBomb()
        {
            if (this.BombsOut >= this.BombCapacity) return false;
            this.SceneDelegate.ToAddEntity(new WaterBomb(this.GameCoord, this.CurrentBlastLength, this));
            return true;
        }

        private bool isToNewBlock(Vector2 newGameCoord, Vector2 gameCoord, bool verticallyMove)
        {
            float newX = newGameCoord.X, newY = newGameCoord.Y, oldX = gameCoord.X, oldY = gameCoord.Y;
            if (verticallyMove) return (int)oldY == oldY || (int)oldY != (int)newY;
            else return (int)oldX == oldX || (int)oldX != (int)newX;
        }

        public void CalculateMovement()
        {
            CurrentSpeed = moveInputs * ModifiedSpeed;
        }
    }
}
