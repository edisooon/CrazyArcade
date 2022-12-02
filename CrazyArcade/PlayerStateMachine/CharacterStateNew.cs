using System;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;

namespace CrazyArcade.PlayerStateMachine
{
    public class CharacterStateNew : ICharacterState
    {
        private bool isPirate;
        private Character character;
        public CharacterStateNew(Character character, bool isPirate)
        {
            this.isPirate = isPirate;
            character.spriteAnims = SetSprites();
            character.ModifiedSpeed = 0;
        }

        public bool CouldGetItem { get => false; }

        public bool CouldPutBomb { get => false; }

        public void ProcessAttaction()
        {
            //player wouldn't take attaction any more when in new state
        }

        public void ProcessItem()
        {
            //player cannot process/use item when in new state
        }

        public void ProcessRide(RideType type)
        {
            //player cannot get a ride when in new state
        }

        public void ProcessState(GameTime time)
        {
            throw new NotImplementedException();
        }

        public SpriteAnimation[] SetSprites()
        {
            SpriteAnimation[] start = new SpriteAnimation[1];
            start[0] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), 10, 7, 527, 480, 64, 10);
            return start;
        }

    }
}

