using CrazyArcade.UI.GUI_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class GameOverGUIComposition : GUIComposition
    {
        public GameOverGUIComposition()
        {
            IGUIComponent gameOverText = new GUIText("Game Over text", "Game Over");
            SetPosition(new Vector2(350, 100));
            this.name = "Game over gui";
            AddComponent(gameOverText);
        }
    }
}
