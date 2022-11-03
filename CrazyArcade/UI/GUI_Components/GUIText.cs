using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Components
{
    abstract public class GUIText : IGUIComponent
    {
        private int componentDrawOrder = 0;
        public int InternalDrawOrder { get => componentDrawOrder; set { componentDrawOrder = value; } }
        private bool visible = true;
        public bool InternalVisible { get => visible; set { visible = value; } }
        private Vector2 position = new(0,0);
        public Vector2 InternalPosition { get => position; set { position = value; } }
        private SpriteFont font;
        private String drawText = "TEXT NOT SET";

        public void Draw(GameTime time, SpriteBatch batch)
        {
            batch.DrawString(font, drawText, position, Color.Black);
        }
        public void ChangeDrawText(String newText)
        {
            drawText = newText;
        }
    }
}
