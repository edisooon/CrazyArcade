using System;
using CrazyArcade.Blocks;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.Transition
{
	public class Door: CAGridBoxEntity, IPlayerCollidable
    {
		public Door(GridBoxPosition position): base(position)
        {
		}
        //---------------Gridable Start------------------
        private Vector2 gamePos;
        private Vector2 pos;
        public override Vector2 ScreenCoord
        {
            get => pos;
            set
            {
                pos = value;
                this.UpdateCoord(value);
            }
        }
        private IGridTransform trans = new NullTransform();
        public override IGridTransform Trans { get => trans; set => trans = value; }

        public void UpdateCoord(Vector2 value)
        {
            this.X = (int)value.X;
            this.Y = (int)value.Y;
        }

        public override Vector2 GameCoord { get => gamePos; set => gamePos = value; }

        public Rectangle boundingBox => new Rectangle();

        //---------------Gridable End------------------
        public override void Load()
        {
            
        }

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {

        }
    }
}

