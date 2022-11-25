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
        public CharacterStateDie(Character character)
        {
            this.character = character;
            character.spriteAnims = SetSprites();
            character.ModifiedSpeed = 0;
        }

        public bool CouldGetPowerup { get => false; }

        public bool CouldPutBomb { get => false; }

        public void ProcessAttaction()
        {
            //throw new NotImplementedException();
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
                character.playerState = new CharacterStateFree(character);
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
            die[0] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 11, 7, 275, 531, 108, 10);
            return die;
        }
    }
}

