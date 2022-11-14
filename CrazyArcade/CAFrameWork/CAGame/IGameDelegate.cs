using System;
namespace CrazyArcade.CAFrameWork.CAGame
{
	public interface IGameDelegate
	{
		void StageTransitTo(int stageNum, int dir);
	}
}

