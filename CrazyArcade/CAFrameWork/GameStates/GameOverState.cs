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
        private CAScene parentScene;
        private CAScene restoreScene;
        public GameOverState(CAScene scene)
        {
            parentScene = new GameOverScene(scene.gameRef, this);
            parentScene.Load();
            scene.gameRef.scene = parentScene;
        }
        public CAScene Scene => parentScene;
        public CAScene Restore
        {
            get => restoreScene;
            set => restoreScene = value;
        }

        public void SwitchToGameOver()
        {
        }
    }
}
