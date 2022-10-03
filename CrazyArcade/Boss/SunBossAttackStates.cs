using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Boss
{
	public class SunBossAttackStates: SunBossStates
	{
		public SunBossAttackStates(ISunBossDelegate bossDelegate, GameTime time) : base(bossDelegate, time)
        {
            animation = new List<SpriteAnimation>();
            animation.Add(new SpriteAnimation(Singletons.SpriteSheet.SunBoss,
                new Rectangle(88, 184, 88, 88)));
            float sqrt2 = (float)Math.Sqrt(2);
            Vector2[] vectors = new Vector2[8]
                { new Vector2(0, sqrt2), new Vector2(0, -sqrt2),
                new Vector2(1, 1), new Vector2(1, -1),
                new Vector2(sqrt2, 0), new Vector2(-sqrt2, 0),
                new Vector2(-1, -1), new Vector2(-1, 1)};
            for (int i = 0; i < 8; i++)
            {
                bossDelegate.Command().ToAddEntity(
                    new SunBossProjectile(bossDelegate.Command(), vectors[i],
                    bossDelegate.GetCenter(), new CATimer(time.TotalGameTime)));
            }
        }
        List<SpriteAnimation> animation;
        public override List<SpriteAnimation> Animation => animation;

        public override IStates Update(GameTime time)
        {
            base.Update(time);
            int diff = timer.FrameDiff.Milliseconds;
            if (bossDelegate.DidGetDemaged())
            {

            }
            if (timer.TotalMili > 1500)
            {
                return new SunBossNormalStates(bossDelegate, time);
            }
            return this;
        }
    }
}

