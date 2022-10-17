using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Projectile
{
	public interface IProjectileCollidable: IEntity
	{
		Rectangle collideFrame { get; }
		void collide(IProjectile projectile);
	}
}

