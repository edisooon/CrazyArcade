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
        /*
         * One thing I want to change in the future is how sprite animation has to be handled on a case by case basis.
         * Perhaps another level of abstraction?
         */
        Point position = new(100, 100);
        int BlastLength;
        CAScene ParentScene;
        Rectangle InternalSprite;
        float FrameTimer;
        float DetonateTimer;
        float DetonateTime;
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
            DetonateTime = 0;
            DetonateTimer = 1000;
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
            Detonate(time);
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
            //ParentScene.AddSprite(new WaterBomb(ParentScene, position.X + 10, position.Y + 10, BlastLength));
        }
        private void Detonate(GameTime time)
        {
            if(DetonateTime > DetonateTimer)
            {
                DeleteSelf();
                CreateExplosion();
            }
            else
            {
                DetonateTime += (float)time.ElapsedGameTime.TotalMilliseconds;
            }
        }
        private void CreateExplosion()
        {
            int explosionTile = 40;
            Vector2 side = new Vector2(0, 0);
            //Perhaps an enumeration would be useful here
            ParentScene.AddSprite(new WaterExplosionCenter(ParentScene, position.X, position.Y));
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        side = new Vector2(0, -1);
                        break;
                    case 1:
                        side = new Vector2(0, 1);
                        break;
                    case 2:
                        side = new Vector2(-1, 0);
                        break;
                    case 3:
                        side = new Vector2(1, 0);
                        break;
                }
                for (int j = 1; j <= BlastLength; j++)
                {
                    ParentScene.AddSprite(new WaterExplosionEdge(ParentScene, i, j == BlastLength, (int) (position.X + (j*side.X*explosionTile)), (int) (position.Y + (j*side.Y * explosionTile))));
                }
            }
        }
    }
}
