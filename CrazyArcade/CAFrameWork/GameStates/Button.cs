using CrazyArcade.UI.GUI_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.UI.GUI_Compositions;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using System.Transactions;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class Button : GUIComposition
    {
        IGUIComponent button;
        IGUIComponent text;
        public Button(string name, Vector2 position)
        {
            this.name = name;
            button = new ButtonBase("resume");
            text = new GUIText("resume text", "Resume");
            SetButton();
            SetPosition(position);
            //Centers text
            text.SetPosition(new Vector2(position.X, position.Y));
            AddComponent(button);
            AddComponent(text);
        }
        public void Enlarge()
        {
            button.ChangeComponentTextureOutputRect(220, 70);
            button.SetPosition(new Vector2(Position.X - 10, Position.Y - 10));
        }
        public void SetButton()
        {
            button.ChangeComponentTextureOutputRect(200, 50);
            button.SetPosition(Position);
        }
    }
}
