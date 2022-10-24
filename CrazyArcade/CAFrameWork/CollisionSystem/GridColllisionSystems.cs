using System;
using CrazyArcade.Blocks;
using CrazyArcade.Boss;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.CollisionSystem
{
	public class GridColllisionSystems: IGameSystem
	{
        List<IPlayerCollidable> triggers = new List<IPlayerCollidable>();
        List<IPlayerCollisionBehavior> playerBehaviors = new List<IPlayerCollisionBehavior>();

        private ISceneDelegate sceneDelegate;
        public GridColllisionSystems(ISceneDelegate sceneDelegate)
        {
            this.sceneDelegate = sceneDelegate;
        }
        public void AddSprite(IEntity sprite)
        {
            if (sprite is IPlayerCollidable)
            {
                triggers.Add(sprite as IPlayerCollidable);
            }
            if (sprite is IPlayerCollisionBehavior)
            {
                playerBehaviors.Add(sprite as IPlayerCollisionBehavior);
            }
        }

        public void RemoveAll()
        {
            triggers.Clear();
            playerBehaviors.Clear();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IPlayerCollidable) triggers.Remove(sprite as IPlayerCollidable);
            if (sprite is IPlayerCollisionBehavior) playerBehaviors.Remove(sprite as IPlayerCollisionBehavior);
        }

        public void Update(GameTime time)
        {
            
        }
    }
}

