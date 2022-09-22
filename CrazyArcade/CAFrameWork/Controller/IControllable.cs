using System;
namespace CrazyArcade.CAFramework.Controller
{
	public interface IControllable: IControllerDelegate
	{
        IController controller { get; set; }
	}
}

