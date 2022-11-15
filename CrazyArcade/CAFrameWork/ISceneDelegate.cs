using System;
using System.Collections.Generic;
using CrazyArcade.CAFrameWork.CAGame;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFramework
{
	public interface ISceneDelegate
	{
		void ToAddEntity(IEntity entity);
		void ToRemoveEntity(IEntity entity);
		List<Vector2> PlayerPositions { get; }
		void EndGame();
		void TogglePause();
		void Victory();
        void Transition(int stage, Dir dir);
    }
}

