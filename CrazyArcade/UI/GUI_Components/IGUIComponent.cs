using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Components
{
    public interface IGUIComponent
    {
        int ActualDrawOrder { get; set; }
        bool Visible { get; set; }
        Point Position { get; set; }
    }
}
