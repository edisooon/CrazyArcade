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
		public int X;
		public int Y;
        public int Depth;
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
			//Console.WriteLine("new position:" + X + "," + Y);
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

