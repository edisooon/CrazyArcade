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
        List<WaterBomb> bombs = new List<WaterBomb>();  // to handle the collision between player and bomb
        List<IPlayerCollidable> triggers = new List<IPlayerCollidable>();
        List<IPlayerCollisionBehavior> playerBehaviors = new List<IPlayerCollisionBehavior>();
        public void AddSprite(IEntity sprite)
        {
            if (sprite is IPlayerCollidable)
            {
                triggers.Add(sprite as IPlayerCollidable);
                if (sprite is WaterBomb) bombs.Add(sprite as WaterBomb);
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
                bombs.Remove(sprite as WaterBomb);
            }
            if (sprite is IPlayerCollisionBehavior) playerBehaviors.Remove(sprite as IPlayerCollisionBehavior);
        }

        public void Update(GameTime time)
        {
            UpdateHasNotLeftInBomb();
            foreach (IPlayerCollidable trigger in triggers)
            {
                foreach (IPlayerCollisionBehavior playerBehavior in playerBehaviors)
                {
                    Rectangle checkRectangle = Rectangle.Intersect(trigger.boundingBox, playerBehavior.blockCollisionBoundingBox);
                    if (trigger is SunBossProjectile)
                    {
                        //Console.Out.Write(trigger.boundingBox);
                    }
                    if (checkRectangle.Width != 0 || checkRectangle.Height != 0)
                    {
                        trigger.CollisionLogic(checkRectangle, playerBehavior);
                    }
                }
            }
        }

        private void UpdateHasNotLeftInBomb()
        {
            foreach (WaterBomb bomb in bombs) bomb.UpdateHasNotLeft(playerBehaviors);
        }
    }
}
