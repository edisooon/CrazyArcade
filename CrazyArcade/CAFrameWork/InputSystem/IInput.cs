using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;

namespace CrazyArcade.CAFrameWork.InputSystem
{

	public interface IInput: IEntity
	{
		/* Return all the keys that in active for a input
		 * e.g. w key down is 1, w key clicked is 2, s key down is 3, ...
		 */
		HashSet<int> GetInputs();
	}
}

