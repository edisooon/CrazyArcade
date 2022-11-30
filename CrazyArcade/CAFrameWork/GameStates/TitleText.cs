using CrazyArcade.UI.GUI_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class TitleText : GUIComposition
    {
        public TitleText(String name, String text)
        {
            GUIText gameText = new GUIText(name, text);
            SetPosition(GetTextPos(gameText.Font, text));
            this.name = name;
            AddComponent(gameText);
        }
        public static Vector2 GetTextPos(SpriteFont font, String content)
        {
            return new Vector2(CrazyArcade.CAGame.ScreenSize.X / 2 - (int)font.MeasureString(content).X / 2, CrazyArcade.CAGame.ScreenSize.Y / 6);
        }
    }
}
