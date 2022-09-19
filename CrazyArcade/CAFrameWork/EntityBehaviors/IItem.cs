using System;
namespace CrazyArcade.CAFrameWork.EntityBehaviors
{
	public interface IItem : IEntity
	{
		Entity addBuffTo(Entity entity);
	}
}

