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
        private Button[] buttons;
        public MainMenuScene(IGameDelegate gameDelegate)
        {
            buttons = new Button[2];
            this.gameRef = gameDelegate;
            buttons[0] = new Button("Main menu start", "Start", new Vector2(310, 175), gameRef.StartGame);
            buttons[1] = new Button("Main menu quit", "Quit", new Vector2(310, 275), gameRef.Quit);
            this.Load();
        }
        public override void Load()
        {
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(new MainMenuText());
            for(int i = 0; i < buttons.Length; i++)
            {
                UI_Singleton.AddPreDesignedComposite(buttons[i]);
            }
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
            MouseState mouse = Mouse.GetState();
            if(state.IsKeyDown(Keys.P))
            {
                this.gameRef.StartGame();
            }
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Update(mouse, gameRef);
            }
        }
    }
}
