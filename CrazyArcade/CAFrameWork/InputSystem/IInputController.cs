using System;
using System.Collections.Generic;

namespace CrazyArcade.CAFrameWork.InputSystem
{
	public struct CodeRange
	{
		public readonly int Start;
		public readonly int End;
		public CodeRange(int start, int end)
		{
			this.Start = start;
			this.End = end;
		}
		public bool Contains(int val)
		{
			return val >= Start && val <= End;
		}
	}
	public interface IInputController
	{
		Dictionary<int, Action> GetCommands();
		Dictionary<CodeRange, Action<int>> GetRangeCommands()
		{
			return new Dictionary<CodeRange, Action<int>>();
		}
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

