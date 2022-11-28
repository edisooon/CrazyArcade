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
        public MainMenuText(Vector2 pos)
        {
            IGUIComponent gameText = new GUIText("Main Menu Text", "Crazy Arcade");
            SetPosition(pos);
            this.name = "Main Menu Gui";
            AddComponent(gameText);
        }
    }
}
