using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
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
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(new TitleText("Victory text", "You Win!"));
            this.LoadSprites();
        }

        public override List<Vector2> PlayerPositions => throw new NotImplementedException();

        public override void LoadSprites()
        {
            for(int i = 0;i < listSize;i++)
            {
                victoryCoinBags.Add(new CoinBag(this, new Vector2(100*i,0)));
                this.AddSprite(victoryCoinBags[i]);
            }
        }

        public override void LoadSystems()
        {
        }
        public override void Update(GameTime time)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                this.gameRef.NewGame();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.gameRef.Quit();
            }
        }
    }
}
