using System;
using CrazyArcade.CAFrameWork;
using CrazyArcade.CAFrameWork.Controller;
//using CrazyArcade.CAFrameWork.Controller;
using CrazyArcade.CAFrameWork.EntityBehaviors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.DemoStage
{
	public class DemoCharacter: GridEntity, IControllable
	{
        public DemoCharacter(IController controller, Point start)
        {
            this.controller = controller;
            controller.Delegate = this;
            GridX = start.X;
            GridY = start.Y;
        }

        private IController controller;
        public IController Controller => this.controller;
        private double speed = 0.1;
        public override Texture2D Graphics => CAFrameWork.Singleton.Graphics.Character;

        public override IGridTransform Transform => new DemoTransform();

        public override void Load()
        {
            inputFrame = new Rectangle(0, 2 * 64, 48, 64);
        }
        public override double GridY
        {
            get => base.GridY;
            set => base.GridY = value > 9 ? 9 : (value < 0 ? 0 : value);
        }
        public override double GridX {
            get => base.GridX;
            set => base.GridX = value > 9 ? 9 : (value < 0 ? 0 : value);
        }

        public void KeyUp()
        {
            this.GridY -= speed;
        }

        public void KeyDown()
        {
            this.GridY += speed;
        }

        public void KeyLeft()
        {
            this.GridX -= speed;
        }

        public void KeyRight()
        {
            this.GridX += speed;
        }

        public void KeySpace()
        {

        }
    }
}

