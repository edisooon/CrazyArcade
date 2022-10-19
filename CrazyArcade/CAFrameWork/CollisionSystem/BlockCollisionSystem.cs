using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.CollisionSystem
{
    internal class BlockCollisionSystem : IGameSystem
    {
        List<IBlockCollision> blockList = new List<IBlockCollision>();
        List<IBlockCollidable> blockColidableList = new List<IBlockCollidable>();
        public void AddSprite(IEntity sprite)
        {
            if (sprite is IBlockCollision)
            {
                blockList.Add(sprite as IBlockCollision);
            }
            if (sprite is IBlockCollidable)
            {
                blockColidableList.Add(sprite as IBlockCollidable);
            }
        }

        public void RemoveAll()
        {
            blockList = new List<IBlockCollision>();
            blockColidableList = new List<IBlockCollidable>();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IBlockCollision) blockList.Remove(sprite as IBlockCollision);
            if (sprite is IBlockCollidable) blockColidableList.Remove(sprite as IBlockCollidable);
        }

        public void Update(GameTime time)
        {
            foreach(IBlockCollision block in blockList)
            {
                foreach (IBlockCollidable entity in blockColidableList)
                {
                    Rectangle checkRectangle = Rectangle.Intersect(block.boundingBox, entity.blockCollisionBoundingBox);
                    if (checkRectangle.Width != 0 || checkRectangle.Height != 0)
                    {
                        block.CollisionLogic(checkRectangle, entity);
                    }
                }
            }
        }
    }
}
