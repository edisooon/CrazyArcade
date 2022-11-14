using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Loading
{
    public class TestLoad : IGUILoad
    {
        public void LoadGUI()
        {
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(new ScoreComposition());
            UI_Singleton.AddPreDesignedComposite(new GenericTextBox("levelCounter", "Level ", 100, 20));
            UI_Singleton.MoveCompositePosition("levelCounter", new Vector2(300, 0));
        }
    }
}
