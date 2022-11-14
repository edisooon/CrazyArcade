using System;
using CrazyArcade.CAFramework;
using CrazyArcade.GameGridSystems;

namespace CrazyArcade.BombFeature
{
	public interface IExplosionCollidable: IGridable, IEntity
	{
		bool Collide(IExplosion bomb);
	}
}
