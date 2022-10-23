using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.GameGridSystems
{
	public class NullTransform: IGridTransform
	{
		public NullTransform()
		{
		}

        public Vector2 RevScale(Vector2 vec) => vec;

        public Vector2 RevTrans(Vector2 vec) => vec;

        public Vector2 Scale(Vector2 vec) => vec;

        public Vector2 Trans(Vector2 vec) => vec;
    }
}

