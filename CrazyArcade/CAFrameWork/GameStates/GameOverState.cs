using CrazyArcade.CAFramework;
using CrazyArcade.Demo1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class GameOverState : IGameState
    {
        private DemoScene parentScene;
        public GameOverState(DemoScene scene)
        {
            parentScene = scene;
            parentScene.gameRef.scene = new GameOverScene(this.parentScene.gameRef, this);
        }
        public DemoScene DefaultScene => parentScene;

        public void SwitchToGameOver()
        {
        }
    }
}
