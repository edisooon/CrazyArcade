using System;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Pirates
{
	public interface IPirate: IGridable
	{
		Point PiratePosition => new Point((int)GameCoord.X, (int)GameCoord.Y);
		int RemainingBombs { get; }
		int BlastLength { get; }
	}
}

