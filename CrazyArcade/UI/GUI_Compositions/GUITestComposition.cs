using CrazyArcade.UI.GUI_Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Compositions
{
    public class GUITestComposition : GUIComposition
    {
        public GUITestComposition(string name, Vector2 pos)
        {
            IGUIComponent newComponent = new GUIText("1", "test draw text");
            SetPosition(pos);
            this.name = name;
            AddComponent(newComponent);
            newComponent = new GUITestTexture("test2");
            AddComponent(newComponent);
        }
    }
}
