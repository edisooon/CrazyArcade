using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.CollisionSystem
{
    internal class BlockCollisionSystem : IGameSystem
    {
        List<IEntity> blockList = new List<IEntity>();
        List<IEntity> blockColidableList = new List<IEntity>();
        public void AddSprite(IEntity sprite)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveSprite(IEntity sprite)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime time)
        {
            throw new NotImplementedException();
        }
    }
}
