using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.BombFeature
{
    internal class TestScene : CAScene
    {
        public override List<IGameSystem> LoadSystems()
        {
            List<IGameSystem> systemList = new List<IGameSystem>();
            systemList.Add(new CAControllerSystem());
            systemList.Add(new CAGameLogicSystem());
            return systemList;
        }
    }
}
