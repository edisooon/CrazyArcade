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
        public override List<IGameSystem> LoadSystems()
        {
            List<IGameSystem> systemList = new List<IGameSystem>();
            systemList.Add(new CAControllerSystem());
            return systemList;
        }

        public override void Load()
        {
            base.Load();
            AddSprite(new DemoCharacter(new DemoController()));
        }
    }
}
