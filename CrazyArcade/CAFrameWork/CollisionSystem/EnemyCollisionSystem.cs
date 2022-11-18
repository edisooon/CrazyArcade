using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using CrazyArcade.EnemyCollision;
using System.Collections.Generic;


namespace CrazyArcade.CAFrameWork.CollisionSystem
{
    internal class EnemyCollisionSystem : IGameSystem
    {

        List<IEnemyCollidable> triggers = new List<IEnemyCollidable>();
        List<IEnemyCollisionBehavior> playerBehaviors = new List<IEnemyCollisionBehavior>();
        public void AddSprite(IEntity sprite)
        {
            if (sprite is IEnemyCollidable)
            {
                triggers.Add(sprite as IEnemyCollidable);
                
            }
            if (sprite is IEnemyCollisionBehavior)
            {
                playerBehaviors.Add(sprite as IEnemyCollisionBehavior);
            }
        }

        public void RemoveAll()
        {
            triggers.Clear();
            playerBehaviors.Clear();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IEnemyCollidable)
            {
                triggers.Remove(sprite as IEnemyCollidable);
               
            }
            if (sprite is IEnemyCollisionBehavior) playerBehaviors.Remove(sprite as IEnemyCollisionBehavior);
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
