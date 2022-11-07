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
    public class EmptyComposite : GUIComposition
    {
        public EmptyComposite(string name)
        {
            this.name = name;
        }
    }
}
