using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.GameGridSystems
{
	public interface IGridable
	{
		IGridTransform Trans { get; set; } //helper method for entities to use
		Vector2 ScreenCoord { get; set; } 
        Vector2 GameCoord { get; set; }
    }
}

