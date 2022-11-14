using System;
namespace CrazyArcade.BombFeature
{
	public interface IExplosionDetector
	{
		/*
		 * Triggers explodable. Generally will call explodable.explode.
		 */
		void Ignite(IExplodable explodable);
	}
}

