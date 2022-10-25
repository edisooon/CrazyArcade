using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Items
{
    public interface IItemCollidable
    {
        //Reused from IPlayerCollisionBehavior
        public Rectangle blockCollisionBoundingBox { get; }
        public bool canHaveItem();
        public void IncreaseBlastLength();
        public void SwitchToMountedState();
        public void IncreaseSpeed();
        public void IncreaseBombCount();
    }
}
