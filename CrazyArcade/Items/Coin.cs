using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Blocks;

namespace CrazyArcade.Items
{
    public class Coin : Item, IItem
    {
        public Coin(Rectangle destinationRectangle)
        {
            this.destinationRectangle = destinationRectangle;
            this.spriteTexture = Content.TextureSingleton.GetPowerUps();
            this.sourceRectangle = new Rectangle(0, 0, 50, 50);
        }
    }
}
