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
        public IGridBox CheckAvailable(GridBoxPosition position)
        {
            return !map.ContainsKey(position) ? null : map[position];
        }
        public bool MoveBoxTo(IGridBox box, GridBoxPosition position)
        {
            Console.WriteLine("Contains: " + map.ContainsKey(box.Position));

            if (map[box.Position] == box && !map.ContainsKey(position))
            {
                map.Remove(box.Position);
                map[position] = box;
                box.Position = position;
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
                if (CheckAvailable(gridBox.Position)==null)
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
                    Console.WriteLine("put in: " + gridBox.Position.X + " " + gridBox.Position.Y + " " + gridBox.Position.Depth);

                    map.Remove(gridBox.Position);
                }
            }
        }

        public void Update(GameTime time)
		{
		    potentialDemageTiles = new HashSet<Point>();
            foreach (IGridBox boxes in map.Values)
            {
                potentialDemageTiles.UnionWith(boxes.PotentialDangerousTile()); ;
            }
		}
		HashSet<Point> potentialDemageTiles = new HashSet<Point>();
		public bool IsPotentialDemageTile(Point point)
        {
            return potentialDemageTiles.Contains(point);
        }
    }
}

