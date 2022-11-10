using CrazyArcade.CAFramework;
using CrazyArcade.UI.GUI_Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Compositions
{
    public class ItemCountComposition : GUIComposition
    {
        public ItemCountComposition(string itemName, SpriteAnimation texture)
        {
            this.name = itemName;
            IGUIComponent newComponent = new ItemBoxItem("mainTexture", texture);
            AddComponent(newComponent);
            newComponent = new GUIText("itemCount", "DECLARE ME");
            newComponent.SetPosition(new Vector2(0,50));
            AddComponent(newComponent);
        }
    }
}
