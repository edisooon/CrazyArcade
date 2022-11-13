using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class PauseScene : CAScene
    {
        private ISceneState restoreScene;
        public override List<Vector2> PlayerPositions => throw new NotImplementedException();
        public PauseScene(IGameDelegate game, ISceneState restoreScene)
        {
            this.gameRef = game;
            this.restoreScene = restoreScene;
            this.Load();
        }

        public override void LoadSprites()
        {
            this.AddSprite(new Sneaker(new Vector2(400,200)));
        }

        public override void LoadSystems()
        {
        }
        public override void Update(GameTime time)
        {
            KeyboardState state = Keyboard.GetState();
            if(state.IsKeyDown(Keys.Enter))
            {
                gameRef.Scene = restoreScene;
            }
            if(state.IsKeyDown(Keys.Escape))
            {
                gameRef.Quit();
            }
        }
    }
}
