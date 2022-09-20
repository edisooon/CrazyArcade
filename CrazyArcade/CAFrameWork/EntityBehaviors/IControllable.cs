using System;
using CrazyArcade.CAFrameWork.Controller;
namespace CrazyArcade.CAFrameWork.EntityBehaviors
{
	public interface IControllable: IControllerDelegate
	{
		IController Controller { get; }
	}
}

