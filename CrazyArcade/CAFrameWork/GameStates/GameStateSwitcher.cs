using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.Demo1;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class GameStateSwitcher : IGameSystem
    {
        CAScene sceneRef;
        public GameStateSwitcher(CAScene scene)
        {
            sceneRef = scene;
        }
        public void AddSprite(IEntity sprite)
        {
        }

        public void RemoveAll()
        {
        }

        public void RemoveSprite(IEntity sprite)
        {
        }

        public void Update(GameTime time)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.O))
            {
                sceneRef.EndGame();
            }
            if(state.IsKeyDown(Keys.Back))
            {
                sceneRef.Pause();
            }
        }
    }
}
