using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CrazyArcade.Blocks
{
    public interface IBlock : IEntity
    {
        public Texture2D Texture { get; }
        public Rectangle InputFrame { get; }
        public Rectangle OutputFrame { get; }
        public Color Tint { get; }
    }
    public abstract class Block : CAEntity, IBlock
    {
        protected Texture2D spriteTexture;
        protected Rectangle destinationRectangle;
        protected Rectangle sourceRectangle;
        public override Texture2D Texture => this.spriteTexture;

        public override Rectangle InputFrame => this.sourceRectangle;

        public override Rectangle OutputFrame => this.destinationRectangle;

        public override Color Tint => Color.White;
        public override void Update(GameTime time)
        {

        }
        public override void Load()
        {

        }
        public void GetNewDestination()
        {
            double ratio = (double)this.sourceRectangle.Height / this.sourceRectangle.Width;
            double newHeight = ratio * this.destinationRectangle.Height;
            double oldHeight = this.destinationRectangle.Height;
            this.destinationRectangle.Height = (int)newHeight;
            this.destinationRectangle.Y = this.destinationRectangle.Y - (int)(newHeight - oldHeight);
        }
    }
}
