using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.BombFeature
{
	public class Explosion: CAEntity, IExplosion
	{
		private int distance;
		private Point center;
		public Explosion(Point center, int distance)
		{
			this.center = center;
			this.distance = distance;
		}

        public int Distance => distance;

        public Point Center => center;

        public override void Load()
        {
            int explosionTile = 40;
            Vector2 side = new Vector2(0, 0);
            SceneDelegate.ToAddEntity(new WaterExplosionCenter(X, Y));
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        side = new Vector2(0, -1);
                        break;
                    case 1:
                        side = new Vector2(0, 1);
                        break;
                    case 2:
                        side = new Vector2(-1, 0);
                        break;
                    case 3:
                        side = new Vector2(1, 0);
                        break;
                }
                for (int j = 1; j <= distance; j++)
                {
                    SceneDelegate.ToAddEntity(new WaterExplosionEdge(i, j == distance, (int)(X + (j * side.X * explosionTile)), (int)(Y + (j * side.Y * explosionTile))));
                }
            }
        }
    }
}

