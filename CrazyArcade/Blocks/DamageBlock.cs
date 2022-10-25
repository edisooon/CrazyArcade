﻿using CrazyArcade.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Blocks
{
    public abstract class DamageBlock : Block
    {
        public DamageBlock(Vector2 position, Rectangle sourceRectangle) : base(position, sourceRectangle, Content.TextureSingleton.GetDesertBlocks())
        {

        }
    }
    public class Cactus : DamageBlock
    {
        private static Rectangle source = new Rectangle(11, 230, 38, 56);
        public Cactus(Vector2 position) : base(position, source)
        {
            
        }
    }
    public class FlowerCactus : DamageBlock
    {
        private static Rectangle source = new Rectangle(61, 227, 38, 59);
        public FlowerCactus(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
    public class LightFlowerCactus : DamageBlock
    {
        private static Rectangle source = new Rectangle(111, 227, 38, 59);
        public LightFlowerCactus(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {

        }
    }
}
