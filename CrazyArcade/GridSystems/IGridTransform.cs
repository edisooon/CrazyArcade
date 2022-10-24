using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.GameGridSystems
{
	public interface IGridTransform
	{
        Vector2 Trans(Vector2 vec);
        Vector2 RevTrans(Vector2 vec);
        Vector2 Scale(Vector2 vec);
        Vector2 RevScale(Vector2 vec);
    }
}

