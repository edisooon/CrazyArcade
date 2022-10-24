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
using CrazyArcade.GameGridSystems;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.Blocks
{
    public interface IBlock : IEntity
    {

    }
    public abstract class Block : CAEntity, IBlock, IPlayerCollidable, IGridable
    {
        protected SpriteAnimation spriteAnimation;

        private Rectangle internalRectangle = new Rectangle(0, 0, 40, 40);

        public Block(Rectangle destination, Rectangle source, Texture2D texture)
        {
            spriteAnimation = new SpriteAnimation(texture, source);
            this.X = destination.X;
            this.Y = destination.Y;
            pos = new Vector2(X, Y);
            internalRectangle.X = X;
            internalRectangle.Y = Y;
            ScreenCoord = new Vector2(X, Y);
        }
        public Block(Rectangle destination, Rectangle source, Texture2D texture,int frames, int fps)
        {
            spriteAnimation = new SpriteAnimation(texture, frames, fps);
            this.X = destination.X;
            pos = new Vector2(X, Y);
            this.Y = destination.Y;
            internalRectangle.X = X;
            internalRectangle.Y = Y;
            ScreenCoord = new Vector2(X, Y);
        }

        public override SpriteAnimation SpriteAnim => this.spriteAnimation;

        public Rectangle boundingBox => internalRectangle;
        private Vector2 gamePos;
        private Vector2 pos;

        public Vector2 ScreenCoord
        {
            get => pos;
            set
            {
                pos = value;
                this.X = (int)value.X;
                this.Y = (int)value.Y;
            }
        }
        public Vector2 GameCoord { get => gamePos; set => gamePos = value; }
        private IGridTransform trans = new NullTransform();
        public IGridTransform Trans { get => trans; set => trans = value; }

        public override void Update(GameTime time)
        {
            internalRectangle.X = X;
            internalRectangle.Y = Y;
            pos.X = X;
            pos.Y = Y;
        }
        public override void Load()
        {
        }

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            Debug.WriteLine(overlap.Width);
            Debug.WriteLine(overlap.Height);
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