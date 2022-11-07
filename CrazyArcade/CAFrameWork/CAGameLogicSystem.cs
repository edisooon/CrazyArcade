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
            sprites.Add(sprite);
        }

        public void RemoveAll()
        {
            sprites = new List<IEntity>();
        }

        public void RemoveSprite(IEntity sprite)
        {
            //return sprites.Remove(sprite);
            sprites.Remove(sprite);
        }
        
        public void Update(GameTime time)
        {
            foreach (IEntity sprite in sprites)
            {
                sprite.Update(time);
            }
        }
    }
}
