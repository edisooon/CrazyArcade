using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Components
{
    public interface IGUIComponent
    {
        int InternalDrawOrder { get; set; }
        bool InternalVisible { get; set; }
        Vector2 InternalPosition { get; set; }
        public void Draw(GameTime time, SpriteBatch batch);
    }
}
