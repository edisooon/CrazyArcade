using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.Items
{
    /**public abstract class Powerups : Item, IItem
    {
        public Powerups(Rectangle destinationRectangle, Rectangle sourceRectangle) : base(destinationRectangle, sourceRectangle, Content.TextureSingleton.GetPowerUps())
        {
        }
    }**/
    public class Balloon : Item, IItem
    {
        //public static Rectangle[] sources = new Rectangle[5];
        private static Rectangle source = new Rectangle(11, 73, 40, 53);
        public Balloon(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetBomb(),5,5)
        {
        }
    }
    public class CoinBag : Item, IItem
    {
        private static Rectangle source = new Rectangle(519,134,50,52);
        public CoinBag(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetCoinbag(),2,5)
        {
        }
    }
    public class Sneaker : Item, IItem
    {
        //public static Rectangle[] sources = new Rectangle[3];
        private static Rectangle source = new Rectangle(396,138,40,44);
        public Sneaker(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetRollerskates(), 3, 5)
        {
        }
    }
    public class Turtle : Item, IItem
    {
        //public static Rectangle[] sources = new Rectangle[5];
        private static Rectangle source = new Rectangle(14,131,37,59);
        public Turtle(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetTurtle(), 5, 5)
        {
        }
    }
    public class Potion : Item, IItem
    {
        //public static Rectangle[] sources = new Rectangle[5];
        private static Rectangle source = new Rectangle(330, 65, 43, 59);
        public Potion(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetPotion(), 5, 5)
        {
        }
    }
    public class Coin : Item, IItem
    {
        //public static Rectangle[] sources = new Rectangle[10];

        public static Rectangle source = new Rectangle(0, 0, 60, 60);
        public Coin(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetCoin(), 10, 10)
        {
        }
    }
}
