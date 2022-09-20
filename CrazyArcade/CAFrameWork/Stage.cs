using System;
using CrazyArcade.AWFrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.CAFrameWork;
using CrazyArcade.CAFrameWork.EntityBehaviors;
using CrazyArcade.CAFrameWork.Controller;
using System.Linq;
using System.Collections.Generic;

namespace CrazyArcade.CAFrameWork
{
    //this should be the base class for all Stages
	public abstract class Stage: AWScene, IStageModifyProxy
	{
        public override void Load()
        {
            base.Load();
            loadBackground();
            loadCharacters();
        }
        private List<Entity> newEntities = new List<Entity>();
        private List<Entity> removeEntities = new List<Entity>();
        public abstract void loadBackground();
        public abstract void loadCharacters();
        public override void Update(GameTime time)
        {
            base.Update(time);
            updateControllable();
            updateBlock();
            updateMovable();
            updateItems();
            updateProjectile();
        }
        private void updateEnities()
        {
            foreach (Entity entity in newEntities)
            {
                this.AddSprite(entity);
            }
            foreach (Entity entity in removeEntities)
            {
                this.Remove(entity);
            }
        }
        private void updateBlock()
        {
            foreach (var sprite in sprites.Where(s => s is IBlock))
            {
                (sprite as IBlock).BlockBehavior.UpdateBlock();
            }
        }
        private void updateControllable()
        {
            foreach (var sprite in sprites.Where(s => s is IControllable))
            {
                (sprite as IControllable).Controller.Update();
            }
        }
        private void updateMovable()
        {
            foreach (var sprite in sprites.Where(s => s is IBlock))
            {
                (sprite as IMovable).MovableBehavior.move();
            }
        }
        private void updateProjectile()
        {
            foreach (var sprite in sprites.Where(s => s is IProjectile))
            {
                (sprite as IProjectile).ProjectileBehavior.updateProjectile();
            }
        }
        private void updateItems()
        {
            foreach (var sprite in sprites.Where(s => s is IItem))
            {

            }
        }
        
        public void AddEntity(Entity entity)
        {
            entity.Stage = this;
            newEntities.Add(entity);
        }

        public void removeEntity(Entity entity)
        {
            removeEntities.Remove(entity);
        }

        public Stage()
		{
		}
	}
}

