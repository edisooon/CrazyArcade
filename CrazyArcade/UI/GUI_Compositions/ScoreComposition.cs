using CrazyArcade.UI.GUI_Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.UI.GUI_Compositions
{
    public class ScoreComposition : GUIComposition
    {
        public ScoreComposition()
        {
            BlueBox box = new();
            box.ChangeComponentTextureOutputRect(100, 20);
            AddComponent(box);
            name = "score";
            AddComponent(new GUIText("scoreText", "Score: 0"));
            SetPosition(new Vector2(CAGame.ScreenSize.X - 100, 0));

        }
    }
}
