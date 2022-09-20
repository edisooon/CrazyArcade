using System;

namespace CrazyArcade.CAFrameWork.Controller
{
	public class Controller
	{
        public Controller()
        {

        }
        public Controller(IControllerDelegate reciever)
        {
            this.reciever = reciever;
        }
        private IControllerDelegate reciever;
        public IControllerDelegate Delegate
        {
            set
            {
                reciever = value;
            }
        }
    }
}

