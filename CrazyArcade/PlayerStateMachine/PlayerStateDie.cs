using System;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;

namespace CrazyArcade.PlayerStateMachine
{
    public class PlayerStateDie : ICharacterState
    {
        SpriteAnimation[] die;
        public PlayerStateDie()
        {
            die = new SpriteAnimation[1];
            die[0] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 11, 7, 275, 531, 108, 10);
        }

        public void ProcessAttaction()
        {
            throw new NotImplementedException();
        }

        public void ProcessItem(Item toProcess)
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
            return die;
        }
    }
}

