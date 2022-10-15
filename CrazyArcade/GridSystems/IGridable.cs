using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.GameGridSystems
{
	public interface IGridable
	{
		Vector2 ScreenCoord { get; set; }
        Vector2 GameCoord { get; set; }
    }
}

