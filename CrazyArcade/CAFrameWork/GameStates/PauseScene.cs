using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Button resume;
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
            /* Buttons to be implemented in sprint 5
            UI_Singleton.AddPreDesignedComposite(resume = new Button("resume", new Vector2(310, 150)));*/
        }
        private void RemoveGUI()
        {
            UI_Singleton.RemoveComposition("Pause GUI");

            //Buttons
            //UI_Singleton.RemoveComposition("resume");
        }
        public override void LoadSprites()
        {
        }

        public override void LoadSystems()
        {
        }
        private Boolean inButton(MouseState ms)
        {
            return ms.X > resume.Position.X;
        }
        public override void Update(GameTime time)
        {
            KeyboardState ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            if(ks.IsKeyDown(Keys.Escape))
            {
                gameRef.Quit();
            }
            if(ks.IsKeyDown(Keys.Enter))
            {
                TogglePause();
            }

            // To be implemented in sprint 5
            /*if(inButton(ms))
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
            }*/
        }
        public override void TogglePause()
        {
            RemoveGUI();
            gameRef.Scene = restoreScene;
        }
    }
}
