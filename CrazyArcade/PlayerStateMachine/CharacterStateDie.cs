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
        SpriteAnimation[] die;
        private Character character;
        private bool isPirate;
        public CharacterStateDie(Character character, bool isPirate)
        {
            this.isPirate = isPirate;
            this.character = character;
            die = new SpriteAnimation[1];
            die[0] = new FadeOutEffect(new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), 11, 7, 275, 531, 108, 10), 1000);
        }

        public bool ProcessAttaction()
        {
            return false;
        }

        public void ProcessItem()
        {
            
        }

        public void ProcessRide()
        {
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

        public int SetSpeed()
        {
            return 0;
        }

        public SpriteAnimation[] SetSprites()
        {
            return die;
        }
    }
}

