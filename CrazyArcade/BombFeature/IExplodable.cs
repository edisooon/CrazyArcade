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
		 *	Detector will detect and triggers all the handler of entities 
		 *	collide with this explosion.
		 */
		IExplosionDetector Detector { get; set; }

		/*	This method shouldn't called by it self. 
		 *		i.e. Never use this.explode();
		 *	This will called by detector as an explosion handler.
		 *	You should return an Explosion and update canExplode here
		 */
		IExplosion explode();
	}
}

