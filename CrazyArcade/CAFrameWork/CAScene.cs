using System;
using System.Collections.Generic;
using CrazyArcade.CAFrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public abstract class CAScene: IScene
	{
        protected List<IGameSystem> systems;
        
        public abstract void LoadSystems();

        public abstract void LoadSprites();

        public CAScene()
        {
            this.systems = new List<IGameSystem>();
        }

        public virtual void Update(GameTime time)
        {
            foreach (IGameSystem system in systems)
            {
                system.Update(time);
            }
        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            foreach(IGameSystem system in systems)
            {
                system.Draw(time, batch);
            }
        }

        public virtual void Load()
        {
            LoadSystems();
            LoadSprites();
        }

        public void AddSprite(IEntity sprite)
        {
            sprite.Load();
            foreach (IGameSystem system in systems)
            {
                system.AddSprite(sprite);
            }
        }

        public void RemoveAllSprite()
        {
            foreach (IGameSystem system in systems)
            {
                system.RemoveAll();
            }
        }

        public void RemoveSprite(IEntity sprite)
        {
            foreach (IGameSystem system in systems)
            {
                system.RemoveSprite(sprite);
            }
        }

    }
}

