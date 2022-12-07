using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.GameGridSystems;
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
    public class CharacterStateM2F : ICharacterState
    {
        private Character character;
        private int high = CAGameGridSystems.BlockLength + 25;
        private int initial;
        private int dest = 20;
        private int dist = 0;
        bool isPirate;
        public CharacterStateM2F(Character character, bool isPirate)
        {
            this.isPirate = isPirate;
            this.character = character;
            this.initial = character.bboxOffset.Y;
            character.animationHandleInt = 0;
            character.spriteAnims = SetSprites();
        }

        public bool CouldPutBomb { get => false; }

        public bool CouldGetItem { get => false; }

        public void ProcessAttaction()
        {
        }

        public void ProcessRide(RideType type, Vector2 pos)
        {
        }

        public void ProcessState(GameTime time)
        {
            //character.CalculateMovement();
            //character.UpdatePosition();
            character.animationHandleInt = (int)character.direction;
            if (dist < high - initial)
            {
                character.bboxOffset.Y += 2;
            }
            else
            {
                if (character.bboxOffset.Y <= dest)
                {
                    character.bboxOffset.Y = dest;
                    character.playerState = new CharacterStateFree(character, isPirate);
                }
                else
                {
                    character.bboxOffset.Y -= 2;
                }
            }
            dist += 2;
        }

        public SpriteAnimation[] SetSprites()
        {
            SpriteAnimation[] spriteAnims = new SpriteAnimation[4];
            spriteAnims[(int)Dir.Up] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), new Rectangle(12, 460, 44, 56));
            spriteAnims[(int)Dir.Down] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), new Rectangle(60, 460, 44, 56));
            spriteAnims[(int)Dir.Left] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), new Rectangle(110, 460, 44, 56));
            spriteAnims[(int)Dir.Right] = new SpriteAnimation(TextureSingleton.GetPlayer(isPirate), new Rectangle(156, 460, 44, 56));

            for (int i = 0; i < 4; i++)
            {
                spriteAnims[i].SetScale(0.93f);
            }
            return spriteAnims;
        }

        public void ProcessItem(string itemName)
        {
            //if (itemName == "shield" && !character.invincible && character.shields > 0) character.SetInvincibilityTime(300);
        }
    }
}