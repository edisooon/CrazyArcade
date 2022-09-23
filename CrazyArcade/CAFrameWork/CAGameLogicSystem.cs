using CrazyArcade.CAFramework.Controller;
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
        List<ISprite> sprites = new List<ISprite>();
        public CAGameLogicSystem()
        {
            sprites = new List<ISprite>();
        }

        public void AddSprite(ISprite sprite)
        {
            sprites.Add(sprite);
        }

        public void RemoveAll()
        {
            sprites = new List<ISprite>();
        }

        public bool RemoveSprite(ISprite sprite)
        {
            return sprites.Remove(sprite);
        }

        public void Update(GameTime time)
        {
            foreach (ISprite sprite in sprites)
            {
                sprite.Update(time);
            }
        }
    }
}
