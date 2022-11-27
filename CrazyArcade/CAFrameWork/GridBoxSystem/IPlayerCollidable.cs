using System;
using CrazyArcade.PlayerStateMachine;

namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	public interface IGridPlayerCollidable: IGridBox
	{
		void PreCollide(IPlayer player);
		void Collide(IPlayer player);
	}
}

