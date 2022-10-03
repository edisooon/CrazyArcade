using CrazyArcade.CAFramework.Controller;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFramework
{
    public class CAGameLogicSystem : IGameSystem
    {
        List<IEntity> sprites = new List<IEntity>();
        List<IEntity> removeSpriteList = new List<IEntity>();
        List<IEntity> addSpriteList = new List<IEntity>();
        public CAGameLogicSystem()
        {
            sprites = new List<IEntity>();
        }

        public void AddSprite(IEntity sprite)
        {
            //sprites.Add(sprite);
            QueueAdd(sprite);
        }

        public void RemoveAll()
        {
            sprites = new List<IEntity>();
        }

        public void RemoveSprite(IEntity sprite)
        {
            //return sprites.Remove(sprite);
            QueueRemove(sprite);
        }

        public void Update(GameTime time)
        {
            foreach (IEntity sprite in sprites)
            {
                sprite.Update(time);
            }
            foreach (IEntity removeSprite in removeSpriteList)
            {
                sprites.Remove(removeSprite);
            }
            foreach (IEntity addSprite in addSpriteList)
            {
                sprites.Add(addSprite);
            }
            removeSpriteList.Clear();
            addSpriteList.Clear();
        }
        private void QueueRemove(IEntity sprite)
        {
            removeSpriteList.Add(sprite);
        }
        private void QueueAdd(IEntity sprite)
        {
            addSpriteList.Add(sprite);
        }
    }
}
