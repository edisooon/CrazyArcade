using System;
namespace CrazyArcade.CAFrameWork.Controller
{
	public interface IController
    {
        IControllerDelegate Delegate { set; }
        void Update();
        //
    }
}

