using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.GameGridSystems;

namespace CrazyArcade.PlayerStateMachine
{
    internal class CharacterStateFree : ICharacterState
    {
        private Character character;
        public SpriteAnimation[] spriteAnims;
        private bool d1HeldDown;
        private bool d2HeldDown;
        public CharacterStateFree(Character character)
        {
            this.spriteAnims = new SpriteAnimation[4];
            this.character = character;
            character.spriteAnims = SetSprites();
            character.ModifiedSpeed = character.DefaultSpeed;   // not sure, since character shouldn't use default speed after being mounted, would modify later
            d1HeldDown = false;
            d2HeldDown = false;
        }

        public bool CouldPutBomb { get => true; }

        public bool CouldGetPowerup { get => true; }

        public SpriteAnimation[] SetSprites()
        {
            spriteAnims[(int)Dir.Up] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 14, 44, 56, 6, 4, 10);
            spriteAnims[(int)Dir.Down] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 78, 44, 56, 6, 4, 10);
            spriteAnims[(int)Dir.Left] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 142, 44, 56, 6, 4, 10);
            spriteAnims[(int)Dir.Right] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 206, 44, 56, 6, 4, 10);
            return spriteAnims;
        }
        public void ProcessState(GameTime time)
        {
            character.CalculateMovement();
            character.UpdatePosition();
            character.animationHandleInt = (int)character.direction;
            if (character.CurrentSpeed.X == 0 && character.CurrentSpeed.Y == 0)
            {
                character.SpriteAnim.playing = false;
                character.SpriteAnim.setFrame(0);
            }
            else
            {
                character.SpriteAnim.playing = true;
            }
            //if (Keyboard.GetState().IsKeyDown(Keys.E))
            //{
            //    character.playerState = new CharacterStateBubble(character);
            //    character.spriteAnims = character.playerState.SetSprites();
            //    character.playerState.SetSpeed();
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D1) && !d1HeldDown)
            //{
            //    d1HeldDown = true;
            //    character.CurrentBlastLength = character.CurrentBlastLength + 1 < 5 ? character.CurrentBlastLength + 1 : 5;
            //}
            //d1HeldDown = Keyboard.GetState().IsKeyDown(Keys.D1);
            //if (Keyboard.GetState().IsKeyDown(Keys.D2) && !d2HeldDown)
            //{
            //    d2HeldDown = true;
            //    character.BombCapacity = character.BombCapacity + 1 < 5 ? character.BombCapacity + 1 : 5;
            //}
            //d2HeldDown = Keyboard.GetState().IsKeyDown(Keys.D2);
        }
        public void ProcessItem()
        {

        }
        public void ProcessRide()
        {
            //this.character.playerState = new CharacterStateRides(this.character);
        }
        public void ProcessAttaction()
        {
            character.playerState = new CharacterStateBubble(character);
        }

    }
}