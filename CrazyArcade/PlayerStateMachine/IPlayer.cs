using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.PlayerStateMachine
{
	public interface IPlayer: IGridBoxReciever, IBoxOccupy, IGridable
	{
		Dir Direction { get; }
		bool CouldKick { get; }
	}
}

