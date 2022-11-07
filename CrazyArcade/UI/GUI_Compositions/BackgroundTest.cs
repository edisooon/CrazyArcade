using CrazyArcade.UI.GUI_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Compositions
{
    public class BackgroundTest : GUIComposition
    {
        public BackgroundTest()
        {
            AddComponent(new BlueBackground());
            name = "BackGround";
        }
    }
}
