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
        void Move(Vector2 distance);
        ISceneDelegate Command();
        Vector2 GetCenter();
    }
}