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
        public override Texture2D Texture => TestTextureSingleton.GetSpriteSheet();
        public override Rectangle InputFrame => InternalSprite;
        public override Rectangle OutputFrame => new Rectangle(position.X, position.Y, FrameLength, FrameLength);
        public override Color Tint => Color.White;
        private List<Rectangle> AnimationFrames;
        public WaterExplosionEdge(CAScene ParentScene, int direction, bool head, int X = 0, int Y = 0)
        {
            position.X = X;
            position.Y = Y;
            FrameTimer = 0;
            FrameSpeed = 25;
            Direction = direction;
            this.head = head;
            this.ParentScene = ParentScene;
            AnimationFrames = GetAnimationFrames(Direction, head);
            CurrentFrame = 0;
            InternalSprite = AnimationFrames[CurrentFrame];
        }
        private static List<Rectangle> GetAnimationFrames(int dir, bool head)
        {
            List<Rectangle> NewFrames = new();
            if (head)
            {
                NewFrames.Add(new Rectangle(5, 567 + (dir * FrameLength), FrameLength, FrameLength));
                NewFrames.Add(new Rectangle(5 + FrameLength, 567 + (dir * FrameLength), FrameLength, FrameLength));
                NewFrames.Add(new Rectangle(5 + (2 * FrameLength), 567 + (dir * FrameLength), FrameLength, FrameLength));
            }
            else
            {
                NewFrames.Add(new Rectangle(125, 567 + (dir * FrameLength), FrameLength, FrameLength));
                NewFrames.Add(new Rectangle(125 + FrameLength, 567 + (dir * FrameLength), FrameLength, FrameLength));
            }
            return NewFrames;
        }
        public override void Update(GameTime time)
        {
            Animate(time);
        }
        private void Animate(GameTime time)
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
    }
}
