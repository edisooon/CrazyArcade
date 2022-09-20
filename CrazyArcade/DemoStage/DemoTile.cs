using System;
using CrazyArcade.CAFrameWork;
using CrazyArcade.CAFrameWork.Singleton;
using CrazyArcade.CAFrameWork.EntityBehaviors;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrazyArcade.DemoStage
{
	public class DemoTile: GridEntity
	{
		public DemoTile(Point gridPosition)
		{
            GridX = gridPosition.X;
            GridY = gridPosition.Y;
        }

        public override Texture2D Graphics => CAFrameWork.Singleton.Graphics.SandGround;

        public override IGridTransform Transform => new DemoTransform();

        public override void Load()
        {
            inputFrame = new Rectangle(new Random().Next() % 2 * 40, 0, 40, 40);
        }
    }
}

