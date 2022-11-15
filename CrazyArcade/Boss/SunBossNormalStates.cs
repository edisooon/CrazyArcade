using System;
using System.Collections.Generic;
using System.Numerics;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace CrazyArcade.Boss
{
	public class SunBossNormalStates: SunBossStates
    {
        Rectangle[] eyes = new Rectangle[8];
		public SunBossNormalStates(ISunBossDelegate bossDelegate, GameTime time) : base(bossDelegate, time)
        {
            animation.Add(new SpriteAnimation(Singletons.SpriteSheet.SunBoss, eyes[0]));
            animation.Add(new SpriteAnimation(Singletons.SpriteSheet.SunBoss, new Rectangle(43, 0, 88, 88)));
            for (int i = 0; i < 8; i++)
            {
                eyes[i] = new Rectangle(0, i * 17, 44, 17);
            }
            Vector2 direction = bossDelegate.GetCharacterRelativePosition();
            float len = (float)Math.Sqrt(Math.Pow(direction.X, 2) + Math.Pow(direction.Y, 2));
            Vector2 adjust = new Vector2(bossDelegate.Range.Center.X, bossDelegate.Range.Center.Y) - bossDelegate.GetCenter();
            direction += adjust / 4;
            speed = new Vector2(direction.X / len, direction.Y / len);
            speed /= 40;
		}
        Vector2 speed;
        private List<SpriteAnimation> animation = new List<SpriteAnimation>();
        public override List<SpriteAnimation> Animation => animation;
        
        public override IStates Update(GameTime time)
        {
            base.Update(time);
            int diff = timer.FrameDiff.Milliseconds;
            Vector2 distance = new Vector2((speed.X * diff / 8), (speed.Y * diff / 8));
            
            if (bossDelegate.DidGetDemaged())
            {
                return new SunBossHurtStates(bossDelegate, time);
            }
            if (!bossDelegate.Move(distance))
            {
                return new SunBossAttackStates(bossDelegate, time);
            }
            animation[0] = new SpriteAnimation(Singletons.SpriteSheet.SunBoss, eyes[getEyeFrame()]);
            animation[0].Position.X += 22;
            animation[0].Position.Y += 32;
            return this;

        }
        private int getEyeFrame()
        {
            Vector2 dir = bossDelegate.GetCharacterRelativePosition();

            if (dir.X != 0)
            {
                double radius = Math.Atan(-dir.Y / dir.X);
                radius += dir.X < 0 ? Math.PI : 0;
                radius += Math.PI / 4;
                radius = radius / (2 * Math.PI) * 8;
                return ((int)radius + 10) % 8;
            } else
            {
                return dir.Y < 0 ? 4 : 0;
            }
        }
    }
    
}

