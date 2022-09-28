using CrazyArcade.CAFramework;
using CrazyArcade.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrazyArcade.Content;

namespace CrazyArcade.Blocks
{
    public abstract class DefaultBlock : Block, IBlock
    {
        public DefaultBlock(Rectangle destinationRectangle, Rectangle sourceRectangle) : base(destinationRectangle, sourceRectangle, Content.TextureSingleton.GetDesertBlocks())
        {
        }
    }

    public class LightSandBlock : DefaultBlock
    {
        private static Rectangle source = new Rectangle(10, 10, 40, 44);
        public LightSandBlock(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
    public class SandBlock : DefaultBlock
    {
        private static Rectangle source = new Rectangle(60, 10, 40, 44);
        public SandBlock(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
    public class Rock : DefaultBlock
    {
        private static Rectangle source = new Rectangle(110, 10, 40, 47);
        public Rock(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
    public class Tree : DefaultBlock
    {
        private static Rectangle source = new Rectangle(10, 127, 63, 80);
        public Tree(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
    public class DarkTree : DefaultBlock
    {
        private static Rectangle source = new Rectangle(83, 127, 63, 80);
        public DarkTree(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
}
