using CrazyArcade.Boss;
using CrazyArcade.Levels;
using CrazyArcade.BombFeature;
using CrazyArcade.CAFramework;
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
using CrazyArcade.CAFrameWork.InputSystem;
using CrazyArcade.UI;
using CrazyArcade.CAFrameWork.SoundEffectSystem;
using CrazyArcade.CAFrameWork.DoorUtils;
using Microsoft.Xna.Framework.Input;

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
					//res.Add(player.GameCoord + new Vector2(0.2f, 0.4f));
					res.Add(player.GameCoord);
				}
                return res;
            }
        }
        
        public DemoScene(IGameDelegate game, string fileName, Vector2 stageOffset)
        {
            base.StageOffset = stageOffset;
            this.fileName = fileName;
            gameRef = game;
        }
        public override void LoadSystems()
        {
            //this.systems.Add(new BlockCollisionSystem());
            //this.systems.Add(new CAControllerSystem());
            this.systems.Add(new CASoundSystem());
            this.systems.Add(new InputSystems());
            this.systems.Add(new GridBoxSystem());
            this.systems.Add(new BombCollisionSystem(this, new Rectangle(0, 0, 15, 15)));
            this.systems.Add(gridSystems);
            this.systems.Add(new PlayerCollisionSystem());
            this.systems.Add(new BossCollisionSystem());
            this.systems.Add(new CAGameLogicSystem());
            this.systems.Add(gridSystems);
            this.systems.Add(new EnemyCollisionSystem());
            this.systems.Add(new DoorManager(this));
            //this.systems.Add(new LevelManager(this, new DemoController()));
            level = new Level(this, fileName);
            foreach (IEntity entity in level.DrawLevel())
            {
                if (entity is PlayerCharacter)
                {
                    players.Add(entity as PlayerCharacter);
                    UI_Singleton.ChangeComponentText("lifeCounter", "count", "Lives: " + (entity as PlayerCharacter).lives);
                    UI_Singleton.ChangeComponentText("needle", "itemCount", "X" + (entity as PlayerCharacter).needles);
                    UI_Singleton.ChangeComponentText("shield", "itemCount", "X" + (entity as PlayerCharacter).shields);
                }
                this.AddSprite(entity);
            }
        }
        public override void LoadSprites()
        {
            
            //This may not be neccessary
            this.AddSprite(new KeyBoardInput());
            this.AddSprite(new CASoundEffect("SoundEffects/StageStart"));
            //this.AddSprite(new PirateCharacter());
            this.AddSprite(new InputManager(getCommands()));
        }
        private bool EscapePressed = false;
        private Dictionary<int, Action> getCommands()
        {
            Dictionary<int, Action> commands = new Dictionary<int, Action>();
            commands[KeyBoardInput.KeyDown(Keys.Escape)] = TogglePause;
            /*commands[KeyBoardInput.KeyDown(Keys.V)] = Victory;
            commands[KeyBoardInput.KeyDown(Keys.O)] = EndGame;*/
            return commands;
        }
        public override void EndGame()
        {
            gameRef.Scene = new GameOverScene(gameRef);
        }
        public override void TogglePause()
        {
            if (EscapePressed == true)
            {
                gameRef.Scene = new PauseScene(gameRef, this);
                EscapePressed = false;
            }
            else EscapePressed = true;
        }
        public override void Victory()
        {
            gameRef.Scene = new VictoryScene(gameRef);
        }

    }
}
