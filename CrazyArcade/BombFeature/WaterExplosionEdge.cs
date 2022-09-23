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
        int BlastLength;
        CAScene ParentScene;
        Rectangle InternalSprite;
        float FrameTimer;
        float Lifespan;
        float AliveTime;
        float FrameSpeed;
        int CurrentFrame;
        int Direction;
        public override Texture2D Texture => TestTextureSingleton.GetSpriteSheet();
        public override Rectangle InputFrame => InternalSprite;
        public override Rectangle OutputFrame => new Rectangle(position.X, position.Y, 40, 40);
        public override Color Tint => Color.White;
        private List<Rectangle> AnimationFrames;
        public WaterExplosionEdge(CAScene ParentScene, int direction, int X = 0, int Y = 0)
        {
            position.X = X;
            position.Y = Y;
            this.ParentScene = ParentScene;
            AnimationFrames = GetAnimationFrames();
            CurrentFrame = 0;
            InternalSprite = AnimationFrames[CurrentFrame];
            FrameTimer = 0;
            FrameSpeed = 25;
            Direction = direction;
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
            
        }
    }
}
