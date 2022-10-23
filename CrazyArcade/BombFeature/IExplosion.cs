using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.BombFeature
{
	public interface IExplosion
	{
		int Distance { get; }
		Point Center { get; }
	}
}

