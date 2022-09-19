using System;
namespace CrazyArcade.CAFrameWork.Controller
{
	public interface IControllerDelegate
	{
        public void KeyUp();
        public void KeyDown();
        public void KeyLeft();
        public void KeyRight();
        public void KeySpace();
    }
}

