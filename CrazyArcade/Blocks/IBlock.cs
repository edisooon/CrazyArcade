using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using System.Diagnostics;

namespace CrazyArcade.Blocks
{
    //The purpose of this interface is to group together all blocks in the future. All code contained within must apply to all blocks, and changes can be 
    //Made in the future to enforce this. As of now however, it's purpose is to have an easy way to catagorise all blocks as this.
    public interface IBlock : IEntity
    {

    }
    public abstract class Block : CAEntity, IBlock, IPlayerCollidable
    {
        protected SpriteAnimation spriteAnimation;

        private Rectangle internalRectangle = new Rectangle(0, 0, 40, 40);

        public Block(Rectangle destination, Rectangle source, Texture2D texture)
        {
            spriteAnimation = new SpriteAnimation(texture, source);
            this.X = destination.X;
            this.Y = destination.Y;
        }
        public Block(Rectangle destination, Rectangle source, Texture2D texture,int frames, int fps)
        {
            spriteAnimation = new SpriteAnimation(texture, frames, fps);
            this.X = destination.X;
            this.Y = destination.Y;
        }

        public override SpriteAnimation SpriteAnim => this.spriteAnimation;

        public Rectangle boundingBox => internalRectangle;

        public override void Update(GameTime time)
        {
            internalRectangle.X = X;
            internalRectangle.Y = Y;
        }
        public override void Load()
        {
        }

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            int modifier = 1;
            if (overlap.Width > overlap.Height)
            {
                if (Y < collisionPartner.blockCollisionBoundingBox.Y) modifier = -1;
                collisionPartner.CollisionHaltLogic(new Point(0, modifier * overlap.Height));
            } 
            else
            {
                if (X < collisionPartner.blockCollisionBoundingBox.X) modifier = -1;
                collisionPartner.CollisionHaltLogic(new Point(modifier * overlap.Width, 0));
            }
        }
    }
}