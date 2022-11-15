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
using CrazyArcade.GameGridSystems;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFrameWork.GridBoxSystem;
namespace CrazyArcade.Blocks
{
    //The purpose of this interface is to group together all blocks in the future. All code contained within must apply to all blocks, and changes can be 
    //Made in the future to enforce this. As of now however, it's purpose is to have an easy way to catagorise all blocks as this.
    public interface IBlock : IEntity
    {

    }
    public abstract class Block : CAGridBoxEntity, IBlock, IPlayerCollidable, IGridable, IExplosionCollidable
    {
        //----------IGridable Start------------
        private Vector2 gamePos;
        private Vector2 pos;
        public override Vector2 ScreenCoord
        {
            get => pos;
            set
            {
                pos = value;
                this.UpdateCoord(value);
            }
        }
        public void UpdateCoord(Vector2 value)
        {
            this.X = (int)value.X;
            this.Y = (int)value.Y;
        }
        public override Vector2 GameCoord
        {
            get => gamePos;
            set
            {
                gamePos = value;
                ScreenCoord = trans.Trans(value);
            }
        }
        private IGridTransform trans = new NullTransform();
        public override IGridTransform Trans { get => trans; set => trans = value; }
        //----------IGridable End------------
        protected SpriteAnimation spriteAnimation;

        private Rectangle internalRectangle = new Rectangle(0, 0, 40, 40);

        public Block(Vector2 position, Rectangle source, Texture2D texture) : base(new GridBoxPosition((int)position.X, (int)position.Y, (int)GridObjectDepth.Box))
        {
            spriteAnimation = new SpriteAnimation(texture, source);
            GameCoord = position;
            internalRectangle.X = X;
            internalRectangle.Y = Y;
        }
        public Block(Vector2 position, Rectangle source, Texture2D texture,int frames, int fps) : base(new GridBoxPosition((int)position.X, (int)position.Y, (int)GridObjectDepth.Box))
        {
            spriteAnimation = new SpriteAnimation(texture, frames, fps);
            GameCoord = position;
            internalRectangle.X = X;
            internalRectangle.Y = Y;
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

        public virtual bool Collide(IExplosion bomb)
        {
            return false;
        }
    }
}