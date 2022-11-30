using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.Items;
using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Loading
{
    public class DefaultLoad : IGUILoad
    {
        public void LoadGUI()
        {
            UI_Singleton.ClearGUI();
            UI_Singleton.AddPreDesignedComposite(new ScoreComposition());
            UI_Singleton.AddPreDesignedComposite(new GenericTextBox("levelCounter", "Level ", 100, 20));
            UI_Singleton.AddPreDesignedComposite(new GenericTextBox("itemBoxTitle", "Items", 65, 20));
            UI_Singleton.AddPreDesignedComposite(new LifeCounter());
            UI_Singleton.MoveComponentPosition("itemBoxTitle", "text", new Vector2(7, 0));
            UI_Singleton.MoveComponentPosition("levelCounter", "text", new Vector2(15, 0));
            UI_Singleton.MoveCompositePosition("itemBoxTitle", new Vector2(60, 30));
            UI_Singleton.MoveCompositePosition("levelCounter", new Vector2(370, 0));
            UI_Singleton.AddPreDesignedComposite(new ItemCountComposition("needle", new SpriteAnimation(TextureSingleton.GetNeedle(), new Rectangle(0, 0, 162, 164))));
            UI_Singleton.MoveCompositePosition("needle", new Vector2(750,150));
        }
    }
}
