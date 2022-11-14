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
        private Rectangle bounds;
        public BombCollisionSystem(ISceneDelegate sceneDelegate, Rectangle bounds) {
            this.sceneDelegate = sceneDelegate;
            this.bounds = bounds;
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

        List<IExplosionCollidable>[,] GetMatrix()
        {
            List<IExplosionCollidable>[,] res =
                new List<IExplosionCollidable>[bounds.Width + 1, bounds.Height + 1];
            for (int i = 0; i < bounds.Width; i++)
            {
                for (int k = 0; k < bounds.Height; k++)
                {
                    res[i, k] = new List<IExplosionCollidable>();
                }
            }
            foreach (IExplosionCollidable collidable in triggers)
            {
                Point triggerCenter = new Point((int)((collidable as IGridable).GameCoord.X + 0.5),
                    (int)((collidable as IGridable).GameCoord.Y + 0.5));
                triggerCenter.X -= bounds.X;
                triggerCenter.Y -= bounds.Y;
                if (bounds.Contains(triggerCenter))
                {
                    res[triggerCenter.X, triggerCenter.Y].Add(collidable);
                } else
                {
                    Console.WriteLine("Position not exists: " + triggerCenter);
                }
            }
            return res;
        }
        private int detect(IExplosion explosion, int length, Vector2 dir, List<IExplosionCollidable>[,] matrix)
        {
            Console.WriteLine("Detecting");
            for (int i = 1; i <= length; i++)
            {
                Vector2 pos = i * dir;
                Point point = new Point((int)pos.X + explosion.Center.X, (int)pos.Y + explosion.Center.Y);
                if (!bounds.Contains(point)) continue;
                Console.WriteLine("Detecting Collidables at: " + point);
                bool isLeaf = false;
                foreach (IExplosionCollidable collidable in matrix[point.X, point.Y])
                {
                    Console.WriteLine("Collide");
                    isLeaf = isLeaf || !collidable.Collide(explosion);
                }
                if (isLeaf)
                {
                    return i;
                }
            }
            return length;
        }
        public int[] Detect(IExplosion explosion)
        {
            List<IExplosionCollidable>[,] matrix = GetMatrix();
            int[] res = new int[4];
            res[0] = detect(explosion, explosion.Distance, new Vector2(0, -1), matrix);
            res[1] = detect(explosion, explosion.Distance, new Vector2(0, 1), matrix);
            res[2] = detect(explosion, explosion.Distance, new Vector2(-1, 0), matrix);
            res[3] = detect(explosion, explosion.Distance, new Vector2(1, 0), matrix);
            return res;
        }

        public void Ignite(IExplodable explodable)
        {
            if (explodable.CanExplode)
            {
                IExplosion explosion = explodable.explode();
                explosion.Display(Detect(explosion));
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

