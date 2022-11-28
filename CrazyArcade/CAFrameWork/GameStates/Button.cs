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
using Microsoft.Xna.Framework.Input;
using CrazyArcade.CAFrameWork.CAGame;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public class Button : GUIComposition
    {
        ButtonBase button;
        IGUIComponent text;
        Rectangle buttonRectangle;
        private bool enlarged = false;
        private Action pressButtonAction;
        public Button(string name, string content, Vector2 position, Action action)
        {
            pressButtonAction = action;
            this.name = name;
            button = new ButtonBase(content);
            text = new GUIText(name, content);
            SetPosition(position);
            buttonRectangle = new Rectangle((int)position.X, (int)position.Y, button.Rect.Width, button.Rect.Height);
            SetButton();
            //Centers text
            text.SetPosition(new Vector2(buttonRectangle.Width - 125, buttonRectangle.Height - 37));
            AddComponent(button);
            AddComponent(text);
        }
        private void Enlarge()
        {
            button.ChangeComponentTextureOutputRect(buttonRectangle.Width+20, buttonRectangle.Height+20);
            button.SetPosition(new Vector2(-10, -10));
            enlarged = true;
        }
        public void SetButton()
        {
            button.ChangeComponentTextureOutputRect(buttonRectangle.Width, buttonRectangle.Height);
            button.SetPosition(new Vector2(0, 0));
        }
        private bool HasMouse(MouseState mouse)
        {
            return buttonRectangle.Intersects(new Rectangle(mouse.X,mouse.Y,0,0));
        }
        public void Update(MouseState mouse, IGameDelegate gameRef)
        {
            if(HasMouse(mouse))
            {
                Enlarge();
            }
            if(!HasMouse(mouse) && enlarged)
            {
                SetButton();
            }
            if(HasMouse(mouse) && mouse.LeftButton.Equals(ButtonState.Pressed))
            {
                pressButtonAction();
            }
        }
    }
}
