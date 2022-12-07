using CrazyArcade.Blocks;
using CrazyArcade.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.DoorUtils
{
    public class Key : Item
    {
        public Key(Vector2 position) : base(position, new Rectangle(0,0,41,74), Content.TextureSingleton.GetKey(), 1, 0)
        {
            canExplode = false;
        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            if (collisionPartner.Pirate) return;
            SceneDelegate.ToRemoveEntity(this);
        }
    }
}
