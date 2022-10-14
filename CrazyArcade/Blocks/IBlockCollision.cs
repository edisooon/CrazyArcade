using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Blocks
{
    internal interface IBlockCollision
    {
        public Rectangle boundingBox {get; set;}

        public void CollisionLogic();
    }
}
