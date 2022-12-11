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
        List<IExplosionCollidable>[,] collidableMatrix;
        private ISceneDelegate sceneDelegate;
        private Rectangle bounds;
        public BombCollisionSystem(ISceneDelegate sceneDelegate, Rectangle bounds) {
            this.sceneDelegate = sceneDelegate;
            this.bounds = bounds;
            collidableMatrix = new List<IExplosionCollidable>[bounds.Width + 1, bounds.Height + 1];
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

        private void updateMatrix()
        {
            for (int i = 0; i < bounds.Width; i++)
            {
                for (int k = 0; k < bounds.Height; k++)
                {
                    collidableMatrix[i, k] = new List<IExplosionCollidable>();
                }
            }
            foreach (IExplosionCollidable collidable in triggers)
            {
                if ((collidable as IGridable).GameCoord.X < 0 || (collidable as IGridable).GameCoord.Y < 0) {
                    continue;
                }
                Point triggerCenter = new Point((int)((collidable as IGridable).GameCoord.X + 0.5),
                    (int)((collidable as IGridable).GameCoord.Y + 0.5));
                triggerCenter.X -= bounds.X;
                triggerCenter.Y -= bounds.Y;
                if (bounds.Contains(triggerCenter))
                {
                    collidableMatrix[triggerCenter.X, triggerCenter.Y].Add(collidable);
                } else
                {
                    Console.WriteLine("Position not exists: " + triggerCenter);
                }
            }
        }

        private void detectCenter(IExplosion explosion, List<IExplosionCollidable>[,] matrix)
        {
            if (!bounds.Contains(explosion.Center)) return;
            Console.WriteLine("Detecting Collidables at: " + explosion.Center);

            foreach (IExplosionCollidable collidable in matrix[explosion.Center.X, explosion.Center.Y])
            {
                collidable.Collide(explosion);
            }
        }
        private int detect(IExplosion explosion, int length, Vector2 dir, List<IExplosionCollidable>[,] matrix)
        {
            Console.WriteLine("Detecting");
            for (int i = 1; i <= length; i++)
            {
                Vector2 pos = i * dir;
                Point point = new Point((int)pos.X + explosion.Center.X, (int)pos.Y + explosion.Center.Y);
                if (!bounds.Contains(point)) return i - 1;
                Console.WriteLine("Detecting Collidables at: " + point);

                foreach (IExplosionCollidable collidable in matrix[point.X, point.Y])
                {
                    Console.WriteLine("Collide");
                    if(!collidable.Collide(explosion))  return i-1;
                }
            }
            return length;
        }
        public int[] detect(IExplosion explosion)
        {
            updateMatrix();
            int[] res = new int[4];
            detectCenter(explosion, collidableMatrix);
            res[0] = detect(explosion, explosion.Distance, new Vector2(0, -1), collidableMatrix);
            res[1] = detect(explosion, explosion.Distance, new Vector2(0, 1), collidableMatrix);
            res[2] = detect(explosion, explosion.Distance, new Vector2(-1, 0), collidableMatrix);
            res[3] = detect(explosion, explosion.Distance, new Vector2(1, 0), collidableMatrix);
            return res;
        }

        public void Ignite(IExplodable explodable)
        {
            if (explodable.CanExplode)
            {
                IExplosion explosion = explodable.explode();
                explosion.Display(detect(explosion));
                sceneDelegate.ToRemoveEntity(explodable);
            }
        }
                
        public void RemoveAll()
        {
            triggers.Clear();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IExplosionCollidable)
            {
                triggers.Remove(sprite as IExplosionCollidable);
            }
        }

        public void Update(GameTime time)
        {
        }
    }
}

