using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Boss
{
    public abstract class SunBossStates : IStates
    {
        protected ITimer timer;
        protected ISunBossDelegate bossDelegate;
        public abstract List<SpriteAnimation> Animation { get; }
        public SunBossStates(ISunBossDelegate bossDelegate, GameTime time) {
            this.bossDelegate = bossDelegate;
            timer = new CATimer(time.TotalGameTime);
        }

        public virtual IStates Update(GameTime time)
        {
            timer.Update(time.TotalGameTime);
            return this;
        }

    }
}

