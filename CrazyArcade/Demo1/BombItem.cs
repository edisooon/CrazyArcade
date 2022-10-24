using CrazyArcade.CAFramework.Controller;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Demo1
{
    internal class BombItem : CAEntity, IControllable
    {
        public BombItem(IController controller)
        {
            this.controller = controller;
            controller.Delegate = this;
        }
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

        Point position = new Point(100, 100);

        public override SpriteAnimation SpriteAnim => throw new NotImplementedException();

        public void KeyDown()
        {
        }

        public void KeyLeft()
        {
        }

        public void KeyRight()
        {
        }


        public void KeyUp()
        {
        }

        public void KeySpace()
        {
        }

        public override void Update(GameTime time)
        {

        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public void RightClick()
        {
            throw new NotImplementedException();
        }

        public void LeftClick()
        {
            throw new NotImplementedException();
        }
        public void LeftClick(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
