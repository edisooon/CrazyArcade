using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.Transition
{
	public interface ISceneState: IScene
    {
        //implement setter by setting camera in grid system
        Vector2 Camera { get; set; }
        //implement setter by setting StageOffset in grid system
        Vector2 StageOffset { get; set; }
        //completion handler, end for the life cycle
        void EndAfterTransition();
        //completion handler, begin for the life cycle
        void LoadAfterTransition();
    }
}

