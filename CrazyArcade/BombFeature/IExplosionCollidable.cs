using System;
using CrazyArcade.GameGridSystems;

namespace CrazyArcade.BombFeature
{
	public interface IExplosinoCollidable: IGridable
	{
		void Collide(IExplosion bomb);
	}
}

