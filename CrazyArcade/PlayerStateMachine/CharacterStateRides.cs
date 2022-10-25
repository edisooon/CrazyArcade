using System;
using System.Net.Http;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.PlayerStateMachine
{
    //overall goal is to keep ride synced with player, speed, location, and direction.
    //This class should only be able to lead to the free state, implementing the extra life
    public class PlayerStateRides : ICharacterState
    {
        Ride mount;
        private Character character;
        private bool d1HeldDown;
        private bool d2HeldDown;

        public PlayerStateRides(Character character, int ride)
        {
            //int ride used to indicate turtle, pirate turtle, UFO, or owl [0-3]
            //only use 0 for now
            this.character = character;
            Ride newRide = new(character, ride);
            mount = newRide;
            d1HeldDown = false;
            d2HeldDown = false;
            character.parentScene.AddSprite(mount);
        }

        public void ProcessAttaction()
        {
            // there shall be a way to store the free state inside player character
            // rather than create a new one (preserve the powerups)

            //character.playerState = character.PlayerStateFree;
            //add ride here?
            
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
            //duplicate code, fix
            character.CalculateMovement();
            character.UpdatePosition();
            character.animationHandleInt = (int)character.direction;
            character.playerState = new PlayerStateRides(character, 0);
            character.spriteAnims = character.playerState.SetSprites();
            character.playerState.SetSpeed();
            if (character.CurrentSpeed.X == 0 && character.CurrentSpeed.Y == 0)
            {
                character.SpriteAnim.playing = false;
                character.SpriteAnim.setFrame(0);
            }
            else
            {
                character.SpriteAnim.playing = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                character.playerState = new CharacterStateBubble(character);
                character.spriteAnims = character.playerState.SetSprites();
                character.playerState.SetSpeed();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D1) && !d1HeldDown)
            {
                d1HeldDown = true;
                character.currentBlastLength = character.currentBlastLength + 1 < 5 ? character.currentBlastLength + 1 : 5;
            }
            d1HeldDown = Keyboard.GetState().IsKeyDown(Keys.D1);
            if (Keyboard.GetState().IsKeyDown(Keys.D2) && !d2HeldDown)
            {
                d2HeldDown = true;
                character.bombCapacity = character.bombCapacity + 1 < 3 ? character.bombCapacity + 1 : 3;
            }
            d2HeldDown = Keyboard.GetState().IsKeyDown(Keys.D2);
        }

        public int SetSpeed()

        {
            character.ModifiedSpeed = 7;
            return 1;
        }

        public SpriteAnimation[] SetSprites()
        {
            SpriteAnimation[] newSprites = mount.spriteAnims;
            return newSprites;
        }
    }
}