using System;
namespace CrazyArcade.CAFrameWork.EntityBehaviors
{
	public interface ITile: IEntity
	{
		public ITileBehavior TileBehavior { get; }
    }
}

