using System;
using CrazyArcade.CAFrameWork.Controller;
using CrazyArcade.CAFrameWork.EntityBehaviors;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFrameWork
{
	public class SomeControllableEntity: Entity, IControllable
	{
		public SomeControllableEntity()
		{
            controller.Delegate = behavior;

        }
		private IControllerDelegate behavior;
        private IController controller;
        public IControllerDelegate Behavior => behavior;

        public IController Controller => throw new NotImplementedException();

        public override Texture2D Graphics => throw new NotImplementedException();
    }
}

