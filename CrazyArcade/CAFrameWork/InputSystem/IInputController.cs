using System;
using System.Collections.Generic;

namespace CrazyArcade.CAFrameWork.InputSystem
{
	public interface IInputController
	{
		Dictionary<int, Action> getCommands();
		/* A command pattern is used here, you need to return a key-command
		 * map. You can use lambda expression for Action.
		 * i.e. 
		 * () => expression
		 * OR
		 * () => {
		 *		//your code
		 * }
		 * 
		 */
		

	}
}

