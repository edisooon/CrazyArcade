using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;

namespace CrazyArcade.CAFrameWork.InputSystem
{
	public interface IInput: IEntity
	{
		HashSet<int> GetInputs();
	}
}

