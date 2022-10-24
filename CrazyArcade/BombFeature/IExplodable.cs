using System;
using System.Collections.Generic;

namespace CrazyArcade.BombFeature
{
	public interface IExplodable: IExplosion
	{
		bool CanExplode { get; }
		IExplosionDetector Detector { get; set; }
		IExplosion explode();
	}
}

