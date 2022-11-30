using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.UI;
using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class MainMenuScene : CAScene
    {
        public override List<Vector2> PlayerPositions => throw new NotImplementedException();
        private Button[] buttons;
        private readonly GUIComposition MainMenuText;
        public MainMenuScene(IGameDelegate gameDelegate)
        {
            buttons = new Button[2];
            this.gameRef = gameDelegate;
            MainMenuText = new TitleText("Main Menu Text", "Crazy Arcade");
            buttons[0] = new Button("Main menu start", "Start", Button.GetBasePosition(3f), gameRef.StartGame);
            buttons[1] = new Button("Main menu quit", "Quit To Desktop", Button.GetBasePosition(2f), gameRef.Quit);
            this.Load();
        }
        public override void Load()
        {
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(MainMenuText);
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
            MouseState mouse = Mouse.GetState();
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Update(mouse, gameRef);
            }
        }
    }
}
