using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using CrazyArcade.UI.GUI_Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Compositions
{
    public class LifeCounter : GUIComposition
    {
        public LifeCounter()
        {
            name = "lifeCounter";
            ItemBoxItem rep = new("lifeRep", new SpriteAnimation(TextureSingleton.GetPlayer(false), new Rectangle(12, 77, 44, 41)));
            rep.ChangeComponentTextureOutputRect(30, 30);
            AddComponent(rep);
            GUIText text = new("count", "Lives: -1");
            Vector2 textPos = new(40, 5);
            text.SetPosition(textPos);
            text.InternalDrawOrder = 1;
            AddComponent(text);
            BlueBox box = new();
            box.ChangeComponentTextureOutputRect(80, 20);
            box.SetPosition(textPos);
            AddComponent(box);
        }
    }
}
