using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Utilities
{
	public class Vectors
	{
		public static Vector2 ContructFromPoint(Point point)
		{
			return new Vector2(point.X, point.Y);
		}
	}
}

