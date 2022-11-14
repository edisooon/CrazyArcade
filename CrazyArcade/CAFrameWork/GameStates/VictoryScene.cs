using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.Items;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class VictoryScene : CAScene
    {
        private IGameDelegate gameRef;
        public VictoryScene(IGameDelegate gameRef)
        {
            this.gameRef = gameRef;
            this.Load();
        }

        public override List<Vector2> PlayerPositions => throw new NotImplementedException();

        public override void LoadSprites()
        {
            this.AddSprite(new CoinBag(new Vector2(400, 200)));
        }

        public override void LoadSystems()
        {
        }
    }
}
