using System;
namespace CrazyArcade.BombFeature
{
	public interface IExplosionDetector
	{
		void Detect(IExplosion explosion);
		void Ignite(IExplodable explodable);
	}
}

