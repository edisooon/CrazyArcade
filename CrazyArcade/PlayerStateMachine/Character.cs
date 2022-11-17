using System;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.Demo1;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;
using CrazyArcade.CAFrameWork.GameStates;
using CrazyArcade.PlayerStateMachine.PlayerItemInteractions;
using CrazyArcade.Blocks;
using System.Diagnostics;
using CrazyArcade.UI;
using CrazyArcade.UI.GUI_Compositions;

namespace CrazyArcade.PlayerStateMachine
{
    /*
     * State machine is implemented here
     * 
     */
    public class Character: CharacterBase, IBombCollectable, IExplosionCollidable, IPlayerCollisionBehavior
    {
		public SpriteAnimation[] spriteAnims;
        public CAScene parentScene;
        public ItemContainer playerItems = new();
        public ICharacterState playerState;
        public int animationHandleInt;
        public int CurrentBlastLength { get => playerItems.BlastModifier; set { playerItems.BlastModifier = value; } }
        public int BombCapacity {get => playerItems.BombModifier; set { playerItems.BombModifier = value; } }
        public int FreeModifiedSpeed { get => playerItems.SpeedModifier; }
        private int bombOut;
        public int BombsOut => bombOut;
        static int CCount = 0;
        private int loseRideFlag = 5;
        private bool couldKick = true;
        public bool CouldKick { get => couldKick; }
        public int lives;
        private int score = 0;
        private bool invincible = false;
        private int ICounter = 0;

        public override SpriteAnimation SpriteAnim => spriteAnims[animationHandleInt];

        public Character()
        {
            //ModifiedSpeed = DefaultSpeed;
            playerState = new CharacterStateFree(this);
            spriteAnims = playerState.SetSprites();
            playerState.SetSpeed();
            direction = Dir.Down;
            bombOut = 0;
            GameCoord = new Vector2(3, 3);
            //currentBlastLength = defaultBlastLength;
            DrawOrder = 1;
            lives = 2;
            Console.WriteLine("Count: " + ++CCount);
            //this.bboxOffset = new Point(20, 20);
        }
        public override void Update(GameTime time)
        {
            ProcessInvincibility();
            playerState.ProcessState(time);
            //Console.WriteLine("bombsOut: " + BombsOut);
            base.Update(time);
        }
        private void ProcessInvincibility()
        {
            if(invincible)
            {
                ICounter++;
                if(ICounter >= 30)
                {
                    invincible = false;
                    ICounter = 0;
                }
            }
        }
        public void CollisionHaltLogic(Point move)
        {
            GameCoord -= Trans.RevScale(new Vector2(move.X, move.Y));
        }

        //@implement IPlayerCollisionBehavior
        public void CollisionDestroyLogic()
        {
            if (this.playerState is CharacterStateBubble || invincible) return;
            if (this.playerState is CharacterStateTurtle )
            {
                
                this.playerState = new CharacterStateFree(this);
                loseRideFlag = 0;
                invincible = true;
            }
            else if (loseRideFlag >= 5)
            {
                this.playerState = new CharacterStateBubble(this);
            }
            else
            {
                loseRideFlag++;
            }
            
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
            return (playerState is CharacterStateFree || playerState is CharacterStateTurtle);
        }
        public void IncreaseBlastLength()
        {
            playerItems.AddItem(new BlastLengthModifier());
        }
        public void SwitchToMountedState()
        {
            this.playerState = new CharacterStateTurtle(this);
            spriteAnims = this.playerState.SetSprites();
            this.playerState.SetSpeed();
        }
        public void IncreaseSpeed()
        {
            playerItems.AddItem(new SpeedModifier());
        }
        public void IncreaseBombCount()
        {
            playerItems.AddItem(new BombCountModifier());
        }
        public void IncreaseScore(int score)
        {
            this.score += score;
            UI_Singleton.ChangeComponentText("score", "scoreText", "Score : " + this.score);
        }

        public void SpendBomb()
        {
            bombOut++;
            Console.WriteLine("Spend: " + BombsOut);
        }

        public bool Collide(IExplosion bomb)
        {
            CollisionDestroyLogic();
            return true;
        }
    }
}

