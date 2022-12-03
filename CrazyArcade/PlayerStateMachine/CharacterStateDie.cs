using System;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;
using CrazyArcade.Levels;
using CrazyArcade.CAFrameWork;

namespace CrazyArcade.PlayerStateMachine
{
    public class CharacterStateDie : ICharacterState
    {
        ITimer timer;
        private Character character;
        private bool isPirate;
		SpriteAnimation[] die = new SpriteAnimation[1];
		public CharacterStateDie(Character character, bool isPirate)
		{
            SpriteAnimation anim = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), 11, 7, 275, 531, 108, 10);
            anim.Scale = 0.5f;
			die[0] = new FadeOutEffect(anim, 1000);
            //die[0].Scale = 0.5f;
			this.isPirate = isPirate;
            this.character = character;
            character.spriteAnims = SetSprites();
            character.ModifiedSpeed = 0;
        }

        public bool CouldGetItem { get => false; }

        public bool CouldPutBomb { get => false; }

        public void ProcessAttaction()
        {
            //player wouldn't take attaction any more when in dead state
        }

        public void ProcessItem()
        {
            //player cannot process/use item when in dead state
        }

        public void ProcessRide(RideType type)
        {
            //player cannot get a ride when in dead state
        }

        public void ProcessState(GameTime time)
        {
            if (timer == null)
            {
                timer = new CATimer(time.TotalGameTime);
            }
            timer.Update(time.TotalGameTime);
            if (timer.TotalMili > 1000)
            {
                character.SceneDelegate.ToRemoveEntity(character);
				if (character.lives == 0 && !isPirate)
				{
					character.SceneDelegate.EndGame();
				}
			}
			character.spriteAnims = character.playerState.SetSprites();
			//throw new NotImplementedException();
			
        }

        public SpriteAnimation[] SetSprites()
        {
            return die;
        }
    }
}

