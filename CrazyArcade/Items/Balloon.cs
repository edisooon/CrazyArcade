using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Blocks;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Items
{
    public class Balloon : Item, IItem
    {
        public Balloon(Rectangle destinationRectangle)
        {
            this.destinationRectangle = destinationRectangle;
            this.spriteTexture = Content.TextureSingleton.GetBallons();
            this.sourceRectangle = new Rectangle(0, 0, 50, 50);
        }
    }
}
