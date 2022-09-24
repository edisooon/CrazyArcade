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
        public DemoScene()
        {
            this.sprites = new List<ISprite>();
            this.systems = new List<IGameSystem>();
        }

        public override void LoadSystems()
        {
            this.systems.Add(new CAControllerSystem());
        }

        public override void Load()
        {
            base.Load();
            AddSprite(new DemoCharacter(new DemoController()));
        }

    }
}
