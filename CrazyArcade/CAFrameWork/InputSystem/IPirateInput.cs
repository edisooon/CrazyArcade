using System;
using CrazyArcade.Pirates;

namespace CrazyArcade.CAFrameWork.InputSystem
{
	public interface IPirateInput: IInput
	{
		IPirate Pirate { set; }
		int[] ValidKeys { get; }
	}
}

