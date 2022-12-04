 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using CrazyArcade.PlayerStateMachine;
using CrazyArcade.PlayerStateMachine.PlayerItemInteractions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.Items
{
    public class Balloon : Item
    {

        private static Rectangle source = new Rectangle(11, 73, 40, 53);
        public Balloon(Vector2 position) : base(position, source, Content.TextureSingleton.GetBomb(), 5, 5)
        {

        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.ObtainItem(new BombCountModifier());
            this.DeleteSelf();
        }
    }
    public class CoinBag : Item
    {

        private static Rectangle source = new Rectangle(519, 134, 50, 52);
        public CoinBag(Vector2 position) : base(position, source, Content.TextureSingleton.GetCoinbag(), 2, 5)
        {

        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.IncreaseScore(50);
            this.DeleteSelf();
        }
    }
    public class Sneaker : Item
    {
        private static Rectangle source = new Rectangle(396, 138, 40, 44);
        public Sneaker(Vector2 position) : base(position, source, Content.TextureSingleton.GetRollerskates(), 3, 5)
        {
        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.ObtainItem(new SpeedModifier());
            this.DeleteSelf();
        }
    }
    public class Turtle : Item
    {
        private static Rectangle source = new Rectangle(14, 131, 37, 59);
        public Turtle(Vector2 position) : base(position, source, Content.TextureSingleton.GetTurtle(), 5, 5)
        {
        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.SwitchToMountedState();
            this.DeleteSelf();
        }

    }
    public class Potion : Item
    {

        private static Rectangle source = new Rectangle(330, 65, 43, 59);
        public Potion(Vector2 position) : base(position, source, Content.TextureSingleton.GetPotion(), 5, 5)
        {
        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.ObtainItem(new BlastLengthModifier());
            this.DeleteSelf();
        }

        public override void Update(GameTime time)
        {
            //Console.WriteLine("Potion" + base.ScreenCoord);
            base.Update(time);
        }
    }
    public class Coin : Item
    {
        public static Rectangle source = new Rectangle(0, 0, 60, 60);
        public Coin(Vector2 position) : base(position, source, Content.TextureSingleton.GetCoin(), 10, 10)
        {

        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.IncreaseScore(10);
            this.DeleteSelf();
        }
    }
    public class KickBoot : Item
    {
        public static Rectangle source = new Rectangle(0, 0, 42, 46);
        public KickBoot(Vector2 position) : base(position, source, Content.TextureSingleton.GetKick(), 3, 10)
        {

        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.ObtainItem(new KickModifier());
            this.DeleteSelf();
        }
    }
}
