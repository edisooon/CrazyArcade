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

    public class Balloon : Item
    {

        private static Rectangle source = new Rectangle(11, 73, 40, 53);
        public Balloon(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetBomb(),5,5)
        { 

        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
            collisionPartner.IncreaseBombCount();
        }
    }
    public class CoinBag : Item
    {

        private static Rectangle source = new Rectangle(519,134,50,52);
        public CoinBag(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetCoinbag(),2,5)
        {

        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
        }
    }
    public class Sneaker : Item
    {
        private static Rectangle source = new Rectangle(396,138,40,44);
        public Sneaker(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetRollerskates(), 3, 5)
        {

        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
            collisionPartner.IncreaseSpeed();
        }
    }
    public class Turtle : Item
    {
        private static Rectangle source = new Rectangle(14,131,37,59);
        public Turtle(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetTurtle(), 5, 5)
        {

        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
            //Commented out since Mounted State is not implemented in branch this was worked on

            //collisionPartner.SwitchToMountedState();
        }
    }
    public class Potion : Item
    {

        private static Rectangle source = new Rectangle(330, 65, 43, 59);
        public Potion(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetPotion(), 5, 5)
        {

        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
            collisionPartner.IncreaseBlastLength();
        }
    }
    public class Coin : Item
    {
        public static Rectangle source = new Rectangle(0, 0, 60, 60);
        public Coin(Rectangle destinationRectangle) : base(destinationRectangle, source, Content.TextureSingleton.GetCoin(), 10, 10)
        {

        }
        public override void CollisionLogic(IItemCollidable collisionPartner)
        {
        }
    }
}
