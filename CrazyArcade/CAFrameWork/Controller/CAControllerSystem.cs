using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFramework.Controller
{
	public class CAControllerSystem: IGameSystem
	{
        List<IControllable> sprites = new List<IControllable>();
		public CAControllerSystem()
		{
		}

        public void AddSprite(ISprite sprite)
        {
            if (sprite is IControllable)
            {
                sprites.Add(sprite as IControllable);
            }
        }

        public void RemoveAll()
        {
            sprites = new List<IControllable>();
        }

        public bool RemoveSprite(ISprite sprite)
        {
            if (sprite is IControllable)
            {
                return sprites.Remove(sprite as IControllable);
            }
            return false;
        }

        public void Update(GameTime time)
        {
            foreach(IControllable sprite in sprites)
            {
                sprite.controller.Update();
            }
        }
    }
}

