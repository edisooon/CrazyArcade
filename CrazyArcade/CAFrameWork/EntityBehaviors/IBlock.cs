using System;
namespace CrazyArcade.CAFrameWork.EntityBehaviors
{
	public interface IBlock: IGridTransformable
	{
		public IBlockBehavior BlockBehavior { get; }
    }
}

