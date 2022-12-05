using CrazyArcade.Boss;
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
        //Since enemy does not contain the position on IGridable, we cannot use EnemyEntity, and therefore
        //Must have a list for each kind of enemy
        private List<SunBoss> sunBossList = new();
        private List<OctopusEnemy> octopusList = new();
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
            if (sprite is OctopusEnemy octo)
            {
                octopusList.Add(octo);
            }
            if (sprite is SunBoss sun)
            {
                sunBossList.Add(sun);
            }
            if (sprite is ObtainFlag flag)
            {
                if (flag.flag) AllEnemiesKilled(flag.keyPos);
                sceneRep.ToRemoveEntity(flag);
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
            if (sprite is OctopusEnemy octo)
            {
                octopusList.Remove(octo);
                lastEnemyPos = octo.GameCoord;
            }
            if (sprite is SunBoss sun)
            {
                sunBossList.Remove(sun);
                //Sunboss can be on top of blocks, just unlock the door to be safe
                if (sunBossList.Count <= 0) OpenDoor();
            }
            if (sprite is Key)
            {
                key = null;
                OpenDoor();
            }
            if (enemyList.Count <= 0 && pirateList.Count <= 0 &&
                octopusList.Count <= 0 && !gotKey) AllEnemiesKilled(lastEnemyPos);
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
