using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.BombFeature
{
    internal class TestScene : CAScene
    {
        private BombManager bombManager;
        public TestScene()
        {
            bombManager = new(new BombTestController(), this);
        }
        public override List<IGameSystem> LoadSystems()
        {
            List<IGameSystem> systemList = new();
            systemList.Add(new CAControllerSystem());
            systemList.Add(new CAGameLogicSystem());
            return systemList;
        }
        public override void Load()
        {
            base.Load();
            AddSprite(new WaterBomb(this, 100, 100, 1));
        }
        public override void Update(GameTime time)
        {
            base.Update(time);
            bombManager.Controller.Update(time);
        }
    }
}
