using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.PlayerStateMachine;
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
        {            /**
            sources = new Rectangle[5];
            sources[0] = new Rectangle(0, 60, 60, 60);
            sources[1] = new Rectangle(60, 60, 60, 60);
            sources[2] = new Rectangle(120, 60, 60, 60);
            sources[3] = new Rectangle(180, 60, 60, 60);
            sources[4] = new Rectangle(240, 60, 60, 60);
            **/
        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
            collisionPartner.IncreaseBlastLength();
        }
    }
    public class CoinBag : Item, IItem
    {
        //public static Rectangle[] sources = new Rectangle[2];
        private static Rectangle source = new Rectangle(519,134,50,52);
        public CoinBag(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetCoinbag(),2,5)
        {/**
            sources = new Rectangle[2];
            sources[0] = new Rectangle(520, 130, 60, 60);
            sources[1] = new Rectangle(580, 130, 60, 60);
     **/
        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
        }
    }
    public class Sneaker : Item, IItem
    {
        //public static Rectangle[] sources = new Rectangle[3];
        private static Rectangle source = new Rectangle(396,138,40,44);
        public Sneaker(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetRollerskates(), 3, 5)
        {/**
            sources = new Rectangle[3];
            sources[0] = new Rectangle(320, 130, 60, 60);
            sources[1] = new Rectangle(380, 130, 60, 60);
            sources[1] = new Rectangle(460, 130, 60, 60);
     **/
        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
        }
    }
    public class Turtle : Item, IItem
    {
        //public static Rectangle[] sources = new Rectangle[5];
        private static Rectangle source = new Rectangle(14,131,37,59);
        public Turtle(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetTurtle(), 5, 5)
        {/**
            sources = new Rectangle[5];
            sources[0] = new Rectangle(0, 130, 60, 60);
            sources[1] = new Rectangle(60, 130, 60, 60);
            sources[2] = new Rectangle(120, 130, 60, 60);
            sources[3] = new Rectangle(180, 130, 60, 60);
            sources[4] = new Rectangle(240, 130, 60, 60);
      **/
        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
            collisionPartner.SwitchToMountedState();
        }
    }
    public class Potion : Item, IItem
    {
        //public static Rectangle[] sources = new Rectangle[5];
        private static Rectangle source = new Rectangle(330, 65, 43, 59);
        public Potion(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetPotion(), 5, 5)
        {/**
            sources = new Rectangle[5];
            sources[0] = new Rectangle(320, 130, 60, 60);
            sources[1] = new Rectangle(380, 130, 60, 60);
            sources[2] = new Rectangle(450, 130, 60, 60);
            sources[3] = new Rectangle(520, 130, 60, 60);
            sources[4] = new Rectangle(580, 130, 60, 60);
    **/
        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
        }
    }
    public class Coin : Item, IItem
    {
        //public static Rectangle[] sources = new Rectangle[10];

        public static Rectangle source = new Rectangle(0, 0, 60, 60);
        public Coin(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetCoin(), 10, 10)
        {/**
            sources = new Rectangle[10];
            sources[0] = new Rectangle(0, 0, 60, 60);
            sources[1] = new Rectangle(60, 0, 60, 60);
            sources[2] = new Rectangle(120, 0, 60, 60);
            sources[3] = new Rectangle(180, 0, 60, 60);
            sources[4] = new Rectangle(240, 0, 60, 60);
            sources[5] = new Rectangle(320, 0, 60, 60);
            sources[6] = new Rectangle(380, 0, 60, 60);
            sources[7] = new Rectangle(450, 0, 60, 60);
            sources[8] = new Rectangle(520, 0, 60, 60);
            sources[9] = new Rectangle(580, 0, 60, 60);
    **/
        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
        }
    }
}
