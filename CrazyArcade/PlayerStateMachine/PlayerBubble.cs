using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.Demo1;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Note: this is kept in the PlayerStateMachine namespace due to the lack of higher orginization for entities and the project in general.
namespace CrazyArcade.PlayerStateMachine
{
    public class PlayerBubble : CAEntity
    {
        public PlayerCharacter player;
        public CAScene scene;
        private SpriteAnimation[] currentBubble;
        public int bubbleInt;

        private static readonly float bubbleScale = 1.1f;
        private static readonly Point bubbleCenter = new(-18, -8);
        private static readonly int bubbleWidthHeight = 72;
        private static readonly int secondBubbleStartXPos = 216;
        private static readonly int thirdBubbleStartXPos = 288;
        private static readonly int bubbleGrowFrames = 4;
        private static readonly int bubblePopFrames = 6;
        private static readonly int bubbleFPS = 10;

        public PlayerBubble(PlayerCharacter player, CAScene scene)
        {
            
            this.player = player;
            this.scene = scene;
            bubbleInt = 0;
            X = player.X + bubbleCenter.X;
            Y = player.Y + bubbleCenter.Y;
            //Note, there is a way to do this within the animation system, however changes are being made straight to the code itself for
            //reasons of time constraints.
            currentBubble = new SpriteAnimation[3];
            currentBubble[0] = new SpriteAnimation(TextureSingleton.GetBubble(), 0, 0, bubbleWidthHeight, bubbleWidthHeight, bubbleGrowFrames, 0, bubbleFPS);
            currentBubble[0].SetScale(bubbleScale);
            currentBubble[1] = new SpriteAnimation(TextureSingleton.GetBubble(), new Rectangle(secondBubbleStartXPos, 0, bubbleWidthHeight, bubbleWidthHeight));
            currentBubble[1].SetScale(bubbleScale);
            currentBubble[2] = new SpriteAnimation(TextureSingleton.GetBubble(), thirdBubbleStartXPos, 0, bubbleWidthHeight, bubbleWidthHeight, bubblePopFrames, 0, bubbleFPS);
            currentBubble[2].SetScale(bubbleScale);
        }
        public override void Update(GameTime time)
        {
            if (bubbleInt == 0) Grow();
            if (bubbleInt == 2)
            {
                Pop();
                return;
            }
            X = player.X + bubbleCenter.X;
            Y = player.Y + bubbleCenter.Y;
        }

        public override SpriteAnimation SpriteAnim => currentBubble[bubbleInt];

        public override void Load()
        {
            //sorry nothing
        }
        public void Grow()
        {
            if (SpriteAnim.getCurrentFrame() == SpriteAnim.getTotalFrames() - 1)
            {
                bubbleInt = 1;
            }
        }
        public void Pop()
        {
            if (SpriteAnim.getCurrentFrame() == SpriteAnim.getTotalFrames() - 1)
            {
                Delete_Self();
            }
        }
        public void Delete_Self()
        {
            scene.RemoveSprite(this);
        }
    }
}
