using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Boss
{
	public class SunBossHurtStates: SunBossStates
    {
        private List<SpriteAnimation> animation = new List<SpriteAnimation>();
        public override List<SpriteAnimation> Animation => animation;
        private bool isDead;
        public SunBossHurtStates(ISunBossDelegate bossDelegate, GameTime time) : base(bossDelegate, time)
        {
            animation.Add(new SpriteAnimation(Singletons.SpriteSheet.SunBoss, new Rectangle(0, 68, 44, 17)));
            animation[0].Position.X += 22;
            animation[0].Position.Y += 32;
            Rectangle[] rectangles = new Rectangle[2];
            rectangles[0] = new Rectangle(179, 185, 88, 88);
            rectangles[1] = new Rectangle(0, 311, 88, 88);
            animation.Add(new SpriteAnimation(Singletons.SpriteSheet.SunBoss, rectangles, 5));
            bossDelegate.DecreaseHealth();
            isDead = bossDelegate.IsDead;
            if (isDead)
            {
                animation[0] = new FadeOutEffect(animation[0], 1000);
                animation[1] = new FadeOutEffect(animation[1], 1000);
            }
        }
        public override IStates Update(GameTime time)
        {
            base.Update(time);
            if (timer.TotalMili > 1000)
            {
                if (isDead)
                    bossDelegate.Dead();
                else
                    return new SunBossNormalStates(bossDelegate, time);
            }
            return this;
        }
    }
}

