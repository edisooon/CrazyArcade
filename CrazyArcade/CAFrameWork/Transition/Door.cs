﻿using System;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFrameWork.Transition
{
	public class Door: Block, IPlayerCollidable
    {
        
        public override void Load()
        {
            
        }
        private int stage;
        private Dir dir;
        private static Rectangle source = new Rectangle(0, 0, 80, 80);
        public Door(Vector2 position, int to, Dir dir) : base(position, source, Content.TextureSingleton.GetDoor())
        {
            stage = to;
            this.dir = dir;
        }
        public override void CollisionLogic(Rectangle overlap, IPlayerCollisionBehavior collisionPartner)
        {
            SceneDelegate.Transition(stage, dir);
        }
    }
}

