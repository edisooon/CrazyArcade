using System;
using System.Collections.Generic;
using CrazyArcade.PlayerStateMachine;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFramework
{
	public interface ISceneDelegate
	{
		void ToAddEntity(IEntity entity);
		void ToRemoveEntity(IEntity entity);
		List<Vector2> PlayerPositions { get; }
		List<PlayerCharacter> Players { get; }

    }
}

