using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.UI.GUI_Components;
using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class PauseGUIComposition : GUIComposition
    {
        public PauseGUIComposition(string name)
        {
            this.name = name;            
            IGUIComponent pauseText = new GUIText("Pause text", "Game Paused");
            AddComponent(pauseText);
            SetPosition(new Vector2(350, 100));
        }
    }
}
