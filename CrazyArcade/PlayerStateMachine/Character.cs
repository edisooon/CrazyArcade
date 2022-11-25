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
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.UI.GUI_Components;

namespace CrazyArcade.PlayerStateMachine
{
    /*
     * State machine is implemented here
     * 
     */
    public class Character: CharacterBase, IExplosionCollidable, IPlayerCollisionBehavior, ISavable
    {
		public SpriteAnimation[] spriteAnims;
        public CAScene parentScene;
        public ICharacterState playerState;
        public int animationHandleInt;
        static int CCount = 0;
        private int loseRideFlag = 5;
        public int lives;
        private int score = 0;
        //private bool invincible = false;
        private int ICounter = 0;

        public override SpriteAnimation SpriteAnim => spriteAnims[animationHandleInt];

        public ICharacterState State => playerState;

        public Character()
        {
            //ModifiedSpeed = DefaultSpeed;
            playerState = new CharacterStateFree(this);
            direction = Dir.Down;
            GameCoord = new Vector2(3, 3);
            //currentBlastLength = defaultBlastLength;
            DrawOrder = 1;
            lives = 2;
            //Console.WriteLine("Count: " + ++CCount);
            //this.bboxOffset = new Point(20, 20);
        }
        public override void Update(GameTime time)
        {
            //ProcessInvincibility();
            playerState.ProcessState(time);
            //Console.WriteLine("bombsOut: " + BombsOut);
            base.Update(time);
        }
        //private void ProcessInvincibility()
        //{
        //    if(invincible)
        //    {
        //        ICounter++;
        //        if(ICounter >= 30)
        //        {
        //            invincible = false;
        //            ICounter = 0;
        //        }
        //    }
        //}
        public void CollisionHaltLogic(Point move)
        {
            //GameCoord -= Trans.RevScale(new Vector2(move.X, move.Y));
        }

        //@implement IPlayerCollisionBehavior
        public void CollisionDestroyLogic()
        {
            this.playerState.ProcessAttaction();
        }
        public override void Load()
        {

        }

        //@implement IItemCollidable
        //public bool canHaveItem()
        //{
        //    return (playerState is CharacterStateFree || playerState is CharacterStateTurtle);
        //}
        public void IncreaseBlastLength()
        {
            playerItems.AddItem(new BlastLengthModifier());
        }
        public void EnableKick()
        {
            playerItems.AddItem(new KickModifier());
        }
        //public void SwitchToMountedState()
        //{
        //    this.playerState = new CharacterStateMounted(this);
        //    Console.WriteLine("has triggerred");
        //}
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
            if (this.playerState.CouldGetItem)
            {
                this.score += score;
                UI_Singleton.ChangeComponentText("score", "scoreText", "Score : " + this.score);
            }

        }


        public bool Collide(IExplosion bomb)
        {
            CollisionDestroyLogic();
            return true;
        }
        public void Save(LevelPersnstance level)
        {
            level.SavedStatInt.Add("playerScore", score);
            level.SavedStatInt.Add("playerLives", lives);
        }
        public void Load(LevelPersnstance level)
        {
            if (level.SavedStatInt.ContainsKey("playerScore"))
            {
                score = level.SavedStatInt["playerScore"];
                UI_Singleton.ChangeComponentText("score", "scoreText", "Score : " + this.score);
            }
            if (level.SavedStatInt.ContainsKey("playerLives"))
            {
                lives = level.SavedStatInt["playerLives"];
                UI_Singleton.ChangeComponentText("lifeCounter", "count", "Lives: " + lives);
            }
        }
    }
}

