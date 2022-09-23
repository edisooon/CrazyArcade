using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.BombFeature
{
    public class WaterBomb : CAEntity
    {
        Point position = new(100, 100);
        int BlastLength;
        CAScene ParentScene;
        Rectangle InternalSprite;
        float FrameTimer;
        float DetonateTimer;
        float FrameSpeed;
        int CurrentFrame;
        public override Texture2D Texture => TestTextureSingleton.GetSpriteSheet();
        public override Rectangle InputFrame => InternalSprite;
        public override Rectangle OutputFrame => new Rectangle(position.X, position.Y, 42, 42);
        public override Color Tint => Color.White;
        private List<Rectangle> AnimationFrames;
        public WaterBomb(CAScene ParentScene, int X = 0, int Y = 0, int BlastLength = 1)
        {
            position.X = X;
            position.Y = Y;
            this.ParentScene = ParentScene;
            this.BlastLength = BlastLength;
            AnimationFrames = GetAnimationFrames();
            CurrentFrame = 0;
            InternalSprite = AnimationFrames[CurrentFrame];
            FrameTimer = 0;
            FrameSpeed = 75;
        }
        private static List<Rectangle> GetAnimationFrames()
        {
            List<Rectangle> NewFrames = new();
            NewFrames.Add(new Rectangle(11, 10, 42, 42));
            NewFrames.Add(new Rectangle(56, 10, 42, 42));
            NewFrames.Add(new Rectangle(97, 10, 46, 42));
            return NewFrames;
        }
        public override void Update(GameTime time)
        {
            AnimateSprite(time);
        }
        private void AnimateSprite(GameTime time)
        {
            if (FrameTimer > FrameSpeed)
            {
                CurrentFrame++;
                CurrentFrame = CurrentFrame % AnimationFrames.Count;
                FrameTimer = 0;
                InternalSprite = AnimationFrames[CurrentFrame];
            }
            else
            {
                FrameTimer += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
        }
        private void DeleteSelf()
        {
            ParentScene.RemoveSprite(this);
        }
    }
}
