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
        protected Vector2 position = new(0,0);
        public Vector2 InternalPosition { get => position; set { position = value; } }
        protected string name;
        public string InternalName { get => name; set { name = value; } }

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
        }
        public virtual void ChangeComponent(string newText)
        {
        }
    }
}
