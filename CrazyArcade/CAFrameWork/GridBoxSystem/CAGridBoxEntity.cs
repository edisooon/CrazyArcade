using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.GridBoxSystem
{
	public abstract class CAGridBoxEntity: CAEntity, IGridBox
	{
		public CAGridBoxEntity(GridBoxPosition position)
		{
			this.position = position;
		}
        private GridBoxPosition position;
        public GridBoxPosition Position { get => position; set => position = value; }
		protected IGridBoxManager manager;
        public IGridBoxManager Manager { set => manager = value; }
        public abstract IGridTransform Trans { get; set; }
        public abstract Vector2 ScreenCoord { get; set; }
        public abstract Vector2 GameCoord { get; set; }

        public abstract bool IsSolid(Dir dir, bool couldKick);
        public abstract HashSet<Point> PotentialDangerousTile();
    }
}

