using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.Demo1
{
	public class DemoCharacter: CAEntity, IControllable
	{
        private IController controller;

        public IController Controller
        {
            get => controller;
            set
            {
                controller = value;
                controller.Delegate = this;
            }
        }

        public override Rectangle OutputFrame => new Rectangle(position.X, position.Y, 56, 67);
        public override Rectangle InputFrame => new Rectangle(0, 67, 56, 67);


        public DemoCharacter(IController controller)
		{
            this.position = new Point(100, 100);
            this.tint = Color.White;

            this.controller = controller;
            controller.Delegate = this;
		}

        public override void Load()
        {
            this.texture = Singletons.SpriteSheet.Character;
        }

        public override void Update(GameTime time)
        {

        }

        public void KeyDown()
        {
            position.Y += 1;
            position.Y = position.Y > 300 ? 300 : position.Y;
        }

        public void KeyLeft()
        {
            position.X -= 1;
            position.X = position.X < 0 ? 0 : position.X;
        }

        public void KeyRight()
        {
            position.X += 1;
            position.X = position.X > 300 ? 300 : position.X;
        }


        public void KeyUp()
        {
            position.Y -= 1;
            position.Y = position.Y < 0 ? 0 : position.Y;
        }

        public void KeySpace()
        {
            position.Y += 1;
        }

    }
}

