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
            UI_Singleton.AddPreDesignedComposite(new GUITestComposition("1", new Vector2(10, 225)));
        }
    }
}
