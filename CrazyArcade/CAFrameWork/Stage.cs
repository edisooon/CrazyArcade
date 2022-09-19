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
	public class Stage: AWScene, IControllerDelegate
	{
        private IController controller => throw new NotImplementedException();
        public override void Load()
        {
            controller.Delegate = this;
        }
        public override void Update(GameTime time, KeyboardState kstate, MouseState mstate)
        {
            base.Update(time, kstate, mstate);
        }
        private void updateTile()
        {
            foreach (var sprite in sprites.Where(s => s is ITile))
            {
                (sprite as ITile).TileBehavior.UpdateTile();
            }
        }
        private void updateDetectable()
        {
            foreach (var sprite in sprites.Where(s => s is IDetectable))
            {
                (sprite as IDetectable).Behavior.Detect();
            }
        }
        private void updateControllable()
        {
            controller.Update();
        }

        public void Up()
        {
            foreach (var sprite in sprites.Where(s => s is IControllable))
            {
                (sprite as IControllable).Behavior.Up();
            }
        }

        public void Down()
        {
            foreach (var sprite in sprites.Where(s => s is IControllable))
            {
                (sprite as IControllable).Behavior.Down();
            }
        }

        public void Left()
        {
            foreach (var sprite in sprites.Where(s => s is IControllable))
            {
                (sprite as IControllable).Behavior.Left();
            }
        }

        public void Right()
        {
            foreach (var sprite in sprites.Where(s => s is IControllable))
            {
                (sprite as IControllable).Behavior.Right();
            }
        }

        public void Space()
        {
            foreach (var sprite in sprites.Where(s => s is IControllable))
            {
                (sprite as IControllable).Behavior.Space();
            }
        }

        public Stage()
		{
		}
	}
}

