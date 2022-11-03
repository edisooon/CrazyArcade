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
        public GUITestComposition(string name)
        {
            IGUIComponent newComponent = new GUIText("1", "test draw text");
            newComponent.SetPosition(new Vector2(100,100));
            this.name = name;
            AddComponent(newComponent);
        }
    }
}
