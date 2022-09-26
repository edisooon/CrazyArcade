using CrazyArcade.CAFramework.Controller;
using CrazyArcade.CAFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFrameWork;
using CrazyArcade.Demo1;
using CrazyArcade.Singletons;
using CrazyArcade.Content;

namespace CrazyArcade.PlayerStateMachine
{
    public class PlayerCharacter : Character, IControllable
    {
        private IController controller;
        private SpriteAnimation[] spriteAnims;
        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];
        public IController Controller
        {
            get => controller;
            set
            {
                controller = value;
                controller.Delegate = this;
            }
        }
        public PlayerCharacter(IController controller)
        {
            this.spriteAnims = new SpriteAnimation[4];
            direction = Dir.Down;
            X = 100;
            Y = 100;

            this.controller = controller;
            controller.Delegate = this;
        }

        public override void Load()
        {
            spriteAnims[0] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 14, 44, 56, 6, 4, 10);
            spriteAnims[1] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 78, 44, 56, 6, 4, 10);
            spriteAnims[2] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 142, 44, 56, 6, 4, 10);
            spriteAnims[3] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 206, 44, 56, 6, 4, 10);
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

        }

        public void RightClick()
        {

        }

        public void LeftClick(int x, int y)
        {

        }
    }
}
