using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Boss
{
	public interface IBossCollidable
	{
		void Collide(IBossCollideBehaviour boss);
		Rectangle hitBox { get; }
	}
}

