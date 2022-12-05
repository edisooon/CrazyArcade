using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork
{
	public class FadeOutEffect: SpriteAnimation
    {
		ITimer timer;
		private SpriteAnimation decoratee;
		int duraction;
		public override float Scale {
			get => base.Scale;
			set {
				base.Scale = value;
				decoratee.Scale = value;
			}
		}
		public FadeOutEffect(SpriteAnimation anim, int duractionInMili)
		{
			decoratee = anim;
			this.CopyFrom(decoratee);
			duraction = duractionInMili;
		}

        public override void Update(GameTime gameTime)
		{
			if (timer == null)
			{
				timer = new CATimer(gameTime.TotalGameTime);
			}
			timer.Update(gameTime.TotalGameTime);
			base.Update(gameTime);
			decoratee.Update(gameTime);
			this.CopyFrom(decoratee);
			this.Color = Color * (1.0f - (float)timer.TotalMili / (float)duraction);
		}

    }
}

