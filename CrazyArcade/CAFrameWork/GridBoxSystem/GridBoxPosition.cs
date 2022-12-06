using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	enum GridObjectDepth
	{
		Box,
		Item,
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
		public GridBoxPosition(Point grid, int depth)
		{
			X = grid.X;
			Y = grid.Y;
			//Console.WriteLine("new position:" + X + "," + Y);
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
		public GridBoxPosition Adj(Dir dir)
		{
			Point[] direction = new Point[]
			{
				new Point(0, -1),
				new Point(-1, 0),
				new Point(0, 1),
				new Point(1, 0)
			};
			return new GridBoxPosition(this.X + direction[(int)dir].X, this.Y + direction[(int)dir].Y, this.Depth);
		}
		public Point toPoint()
		{
			return new Point(this.X, this.Y);
		}
	}
}

