using System;
using CrazyArcade.CAFramework;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.BombFeature
{
	public interface IExplosion: IGridable, IEntity
	{
		int Distance { get; }
		Point Center { get; }
	}
}

