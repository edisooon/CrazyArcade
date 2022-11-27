using System;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using Microsoft.Xna.Framework;

namespace CrazyArcade.PlayerStateMachine
{
	public interface IPlayer: IGridBoxReciever
	{
		bool CouldKick { get; }
	}
}

