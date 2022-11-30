using System;
using CrazyArcade.CAFrameWork.InputSystem;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Pirates
{
	public interface IPirate: IGridable, IInputController
	{
		Point PiratePosition => new Point((int)(GameCoord.X + 0.5), (int)(GameCoord.Y + 0.5));
		int RemainingBombs { get; }
		int BlastLength { get; }
	}
}

