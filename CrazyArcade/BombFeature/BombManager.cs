using CrazyArcade.CAFramework.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.BombFeature
{
    public class BombManager : IControllable
    {
        public BombManager(IController controller)
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
        public void KeyUp()
        {

        }
        public void KeyDown()
        {

        }
        public void KeyLeft()
        {

        }
        public void KeyRight()
        {

        }
        public void KeySpace()
        {

        }
        public void LeftClick()
        {

        }
        public void RightClick()
        {

        }
    }
}
