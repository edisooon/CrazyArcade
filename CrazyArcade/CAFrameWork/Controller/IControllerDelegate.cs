using System;
namespace CrazyArcade.CAFrameWork.Controller
{
	public interface IControllerDelegate
	{
        public void Up();
        public void Down();
        public void Left();
        public void Right();
        public void Space();
    }
}

