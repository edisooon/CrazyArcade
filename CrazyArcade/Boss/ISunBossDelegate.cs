using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Boss
{
	public interface ISunBossDelegate
	{
        bool DidGetDemaged();
        Point GetCharacterRelativePosition();
        Point GetCharacterPosition();
        void Move(Vector2 distance);
        ISceneDelegate Command();
        Vector2 GetCenter();
    }
}

