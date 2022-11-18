using CrazyArcade.Blocks;
using Microsoft.Xna.Framework;


namespace CrazyArcade.EnemyCollision
{
    public interface IEnemyCollidable
    {
        //The rectangle that is collided with
        public Rectangle EnemyBoundingBox { get; }
        //The code that is executed when a collision is detected. (Defined in IBlock)
        public void EnemyCollisionLogic(IEnemyCollisionBehavior collisionPartner);
    }
}
