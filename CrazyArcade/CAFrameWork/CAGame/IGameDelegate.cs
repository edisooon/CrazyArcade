using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.Transition;
using System;
namespace CrazyArcade.CAFrameWork.CAGame
{
	public interface IGameDelegate
	{
		public void NewInstance();
		public ISceneState Scene { get; set; }
		public void Quit();
        void StageTransitTo(int stageNum, int dir);
    }
}

