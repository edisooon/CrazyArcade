using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.GameGridSystems
{
	public class CAGameGridSystems: IGameSystem, IGridTransform
	{
        public static int BlockLength => 40;
        List<IGridable> list = new List<IGridable>();
		Vector2 camera { get; set; }
        private Vector2 stageOffset;
        private float gridSize;
        public CAGameGridSystems(Vector2 stageOffset, float gridSize)
        {
            this.gridSize = gridSize;
            this.stageOffset = stageOffset;
        }


        public Vector2 Trans(Vector2 vec)
        {
            vec = Scale(vec);
            vec += camera;
            vec += stageOffset;
            return vec;
        }
        public Vector2 RevTrans(Vector2 vec)
        {
            vec -= camera;
            vec -= stageOffset;
            vec = RevScale(vec);
            return vec;
        }

        public void AddSprite(IEntity sprite)
        {
            if (sprite is IGridable)
            {
                (sprite as IGridable).Trans = this;
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
                gridable.ScreenCoord = Trans(gridable.GameCoord);
            }
        }

        public Vector2 Scale(Vector2 vec)
        {
            return vec * BlockLength;
        }

        public Vector2 RevScale(Vector2 vec)
        {
            return vec / BlockLength;
        }
    }
}

