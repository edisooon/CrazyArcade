using System;
using CrazyArcade.CAFrameWork.EntityBehaviors;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork
{
	public class GridEntity: Entity, IGridTransformable
	{
		public GridEntity()
		{
        }
        private Point gridPosition;
        public override Rectangle Frame
        {
            get => Transform.Trans(gridPosition);
        }
        public virtual IGridTransform Transform => throw new NotImplementedException();
    }
}

