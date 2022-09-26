using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Blocks
{
    public abstract class DamageBlock : Block, IBlock
    {
        public DamageBlock(Rectangle destinationRectangle, Rectangle sourceRectangle)
        {
            this.spriteTexture = Content.TextureSingleton.GetDesertBlocks();
            this.destinationRectangle = destinationRectangle;
            this.sourceRectangle = sourceRectangle;
            GetNewDestination();
        }
    }
    public class Cactus : DamageBlock
    {
        private static Rectangle source = new Rectangle(11, 230, 38, 56);
        public Cactus(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
}
