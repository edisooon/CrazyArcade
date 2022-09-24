using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrazyArcade.CAFramework;


namespace CrazyArcade.CAFramework.Controller
{
	public class CAControllerSystem: IGameSystem
	{
        List<ISprite> sprites;
		public CAControllerSystem()
		{
            sprites = new List<ISprite>();
        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            foreach (ISprite sprite in sprites)
            {
                sprite.Draw(time, batch);
            }
        }

        public void Update(GameTime time)
        {
            foreach (IControllable sprite in sprites)
            {
                sprite.Controller.Update(time);
            }
        }

        public void AddSprite(ISprite sprite)
        {
            if (sprite is IControllable)
            {
                sprites.Add(sprite);
            }
        }

        public void RemoveAll()
        {
            sprites.Clear();
        }

        public void RemoveSprite(ISprite sprite)
        {
            if (sprite is IControllable)
            {
                sprites.Remove(sprite);
            }
        }

    }
}

