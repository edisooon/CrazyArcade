using System;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;

namespace CrazyArcade.PlayerStateMachine
{
    public class CharacterStateRides : ICharacterState
    {
        int turtleSpeed = 2;
        public SpriteAnimation[] spriteAnims;
        private PlayerCharacter character;

        public CharacterStateRides(PlayerCharacter character)
        {
            spriteAnims = new SpriteAnimation[4];
            spriteAnims[0] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 4, 96, 32, 3);
            spriteAnims[1] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 37, 96, 32, 3);
            spriteAnims[2] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 68, 96, 32, 3);
            spriteAnims[3] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 100, 96, 32, 3);

            this.character = character;
        }

        public void ProcessAttaction()
        {
            // there shall be a way to store the free state inside player character
            // rather than create a new one (preserve the powerups)

            //pesudo code:
            // character.playerState = character.playerFree;
        }

        public void ProcessItem()
        {
            //pesudo code:
            // character.playerFree.ProcessItem();
        }

        public void ProcessRide()
        {
            // shall do nothing
        }

        public void ProcessState(GameTime time)
        {
            throw new NotImplementedException();
        }

        public int SetSpeed()
        {
            return turtleSpeed;
        }

        public SpriteAnimation[] SetSprites()
        {
            return spriteAnims;
        }
    }
}

