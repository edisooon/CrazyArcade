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
    public class VictoryScene : CAScene
    {
        List<CoinBag> victoryCoinBags;
        readonly int listSize = 10;
        public VictoryScene(IGameDelegate gameRef)
        {
            this.gameRef = gameRef;
            this.victoryCoinBags = new List<CoinBag>();
            this.Load();
        }
        public override void Load()
        {
            base.Load();
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(new TitleText("Victory text", "You Win!"));
            this.LoadSprites();
        }

        public override List<Vector2> PlayerPositions => throw new NotImplementedException();

        public override void LoadSprites()
        {
            for(int i = 0;i < listSize;i++)
            {
                victoryCoinBags.Add(new CoinBag(new Vector2(100*i,0)));
                this.AddSprite(victoryCoinBags[i]);
            }
            this.AddSprite(new InputManager(getCommands()));
            this.AddSprite(new KeyBoardInput());
        }

        public override void LoadSystems()
        {
            systems.Add(new InputSystems());
            systems.Add(new CAGameLogicSystem());
        }
        private Dictionary<int, Action> getCommands()
        {
            var commands = new Dictionary<int, Action>();
            commands[KeyBoardInput.KeyDown(Keys.R)] = gameRef.NewGame;
            commands[KeyBoardInput.KeyDown(Keys.Escape)] = gameRef.Quit;
            return commands;
        }
    }
}
