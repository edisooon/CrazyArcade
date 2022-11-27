using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.CAFrameWork.CAGame;
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
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(new GameOverGUIComposition());
        }
        public override void LoadSprites()
        {
        }

        public override void LoadSystems()
        {
        }
        public override void Update(GameTime time)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.R))
            {
                this.gameRef.NewGame();
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.gameRef.Quit();
            }
        }
    }
}
