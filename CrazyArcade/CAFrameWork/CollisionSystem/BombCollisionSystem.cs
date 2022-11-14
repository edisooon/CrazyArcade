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
        List<IExplosionCollidable> breakableBlocks = new List<IExplosionCollidable>();
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
                //if (sprite is IBlock) breakableBlocks.Add(sprite as IExplosionCollidable);
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
            //int leftBlastLength = explosion.Distance[2], rightBlastLength = explosion.Distance[1], upBlastLength = explosion.Distance[0], downBlastLength = explosion.Distance[3];
            //// O->->I->
            //foreach (IExplosionCollidable collidable in triggers)
            //{
            //    Point triggerCenter = new Point((int)((collidable as IGridable).GameCoord.X + 0.5),
            //        (int)((collidable as IGridable).GameCoord.Y + 0.5));
            //    bool collided = false;
            //    if (explosion.Center.X == triggerCenter.X)
            //    {
            //        int dist = Math.Abs(explosion.Center.Y - triggerCenter.Y);
            //        if (explosion.Center.Y < triggerCenter.Y && dist <= downBlastLength) collided = true;
            //        else if (explosion.Center.Y > triggerCenter.Y && dist <= upBlastLength) collided = true;
            //    }
            //    else if (explosion.Center.Y == triggerCenter.Y)
            //    {
            //        int dist = Math.Abs(explosion.Center.X - triggerCenter.X);
            //        if (explosion.Center.X < triggerCenter.X && dist <= rightBlastLength) collided = true;
            //        if (explosion.Center.X > triggerCenter.X && dist <= leftBlastLength) collided = true;
            //    }
            //    if (collided)
            //    {
            //        collidable.Collide(explosion);
            //    }
            //}
        }

        public void Ignite(IExplodable explodable)
        {
            if (explodable.CanExplode)
            {
                //IExplosion fakeExplosion = explodable.fakeExplode();
                //int[] blastLengthArr = DetectBreakableBlocks(fakeExplosion);
                IExplosion explosion = explodable.explode();
                sceneDelegate.ToAddEntity(explosion);
                explosion.Display(Detect(explosion));
                sceneDelegate.ToRemoveEntity(explodable);
            }
        }

        //private int[] DetectBreakableBlocks(IExplosion explosion)
        //{
        //    int leftBlastLength = explosion.Distance[2], rightBlastLength = explosion.Distance[1], upBlastLength = explosion.Distance[0], downBlastLength = explosion.Distance[3];
        //    IExplosionCollidable[] detectedBlocks = new IExplosionCollidable[4];
        //    foreach (IExplosionCollidable breakableBlock in breakableBlocks)
        //    {
        //        Point triggerCenter = new Point((int)((breakableBlock as IGridable).GameCoord.X + 0.5),
        //            (int)((breakableBlock as IGridable).GameCoord.Y + 0.5));
        //        if(explosion.Center.X == triggerCenter.X)
        //        {
        //            int dist = Math.Abs(explosion.Center.Y - triggerCenter.Y);
        //            if (explosion.Center.Y < triggerCenter.Y && dist <= downBlastLength)
        //            {
        //                detectedBlocks[3] = breakableBlock;
        //                downBlastLength = dist-1;
        //            }else if (explosion.Center.Y > triggerCenter.Y && dist <= upBlastLength)
        //            {
        //                detectedBlocks[0] = breakableBlock;
        //                upBlastLength = dist-1;
        //            }
        //        }else if (explosion.Center.Y == triggerCenter.Y)
        //        {
        //            int dist = Math.Abs(explosion.Center.X - triggerCenter.X);
        //            if (explosion.Center.X < triggerCenter.X && dist <= rightBlastLength)
        //            {
        //                detectedBlocks[1] = breakableBlock;
        //                rightBlastLength = dist-1;
        //            }
        //            if (explosion.Center.X > triggerCenter.X && dist <= leftBlastLength)
        //            {
        //                detectedBlocks[2] = breakableBlock;
        //                leftBlastLength = dist-1;
        //            }
        //        }
        //    }
        //    foreach (IExplosionCollidable detectedBlock in detectedBlocks)
        //    {
        //        if(detectedBlock!=null) detectedBlock.Collide(explosion);
        //    }
        //    return new int[] {leftBlastLength, rightBlastLength, upBlastLength, downBlastLength };
        //}

        public void RemoveAll()
        {
            triggers.Clear();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IExplosionCollidable)
            {

                //if(sprite is IBlock) breakableBlocks.Remove(sprite as IExplosionCollidable);
                triggers.Remove(sprite as IExplosionCollidable);
            }
        }

        public void Update(GameTime time)
        {
        }
    }
}

