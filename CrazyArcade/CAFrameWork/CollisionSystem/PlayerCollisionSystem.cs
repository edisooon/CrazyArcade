using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Boss;
using CrazyArcade.BombFeature;

namespace CrazyArcade.CAFrameWork.CollisionSystem
{
    internal class PlayerCollisionSystem : IGameSystem
    {
        List<IPlayerCollidable> triggers = new List<IPlayerCollidable>();
        List<IPlayerCollisionBehavior> playerBehaviors = new List<IPlayerCollisionBehavior>();
        public void AddSprite(IEntity sprite)
        {
            if (sprite is IPlayerCollidable)
            {
                triggers.Add(sprite as IPlayerCollidable);
            }
            if (sprite is IPlayerCollisionBehavior)
            {
                playerBehaviors.Add(sprite as IPlayerCollisionBehavior);
            }
        }

        public void RemoveAll()
        {
            triggers.Clear();
            playerBehaviors.Clear();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IPlayerCollidable)
            {
                triggers.Remove(sprite as IPlayerCollidable);
            }
            if (sprite is IPlayerCollisionBehavior) playerBehaviors.Remove(sprite as IPlayerCollisionBehavior);
        }

        public void Update(GameTime time)
        {

            foreach (IPlayerCollidable trigger in triggers)
            {
                foreach (IPlayerCollisionBehavior playerBehavior in playerBehaviors)
                {
                    Rectangle checkRectangle = Rectangle.Intersect(trigger.boundingBox, playerBehavior.blockCollisionBoundingBox);
        
                    if (checkRectangle.Width != 0 || checkRectangle.Height != 0)
                    {
                        trigger.CollisionLogic(checkRectangle, playerBehavior);
                    }
                }
            }
        }
    }
}
