using Microsoft.Xna.Framework;
using System;
namespace CrazyArcade.CAFramework.Controller
{
	public interface IController
	{
		IControllerDelegate Delegate { get; set; }
		void Update(GameTime time);
	}
}

