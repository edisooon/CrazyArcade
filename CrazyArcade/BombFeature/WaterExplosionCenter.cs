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
        /*
         * One thing I want to change in the future is how sprite animation has to be handled on a case by case basis.
         * Perhaps another level of abstraction?
         */
        Point position = new(100, 100);
        static int FrameLength = 40;
        CAScene ParentScene;
        Rectangle InternalSprite;
        float FrameTimer;
        float Lifespan;
        float AliveTime;
        float FrameSpeed;
        int CurrentFrame;
        public override Texture2D Texture => TextureSingleton.GetBallons();
        public override Rectangle InputFrame => InternalSprite;
        public override Rectangle OutputFrame => new Rectangle(position.X, position.Y, FrameLength, FrameLength);
        public override Color Tint => Color.White;
        private List<Rectangle> ActiveAnimationFrames;
        public WaterExplosionCenter(CAScene ParentScene, int X = 0, int Y = 0)
        {
            position.X = X;
            position.Y = Y;
            FrameTimer = 0;
            FrameSpeed = 25;
            Lifespan = 1000;
            AliveTime = 0;
            this.ParentScene = ParentScene;
            ActiveAnimationFrames = GetActiveAnimationFrames();
            CurrentFrame = 0;
            InternalSprite = ActiveAnimationFrames[CurrentFrame];
        }
        private List<Rectangle> GetActiveAnimationFrames()
        {
            List<Rectangle> NewFrames = new();
            for (int i = 0; i < 4; i++)
            {
                NewFrames.Add(new Rectangle(5 + (FrameLength * i), 727, FrameLength, FrameLength));
            }
            return NewFrames;
        }
        public override void Update(GameTime time)
        {
            Animate(time);
        }
        private void Animate(GameTime time)
        {
            if (Lifespan > AliveTime)
            {
                if (FrameTimer > FrameSpeed)
                {
                    CurrentFrame++;
                    CurrentFrame = CurrentFrame % ActiveAnimationFrames.Count;
                    FrameTimer = 0;
                    InternalSprite = ActiveAnimationFrames[CurrentFrame];
                }
                else
                {
                    FrameTimer += (float)time.ElapsedGameTime.TotalMilliseconds;
                }
            }
            else
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
