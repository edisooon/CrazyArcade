using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Projectile
{
	public interface IProjectileCollidable
	{
		Rectangle collideFrame { get; }
		void collide(IProjectile projectile);
	}
}

