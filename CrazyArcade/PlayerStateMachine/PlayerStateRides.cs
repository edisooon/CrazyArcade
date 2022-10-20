using System;
using System.Net.Http;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.PlayerStateMachine
{
    //overall goal is to keep ride synced with player, speed, location, and direction.
    public class PlayerStateRides : ICharacterState
    {
        Ride mount;
        private PlayerCharacter character;
        private int direction; //0-3, in line w/ spriteAnims

        public PlayerStateRides(PlayerCharacter character, int ride)
        {
            //int ride used to indicate turtle, pirate turtle, UFO, or owl [0-3]
            Ride newRide = new Ride(character, ride);
            mount = newRide;
        }

        public void ProcessAttaction()
        {
            // there shall be a way to store the free state inside player character
            // rather than create a new one (preserve the powerups)

            //character.playerState = character.PlayerStateFree;
            //add ride here?
            character.parentScene.AddSprite(mount);
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
            mount.Update(time);
        }

        public int SetSpeed()
        {
            return (int)character.CurrentSpeed.Length();//how come this is not vector type
        }

        public SpriteAnimation[] SetSprites()
        {
            return mount.spriteAnims;
        }
    }
}

