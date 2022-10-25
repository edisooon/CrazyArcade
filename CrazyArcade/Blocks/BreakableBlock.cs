using CrazyArcade.Items;
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
        public BreakableBlock(Vector2 position, Rectangle source) : base(position, source, Content.TextureSingleton.GetDesertBlocks())
        {

        }
    }
    public class BlueCrate : BreakableBlock
    {
        private static Rectangle source = new Rectangle(10, 306, 40, 63);
        public BlueCrate(Vector2 position) : base(position, source)
        {

        }
    }
    public class GreenCrate : BreakableBlock
    {
        private static Rectangle source = new Rectangle(60, 306, 40, 63);
        public GreenCrate(Vector2 position) : base(position, source)
        {

        }
    }
    public class CyanCrate : BreakableBlock
    {
        private static Rectangle source = new Rectangle(110, 306, 40, 63);
        public CyanCrate(Vector2 position) : base(position, source)
        {

        }
    }

}
