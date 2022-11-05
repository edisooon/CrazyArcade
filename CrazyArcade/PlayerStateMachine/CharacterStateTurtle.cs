using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine
{
    public class CharacterStateTurtle : ICharacterState
    {
        private Character character;
        private PlayerTurtle turtle;
        public SpriteAnimation[] spriteAnims;
        private bool d1HeldDown;
        private bool d2HeldDown;
        public CharacterStateTurtle(Character character)
        {
            this.character = character;
            character.animationHandleInt = 0;
            turtle = new PlayerTurtle(character, character.parentScene);
            character.parentScene.AddSprite(turtle);
            this.spriteAnims = new SpriteAnimation[4];
            this.character = character;
            d1HeldDown = false;
            d2HeldDown = false;

        }
        public void ProcessAttaction()
        {
            //can't
        }

        public void ProcessItem()
        {
            //nope
        }

        public void ProcessRide()
        {
            //Nope
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
                turtle.SpriteAnim.playing = false;
                turtle.SpriteAnim.setFrame(0);
            }
            else
            {
                character.SpriteAnim.playing = true;
                turtle.SpriteAnim.playing = true;
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
                character.bombCapacity = character.bombCapacity + 1 < 5 ? character.bombCapacity + 1 : 5;
            }
            d2HeldDown = Keyboard.GetState().IsKeyDown(Keys.D2);

        }
        public void endState()
        {
            turtle.Delete_Self();
        }
        public int SetSpeed()
        {
            character.ModifiedSpeed = character.DefaultSpeed*2f;
            return 1;
        }

        public SpriteAnimation[] SetSprites()
        {
            spriteAnims[(int)Dir.Up] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 14, 44, 56, 6, 4, 10);
            spriteAnims[(int)Dir.Down] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 78, 44, 56, 6, 4, 10);
            spriteAnims[(int)Dir.Left] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 142, 44, 56, 6, 4, 10);
            spriteAnims[(int)Dir.Right] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 206, 44, 56, 6, 4, 10);
            return spriteAnims;
        }
    }
}
