using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Boss
{
	public interface ISunBossDelegate
	{
        bool DidGetDemaged();
        Vector2 GetCharacterRelativePosition();
        Vector2 GetCharacterPosition();
        bool Move(Vector2 distance);
        ISceneDelegate Command();
        Vector2 GetCenter();
        bool IsDead { get; }
        int Health { get; }
        void DecreaseHealth();
        void Dead();
        Rectangle Range { get; }

    }
}

