using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using CrazyArcade.CAFrameWork.InputSystem;
using CrazyArcade.UI;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public abstract class MenuScene : CAScene
    {
        protected Button[] buttons;
        protected abstract Dictionary<int,Action> getCommands();
        public override void LoadSprites()
        {
            this.AddSprite(new KeyBoardInput());
            this.AddSprite(new MouseInput());
            this.AddSprite(new InputManager(getCommands(), getRangeCommands()));
        }
        public override void LoadSystems()
        {
            this.systems.Add(new InputSystems());
            this.systems.Add(new CAGameLogicSystem());
        }
        public override void Update(GameTime time)
        {
            base.Update(time);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Update(mousePos, leftClick, gameRef);
            }
            leftClick = false;
        }
    }
}
