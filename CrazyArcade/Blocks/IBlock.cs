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

namespace CrazyArcade.Blocks
{
    public interface IBlock : IEntity
    {

    }
    public abstract class Block : CAEntity, IBlock
    {
        protected SpriteAnimation spriteAnimation;

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

        public override void Update(GameTime time)
        {

        }
        public override void Load()
        {
        }
    }
}