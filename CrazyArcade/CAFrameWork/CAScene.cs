using System;
using System.Collections.Generic;
using System.ComponentModel;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public abstract class CAScene: IScene
	{
        protected List<IGameSystem> systems;
        //preserved for the purposes of having one draw per entity
        protected List<IEntity> entities = new List<IEntity>();

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
            foreach(IEntity entity in entities)
            {
                entity.Draw(time, batch);
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
            entities.Add(sprite);
        }

        public void RemoveAllSprite()
        {
            foreach (IGameSystem system in systems)
            {
                system.RemoveAll();
            }
            entities = new List<IEntity> { };
        }

        public void RemoveSprite(IEntity sprite)
        {
            foreach (IGameSystem system in systems)
            {
                system.RemoveSprite(sprite);
            }
            entities.Remove(sprite);
        }

    }
}

