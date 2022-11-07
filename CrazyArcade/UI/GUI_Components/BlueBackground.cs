using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Components
{
    public class BlueBackground : GUIBase
    {
        public BlueBackground()
        {
            name = "BlueBackground";
            Sprite = new SpriteAnimation(TextureSingleton.GetBlueBackground(), new Rectangle(0, 0, 4, 4));
            Sprite.rectangleFlag = 1;
            Sprite.Width = 1000;
            Sprite.Height = 1000;
        }
    }
}
