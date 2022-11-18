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
        List<IEnemyCollisionBehavior> enemyBehaviors = new List<IEnemyCollisionBehavior>();
        public void AddSprite(IEntity sprite)
        {
            if (sprite is IEnemyCollidable)
            {
                triggers.Add(sprite as IEnemyCollidable);
            }
            if (sprite is IEnemyCollisionBehavior)
            {
                enemyBehaviors.Add(sprite as IEnemyCollisionBehavior);
            }
        }

        public void RemoveAll()
        {
            triggers.Clear();
            enemyBehaviors.Clear();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IEnemyCollidable)
            {
                triggers.Remove(sprite as IEnemyCollidable);
               
            }
            if (sprite is IEnemyCollisionBehavior) enemyBehaviors.Remove(sprite as IEnemyCollisionBehavior);
        }

        public void Update(GameTime time)
        {

            foreach (IEnemyCollidable trigger in triggers)
            {
                foreach (IEnemyCollisionBehavior enemyBehavior in enemyBehaviors)
                {

                    
                    if (trigger.EnemyBoundingBox.Intersects(enemyBehavior.BlockBoundingBox))
                    {
                        trigger.EnemyCollisionLogic(enemyBehavior);
                    }
                }
            }
        }

    }
}
