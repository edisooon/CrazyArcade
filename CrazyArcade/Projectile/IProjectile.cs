using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Projectile
{
	public interface IProjectile: IEntity
	{
		Rectangle collideFrame { get; }
	}
}

