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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.Items
{

    public class Balloon : Item
    {

        private static Rectangle source = new Rectangle(11, 73, 40, 53);
        public Balloon(ISceneDelegate parentScence, Vector2 position) : base(parentScence, position, source, Content.TextureSingleton.GetBomb(), 5, 5)
        {

        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.IncreaseBombCount();
            this.DeleteSelf(parentScene);
        }
    }
    public class CoinBag : Item
    {

        private static Rectangle source = new Rectangle(519, 134, 50, 52);
        public CoinBag(ISceneDelegate parentScence, Vector2 position) : base(parentScence, position, source, Content.TextureSingleton.GetCoinbag(), 2, 5)
        {

        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.IncreaseScore(50);
            this.DeleteSelf(parentScene);
        }
    }
    public class Sneaker : Item
    {
        private static Rectangle source = new Rectangle(396, 138, 40, 44);
        public Sneaker(ISceneDelegate parentScence, Vector2 position) : base(parentScence, position, source, Content.TextureSingleton.GetRollerskates(), 3, 5)
        {
        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.IncreaseSpeed();
            this.DeleteSelf(parentScene);
        }
    }
    public class Turtle : Item
    {
        private static Rectangle source = new Rectangle(14, 131, 37, 59);
        public Turtle(ISceneDelegate parentScence, Vector2 position) : base(parentScence, position, source, Content.TextureSingleton.GetTurtle(), 5, 5)
        {
        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.SwitchToMountedState();
            this.DeleteSelf(parentScene);
        }

    }
    public class Potion : Item
    {

        private static Rectangle source = new Rectangle(330, 65, 43, 59);
        public Potion(ISceneDelegate parentScence, Vector2 position) : base(parentScence, position, source, Content.TextureSingleton.GetPotion(), 5, 5)
        {
        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.IncreaseBlastLength();
            this.DeleteSelf(parentScene);
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
        public Coin(ISceneDelegate parentScence, Vector2 position) : base(parentScence, position, source, Content.TextureSingleton.GetCoin(), 10, 10)
        {

        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.IncreaseScore(10);
            this.DeleteSelf(parentScene);
        }
    }
}
