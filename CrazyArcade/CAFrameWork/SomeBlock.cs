using System;
using CrazyArcade.CAFrameWork.EntityBehaviors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFrameWork
{
    //This is an example of how you make a new Entity
	public class SomeGridEntity: Entity, IBlock
	{
		public SomeGridEntity()
		{
        }
        private Point gridPosition;
        public override Rectangle Frame
        {
            get => Transform.Trans(gridPosition);
        }
        //implement IGridTransform
        public virtual IGridTransform Transform => throw new NotImplementedException();

        //implement Sprite
        public override Texture2D Graphics => throw new NotImplementedException();

        public IBlockBehavior BlockBehavior => throw new NotImplementedException();
    }
}

