using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using Microsoft.Xna.Framework;

namespace CrazyArcade.PlayerStateMachine
{
	public interface IPlayer: IGridBoxReciever
	{
		Dir Direction { get; }
		bool CouldKick { get; }
	}
}

