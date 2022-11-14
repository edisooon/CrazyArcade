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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static System.Formats.Asn1.AsnWriter;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class GameOverScene : CAScene
    {
        ISceneDelegate parentScene;
        public GameOverScene(ISceneDelegate parentScene, CrazyArcade.CAGame gameRef, IGameState state)
        {
            this.parentScene = parentScene;
            this.gameRef = gameRef;
            this.gameState = state;
            this.Load();
        }

        public override List<Vector2> PlayerPositions => throw new NotImplementedException();

        public override void LoadSprites()
        {
            //Temporary, will be changed to game over text
            this.AddSprite(new CoinBag(parentScene, new Microsoft.Xna.Framework.Vector2(0, 0)));
        }

        public override void LoadSystems()
        {
        }
        public override void Update(GameTime time)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.R))
            {
                this.gameRef.NewInstance();
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.gameRef.Exit();
            }
        }
    }
}
