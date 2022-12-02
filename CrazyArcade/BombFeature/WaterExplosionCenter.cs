using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Blocks;
using CrazyArcade.Boss;

namespace CrazyArcade.BombFeature
{
    internal class WaterExplosionCenter : CAEntity, IBossCollidable
	{
        static int FrameLength = 40;
        private SpriteAnimation spriteAnims;
        float AliveTime = 0;
        float Lifespan = 500;
        public override SpriteAnimation SpriteAnim => spriteAnims;


		public Rectangle hitBox => internalRectangle;

		public Rectangle internalRectangle;
		private Rectangle[] AnimationFrames;
        public WaterExplosionCenter(int X = 0, int Y = 0)
        {
            this.X = X;
            this.Y = Y;
            AnimationFrames = GetActiveAnimationFrames();
            this.spriteAnims = new SpriteAnimation(TextureSingleton.GetBallons(), AnimationFrames, 15);
            this.internalRectangle = new Rectangle(X, Y, 40, 40);
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
            SceneDelegate.ToRemoveEntity(this);
        }

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.CollisionDestroyLogic();
        }

        public void Collide(IBossCollideBehaviour boss)
        {

        }
    }
}
