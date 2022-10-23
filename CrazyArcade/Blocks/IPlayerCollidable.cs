using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Blocks
{
    public interface IPlayerCollidable
    {
        public Rectangle boundingBox {get;}
        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner);
    }
}
