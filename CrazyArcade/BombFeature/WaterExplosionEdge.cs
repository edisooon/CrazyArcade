using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.BombFeature
{
    internal class WaterExplosionEdge : CAEntity
    {
        static int FrameLength = 40;
        CAScene ParentScene;
        float Lifespan;
        float AliveTime;
        int Direction;
        bool head;
        int living;
        private SpriteAnimation[] spriteAnims;
        public override SpriteAnimation SpriteAnim => spriteAnims[living];
        public WaterExplosionEdge(CAScene ParentScene, int direction, bool head, int X = 0, int Y = 0)
        {
            spriteAnims = new SpriteAnimation[2];
            this.X = X;
            this.Y = Y;
            Lifespan = 1000;
            AliveTime = 0;
            living = 0;
            Direction = direction;
            this.head = head;
            this.ParentScene = ParentScene;
            Rectangle[] activeFrames = GetActiveAnimationFrames();
            Rectangle[] decayFrames = GetDecayedAnimationFrames();
            this.spriteAnims[0] = new SpriteAnimation(TextureSingleton.GetBallons(), activeFrames, 15);
            this.spriteAnims[1] = new SpriteAnimation(TextureSingleton.GetBallons(), decayFrames, 15);
        }
        private Rectangle[] GetActiveAnimationFrames()
        {
            Rectangle[] NewFrames = new Rectangle[2];
            if (head)
            {
                Array.Resize(ref NewFrames, 3);
                NewFrames[0] = (new Rectangle(5, 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames[1] = (new Rectangle(5 + FrameLength, 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames[2] = (new Rectangle(5 + (2 * FrameLength), 567 + (Direction * FrameLength), FrameLength, FrameLength));
            }
            else
            {
                NewFrames[0] = (new Rectangle(125, 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames[1] = (new Rectangle(125 + FrameLength, 567 + (Direction * FrameLength), FrameLength, FrameLength));
            }
            return NewFrames;
        }
        public override void Load()
        {
            //Sorry nothing
        }
        private Rectangle[] GetDecayedAnimationFrames()
        {
            Rectangle[] NewFrames = new Rectangle[4];
            if (head)
            {
                NewFrames[0] = (new Rectangle(205, 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames[1] = (new Rectangle(205 + FrameLength, 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames[2] = (new Rectangle(205 + (2 * FrameLength), 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames[3] = new Rectangle(0, 0, 0, 0);
            }
            else
            {
                Array.Resize(ref NewFrames, 8);
                for (int i = 0; i < 7; i++)
                {
                    NewFrames[i] = (new Rectangle(325 + (FrameLength * i), 567 + (Direction * FrameLength), FrameLength, FrameLength));
                }
                NewFrames[7] = new Rectangle(0, 0, 0, 0);
            }
            return NewFrames;
        }
        public override void Update(GameTime time)
        {
            Animate(time);
        }
        private void Animate(GameTime time)
        {
            if (Lifespan < AliveTime)
            {
                living = 1;
                if (SpriteAnim.getCurrentFrame() == SpriteAnim.getTotalFrames() - 1)
                {
                    DeleteSelf();
                }
            }
            AliveTime += (float)time.ElapsedGameTime.TotalMilliseconds;
        }
        private void DeleteSelf()
        {
            ParentScene.RemoveSprite(this);
        }
    }
}
