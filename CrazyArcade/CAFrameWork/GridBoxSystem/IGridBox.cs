using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	public interface IGridBox: IGridable
	{
        IGridBoxManager Manager { set; }
        GridBoxPosition Position { get; set; }
		bool IsSolid(Dir dir, bool couldKick);
		HashSet<Point> PotentialDangerousTile();
	}
}

