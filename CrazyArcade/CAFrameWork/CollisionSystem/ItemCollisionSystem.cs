using CrazyArcade.CAFramework;
using CrazyArcade.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.CollisionSystem
{
    public class ItemCollisionSystem : IGameSystem
    {
        private List<IItemCollidable> _itemsCollidable;
        private List<IItemCollision> _itemsColliding;
        private ISceneDelegate parentScene;

        public ItemCollisionSystem(ISceneDelegate scene)
        {
            this._itemsCollidable = new List<IItemCollidable>();
            this._itemsColliding = new List<IItemCollision>();
            this.parentScene = scene;
        }
        public void AddSprite(IEntity toAdd)
        {
            if (toAdd is IItemCollidable)
            {
                _itemsCollidable.Add(toAdd as IItemCollidable);
            }
            else if (toAdd is IItemCollision)
            {
                _itemsColliding.Add(toAdd as IItemCollision);
            }
        }
        public void RemoveSprite(IEntity toRemove)
        {
            if (toRemove is IItemCollidable)
            {
                _itemsCollidable.Remove(toRemove as IItemCollidable);
            }
            else if (toRemove is IItemCollision)
            {
                _itemsColliding.Remove(toRemove as IItemCollision);
            }
        }
        public void RemoveAll()
        {
            _itemsCollidable.Clear();
            _itemsColliding.Clear();
        }
        public void Update(GameTime gameTime)
        {
            List<IItemCollision> toRemove = new List<IItemCollision>();
            foreach (IItemCollidable collidable in _itemsCollidable)
            {
                foreach (IItemCollision collisionItem in _itemsColliding)
                {
                    if (collidable.blockCollisionBoundingBox.Intersects(collisionItem.itemHitbox) && collidable.canHaveItem())
                    {
                        collisionItem.CollisionLogic(collidable);
                        toRemove.Add(collisionItem);
                    }
                }
            }
            foreach(IItemCollision itemToRemove in toRemove)
            {
                parentScene.ToRemoveEntity(itemToRemove);
            }
        }
    }
}
