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
    internal class WaterExplosionCenter : CAEntity
    {
        static int FrameLength = 40;
        CAScene ParentScene;
        private SpriteAnimation spriteAnims;
        float AliveTime = 0;
        float Lifespan = 1000;
        public override SpriteAnimation SpriteAnim => spriteAnims;
        private Rectangle[] AnimationFrames;
        public WaterExplosionCenter(CAScene ParentScene, int X = 0, int Y = 0)
        {
            this.X = X;
            this.Y = Y;
            this.ParentScene = ParentScene;
            AnimationFrames = GetActiveAnimationFrames();
            this.spriteAnims = new SpriteAnimation(TextureSingleton.GetBallons(), AnimationFrames, 15);
        }
        private Rectangle[] GetActiveAnimationFrames()
        {
            Rectangle[] NewFrames = new Rectangle[4];
            for (int i = 0; i < 4; i++)
            {
                NewFrames[i] = (new Rectangle(5 + (FrameLength * i), 727, FrameLength, FrameLength));
            }
            return NewFrames;
        }
        public override void Update(GameTime time)
        {
            Animate(time); // does nothing
        }
        public override void Load()
        {
            //Sorry nothing
        }
        private void Animate(GameTime time)
        {
            if (Lifespan < AliveTime)
            {
                DeleteSelf();
            }
            AliveTime += (float)time.ElapsedGameTime.TotalMilliseconds;
        }
        private void DeleteSelf()
        {
            ParentScene.RemoveSprite(this);
        }
    }
}
