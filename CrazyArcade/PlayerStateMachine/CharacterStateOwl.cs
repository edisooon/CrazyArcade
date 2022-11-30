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
    public class CharacterStateOwl : ICharacterState
    {
        private Character character;
        private PlayerOwl owl;
        public SpriteAnimation[] spriteAnims;
        private bool d1HeldDown;
        private bool d2HeldDown;
        private bool isPirate;
        public CharacterStateOwl(Character character, bool isPirate)
        {
            this.isPirate = isPirate;
            this.character = character;
            character.animationHandleInt = 0;
            owl = new PlayerOwl(character);
            //character.parentScene.AddSprite(turtle);
            character.SceneDelegate.ToAddEntity(owl);
            this.spriteAnims = new SpriteAnimation[4];

            this.character = character;

            d1HeldDown = false;
            d2HeldDown = false;

        }
        public bool ProcessAttaction()
        {
            return false;
        }

        public void ProcessItem(string itemName)
        {

        }

        public void ProcessRide()
        {

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
                owl.SpriteAnim.playing = false;
                owl.SpriteAnim.setFrame(0);
            }
            else
            {
                character.SpriteAnim.playing = true;
                owl.SpriteAnim.playing = true;
            }
        }
        public void endState()
        {
            owl.Delete_Self();
        }
        public int SetSpeed()
        {
            character.ModifiedSpeed = character.DefaultSpeed * 1.2f;
            return 1;
        }

        public SpriteAnimation[] SetSprites()
        {

            spriteAnims[(int)Dir.Up] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), new Rectangle(12, 460, 44, 52));
            spriteAnims[(int)Dir.Down] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), new Rectangle(60, 460, 44, 52));
            spriteAnims[(int)Dir.Left] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), new Rectangle(110, 460, 42, 56));
            spriteAnims[(int)Dir.Right] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), new Rectangle(156, 460, 42, 56));

            for (int i = 0; i < 4; i++)
            {
                spriteAnims[i].Scale = character.SpriteAnim.Scale;
            }
            return spriteAnims;
        }
    }
}
