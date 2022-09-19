using System;
namespace CrazyArcade.CAFrameWork.EntityBehaviors
{
	public interface IMovable: IEntity
	{
        IMovableBehavior MovableBehavior { get; }
    }
}

