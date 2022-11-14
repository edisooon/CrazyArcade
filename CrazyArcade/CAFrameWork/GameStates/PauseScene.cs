using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.Transition;
using CrazyArcade.Items;
using CrazyArcade.UI;
using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class PauseScene : CAScene
    {
        private ISceneState restoreScene;
        ResumeButton resume;
        public override List<Vector2> PlayerPositions => throw new NotImplementedException();
        public PauseScene(IGameDelegate game, ISceneState restoreScene)
        {
            this.gameRef = game;
            this.restoreScene = restoreScene;
            this.Load();
        }
        public override void Load()
        {
            LoadGUI();
        }
        private void LoadGUI()
        {
            UI_Singleton.AddPreDesignedComposite(new PauseGUIComposition("Pause GUI"));
            UI_Singleton.AddPreDesignedComposite(resume = new ResumeButton("resume"));
        }
        private void RemoveGUI()
        {
            UI_Singleton.RemoveComposition("Pause GUI");
            UI_Singleton.RemoveComposition("resume");
        }
        public override void LoadSprites()
        {
            //this.AddSprite(new Sneaker(new Vector2(400,200)));
        }

        public override void LoadSystems()
        {
        }
        private Boolean inButton(MouseState ms)
        {
            return ms.X > 310 && ms.X < 510 && ms.Y > 165 && ms.Y < 215;
        }
        public override void Update(GameTime time)
        {
            KeyboardState ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            if(ks.IsKeyDown(Keys.Escape))
            {
                gameRef.Quit();
            }
            if(inButton(ms))
            {
                resume.Enlarge();
            }
            if(!inButton(ms))
            {
                resume.SetButton();
            }
            if(inButton(ms) && ms.LeftButton.Equals(ButtonState.Pressed))
            {
                TogglePause();
            }
        }
        public override void TogglePause()
        {
            RemoveGUI();
            gameRef.Scene = restoreScene;
        }
    }
}
