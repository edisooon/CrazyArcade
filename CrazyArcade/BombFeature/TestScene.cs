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
        public override void LoadSystems()
        {
            //List<IGameSystem> systemList = new();
            this.systems.Add(new CAControllerSystem());
            this.systems.Add(new CAGameLogicSystem());
        }
        public override void Load()
        {
            base.Load();
        }
        public override void Update(GameTime time)
        {
            base.Update(time);
            bombManager.Controller.Update(time);
        }
        public override void LoadSprites()
        {
            //unimplemented
            return;
        }
    }
}
