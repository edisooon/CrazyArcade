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
        public Rectangle blockCollisionBoundingBox { get; }
        public void IncreaseBlastLength();
        public void SwitchToMountedState();
    }
}
