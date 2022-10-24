using System;
namespace CrazyArcade.BombFeature
{
	public interface IExplosionDetector
	{
		/*
		 * Detect and triggers every entities collide with explosion
		 */
		void Detect(IExplosion explosion);
		/*
		 * Triggers explodable. Generally will call explodable.explode.
		 */
		void Ignite(IExplodable explodable);
	}
}

