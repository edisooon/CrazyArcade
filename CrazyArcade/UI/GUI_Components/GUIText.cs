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
        }
        private SpriteFont font = TextureSingleton.getTestFont();
        private string drawText;
        public void ChangeDrawText(string newText)
        {
            drawText = newText;
        }
        public override void Draw(GameTime time, SpriteBatch batch, Vector2 basePosition)
        {
            batch.DrawString(font, drawText, position + basePosition, Color.Black);
        }
        public override void ChangeComponent(string newText)
        {
            drawText = newText;
        }
    }
}
