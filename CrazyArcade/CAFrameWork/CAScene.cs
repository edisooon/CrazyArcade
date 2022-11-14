using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.GameStates;
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFramework
{
	public abstract class CAScene: ISceneState, ISceneDelegate
    {
        protected List<IGameSystem> systems;
        //preserved for the purposes of having one draw per entity
        protected List<IEntity> entities = new List<IEntity>();
        public IGameDelegate gameRef;

        private List<IEntity> newEntities = new List<IEntity>();
        private List<IEntity> removeEntities = new List<IEntity>();
        //-------------------ISceneState Start----------------------------
        protected IGridSystems gridSystems = new CAGameGridSystems(new Vector2(0, 0), 40);
        public Vector2 Camera { get => gridSystems.Camera; set => gridSystems.Camera = value; }
        public Vector2 StageOffset { get => gridSystems.StageOffset; set => gridSystems.StageOffset = value; }
        public abstract List<Vector2> PlayerPositions { get; }

        public void EndAfterTransition()
        {

        }
        public void LoadAfterTransition()
        {

        }
        //-------------------ISceneState End----------------------------
        private void UpdateEnitities()
        {
            foreach (IEntity entity in newEntities)
            {
                this.AddSprite(entity);
            }
            foreach (IEntity entity in removeEntities)
            {
                this.RemoveSprite(entity);
            }
            newEntities = new List<IEntity>();
            removeEntities = new List<IEntity>();
        }

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
                if (system is IControllable)
                {
                    (system as IControllable).Controller.Update(time);
                }
                UpdateSprite(time);
            }
        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            foreach(IEntity entity in entities.OrderBy(e => e.ActualDrawOrder))
            {
                entity.Draw(time, batch);
            }
        }

        public virtual void Load()
        {
            LoadSystems();
            LoadSprites();
        }
        public void UpdateSprite(GameTime time)
        {
            foreach (IEntity addSprite in newEntities)
            {
                this.AddSprite(addSprite);
            }
            foreach (IEntity removeSprite in removeEntities)
            {
                this.RemoveSprite(removeSprite);
            }
            removeEntities.Clear();
            newEntities.Clear();
        }
        public void AddSprite(IEntity sprite)
        {
            sprite.SceneDelegate = this;
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
            if (entities.Contains(sprite))
            {
                sprite.Deload();
                entities.Remove(sprite);
            }
        }

        public void ToAddEntity(IEntity entity)
        {
            newEntities.Add(entity);
        }

        public void ToRemoveEntity(IEntity entity)
        {
            removeEntities.Add(entity);
        }
        public virtual void EndGame()
        {
        }
        public virtual void Pause()
        {
        }
        public virtual void Victory()
        {
        }
    }
}

