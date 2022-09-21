using System;
using CrazyArcade.CAFrameWork.EntityBehaviors;
using Microsoft.Xna.Framework;

namespace CrazyArcade.DemoStage
{
	public class DemoTransform: IGridTransform
	{
        private int size = 40;
		public DemoTransform()
		{
		}

        public Rectangle Trans(double x, double y)
        {
            x = x < 9 ? x : 9;
            x = x > 0 ? x : 0;
            y = y < 9 ? y : 9;
            y = y > 0 ? y : 0;
            return new Rectangle((int)(50 + x * size), (int)(50 + y * size), size, size);
        }
    }
}

