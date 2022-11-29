using System;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.GameGridSystems;
using CrazyArcade.PlayerStateMachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFrameWork.Transition
{
    public class Door : CAEntity, IGridable, IPlayerCollidable
    {
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
			this.X = (int)value.X;
			this.Y = (int)value.Y;
		}
		public Vector2 GameCoord
		{
			get => gamePos;
			set
			{
				gamePos = value;
				ScreenCoord = trans.Trans(value);
			}
		}
		private IGridTransform trans = new NullTransform();
		public IGridTransform Trans { get => trans; set => trans = value; }

        public Rectangle boundingBox => new Rectangle((int)ScreenCoord.X, (int)ScreenCoord.Y, 80, 80);

        //----------IGridable End------------
        bool isEnable = false;
        bool isOpen = false;
        private int stage;
        private Dir dir;
        private static Rectangle source = new Rectangle(0, 0, 80, 80);
        protected SpriteAnimation spriteAnimation;
		public override SpriteAnimation SpriteAnim => this.spriteAnimation;

		public Door(Vector2 position, int to, Dir dir) {
            stage = to;
            this.dir = dir;
			spriteAnimation = new SpriteAnimation(Content.TextureSingleton.GetDoorClose(), source);
			GameCoord = position;
		}

		public override void Load()
		{

		}
		public override void Update(GameTime time)
        {
            base.Update(time);
            if (SceneDelegate.IsDoorOpen() && !isOpen)
            {
                spriteAnimation = new SpriteAnimation(Content.TextureSingleton.GetDoorOpen(), source);
                isOpen = true;
            }
        }
        public void toNextLevel()
        {
            Console.WriteLine("Door transit to: " + stage);
            if (SceneDelegate.IsDoorOpen())
            {
                SceneDelegate.Transition(stage, dir);
            }
        }

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
		{
			toNextLevel();
		}
    }
}

