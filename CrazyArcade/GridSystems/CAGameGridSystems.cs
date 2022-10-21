using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.GameGridSystems
{
	public class CAGameGridSystems: IGameSystem
	{
        List<IGridable> list = new List<IGridable>();
		Vector2 camera { get; set; }
        private Vector2 stageOffset;
        private float gridSize;
        public CAGameGridSystems(Vector2 stageOffset, float gridSize)
        {
            this.gridSize = gridSize;
            this.stageOffset = stageOffset;
        }


        private Vector2 trans(Vector2 vec)
        {
            vec *= 40;
            vec += camera;
            vec += stageOffset;
            return vec;
        }

        public void AddSprite(IEntity sprite)
        {
            if (sprite is IGridable)
            {
                list.Add(sprite as IGridable);
            }
        }

        public void RemoveAll()
        {
            list = new List<IGridable>();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IGridable)
            {
                list.Remove(sprite as IGridable);
            }
        }

        public void Update(GameTime time)
        {
            foreach(IGridable gridable in list)
            {
                gridable.ScreenCoord = trans(gridable.GameCoord);
            }
        }
    }
}

