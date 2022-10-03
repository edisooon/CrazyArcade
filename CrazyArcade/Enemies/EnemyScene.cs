using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Enemy;

namespace CrazyArcade.Enemy
{
    public class EnemyScene : CAScene
    {
        CAEntity sprite;
        private EnemyManager enemyManager;
        public EnemyScene()
        {
            enemyManager = new(new EnemyController(), this);
        }
        public override void LoadSystems()
        {
            List<IGameSystem> systemList = new();
            this.systems.Add(new CAControllerSystem());
            this.systems.Add(new CAGameLogicSystem());
        }
        public override void Load()             
        {    
            base.Load();
        }
        public override void Update(GameTime time)

        {
            foreach (IGameSystem system in systems)
            {
                system.Update(time);
            }
            base.Update(time); 


        }
        public override void LoadSprites()

        {
            foreach (IGameSystem system in systems)
            {
                system.LoadSprites();
            }


        }
    }
}
