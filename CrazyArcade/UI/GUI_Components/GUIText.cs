using CrazyArcade.Items;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Content;
using System.Diagnostics;

namespace CrazyArcade.UI.GUI_Components
{
    public class GUIText : GUIBase
    {
        public GUIText(string name, string drawText)
        {
            this.name = name;
            this.drawText = drawText;
            font = TextureSingleton.getTestFont();
            isTextComponent = true;
        }
    }
}
