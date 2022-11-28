//using System;

//using CrazyArcade.CAFramework.Controller;
//using CrazyArcade.Singletons;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using CrazyArcade.CAFramework;

//namespace CrazyArcade.Demo1
//{
//	public class DemoCharacter: CAEntity, IControllable
//	{
//        private IController controller;

//        // for the sprite that have multiple directions,
//        // we need to have a list of sprite animations combined with direction to handle its different states
//        private SpriteAnimation[] spriteAnims;

//        public override SpriteAnimation SpriteAnim => spriteAnims[(int)direction];

//        public IController Controller
//        {
//            get => controller;
//            set
//            {
//                controller = value;
//                controller.Delegate = this;
//            }
//        }

//        public DemoCharacter(IController controller)
//		{
//            this.spriteAnims = new SpriteAnimation[4];
//            direction = Dir.Down;
//            X = 100;
//            Y = 100;

//            this.controller = controller;
//            controller.Delegate = this;
//		}

//        public override void Load()
//        {
//            //Texture2D texture, int frames, int offset, int height
//            this.spriteAnims[0] = new SpriteAnimation(SpriteSheet.Character, 6, 0, 66);
//            this.spriteAnims[1] = new SpriteAnimation(SpriteSheet.Character, 6, 67, 66);
//            this.spriteAnims[2] = new SpriteAnimation(SpriteSheet.Character, 6, 133, 66);
//            this.spriteAnims[3] = new SpriteAnimation(SpriteSheet.Character, 6, 199, 66);
            
//        }

//        public void KeyDown()
//        {
//            Y += 1;
//            Y = Y > 300 ? 300 : Y;
//            direction = Dir.Down;
//        }

//        public void KeyLeft()
//        {
//            X -= 1;
//            X = X < 0 ? 0 : X;
//            direction = Dir.Left;
//        }

//        public void KeyRight()
//        {
//            X += 1;
//            X = X > 300 ? 300 : X;
//            direction = Dir.Right;
//        }


//        public void KeyUp()
//        {
//            Y -= 1;
//            Y = Y < 0 ? 0 : Y;
//            direction = Dir.Up;
//        }

//        public void KeySpace()
//        {
//            Y += 1;
//        }
//        public void LeftClick(int x, int y)
//        {

//        }
//        public void LeftClick()
//        {

//        }
//        public void RightClick()
//        {

//        }
        
//        public void Key_o()
//        {

//        }
//        public void Key_p()
//        {

//        }


//    }
//}

