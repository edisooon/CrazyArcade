using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.InputSystem;
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.Items;
using CrazyArcade.UI;
using CrazyArcade.UI.GUI_Components;
using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class PauseScene : MenuScene
    {
        private ISceneState restoreScene;
        TitleText titleText;
        public override List<Vector2> PlayerPositions => throw new NotImplementedException();
        public PauseScene(IGameDelegate game, ISceneState restoreScene)
        {
            this.gameRef = game;
            this.restoreScene = restoreScene;
            titleText = new TitleText("Pause text", "Game Paused");
            buttons = new Button[3];
            InitButtons();
            this.Load();
        }
        private void InitButtons()
        {
            buttons[0] = new Button("Pause resume", "Resume", Button.GetBasePosition(6f/2), this.TogglePause);
            buttons[1] = new Button("Pause restart", "Restart", Button.GetBasePosition(6f/3), gameRef.StartGame);
            buttons[2] = new Button("Pause quit", "Main Menu", Button.GetBasePosition(6f / 4), gameRef.NewGame);
        }
        public override void Load()
        {
            LoadGUI();
            base.Load();
        }
        private void LoadGUI()
        {
            UI_Singleton.AddPreDesignedComposite(titleText);
            for(int i = 0; i < buttons.Length; i++)
            {
                UI_Singleton.AddPreDesignedComposite(buttons[i]);
            }
        }
        private void RemoveGUI()
        {
            UI_Singleton.RemoveComposition(titleText.Name);
            for (int i = 0; i < buttons.Length; i++)
            {
                UI_Singleton.RemoveComposition(buttons[i].Name);
            }
        }
        protected override Dictionary<int, Action> getCommands()
        {
            Dictionary<int, Action> commands = new Dictionary<int, Action>();
            commands[KeyBoardInput.KeyDown(Keys.P)] = TogglePause;
            commands[(int)MouseStatus.LeftClick] = () => leftClick = true;
            return commands;
        }
        public override void TogglePause()
        {
            RemoveGUI();
            gameRef.Scene = restoreScene;
        }
    }
}
