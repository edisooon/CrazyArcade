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
        int BlastLength;
        CAScene ParentScene;
        float DetonateTimer;
        float DetonateTime;
        private SpriteAnimation spriteAnims;

        public override SpriteAnimation SpriteAnim => spriteAnims;
        private Rectangle[] AnimationFrames;
        public WaterBomb(CAScene ParentScene, int X = 0, int Y = 0, int BlastLength = 1)
        {
            this.X = X;
            this.Y = Y;
            this.ParentScene = ParentScene;
            this.BlastLength = BlastLength;
            AnimationFrames = GetAnimationFrames();
            DetonateTime = 0;
            DetonateTimer = 1000;
            this.spriteAnims = new SpriteAnimation(TestTextureSingleton.GetSpriteSheet(), AnimationFrames, 8);
        }
        private static Rectangle[] GetAnimationFrames()
        {
            Rectangle[] NewFrames = new Rectangle[3];
            NewFrames[0] = new Rectangle(11, 10, 42, 42);
            NewFrames[1] = new Rectangle(56, 10, 42, 42);
            NewFrames[2] = new Rectangle(97, 10, 46, 42);
            return NewFrames;
        }
        public override void Update(GameTime time)
        {
            Detonate(time);
        }
        public override void Load()
        {
            //Nothing
        }
        //private void AnimateSprite(GameTime time)
        //{
        //    if (FrameTimer > FrameSpeed)
        //    {
        //        CurrentFrame++;
        //        CurrentFrame = CurrentFrame % AnimationFrames.Count;
        //        FrameTimer = 0;
        //        InternalSprite = AnimationFrames[CurrentFrame];
        //    }
        //    else
        //    {
        //        FrameTimer += (float)time.ElapsedGameTime.TotalMilliseconds;
        //    }
        //}
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
            ParentScene.AddSprite(new WaterExplosionCenter(ParentScene, X, Y));
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
                    ParentScene.AddSprite(new WaterExplosionEdge(ParentScene, i, j == BlastLength, (int) (X + (j*side.X*explosionTile)), (int) (Y + (j*side.Y * explosionTile))));
                }
            }
        }
    }
}
