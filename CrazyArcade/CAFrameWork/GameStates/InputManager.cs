using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.CAGame;
using CrazyArcade.CAFrameWork.InputSystem;

namespace CrazyArcade.CAFrameWork.GameStates
{
	public class InputManager: CAEntity, IInputController
	{
		Dictionary<int, Action> commands;
		Dictionary<CodeRange, Action<int>> rangeCommands = new Dictionary<CodeRange, Action<int>>();
		public InputManager(Dictionary<int, Action> commands)
		{
			this.commands = commands;
		}
		public InputManager(Dictionary<int, Action> commands,
			Dictionary<CodeRange, Action<int>> rangeCommands)
		{
			this.commands = commands;
			this.rangeCommands = rangeCommands;
		}
		public Dictionary<int, Action> GetCommands() => commands;
		public Dictionary<CodeRange, Action<int>> GetRangeCommands() => rangeCommands;

		public override void Load()
		{

		}
	}
}

