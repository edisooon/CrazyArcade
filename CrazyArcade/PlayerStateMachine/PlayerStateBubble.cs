using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine
{
    public class PlayerStateBubble : ICharacterState
    {
        private PlayerCharacter character;
        private PlayerBubble bubble;
        private float elapsedTime = 0f;
        private float popTime = 3000f;
        public PlayerStateBubble(PlayerCharacter character)
        {
            this.character = character;
            character.animationHandleInt = 0;
            bubble = new PlayerBubble(character, character.parentScene);
            character.parentScene.AddSprite(bubble);
        }
        public void ProcessAttaction()
        {
            //can't
        }

        public void ProcessItem(Item toProcess)
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
                character.playerState = new PlayerStateFree(character);
                character.spriteAnims = character.playerState.SetSprites();
                bubble.bubbleInt = 2;
                character.playerState.SetSpeed();
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
