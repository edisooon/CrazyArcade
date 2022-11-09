using CrazyArcade.Boss;
using CrazyArcade.Levels;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.PlayerStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Enemies;
using CrazyArcade.CAFrameWork.CollisionSystem;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.Items;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.CAFrameWork.GameStates;

namespace CrazyArcade.Demo1
{
    public class DemoScene : CAScene
    {
        Level level;
        string fileName;

        private List<PlayerCharacter> players = new List<PlayerCharacter>();
        public override List<Vector2> PlayerPositions
        {
            get
            {
                List<Vector2> res = new List<Vector2>();
                foreach(PlayerCharacter player in players)
                {
                    res.Add(player.GameCoord);
                }
                return res;
            }
        }

        public DemoScene(CAGame game, string fileName, Vector2 stageOffset)
        {
            base.StageOffset = stageOffset;
            this.fileName = fileName;
            gameRef = game;
            gameState = new DefaultGameState(this);
        }
        public override void LoadSystems()
        {
            //this.systems.Add(new BlockCollisionSystem());
            this.systems.Add(new GameStateSwitcher(this));
            this.systems.Add(new ItemCollisionSystem(this));
            this.systems.Add(new CAControllerSystem());
            this.systems.Add(new CAGameLogicSystem());
            this.systems.Add(new GridBoxSystem());
            this.systems.Add(new BombCollisionSystem(this));
            this.systems.Add(new PlayerCollisionSystem());
            
            this.systems.Add(gridSystems);
            //this.systems.Add(new LevelManager(this, new DemoController()));
            level = new Level(this, fileName);
            foreach (IEntity entity in level.DrawLevel())
            {
                if (entity is PlayerCharacter)
                {
                    players.Add(entity as PlayerCharacter);
                }
                this.AddSprite(entity);
            }
        }
        public override void LoadSprites()
        {
            
            //This may not be neccessary
            //this.AddSprite(new PlayerCharacter(new DemoController(), this));
        }

    }
}
