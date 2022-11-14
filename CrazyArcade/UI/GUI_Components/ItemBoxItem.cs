using CrazyArcade.CAFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Components
{
    public class ItemBoxItem : GUIBase
    {
        public ItemBoxItem(string name, SpriteAnimation texture)
        {
            Sprite = texture;
            this.name = name;
            ToggleRectangleFlag();
            ChangeComponentTextureOutputRect(50, 50);
        }
    }
}
