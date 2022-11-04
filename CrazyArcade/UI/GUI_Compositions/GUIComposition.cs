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
    abstract public class GUIComposition : IGUIComposite
    {
        protected int externalDrawOrder = 0;
        public int DrawOrder { get => externalDrawOrder; set { externalDrawOrder = value; } }
        protected bool externalVisible = true;
        public bool Visible { get => externalVisible; set { externalVisible = value; } }
        protected Vector2 externalPosition = new(0, 0);
        public Vector2 Position { get => externalPosition; set { externalPosition = value; } }
        protected List<IGUIComponent> componentList = new ();
        public List<IGUIComponent> Components { get => componentList; set { componentList = value; } }
        protected string name;
        public string Name { get => name; set { name = value; } }
        protected Dictionary<string, IGUIComponent> ComponentMap = new();
        public Dictionary<string, IGUIComponent> ComponentDict { get => ComponentMap; set { ComponentMap = value; } }
        public void Draw(GameTime time, SpriteBatch batch)
        {
            foreach (IGUIComponent item in componentList.OrderBy(e => e.InternalDrawOrder))
            {
                item.Draw(time, batch, Position);
            }
        }
        public void AddComponent(IGUIComponent newComponent)
        {
            componentList.Add(newComponent);
            ComponentMap.Add(newComponent.InternalName, newComponent);
        }
        public void RemoveComponent(string componentName)
        {
            componentList.Remove(ComponentMap[componentName]);
            ComponentMap.Remove(componentName);
        }
        public void SetPosition(Vector2 position)
        {
            this.Position = position;
        }
    }
}
