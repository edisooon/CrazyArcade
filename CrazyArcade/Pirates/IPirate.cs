using System;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Pirates
{
	public interface IPirate: IGridable
	{
		Vector2 PiratePosition => GameCoord;
	}
}

