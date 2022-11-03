using CrazyArcade.CAFramework;
using CrazyArcade.UI.GUI_Components;
using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI
{
    public class GUI
    {
        private List<IGUIComposite> GUIItems;
        private Dictionary<string,IGUIComposite> GUILookup;
        public GUI()
        {
            RemoveAllItems();
            AddGUIItem(new GUITestComposition("test1"));
        }
        public void Draw(GameTime time, SpriteBatch batch)
        {
            foreach (IGUIComposite item in GUIItems.OrderBy(e => e.DrawOrder))
            {
                item.Draw(time, batch);
            }
        }
        public void AddGUIItem(IGUIComposite item)
        {
            GUIItems.Add(item);
            GUILookup.Add(item.Name, item);
        }
        public void RemoveGUIItem(IGUIComposite item)
        {
            GUIItems.Remove(item);
            GUILookup.Remove(item.Name);
        }
        public void RemoveAllItems()
        {
            GUIItems = new List<IGUIComposite>();
            GUILookup = new Dictionary<string, IGUIComposite>();
        }
    }
}

