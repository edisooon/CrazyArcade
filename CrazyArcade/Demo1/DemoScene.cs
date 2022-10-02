using CrazyArcade.Boss;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Demo1
{
    public class DemoScene : CAScene
    {
        public override void LoadSystems()
        {
            //this.systems.Add(new CAControllerSystem());
            //this.systems.Add(new Blocks.Sprint2Manager(this));
        }

        public override void LoadSprites()
        {
            this.AddSprite(new SunBoss(this));
            Console.Out.Write("added Boss");
            //this.AddSprite(new DemoCharacter(new DemoController()));
        }
    }
}
