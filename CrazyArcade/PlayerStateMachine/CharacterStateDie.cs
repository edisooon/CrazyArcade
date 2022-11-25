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
        public CharacterStateDie(Character character)
        {
            this.character = character;
            die = new SpriteAnimation[1];
            die[0] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 11, 7, 275, 531, 108, 10);
            character.spriteAnims = SetSprites();
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

