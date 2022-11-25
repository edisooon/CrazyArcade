using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.Items;
using CrazyArcade.Levels;
using CrazyArcade.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine
{
    public class CharacterStateBubble : ICharacterState
    {
        private Character character;
        private PlayerBubble bubble;
        private float elapsedTime = 0f;
        private float popTime = 3000f;
        public CharacterStateBubble(Character character)
        {
            this.character = character;
            character.animationHandleInt = 0;
            bubble = new PlayerBubble(character, character.parentScene);
            character.SceneDelegate.ToAddEntity(bubble);
        }

        public bool CouldPutBomb()
        {
            return false;
        }

        public void ProcessAttaction()
        {
            //do nothing
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
            if (elapsedTime > popTime)
            {
                character.playerState = new CharacterStateFree(character);
                character.spriteAnims = character.playerState.SetSprites();
                bubble.bubbleInt = 2;
                character.playerState.SetSpeed();
                character.lives--;
                UI_Singleton.ChangeComponentText("lifeCounter", "count", "Lives: " + character.lives);
                if (character.lives == 0)
                {
                    character.SceneDelegate.EndGame();
                }
            }
            elapsedTime += (float)time.ElapsedGameTime.TotalMilliseconds;
        }

        public int SetSpeed()
        {
            character.ModifiedSpeed = 2;
            return 1;
        }

        public SpriteAnimation[] SetSprites()
        {
            SpriteAnimation[] newSprites = new SpriteAnimation[1];
            newSprites[0] = new SpriteAnimation(TextureSingleton.GetPlayer1(), 12, 389, 44, 56, 2, 4, 10);
            return newSprites;
        }
    }
}
