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
    public class ButtonBase : GUIBase
    {
        public static readonly Rectangle DefaultButtonRectangle = new(0, 0, 200, 50);
        public Rectangle Rect;
        public ButtonBase(string name)
        {
            Rect = DefaultButtonRectangle;
            this.name = name;
            this.Sprite = new SpriteAnimation(TextureSingleton.GetBlueBackground(), DefaultButtonRectangle);
            Sprite.rectangleFlag = 1;
        }
    }
}
