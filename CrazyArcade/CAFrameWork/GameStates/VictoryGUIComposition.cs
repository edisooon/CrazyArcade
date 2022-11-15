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
    public class VictoryGUIComposition : GUIComposition
    {
        public VictoryGUIComposition()
        {
            IGUIComponent gameOverText = new GUIText("Victory text", "You Win!");
            SetPosition(new Vector2(350, 100));
            this.name = "Victory gui";
            AddComponent(gameOverText);
        }
    }
}
