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
    public class CharacterStateF2M : ICharacterState
    {
        private Character character;
        private PlayerRide ride;
        private int initial;
        private int high = CAGameGridSystems.BlockLength+20;
        private int dest = CAGameGridSystems.BlockLength;
        private float dist = 0; // the distance that character has moved
        bool isPirate;
        public CharacterStateF2M(Character character, RideType type, bool isPirate)
        {
            this.isPirate = isPirate;
            this.character = character;
            initial = character.bboxOffset.Y;
            character.animationHandleInt = 0;
            LoadRide(type);
            character.spriteAnims = SetSprites();
        }

        private void LoadRide(RideType type)
        {
            if (type == RideType.Turtle)
            {
                ride = new PlayerTurtle(character);
            }
            else if (type == RideType.PirateTurtle)
            {
                ride = new PlayerPirateTurtle(character);
            }
            else if (type == RideType.Owl)
            {
                ride = new PlayerOwl(character);
            }
            else if (type == RideType.SpaceCraft)
            {

            }
            character.SceneDelegate.ToAddEntity(ride);
        }

        public bool CouldPutBomb { get => false; }

        public bool CouldGetItem { get => false; }

        public void ProcessAttaction()
        {
            // when player takes attaction by the explosion, it switches to its free state
            dest = initial;
        }

        public void ProcessRide(RideType type, Vector2 pos)
        {
        }

        public void ProcessState(GameTime time)
        {
            //character.CalculateMovement();
            //character.UpdatePosition();
            character.animationHandleInt = (int)character.direction;
            if(dist < high - initial)
            {
                character.bboxOffset.Y += 1;
            }
            else
            {
                if (character.bboxOffset.Y <= dest)
                {
                    if(dest == initial) character.playerState = new CharacterStateFree(character, isPirate);
                    else character.playerState = new CharacterStateMounted(this.character, ride, isPirate);
                }
                else
                {
                    character.bboxOffset.Y -= 1;
                }
            }
            dist += 1;
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