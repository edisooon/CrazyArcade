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
        int Direction;
        bool head;
        public override Texture2D Texture => TextureSingleton.GetBallons();
        public override Rectangle InputFrame => InternalSprite;
        public override Rectangle OutputFrame => new Rectangle(position.X, position.Y, FrameLength, FrameLength);
        public override Color Tint => Color.White;
        private List<Rectangle> ActiveAnimationFrames;
        private List<Rectangle> DecayAnimationFrames;
        public WaterExplosionEdge(CAScene ParentScene, int direction, bool head, int X = 0, int Y = 0)
        {
            position.X = X;
            position.Y = Y;
            FrameTimer = 0;
            FrameSpeed = 25;
            Lifespan = 1000;
            AliveTime = 0;
            Direction = direction;
            this.head = head;
            this.ParentScene = ParentScene;
            ActiveAnimationFrames = GetActiveAnimationFrames();
            DecayAnimationFrames = GetDecayedAnimationFrames();
            CurrentFrame = 0;
            InternalSprite = ActiveAnimationFrames[CurrentFrame];
        }
        private List<Rectangle> GetActiveAnimationFrames()
        {
            List<Rectangle> NewFrames = new();
            if (head)
            {
                NewFrames.Add(new Rectangle(5, 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames.Add(new Rectangle(5 + FrameLength, 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames.Add(new Rectangle(5 + (2 * FrameLength), 567 + (Direction * FrameLength), FrameLength, FrameLength));
            }
            else
            {
                NewFrames.Add(new Rectangle(125, 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames.Add(new Rectangle(125 + FrameLength, 567 + (Direction * FrameLength), FrameLength, FrameLength));
            }
            return NewFrames;
        }
        private List<Rectangle> GetDecayedAnimationFrames()
        {
            List<Rectangle> NewFrames = new();
            if (head)
            {
                NewFrames.Add(new Rectangle(205, 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames.Add(new Rectangle(205 + FrameLength, 567 + (Direction * FrameLength), FrameLength, FrameLength));
                NewFrames.Add(new Rectangle(205 + (2 * FrameLength), 567 + (Direction * FrameLength), FrameLength, FrameLength));
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    NewFrames.Add(new Rectangle(325 + (FrameLength * i), 567 + (Direction * FrameLength), FrameLength, FrameLength));
                }
            }
            return NewFrames;
        }
        public override void Update(GameTime time)
        {
            Animate(time);
        }
        private void Animate(GameTime time)
        {
            if (Lifespan > AliveTime) { 
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
                if (FrameTimer > FrameSpeed)
                {
                    CurrentFrame++;
                    if (CurrentFrame > DecayAnimationFrames.Count - 1) { DeleteSelf(); }
                    else
                    {
                        FrameTimer = 0;
                        InternalSprite = DecayAnimationFrames[CurrentFrame];
                    }
                }
                else
                {
                    FrameTimer += (float)time.ElapsedGameTime.TotalMilliseconds;
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
