using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.InputSystem;
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
            buttons[0] = new Button("Main menu start", "Start", new Vector2(gameRef.ScreenSize.X/2 - ButtonBase.DefaultButtonRectangle.Width/2, gameRef.ScreenSize.Y/3), gameRef.StartGame);
            buttons[1] = new Button("Main menu quit", "Quit", new Vector2(gameRef.ScreenSize.X / 2 - ButtonBase.DefaultButtonRectangle.Width / 2, gameRef.ScreenSize.Y/2), gameRef.Quit);
            this.Load();
        }
        public override void Load()
        {
            base.Load();
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(new MainMenuText(new Vector2(gameRef.ScreenSize.X/2 - ButtonBase.DefaultButtonRectangle.Width/4, gameRef.ScreenSize.Y/7)));
            for(int i = 0; i < buttons.Length; i++)
            {
                UI_Singleton.AddPreDesignedComposite(buttons[i]);
            }
        }

        public override void LoadSprites()
        {
            this.AddSprite(new KeyBoardInput());
            this.AddSprite(new MouseInput());
            this.AddSprite(new InputManager(getCommands(), getRangeCommands()));

		}
        private Point mousePos = new Point();
        private bool leftClick = false;
		private Dictionary<int, Action> getCommands()
		{
			Dictionary<int, Action> res = new Dictionary<int, Action>();
			res[(int)MouseStatus.LeftClick] = () => leftClick = true;
			return res;
		}
		private Dictionary<CodeRange, Action<int>> getRangeCommands()
		{
			Dictionary<CodeRange, Action<int>> res = new Dictionary<CodeRange, Action<int>>();
			res[MouseInput.CodeRangeX] = (val) => mousePos.X = val - MouseInput.CodeRangeX.Start;
			res[MouseInput.CodeRangeY] = (val) => mousePos.Y = val - MouseInput.CodeRangeY.Start;
			return res;
		}

		public override void LoadSystems()
        {
            this.systems.Add(new InputSystems());
			this.systems.Add(new CAGameLogicSystem());
		}
        public override void Update(GameTime time)
        {
            base.Update(time);
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Update(mousePos, leftClick, gameRef);
            }
        }
    }
}
