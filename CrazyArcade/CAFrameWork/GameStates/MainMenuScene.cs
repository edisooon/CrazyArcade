using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class MainMenuScene : CAScene
    {
        public override List<Vector2> PlayerPositions => throw new NotImplementedException();
        public MainMenuScene(IGameDelegate gameDelegate)
        {
            this.gameRef = gameDelegate;
            this.Load();
        }
        public override void Load()
        {
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(new MainMenuText());
        }

        public override void LoadSprites()
        {
        }

        public override void LoadSystems()
        {
        }
        public override void Update(GameTime time)
        {
            KeyboardState state = Keyboard.GetState();
            if(state.IsKeyDown(Keys.P))
            {
                this.gameRef.StartGame();
            }
        }
    }
}
