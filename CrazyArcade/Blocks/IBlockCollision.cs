using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Blocks
{
    //The interface for handling block collision. This will be implemented by blocks that will serve as a barrier to entnties that will collide with it.
    public interface IBlockCollision
    {
        //The rectangle that is collided with
        public Rectangle boundingBox {get;}
        //The code that is executed when a collision is detected
        public void CollisionLogic(Rectangle overlap, IBlockCollidable collisionPartner);
    }
}
