using CrazyArcade.UI.GUI_Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Compositions
{
    public class GenericTextBox : GUIComposition
    {
        public GenericTextBox(string name, string startText, int width, int height)
        {
            this.name = name;
            BlueBox box = new();
            box.ChangeComponentTextureOutputRect(width, height);
            AddComponent(box);
            AddComponent(new GUIText("text", startText));
        }
    }
}
