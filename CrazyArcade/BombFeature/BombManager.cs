using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.BombFeature
{
    public class BombManager : IControllable
    {
        //depreciated test method, marked for deletion
        public BombManager(IController controller, CAScene Scene)
        {
            this.controller = controller;
            controller.Delegate = this;
            this.Scene = Scene;
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
        private CAScene Scene;
        Random random = new();
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
        public void LeftClick(int X, int Y)
        {
            Debug.WriteLine(X + " " + Y);
            //Scene.AddSprite(new WaterBomb(Scene, X, Y, random.Next(1, 7)));
        }
        public void RightClick()
        {

        }
        public void Key_o()
        {

            

        }
        public void Key_p()
        {

            
        }
    }
}
