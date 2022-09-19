using System;
namespace CrazyArcade.CAFrameWork.EntityBehaviors
{
	public interface IDetectable: IEntity
	{
		public IDetectableBehavior Behavior { get; }
	}
}

