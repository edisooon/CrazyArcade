using System;
using CrazyArcade.CAFramework;
using CrazyArcade.GameGridSystems;

namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	public interface IGridBox: IGridable
	{
        IGridBoxManager Manager { set; }
        GridBoxPosition Position { get; set; }
	}
}

