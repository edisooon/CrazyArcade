using System;
namespace CrazyArcade.CAFrameWork.EntityBehaviors
{
	public interface IProjectile
	{
		IProjectileBehavior ProjectileBehavior { get; }
	}
}

