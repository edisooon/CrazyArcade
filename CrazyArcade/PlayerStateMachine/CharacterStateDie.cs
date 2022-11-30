using System;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;
using CrazyArcade.Levels;

namespace CrazyArcade.PlayerStateMachine
{
    public class CharacterStateDie : ICharacterState
    {
        private Character character;
        private bool isPirate;
        public CharacterStateDie(Character character, bool isPirate)
        {
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

        public void ProcessRide()
        {
            //player cannot get a ride when in dead state
        }

        public void ProcessState(GameTime time)
        {
            //throw new NotImplementedException();
            if (character.SpriteAnim.getCurrentFrame() == character.SpriteAnim.getTotalFrames() - 1)
            {
                character.playerState = new CharacterStateFree(character, isPirate);
                character.lives--;
                if (character.lives == 0)
                {
                    character.SceneDelegate.EndGame();
                }
            }
        }

        public SpriteAnimation[] SetSprites()
        {
            SpriteAnimation[] die = new SpriteAnimation[1];
            die[0] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), 11, 7, 275, 531, 108, 10);
            return die;
        }
    }
}

