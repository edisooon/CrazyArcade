using System;
namespace CrazyArcade.CAFramework.Controller
{
	public interface IControllerDelegate
	{
		void KeyUp();
        void KeyDown();
        void KeyLeft();
        void KeyRight();
        void KeySpace();
        void Key_o();
        void Key_p();
        void RightClick();
        void LeftClick(int x, int y);
    }
}

