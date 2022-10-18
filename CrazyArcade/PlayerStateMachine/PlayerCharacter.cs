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
        private IController controller;
        public SpriteAnimation[] spriteAnims;
        public CAScene parentScene;
        public ICharacterState playerState;
        public int animationHandleInt;
        public int currentBlastLength;
        public int bombCapacity = 1;
        public int bombsOut;

        public override SpriteAnimation SpriteAnim => spriteAnims[animationHandleInt];

        public IController Controller
        {
            get => controller;
            set
            {
                controller = value;
                controller.Delegate = this;
            }
        }
        public PlayerCharacter(IController controller, CAScene scene)
        {
            ModifiedSpeed = DefaultSpeed;
            playerState = new PlayerStateFree(this);
            spriteAnims = playerState.SetSprites();
            playerState.SetSpeed();
            direction = Dir.Down;
            this.parentScene = scene;
            bombsOut = 0;
            X = 100;
            Y = 100;
            currentBlastLength = defaultBlastLength;
            this.controller = controller;
            controller.Delegate = this;
            //this.bboxOffset = new Point(20, 20);
        }
        public override void Update(GameTime time)
        {
            
            playerState.ProcessState(time);
            base.Update(time);
        }
        public void BombExplode()
        {
            bombsOut = bombsOut-- >= 0 ? bombsOut-- : 0;
        }
        public override void Load()
        {

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