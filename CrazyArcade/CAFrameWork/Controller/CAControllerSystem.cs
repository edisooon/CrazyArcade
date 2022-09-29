using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork;

namespace CrazyArcade.CAFramework.Controller
{
	public class CAControllerSystem: IGameSystem
	{
        List<IEntity> sprites;
		public CAControllerSystem()
		{
            sprites = new List<IEntity>();
        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            foreach (IEntity sprite in sprites)
            {
                sprite.Draw(time, batch);
            }
        }

        public void Update(GameTime time)
        {
            foreach (IEntity sprite in sprites)
            {
                (sprite as IControllable).Controller.Update(time);
                //sprite.Update(time);
            }
        }

        public void AddSprite(IEntity sprite)
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

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IControllable)
            {
                sprites.Remove(sprite);
            }
        }

    }
}

