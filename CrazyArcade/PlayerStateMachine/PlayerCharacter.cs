using CrazyArcade.CAFramework.Controller;
using CrazyArcade.CAFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CrazyArcade.Demo1;
using CrazyArcade.Singletons;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using CrazyArcade.BombFeature;

namespace CrazyArcade.PlayerStateMachine
{
    public class PlayerCharacter : Character, IControllable
    {
        public IController Controller
        {
            get => controller;
            set
            {
                controller = value;
                controller.Delegate = this;
            }
        }

        private IController controller;

        public PlayerCharacter(IController controller, CAScene scene): base(scene)
        {
            this.controller = controller;
            controller.Delegate = this;
        }
        public void KeyUp()
        {
            moveInputs.Y -= 1;
            direction = Dir.Up;
        }

        public void KeyDown()
        {
            moveInputs.Y += 1;
            direction = Dir.Down;
        }

        public void KeyLeft()
        {
            moveInputs.X -= 1;
            direction = Dir.Left;
        }

        public void KeyRight()
        {
            moveInputs.X += 1;
            direction = Dir.Right;
        }

        public void KeySpace()
        {
            playerState.ProcessAttaction();
        }

        public void RightClick()
        {

        }

        public void LeftClick(int x, int y)
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