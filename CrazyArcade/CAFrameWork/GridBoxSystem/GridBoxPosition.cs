using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	enum GridObjectDepth
	{
		Box,
		Tile
	}
	public struct GridBoxPosition
	{
		int X;
		int Y;
		int Depth;
        public GridBoxPosition(int x, int y, int depth)
        {
			X = x;
			Y = y;
			Depth = depth;
        }
        public GridBoxPosition(Vector2 grid, int depth)
		{
			X = (int)grid.X;
			Y = (int)grid.Y;
			Depth = depth;
		}
		public void Copy(GridBoxPosition position)
		{
			X = position.X;
			Y = position.Y;
			Depth = position.Depth;
		}
	}
}

