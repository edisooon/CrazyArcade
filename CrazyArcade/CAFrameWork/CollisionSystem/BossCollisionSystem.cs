using System;
using CrazyArcade.Blocks;
using CrazyArcade.Boss;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CrazyArcade.CAFrameWork.CollisionSystem
{
	public class BossCollisionSystem: IGameSystem
	{
        List<IBossCollidable> triggers = new List<IBossCollidable>();
        List<IBossCollideBehaviour> bossBehaviors = new List<IBossCollideBehaviour>();
        public void AddSprite(IEntity sprite)
        {
            if (sprite is IBossCollidable)
            {
                triggers.Add(sprite as IBossCollidable);
            }
            if (sprite is IBossCollideBehaviour)
            {
                bossBehaviors.Add(sprite as IBossCollideBehaviour);
            }
        }

        public void RemoveAll()
        {
            triggers.Clear();
            bossBehaviors.Clear();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IBossCollidable) triggers.Remove(sprite as IBossCollidable);
            if (sprite is IBossCollideBehaviour) bossBehaviors.Remove(sprite as IBossCollideBehaviour);
        }

        public void Update(GameTime time)
        {
            foreach (IBossCollidable trigger in triggers)
            {
                foreach (IBossCollideBehaviour bossBehavior in bossBehaviors)
                {
                    Rectangle checkRectangle = Rectangle.Intersect(trigger.hitBox, bossBehavior.hitBox);
                    
                    if (checkRectangle.Width != 0 || checkRectangle.Height != 0)
                    {
                        trigger.Collide(bossBehavior);
                    }
                }
            }
        }
    }
}

