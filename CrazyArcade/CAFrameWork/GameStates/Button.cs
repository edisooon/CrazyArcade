using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.UI.GUI_Components;
using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class Button : GUIBase
    {
        public Button(string name)
        {
            this.name = name;
            this.Sprite = new SpriteAnimation(TextureSingleton.GetBlueBackground(), new Rectangle(0, 0, 100, 20));
            Sprite.rectangleFlag = 1;
        }
    }
}
