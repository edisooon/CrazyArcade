using System;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;

namespace CrazyArcade.PlayerStateMachine
{
    public class CharacterStateNew : ICharacterState
    {
        SpriteAnimation[] start;
        public CharacterStateNew()
        {
            start = new SpriteAnimation[1];
            start[0] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 10, 7, 527, 480, 64, 10);
        }

        public bool CouldPutBomb()
        {
            return false;
        }

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

        public int SetSpeed()
        {
            return 0;
        }

        public SpriteAnimation[] SetSprites()
        {
            return start;
        }
    }
}

