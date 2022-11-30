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
        SpriteAnimation[] die;
        private Character character;
        private bool isPirate;
        public CharacterStateDie(Character character, bool isPirate)
        {
            this.isPirate = isPirate;
            this.character = character;
            die = new SpriteAnimation[1];
            die[0] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), 11, 7, 275, 531, 108, 10);
        }

        public bool ProcessAttaction()
        {
            throw new NotImplementedException();
        }

        public void ProcessItem()
        {
            throw new NotImplementedException();
        }

        public void ProcessRide()
        {
            throw new NotImplementedException();
        }

        public void ProcessState(GameTime time)
        {
            //throw new NotImplementedException();
            if (character.SpriteAnim.getCurrentFrame() == character.SpriteAnim.getTotalFrames() - 1)
            {
                character.playerState = new CharacterStateFree(character, isPirate);
                character.spriteAnims = character.playerState.SetSprites();
                character.playerState.SetSpeed();
                character.lives--;
                if (character.lives == 0)
                {
                    character.SceneDelegate.EndGame();
                }
            }
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

