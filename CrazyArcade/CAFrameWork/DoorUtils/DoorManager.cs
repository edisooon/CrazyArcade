using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.DoorUtils
{
    public class DoorManager : IGameSystem
    {
        private CAScene sceneRep;
        private Door door;
        private List<EnemyEntity> enemyList = new();
        public DoorManager(CAScene sceneRep)
        {
            this.sceneRep = sceneRep;
        }

        public void AddSprite(IEntity sprite)
        {
            //There should only be one door ever, so this should suffice
            if (sprite is Door)
            {
                this.door = sprite as Door;
            }
            if (sprite is EnemyEntity entity)
            {
                enemyList.Add(entity);
            }
        }

        public void RemoveAll()
        {
            //throw new NotImplementedException();
        }

        public void RemoveSprite(IEntity sprite)
        {
            //throw new NotImplementedException();
        }

        public void Update(GameTime time)
        {
            //throw new NotImplementedException();
        }
        private void OpenDoor()
        {
            this.sceneRep.doorFlag = true;
        }
    }
}
