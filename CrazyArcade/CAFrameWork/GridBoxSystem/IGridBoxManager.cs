using System;
namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	public interface IGridBoxManager
	{
        public IGridBox CheckAvailable(GridBoxPosition position);
        public bool MoveBoxTo(IGridBox box, GridBoxPosition position);
    }
}

