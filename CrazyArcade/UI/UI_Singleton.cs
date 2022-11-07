using CrazyArcade.CAFramework;
using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static void ClearGUI()
        {
            internalGUI.RemoveAllItems();
        }
        public static void ChangeComponentText(string compositeName, string componentName, string newText)
        {
            internalGUI.GUILookup[compositeName].ComponentDict[componentName].ChangeComponentText(newText);
        }
        public static void ChangeComponentTexture(string compositeName, string componentName, SpriteAnimation newSpriteAnim)
        {
            internalGUI.GUILookup[compositeName].ComponentDict[componentName].ChangeComponentTexture(newSpriteAnim);
        }
        public static void AddPreDesignedComposite(IGUIComposite newComposite)
        {
            if (internalGUI.GUILookup.ContainsKey(newComposite.Name))
            {
                Debug.WriteLine("element " + newComposite.Name + " already exists!");
                return;
            }
            internalGUI.AddGUIItem(newComposite);
        }
        public static void AddEmptyComposite(string name)
        {
            internalGUI.AddGUIItem(new EmptyComposite(name));
        }
        public static void MoveCompositePosition(string compositeName, Vector2 newPos)
        {
            internalGUI.GUILookup[compositeName].SetPosition(newPos);
        }
        public static void MoveComponentPosition(string compositeName, string componentName, Vector2 newPos)
        {
            internalGUI.GUILookup[compositeName].ComponentDict[componentName].SetPosition(newPos);
        }
        public static void RemoveComposition(string compositeName)
        {
            internalGUI.RemoveGUIItem(compositeName);
        }
        public static void RemoveComponent(string compositeName, string componentName)
        {
            internalGUI.GUILookup[compositeName].RemoveComponent(componentName);
        }
    }
}
