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
using CrazyArcade.Items;
using CrazyArcade.BombFeature;

namespace CrazyArcade.Blocks
{
    public abstract class DefaultBlock : Block
    {
        public DefaultBlock(Vector2 position, Rectangle sourceRectangle) : base(position, sourceRectangle, Content.TextureSingleton.GetDesertBlocks())
        {
        }
    }

    public class LightSandBlock : BreakableBlock
    {
        private static Rectangle source = new Rectangle(10, 10, 40, 44);
        public LightSandBlock(ISceneDelegate parentScene, Vector2 position) : base(parentScene, position, source)
        {
        }
    }
    public class SandBlock : BreakableBlock
    {
        private static Rectangle source = new Rectangle(60, 10, 40, 44);
        public SandBlock(ISceneDelegate parentScene, Vector2 position) : base(parentScene, position, source)
        {
        }
    }
    public class Rock : DefaultBlock
    {
        private static Rectangle source = new Rectangle(110, 10, 40, 47);
        public Rock(Vector2 position) : base(position, source)
        {
        }
    }
    public class Tree : DefaultBlock
    {
        private static Rectangle source = new Rectangle(10, 127, 63, 80);
        public Tree(Vector2 position) : base(position, source)
        {
        }
    }
    public class DarkTree : DefaultBlock
    {
        private static Rectangle source = new Rectangle(83, 127, 63, 80);
        public DarkTree(Vector2 position) : base(position, source)
        {
        }
    }
    public class Door : Block
    {
        private static Rectangle source = new Rectangle(0,0,80,80);
        public Door(Vector2 position) : base(position, source, Content.TextureSingleton.GetDoor())
        {
        }
    }


}
