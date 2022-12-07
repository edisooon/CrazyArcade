using CrazyArcade.Items;
using CrazyArcade.Levels;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Blocks
{
    public class DamageBlock : Block
    {
        public DamageBlock(Vector2 position, CreateLevel.LevelItem type) : base(position, getSource(type), Content.TextureSingleton.GetDesertBlocks())
        {
        }
        private static Rectangle getSource(CreateLevel.LevelItem type)
        {
            //Flower Cactus = new Rectangle(61, 227, 38, 59);
            //Light Flower Cactus = new Rectangle(111, 227, 38, 59);
            switch (type)
            {
                //Default is Cactus
                default:
                    return new Rectangle(11, 230, 38, 56);
            }
        }
    }
}
