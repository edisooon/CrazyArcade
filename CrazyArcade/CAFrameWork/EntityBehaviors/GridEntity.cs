using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFrameWork.EntityBehaviors
{
	public abstract class GridEntity: Entity, IGridTransformable
	{
		public GridEntity()
		{
		}
        public override Rectangle Frame { get => Transform.Trans(GridX, GridY); }
        public abstract IGridTransform Transform { get; }
        double gridX;
        double gridY;
        public double GridX { get => gridX; set => gridX = value; }
        public double GridY { get => gridY; set => gridY = value; }
    }
}

