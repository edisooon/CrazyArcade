using System;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.Demo1;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;

namespace CrazyArcade.PlayerStateMachine
{
    /*
     * State machine is implemented here
     * 
     */
    public class Character: CharacterBase, IBombCollectable, IItemCollidable
    {
		public SpriteAnimation[] spriteAnims;
        public CAScene parentScene;
        public ICharacterState playerState;
        public int animationHandleInt;
        public int currentBlastLength;
        public int bombCapacity = 2;
        private int bombOut;
        public int BombsOut => bombOut;
        static int CCount = 0;

        public override SpriteAnimation SpriteAnim => spriteAnims[animationHandleInt];

        public Character(CAScene scene)
        {
            ModifiedSpeed = DefaultSpeed;
            playerState = new CharacterStateFree(this);
            spriteAnims = playerState.SetSprites();
            playerState.SetSpeed();
            direction = Dir.Down;
            this.parentScene = scene;
            bombOut = 0;
            GameCoord = new Vector2(3, 3);
            currentBlastLength = defaultBlastLength;
            DrawOrder = 1;
            Console.WriteLine("Count: " + ++CCount);
            //this.bboxOffset = new Point(20, 20);
        }
        public override void Update(GameTime time)
        {
            playerState.ProcessState(time);
            //Console.WriteLine("bombsOut: " + BombsOut);
            base.Update(time);
        }

        //@implement IPlayerCollisionBehavior
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

        //@Implement IBombCollectable
        public void RecollectBomb()
        {
            bombOut = bombOut-- >= 0 ? bombOut-- : 0;
            Console.WriteLine("Recollect: " + BombsOut);
        }
        //@implement IItemCollidable
        public bool canHaveItem()
        {
            return (playerState is CharacterStateFree || playerState is CharacterStateRides);
        }
        public void IncreaseBlastLength()
        {
            this.currentBlastLength++;
        }
        public void SwitchToMountedState()
        {
            this.playerState = new CharacterStateRides(this, 0);
        }
        public void IncreaseSpeed()
        {
            this.ModifiedSpeed++;
        }
        public void IncreaseBombCount()
        {
            this.bombCapacity++;
        }

        public void SpendBomb()
        {
            bombOut++;
            Console.WriteLine("Spend: " + BombsOut);
        }
    }
}

