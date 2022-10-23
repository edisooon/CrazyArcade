using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.Demo1;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine
{
    public class PlayerBubble : CAEntity
    {
        public Character player;
        public CAScene scene;
        private SpriteAnimation[] currentBubble;
        public int bubbleInt;
        public PlayerBubble(Character player, CAScene scene)
        {
            this.player = player;
            this.scene = scene;
            bubbleInt = 0;
            X = player.X - 18;
            Y = player.Y - 8;
            currentBubble = new SpriteAnimation[3];
            currentBubble[0] = new SpriteAnimation(TextureSingleton.GetBubble(), 0, 0, 72, 72, 4, 0, 10);
            currentBubble[0].SetScale(1.1f);
            currentBubble[1] = new SpriteAnimation(TextureSingleton.GetBubble(), new Rectangle(216, 0, 72, 72));
            currentBubble[1].SetScale(1.1f);
            currentBubble[2] = new SpriteAnimation(TextureSingleton.GetBubble(), 288, 0, 72, 72, 6, 0, 10);
            currentBubble[2].SetScale(1.1f);
        }
        public override void Update(GameTime time)
        {
            if (bubbleInt == 0) Grow();
            if (bubbleInt == 2)
            {
                Pop();
                return;
            }
            X = player.X - 18;
            Y = player.Y - 8;
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
