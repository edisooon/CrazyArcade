using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Boss
{
	public interface IStates
	{
		IStates Update(GameTime time);

        public List<SpriteAnimation> Animation { get; }
    }
}

