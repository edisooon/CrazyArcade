using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Blocks
{
    public abstract class BreakableBlock : Block, IBlock
    {
        public BreakableBlock(Rectangle destination, Rectangle source) : base(destination, source, Content.TextureSingleton.GetDesertBlocks())
        {

        }
    }
    public class BlueCrate : BreakableBlock
    {
        private static Rectangle source = new Rectangle(10, 306, 40, 63);
        public BlueCrate(Rectangle destination) : base(destination, source)
        {

        }
    }
    public class GreenCrate : BreakableBlock
    {
        private static Rectangle source = new Rectangle(60, 306, 40, 63);
        public GreenCrate(Rectangle destination) : base(destination, source)
        {

        }
    }
    public class CyanCrate : BreakableBlock
    {
        private static Rectangle source = new Rectangle(110, 306, 40, 63);
        public CyanCrate(Rectangle destination) : base(destination, source)
        {

        }
    }

}
