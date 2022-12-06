using System;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	public interface IGridBoxManager
	{
        public IGridBox CheckAvailable(GridBoxPosition position);
        public bool IsPotentialDemageTile(Point point);
        public bool MoveBoxTo(IGridBox box, GridBoxPosition position);
    }
}

