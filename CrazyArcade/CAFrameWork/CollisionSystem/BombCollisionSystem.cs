using System;
using CrazyArcade.Blocks;
using CrazyArcade.Boss;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CrazyArcade.BombFeature;
using CrazyArcade.GameGridSystems;

namespace CrazyArcade.CAFrameWork.CollisionSystem
{
	public class BombCollisionSystem: IGameSystem, IExplosionDetector
	{
        List<IExplosionCollidable> triggers = new List<IExplosionCollidable>();
        private ISceneDelegate sceneDelegate;
        public BombCollisionSystem(ISceneDelegate sceneDelegate) {
            this.sceneDelegate = sceneDelegate;
        }

        public void AddSprite(IEntity sprite)
        {
            if (sprite is IExplosionCollidable)
            {
                triggers.Add(sprite as IExplosionCollidable);
            }
            if (sprite is IExplodable)
            {
                (sprite as IExplodable).Detector = this;
            }
        }

        public void Detect(IExplosion explosion)
        {
            foreach (IExplosionCollidable collidable in triggers)
            {
                Point triggerCenter = new Point((int)((collidable as IGridable).GameCoord.X + 0.5),
                    (int)((collidable as IGridable).GameCoord.Y + 0.5));
                bool collided = explosion.Center.X == triggerCenter.X
                    && Math.Abs(explosion.Center.Y - triggerCenter.Y) <= explosion.Distance;
                collided = collided || explosion.Center.Y == triggerCenter.Y
                    && Math.Abs(explosion.Center.X - triggerCenter.X) <= explosion.Distance;
                if (collided)
                {
                    collidable.Collide(explosion);
                }
            }
        }

        public void Ignite(IExplodable explodable)
        {
            if (explodable.CanExplode)
            {
                IExplosion explosion = explodable.explode();
                sceneDelegate.ToAddEntity(explosion);
                Detect(explosion);
                sceneDelegate.ToRemoveEntity(explodable);
            }
        }

        public void RemoveAll()
        {
            triggers.Clear();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IExplosionCollidable) triggers.Remove(sprite as IExplosionCollidable);
        }

        public void Update(GameTime time)
        {

        }
    }
}

