using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.GameStates;
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.GameGridSystems;
using CrazyArcade.PlayerStateMachine;
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

        private Queue<IEntity> newEntities = new Queue<IEntity>();
        private Queue<IEntity> removeEntities = new Queue<IEntity>();
        //-------------------ISceneState Start----------------------------
        protected IGridSystems gridSystems = new CAGameGridSystems(new Vector2(0, 0), 40);
        public Vector2 Camera { get => gridSystems.Camera; set => gridSystems.Camera = value; }
        public Vector2 StageOffset { get => gridSystems.StageOffset; set => gridSystems.StageOffset = value; }
        public abstract List<Vector2> PlayerPositions { get; }
        public bool doorFlag = false;
        public void EndAfterTransition()
        {

        }
        public void LoadAfterTransition()
        {

        }
        //-------------------ISceneState End----------------------------

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
			while (newEntities.Count > 0)
			{
				this.AddSprite(newEntities.Dequeue());
			}
			while (removeEntities.Count > 0)
			{
				this.RemoveSprite(removeEntities.Dequeue());
			}
		}
        public void AddSprite(IEntity sprite)
        {
            if (sprite == null)
                return;
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
            newEntities.Enqueue(entity);
        }

        public void ToRemoveEntity(IEntity entity)
        {
            removeEntities.Enqueue(entity);
        }
        public virtual void EndGame()
        {
        }
        public virtual void TogglePause()
        {
        }
        public virtual void Victory()
        {
        }
        public virtual void MainMenu()
        {
            gameRef.NewGame();
        }
        public void Transition(int stage, Dir dir)
        {
            gameRef.StageTransitTo(stage, (int)dir);
        }

        public bool IsDoorOpen()
		{
			return doorFlag;
        }
        protected bool loading = false;
        public bool Loading { set => loading = value; }

        public LevelPersistence GetData()
        {
            LevelPersistence saveData = new();
            foreach (IEntity entity in entities)
            {
                if (entity is ISavable)
                {
                    (entity as ISavable).Save(saveData);
                }
            }
            return saveData;
        }
        public void LoadData(LevelPersistence level)
        {
            foreach (IEntity entity in entities)
            {
                if (entity is ISavable)
                {
                    (entity as ISavable).Load(level);
                }
            }
        }
        private int enemyCount = 0;
        public void IncreaseEnemyCount()
        {
            enemyCount++;
        }

        public void DecreaseEnemyCount()
		{
			enemyCount--;
        }
        public int GetEnemyCount()
        {
            return enemyCount;
        }
    }
}

