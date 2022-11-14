using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;

namespace CrazyArcade.BombFeature
{
	public interface IExplodable: IEntity
	{
		/*
		 *	BombCollision system will need this to determain explode or not.
		 *	Generally will be assigned to false in explode
		 */
		bool CanExplode { get; }

		/*	This is the explosion dectecor used for explosion detection.
		 *	
		 */
		IExplosionDetector Detector { get; set; }
		IExplosion explode();
		//IExplosion fakeExplode();
	}
}

