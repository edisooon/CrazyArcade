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
    public class MainMenuText : GUIComposition
    {
        public MainMenuText()
        {
            IGUIComponent gameText = new GUIText("Main Menu Text", "Crazy Arcade");
            SetPosition(new Vector2(350, 75));
            this.name = "Main Menu Gui";
            AddComponent(gameText);
        }
    }
}
