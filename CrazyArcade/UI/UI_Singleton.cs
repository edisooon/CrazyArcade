using CrazyArcade.UI.GUI_Compositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI
{
    public sealed class UI_Singleton
    {
        private static UI_Singleton instance = null;
        private static readonly object padlock = new object();
        public static GUI internalGUI;

        UI_Singleton()
        {
        }

        public static UI_Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UI_Singleton();
                    }
                    return instance;
                }
            }
        }
        
        public static void AddNewElement(IGUIComposite newElement)
        {
            internalGUI.AddGUIItem(newElement);
        }
        public static void ClearGUI()
        {
            internalGUI.RemoveAllItems();
        }
        public static void ChangeComponentText(string compositeName, string componentName, string newText)
        {
            internalGUI.GUILookup[compositeName].ComponentDict[componentName].ChangeComponentText(newText);
        }
        
    }
}
