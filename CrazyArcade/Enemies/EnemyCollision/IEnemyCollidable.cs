using Microsoft.Xna.Framework;


namespace CrazyArcade.EnemyCollision
{
    public interface IEnemyCollidable
    {
        //The rectangle that is collided with
        public Rectangle EnemyBoundingBox { get; }
        public void EnemyCollisionLogic(Rectangle overlap, IEnemyCollisionBehavior collisionPartner);
    }
}
