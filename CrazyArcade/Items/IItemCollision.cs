using CrazyArcade.PlayerStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using CrazyArcade.Blocks;

namespace CrazyArcade.Items
{
    public interface IItemCollision
    {
        //Reused from IPlayerCollidable
        public void CollisionLogic(IItemCollidable collisionPartner);
        public void DeleteSelf(IScene parentScene);
        public Rectangle itemHitbox { get; }
    }
}
