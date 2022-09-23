using System;
namespace CrazyArcade.CAFramework.Controller
{
	public interface IControllable: IControllerDelegate
	{
        IController Controller { get; set; }
	}
}

