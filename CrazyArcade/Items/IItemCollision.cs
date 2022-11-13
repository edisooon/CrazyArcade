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
    public interface IItemCollision: IEntity
    {
        //Reused from IPlayerCollidable
        public bool Enabled { get; }
        public void CollisionLogic(IItemCollidable collisionPartner);
        public void DeleteSelf(ISceneDelegate parentScene);
        public Rectangle itemHitbox { get; }
    }
}
