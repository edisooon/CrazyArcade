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
        private CAScene parentScene;
        private CAScene restoreScene;
        public DefaultGameState(CAScene scene)
        {
            parentScene = scene;
        }
        public CAScene Scene => parentScene;
        public CAScene Restore
        {
            get => restoreScene;
            set => restoreScene = value;
        }
        public void SwitchToGameOver()
        {
            GameOverState gameOver = new GameOverState(parentScene);
        }
    }
}
