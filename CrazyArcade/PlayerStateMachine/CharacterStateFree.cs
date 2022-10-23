using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
            d1HeldDown = false;
            d2HeldDown = false;
        }
        public SpriteAnimation[] SetSprites()
        {
            spriteAnims[0] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 14, 44, 56, 6, 4, 10);
            spriteAnims[1] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 78, 44, 56, 6, 4, 10);
            spriteAnims[2] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 142, 44, 56, 6, 4, 10);
            spriteAnims[3] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 206, 44, 56, 6, 4, 10);
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
        public void ProcessItem()
        {
            //nothing yet
        }
        public void ProcessRide()
        {
            //nothing yet
        }
        public int SetSpeed()
        {
            character.ModifiedSpeed = character.DefaultSpeed;
            return 1;
        }
        public void ProcessAttaction()
        {
            if (character.bombsOut >= character.bombCapacity) return;
            character.parentScene.AddSprite(new WaterBomb(character.GameCoord, character.currentBlastLength, character));
            character.bombsOut++;
        }
    }
}