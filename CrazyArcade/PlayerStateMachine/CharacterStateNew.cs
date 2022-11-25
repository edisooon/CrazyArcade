using System;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;

namespace CrazyArcade.PlayerStateMachine
{
    public class CharacterStateNew : ICharacterState
    {
        private Character character;
        public CharacterStateNew(Character character)
        {
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
            throw new NotImplementedException();
        }

        public SpriteAnimation[] SetSprites()
        {
            SpriteAnimation[] start = new SpriteAnimation[1];
            start[0] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 10, 7, 527, 480, 64, 10);
            return start;
        }
    }
}

