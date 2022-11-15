using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	public class GridBoxSystem: IGameSystem, IGridBoxManager
	{
		public GridBoxSystem()
		{
		}
        private Dictionary<GridBoxPosition, IGridBox> map = new Dictionary<GridBoxPosition, IGridBox>();
        public bool CheckAvailable(GridBoxPosition position)
        {
            return !map.ContainsKey(position);
        }
        public bool MoveBoxTo(IGridBox box, GridBoxPosition position)
        {
            if (map[box.Position] == box && !map.ContainsKey(position))
            {
                map.Remove(box.Position);
                map[position] = box;
                box.Position.Copy(position);
                return true;
            }
            return false;
        }
        public void AddSprite(IEntity sprite)
        {
            if (sprite is IGridBoxReciever)
            {
                (sprite as IGridBoxReciever).Manager = this;
            }
            if (sprite is IGridBox)
            {
                IGridBox gridBox = (sprite as IGridBox);
                if (CheckAvailable(gridBox.Position))
                {
                    map[gridBox.Position] = gridBox;
                    gridBox.Manager = this;
                } else
                {
                    gridBox.RemoveFromStage();
                }
            }
        }
        public void RemoveAll()
        {
            map = new Dictionary<GridBoxPosition, IGridBox>();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IGridBox)
            {
                IGridBox gridBox = (sprite as IGridBox);
                if (map.ContainsKey(gridBox.Position) && map[gridBox.Position] == gridBox)
                {
                    map.Remove(gridBox.Position);
                }
            }
        }

        public void Update(GameTime time)
        {
            //Empty
        }
    }
}

