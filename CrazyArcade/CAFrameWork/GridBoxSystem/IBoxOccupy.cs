using System;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	public interface IBoxOccupy: IGridable
	{
		Point GetOccupiedBox()
		{
			Vector2 vec = (GameCoord + new Vector2(0.5f, 0.5f));
			return new Point((int)vec.X, (int)vec.Y);
		}
	}
}

