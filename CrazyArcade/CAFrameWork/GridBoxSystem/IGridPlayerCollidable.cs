using System;
using CrazyArcade.PlayerStateMachine;

namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	public interface IGridPlayerCollidable: IGridBox
	{
		void Collide(IPlayer player);
	}
}

