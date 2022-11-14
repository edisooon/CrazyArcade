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
    public class ResumeButton : GUIComposition
    {
        IGUIComponent resume;
        IGUIComponent text;
        public ResumeButton(string name)
        {
            this.name = name;
            resume = new Button("resume");
            text = new GUIText("resume text", "Resume");
            text.SetPosition(new Vector2(375, 165));
            SetButton();
            AddComponent(resume);
            AddComponent(text);
        }
        public void Enlarge()
        {
            resume.ChangeComponentTextureOutputRect(220, 70);
            resume.SetPosition(new Vector2(300, 140));
        }
        public void SetButton()
        {
            resume.ChangeComponentTextureOutputRect(200, 50);
            resume.SetPosition(new Vector2(310, 150));
        }
    }
}
