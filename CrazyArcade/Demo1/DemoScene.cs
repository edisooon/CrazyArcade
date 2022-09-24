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
            this.systems.Add(new CAControllerSystem());
        }

        public override void LoadSprites()
        {
            this.AddSprite(new DemoCharacter(new DemoController()));
        }
    }
}
