using System;

using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.CAFramework;

namespace CrazyArcade.Demo1
{
	public class DemoCharacter: CAEntity, IControllable
	{
        private IController controller;

        // for the sprite that have multiple directions,
        // we need to have a list of sprite animations combined with direction to handle its different states
        private SpriteAnimation[] spriteAnims;
        private Dir direction;

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

        public DemoCharacter(IController controller)
		{
            this.spriteAnims = new SpriteAnimation[4];
            direction = Dir.Down;
            GameCoord = new Vector2(100, 100);

            this.controller = controller;
            controller.Delegate = this;
		}

        public override void Load()
        {
            //Texture2D texture, int frames, int offset, int height
            this.spriteAnims[0] = new SpriteAnimation(SpriteSheet.Character, 6, 0, 66);
            this.spriteAnims[1] = new SpriteAnimation(SpriteSheet.Character, 6, 67, 66);
            this.spriteAnims[2] = new SpriteAnimation(SpriteSheet.Character, 6, 133, 66);
            this.spriteAnims[3] = new SpriteAnimation(SpriteSheet.Character, 6, 199, 66);
        }

        public void KeyDown()
        {
            GameCoord = new Vector2(GameCoord.X, (int)GameCoord.Y + 1);
            GameCoord = GameCoord.Y > 300 ? new Vector2(GameCoord.X, 300) : GameCoord;
            direction = Dir.Down;
        }

        public void KeyLeft()
        {
            GameCoord = new Vector2((int)GameCoord.X - 1, GameCoord.Y);
            GameCoord = GameCoord.X < 0 ? new Vector2(0, GameCoord.Y) : GameCoord;
            direction = Dir.Left;
        }

        public void KeyRight()
        {
            GameCoord = new Vector2((int)GameCoord.X + 1, GameCoord.Y);
            GameCoord = GameCoord.X > 300 ? new Vector2(300, GameCoord.Y) : GameCoord;
            direction = Dir.Right;
        }


        public void KeyUp()
        {
            GameCoord = new Vector2(GameCoord.X, (int)GameCoord.Y - 1);
            GameCoord = GameCoord.Y < 0 ? new Vector2(GameCoord.X, 0) : GameCoord;
            direction = Dir.Up;
        }

        public void KeySpace()
        {
            GameCoord = new Vector2(GameCoord.X, (int)GameCoord.Y + 1);
        }
        public void LeftClick(int x, int y)
        {

        }
        public void LeftClick()
        {

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

