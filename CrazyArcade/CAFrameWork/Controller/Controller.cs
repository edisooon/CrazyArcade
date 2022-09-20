using System;

namespace CrazyArcade.CAFrameWork.Controller
{
	public abstract class Controller: IController
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
            get
            {
                return reciever;
            }
            set
            {
                reciever = value;
            }
        }

        public abstract void Update();
    }
}

