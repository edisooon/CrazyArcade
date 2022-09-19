using System;
using CrazyArcade.AWFrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.CAFrameWork;
using CrazyArcade.CAFrameWork.EntityBehaviors;
using CrazyArcade.CAFrameWork.Controller;
using System.Linq;


namespace CrazyArcade.CAFrameWork
{
    //this should be the base class for all Stages
	public abstract class Stage: AWScene
	{
        public override void Load()
        {
            base.Load();
            loadBackground();
            loadCharacters();
        }
        public abstract void loadBackground();
        public abstract void loadCharacters();
        public override void Update(GameTime time, KeyboardState kstate, MouseState mstate)
        {
            base.Update(time, kstate, mstate);
            updateControllable();
            updateBlock();
            updateMovable();
            updateItems();
            updateProjectile();
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

        public Stage()
		{
		}
	}
}

