using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Blocks
{
    //Please note, the reason this is in the blocks folder is due to the fact that
    //there is not a ton of entity orginizaion in the folder hirearchy.
    //Keep in mind that blocks do not utelize the code below themselves, rather,
    //the objects that collide with the blocks.
    public interface IPlayerCollisionBehavior
    {
        //The rectangle that detects the collision
        public Rectangle blockCollisionBoundingBox { get; }
        //The code that is executed when a collision is detected. (Called by the block)
        public bool CouldKick { get; }
        public void CollisionHaltLogic(Point amountMoved);
        public void CollisionDestroyLogic();
        public bool canHaveItem();
        public void IncreaseBlastLength();
        public void SwitchToMountedState();
        public void IncreaseSpeed();
        public void IncreaseBombCount();
        public bool Active { get; set; }
    }
}
