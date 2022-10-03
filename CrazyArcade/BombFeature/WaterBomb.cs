using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.Demo1;
using CrazyArcade.PlayerStateMachine;
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
        PlayerCharacter owner;
        public override SpriteAnimation SpriteAnim => spriteAnims;
        private Rectangle[] AnimationFrames;
        public WaterBomb(CAScene ParentScene, int X, int Y, int BlastLength, PlayerCharacter character)
        {
            this.X = X;
            this.Y = Y;
            this.ParentScene = ParentScene;
            this.BlastLength = BlastLength;
            this.owner = character;
            AnimationFrames = GetAnimationFrames();
            DetonateTime = 0;
            DetonateTimer = 1000;
            this.spriteAnims = new SpriteAnimation(TextureSingleton.GetBallons(), AnimationFrames, 8);
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
        private void DeleteSelf()
        {
            ParentScene.RemoveSprite(this);
        }
        private void Detonate(GameTime time)
        {
            if(DetonateTime > DetonateTimer)
            {
                DeleteSelf();
                owner.BombExplode();
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
