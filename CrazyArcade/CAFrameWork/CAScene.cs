using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public abstract class CAScene: IScene
	{
        protected List<ISprite> sprites;
        protected List<IGameSystem> systems;
        
        public abstract void LoadSystems();

        public void Draw(GameTime time, SpriteBatch batch)
        {
            foreach(ISprite sprite in sprites)
            {
                sprite.Draw(time, batch);
            }
        }

        public virtual void Load()
        {
            LoadSystems();
        }

        public void AddSprite(ISprite sprite)
        {
            foreach(IGameSystem system in systems)
            {
                system.AddSprite(sprite);
            }
            sprites.Add(sprite);
            sprite.Load();
        }

        public void RemoveAllSprite()
        {
            foreach (IGameSystem system in systems)
            {
                system.RemoveAll();
            }
            sprites = new List<ISprite>();
        }

        public bool RemoveSprite(ISprite sprite)
        {
            foreach (IGameSystem system in systems)
            {
                system.RemoveSprite(sprite);
            }
            return sprites.Remove(sprite);
        }

        public void Update(GameTime time)
        {
            foreach (IGameSystem system in systems)
            {
                system.Update(time);
            }
        }
    }
}

