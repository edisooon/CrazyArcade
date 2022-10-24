using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Boss
{
    public class SunBossStartStates : SunBossStates
    {
        public SunBossStartStates(ISunBossDelegate bossDelegate, GameTime time) : base(bossDelegate, time)
        {

            animation = new List<SpriteAnimation>();
            animation.Add(new SpriteAnimation(Singletons.SpriteSheet.SunBoss, new Rectangle(43, 0, 88, 88)));
        }
        List<SpriteAnimation> animation;
        public override List<SpriteAnimation> Animation => animation;

        public override IStates Update(GameTime time)
        {
            Console.Out.Write("Started\n");
            return new SunBossNormalStates(bossDelegate, time);
        }
    }
}