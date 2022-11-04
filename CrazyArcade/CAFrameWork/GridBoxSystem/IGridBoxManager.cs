using System;
namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	public interface IGridBoxManager
	{
        public bool CheckAvailable(GridBoxPosition position);
        public bool MoveBoxTo(IGridBox box, GridBoxPosition position);
    }
}

