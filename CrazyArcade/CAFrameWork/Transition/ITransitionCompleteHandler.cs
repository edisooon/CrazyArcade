using System;
namespace CrazyArcade.CAFrameWork.Transition
{
	public interface ITransitionCompleteHandler
	{
		void Complete(ISceneState oldState, ISceneState newState);
	}
}

