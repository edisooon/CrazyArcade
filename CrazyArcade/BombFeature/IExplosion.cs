using System;
using CrazyArcade.CAFramework;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.BombFeature
{
	public interface IExplosion: IGridable, IEntity
	{
		/*
		 *	Distance away from center.
		 *		e.g.Distance = 1, then it is:
		 *			 0
		 *			000
		 *			 0
		 *			Distance = 2, then it is:
		 *			  0
		 *			  0
		 *			00000
		 *			  0
		 *			  0
		 */
		int Distance { get; }

		/*
		 *	Uses GameCoordinate
		 */
		Point Center { get; }
	}
}

