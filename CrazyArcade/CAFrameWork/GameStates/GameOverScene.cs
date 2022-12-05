using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.InputSystem;
using CrazyArcade.Demo1;
using CrazyArcade.Items;
using CrazyArcade.PlayerStateMachine;
using CrazyArcade.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static System.Formats.Asn1.AsnWriter;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class GameOverScene : CAScene
    {
        public GameOverScene(IGameDelegate gameRef)
        {
            this.gameRef = gameRef;
            this.Load();
        }

        public override List<Vector2> PlayerPositions => throw new NotImplementedException();

        public override void Load()
        {
            base.Load();
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(new TitleText("Game over title","Game Over"));
        }
        public override void LoadSprites()
        {
            this.AddSprite(new KeyBoardInput());
			this.AddSprite(new InputManager(getCommands()));
        }
        private Dictionary<int, Action> getCommands()
        {
            Dictionary<int, Action> res = new Dictionary<int, Action>();
            res[KeyBoardInput.KeyDown(Keys.R)] = gameRef.NewGame;
			res[KeyBoardInput.KeyDown(Keys.Escape)] = gameRef.Quit;
            return res;
		}
		public override void LoadSystems()
        {
            this.systems.Add(new InputSystems());
			this.systems.Add(new CAGameLogicSystem());
		}
    }
}
