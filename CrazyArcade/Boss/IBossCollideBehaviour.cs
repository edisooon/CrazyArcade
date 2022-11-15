using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Boss
{
	public interface IBossCollideBehaviour
	{
		Rectangle hitBox { get; }
		void HurtBoss();
	}
}

