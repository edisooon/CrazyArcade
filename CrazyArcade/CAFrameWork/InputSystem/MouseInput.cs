using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.CAFrameWork.InputSystem
{
	enum MouseStatus
	{
		LeftDown = 30000,
		LeftClick = 30001,
		RightDown = 30002,
		RightClick = 30003
	}
	public class MouseInput: CAEntity, IInput
	{

		/* Indexed from 10000 - 19999 for mouse position X
		 * i.e. 10000 means position at 0, 10999 means position at 999
		 * Indexed from 20000 - 29999 for mouse position Y
		 * i.e. 10000 means position at 0, 10999 means position at 999
		 * 30000 means left Down
		 * 30001 means left Click
		 * 30002 means right Down
		 * 30003 means right Click
		 */
		private const int mouseXStartIndex = 10000;
		private const int mouseYStartIndex = 20000;
		public MouseInput()
		{

		}
		HashSet<int> previous = new HashSet<int>();
		public HashSet<int> GetInputs()
		{
			HashSet<int> res = new HashSet<int>();
			MouseState state = Mouse.GetState();
			res.Add(mouseXStartIndex + state.Position.X);
			res.Add(mouseYStartIndex + state.Position.Y);
			if (state.LeftButton == ButtonState.Pressed)
				res.Add((int)MouseStatus.LeftDown);
			else if (previous.Contains((int)MouseStatus.LeftDown))
				res.Add((int)MouseStatus.LeftClick);
			if (state.RightButton == ButtonState.Pressed)
				res.Add((int)MouseStatus.RightClick);
			else if (previous.Contains((int)MouseStatus.RightDown))
				res.Add((int)MouseStatus.RightClick);
			previous = res;
			return res;
		}

		

		public override void Load()
		{
		}
		public static CodeRange CodeRangeX => new CodeRange(10000, 19999);
		public static CodeRange CodeRangeY => new CodeRange(20000, 29999);
	}
}

