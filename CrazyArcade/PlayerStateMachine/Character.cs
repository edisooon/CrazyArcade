using System;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.Demo1;
using Microsoft.Xna.Framework;

namespace CrazyArcade.PlayerStateMachine
{
	public class Character: CharacterBase, IBombCollectable
    {
		public SpriteAnimation[] spriteAnims;
        public CAScene parentScene;
        public ICharacterState playerState;
        public int animationHandleInt;
        public int currentBlastLength;
        public int bombCapacity = 1;
        public int bombsOut;

        private int x;
        private int y;
        public override int X {
            get => x; set
            {
                Console.WriteLine("Set X: " + value);
                x = value;
            }
        }
        public override int Y
        {
            get => y;
            set
            {
                Console.WriteLine("Set Y: " + value);
                y = value;
            }
        }

        public override SpriteAnimation SpriteAnim => spriteAnims[animationHandleInt];
       
        
        public Character(CAScene scene)
        {
            ModifiedSpeed = DefaultSpeed;
            playerState = new CharacterStateFree(this);
            spriteAnims = playerState.SetSprites();
            playerState.SetSpeed();
            direction = Dir.Down;
            this.parentScene = scene;
            bombsOut = 0;
            X = 100;
            Y = 100;
            currentBlastLength = defaultBlastLength;
            //this.bboxOffset = new Point(20, 20);
        }
        public override void Update(GameTime time)
        {
            playerState.ProcessState(time);
            base.Update(time);
        }
        public override void CollisionDestroyLogic()
        {
            if (this.playerState is CharacterStateBubble) return;
            this.playerState = new CharacterStateBubble(this);
            this.spriteAnims = this.playerState.SetSprites();
            this.playerState.SetSpeed();
        }
        public override void Load()
        {

        }

        public void recollectBomb()
        {
            bombsOut = bombsOut-- >= 0 ? bombsOut-- : 0;
        }
    }
}

