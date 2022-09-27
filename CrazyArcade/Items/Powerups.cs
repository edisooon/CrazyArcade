using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.Items
{
    public abstract class Powerups : Item, IItem
    {
        public Powerups(Rectangle destinationRectangle, Rectangle sourceRectangle)
        {
            this.destinationRectangle = destinationRectangle;
            this.spriteTexture = Content.TextureSingleton.GetPowerUps();
            this.sourceRectangle = sourceRectangle;
            GetNewDestination();
        }
    }
    public class Balloon : Powerups, IItem
    {
        private static Rectangle source = new Rectangle(250, 7, 114, 150);
        public Balloon(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {            
        }
    }
    public class CoinBag : Powerups, IItem
    {
        private static Rectangle source = new Rectangle(8, 5, 226, 229);
        public CoinBag(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
    public class Sneaker : Powerups, IItem
    {
        private static Rectangle source = new Rectangle(376, 8, 117, 126);
        public Sneaker(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
    public class Turtle : Powerups, IItem
    {
        private static Rectangle source = new Rectangle(511, 8, 108, 126);
        public Turtle(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
    public class Potion : Powerups, IItem
    {
        private static Rectangle source = new Rectangle(634, 7, 197, 270);
        public Potion(Rectangle destinationRectangle) : base(destinationRectangle, source)
        {
        }
    }
}
