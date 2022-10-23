using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Projectile
{
    public class IProjectileCollisionSystem : IGameSystem
    {
        List<IProjectile> projectiles = new List<IProjectile>();
        List<IProjectileCollidable> collidables = new List<IProjectileCollidable>();
        public void AddSprite(IEntity sprite)
        {
            if (sprite is IProjectile)
            {
                projectiles.Add(sprite as IProjectile);
            }
            if (sprite is IProjectileCollidable)
            {
                collidables.Add(sprite as IProjectileCollidable);
            }
        }

        public void RemoveAll()
        {
            projectiles = new List<IProjectile>();
            collidables = new List<IProjectileCollidable>();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IProjectile)
            {
                projectiles.Remove(sprite as IProjectile);
            }
            if (sprite is IProjectileCollidable)
            {
                collidables.Remove(sprite as IProjectileCollidable);
            }
        }

        private void sort() {
            projectiles.Sort((e1, e2) =>
            {
                return e1.collideFrame.X - e2.collideFrame.X;
            });
            collidables.Sort((e1, e2) =>
            {
                return e1.collideFrame.X - e2.collideFrame.X;
            });
        }

        public void Update(GameTime time)
        {
            foreach (IProjectile projectile in projectiles)
            {
                foreach (IProjectileCollidable entity in collidables)
                {
                    Rectangle checkRectangle = Rectangle.Intersect(projectile.collideFrame, entity.collideFrame);
                    if (checkRectangle.Width != 0 || checkRectangle.Height != 0)
                    {
                        entity.collide(projectile);
                    }
                }
            }
        }
    }
}

