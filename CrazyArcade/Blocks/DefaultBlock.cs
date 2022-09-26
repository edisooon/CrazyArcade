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
        
    }

    public class BrickBlock : DefaultBlock
    {
        public BrickBlock(Rectangle destinationRectangle)
        {
            this.destinationRectangle = destinationRectangle;
            //Change to brick texture
            this.spriteTexture = Singletons.SpriteSheet.Character;
            this.sourceRectangle = new Rectangle(0, 0, 100, 100);
        }
    }
    public class SandBlock : DefaultBlock
    {
        public SandBlock(Rectangle destinationRectangle)
        {
            this.destinationRectangle = destinationRectangle;
            //Change to brick texture
            this.spriteTexture = Singletons.SpriteSheet.Character;
            this.sourceRectangle = new Rectangle(0, 50, 100, 100);
        }
    }
}
