using System;
namespace CrazyArcade.CAFramework
{
	public interface ISceneDelegate
	{
		void ToAddEntity(IEntity entity);
		void ToRemoveEntity(IEntity entity);
	}
}

