using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.InputSystem;
using CrazyArcade.Items;
using CrazyArcade.UI;
using CrazyArcade.UI.GUI_Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class VictoryScene : MenuScene
    {
        List<CoinBag> victoryCoinBags;
        readonly int listSize = 10;
        public VictoryScene(IGameDelegate gameRef)
        {
            buttons = new Button[1];
            buttons[0] = new Button("Victory main menu", "Main Menu", Button.GetBasePosition(2f), gameRef.NewGame);
            this.gameRef = gameRef;
            this.victoryCoinBags = new List<CoinBag>();
            this.Load();
        }
        public override void Load()
        {
            base.Load();
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(new TitleText("Victory text", "You Win!"));
            UI_Singleton.AddPreDesignedComposite(buttons[0]);
        }

        public override List<Vector2> PlayerPositions => throw new NotImplementedException();

        public override void LoadSprites()
        {
            for(int i = 0;i < listSize;i++)
            {
                victoryCoinBags.Add(new CoinBag(new Vector2(100*i,0)));
                this.AddSprite(victoryCoinBags[i]);
            }
            base.LoadSprites();
        }
        protected override Dictionary<int, Action> getCommands()
        {
            var commands = new Dictionary<int, Action>();
            commands[KeyBoardInput.KeyDown(Keys.R)] = gameRef.NewGame;
            commands[KeyBoardInput.KeyDown(Keys.Escape)] = gameRef.Quit;
            commands[(int)MouseStatus.LeftClick] = () => leftClick = true;
            return commands;
        }
    }
}
