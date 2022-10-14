using CrazyArcade.Boss;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.PlayerStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Enemy;
using CrazyArcade.CAFrameWork.CollisionSystem;

namespace CrazyArcade.Demo1
{
    public class DemoScene : CAScene
    {
        public DemoScene(Game1 game)
        {
            gameRef = game;
        }
        public override void LoadSystems()
        {
            this.systems.Add(new CAControllerSystem());
            this.systems.Add(new CAGameLogicSystem());
            this.systems.Add(new Blocks.Sprint2Manager(this));
            this.systems.Add(new EnemyManager(this));
            //Added to the demo scene file in order to test the functionality of the code
            this.systems.Add(new BlockCollisionSystem());
        }

        public override void LoadSprites()
        {

            Console.Out.Write("added Boss");
            //this.AddSprite(new DemoCharacter(new DemoController()));
            //this.AddSprite(new BombEnemySprite(100,100));
            this.AddSprite(new PlayerCharacter(new DemoController(), this));
        }
    }
}
