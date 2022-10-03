using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Enemy;

namespace CrazyArcade.Enemy
{
    public class EnemyManager : IControllable

    {
        int i = 0;
        int length;
        int X;
        int Y;
        CAEntity[] CAEntityList;
        CAEntity currentSprite;
        CAEntity oldSprite;

        public EnemyManager(IController controller, CAScene Scene)
        {
            length = 4;
            X = 100;
            Y = 400;
            CAEntityList = new CAEntity[length];
            CAEntityList[0] = new BombEnemySprite(X, Y);
            CAEntityList[1] = new SquidEnemySprite(X, Y);
            CAEntityList[2] = new BatEnemySprite(X, Y);
            CAEntityList[3] = new RobotEnemySprite(X, Y);
            currentSprite = CAEntityList[i];

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
        public void Key_o()
        {

            if (oldSprite != null)
            {
  
                Scene.RemoveSprite(oldSprite);
            }
            Scene.AddSprite(currentSprite);
            oldSprite = currentSprite;
            currentSprite = CAEntityList[i];
            i++;
            if (i == CAEntityList.Length)
            {
                i = 0;
            }

        }
        public void Key_p()
        {

            if (oldSprite != null)
            {

                Scene.RemoveSprite(oldSprite);
            }
            Scene.RemoveSprite(oldSprite);
            Scene.AddSprite(currentSprite);
            oldSprite = currentSprite;
            currentSprite = CAEntityList[i];
            i--;
            if (i == -1)
            {
                i = CAEntityList.Length - 1;
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
        public void LeftClick(int X, int Y)
        {
            
        }
        public void RightClick()
        {

        }

    }
}
