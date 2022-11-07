using CrazyArcade.CAFramework;
using CrazyArcade.Demo1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class DefaultGameState : IGameState
    {
        private DemoScene parentScene;
        public DefaultGameState(DemoScene scene)
        {
            parentScene = scene;
        }
        public DemoScene DefaultScene => parentScene;
        public void SwitchToGameOver()
        {
            parentScene.gameState = new GameOverState(parentScene);
        }
    }
}
