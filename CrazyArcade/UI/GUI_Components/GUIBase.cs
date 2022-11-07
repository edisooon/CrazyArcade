using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Components
{
    abstract public class GUIBase : IGUIComponent
    {
        protected int componentDrawOrder = 0;
        public int InternalDrawOrder { get => componentDrawOrder; set { componentDrawOrder = value; } }
        protected bool visible = true;
        public bool InternalVisible { get => visible; set { visible = value; } }
        protected bool isTextComponent = false;
        public bool IsTextComponent { get => isTextComponent; set { isTextComponent = value; } }
        protected Vector2 position = new(0, 0);
        public Vector2 InternalPosition { get => position; set { position = value; } }
        protected string name;
        public string InternalName { get => name; set { name = value; } }
        protected string drawText = "";
        public string DrawText { get => drawText; set { drawText = value; } }
        private SpriteAnimation spriteAnim = new(TextureSingleton.GetNull(), 1, 0, 0, 0);
        public SpriteAnimation Sprite { get => spriteAnim; set { spriteAnim = value; } }
        
        protected SpriteFont font = null;
        //Set to as a default as well as to test
        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }
        public void ToggleVisibility()
        {
            visible = !visible;
        }
        public virtual void Draw(GameTime time, SpriteBatch batch, Vector2 basePosition)
        {
            if (isTextComponent) batch.DrawString(font, drawText, position + basePosition, Color.Black);
            else
            {
                Sprite.Position = basePosition + InternalPosition;
                Sprite.Update(time);
                Sprite.Draw(batch, 0, 0);
            }
        }
        public virtual void ChangeComponentTexture(SpriteAnimation sprite)
        {
            Sprite = sprite;
        }
        public virtual void ChangeComponentText(string newText)
        {
            drawText = newText;
        }

        public void ChangeComponentTextureOutputRect(int newWidth, int newHeight)
        {
            Sprite.Width = newWidth;
            Sprite.Height = newHeight;
        }

        public void ToggleRectangleFlag()
        {
            if (Sprite.rectangleFlag == 0) Sprite.rectangleFlag = 1;
            else Sprite.rectangleFlag = 0;
        }
    }
}
