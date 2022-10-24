using System;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace CrazyArcade.Enemies
{
    public abstract class Enemy: CAEntity, IPlayerCollidable
    {
        protected Rectangle internalRectangle = new Rectangle(0, 0, 30, 30);

        public Rectangle boundingBox => internalRectangle;

        public void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            collisionPartner.CollisionDestroyLogic();
        }

    }
}

