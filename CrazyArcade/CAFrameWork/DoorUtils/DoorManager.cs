using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.Enemies;
using CrazyArcade.Pirates;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.DoorUtils
{
    public class DoorManager : IGameSystem
    {
        Vector2 lastEnemyPos = new(0, 0);
        private CAScene sceneRep;
        private Door door;
        private List<Enemy> enemyList = new();
        private List<PirateCharacter> pirateList = new();
        private Key key;
        bool gotKey = false;
        public DoorManager(CAScene sceneRep)
        {
            this.sceneRep = sceneRep;
            //each level will only have one key per
            key = new(new Vector2(-5, -5));
            sceneRep.ToAddEntity(key);
        }

        public void AddSprite(IEntity sprite)
        {
            //There should only be one door per level
            if (sprite is Door door)
            {
                this.door = door;
            }
            if (sprite is Enemy entity)
            {
                enemyList.Add(entity);
            }
            if (sprite is PirateCharacter pirate)
            {
                pirateList.Add(pirate);
            }
        }

        public void RemoveAll()
        {
            enemyList.Clear();
            pirateList.Clear();
            door = null;
            gotKey = false;
        }

        public void RemoveSprite(IEntity sprite)
        {
            
            if (sprite is Enemy entity)
            {
                enemyList.Remove(entity);
                lastEnemyPos = entity.GameCoord;
            }
            if (sprite is PirateCharacter pirate)
            {
                pirateList.Remove(pirate);
                lastEnemyPos = pirate.GameCoord;
            }
            if (sprite is Key)
            {
                key = null;
                OpenDoor();
            }
            if (enemyList.Count <= 0 && pirateList.Count <= 0 && !gotKey) AllEnemiesKilled(lastEnemyPos);
        }

        public void Update(GameTime time)
        {
            //Will likely be untouched
        }
        private void OpenDoor()
        {
            door.OpenDoor();
        }
        private void AllEnemiesKilled(Vector2 cord)
        {
            gotKey = true;
            key.GameCoord = cord;
        }
    }
}
