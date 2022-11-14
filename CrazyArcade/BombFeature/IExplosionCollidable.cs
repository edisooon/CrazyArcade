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

/*
 *	000000000000000000
 *  000000001000000000
 *	000000002000000000
 *  000000001000000000
 *  000000000000000000
 *  000000002000000000
 *  000000000000000000
 *  000000000000000000
 * 
 * 
 */