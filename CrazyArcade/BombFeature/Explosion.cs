using System;
using CrazyArcade.CAFramework;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;

namespace CrazyArcade.BombFeature
{
	public class Explosion: CAEntity, IExplosion
	{
		private int distance;
		private Point center;
        public int Distance => distance;
        public Point Center => center;

        private Vector2 gamePos;
        private Vector2 pos;
        IBombCollectable owner;
        public Vector2 ScreenCoord
        {
            get => pos;
            set
            {
                pos = value;
                this.UpdateCoord(value);
            }
        }
        public void UpdateCoord(Vector2 value)
        {
            this.X = (int)value.X;
            this.Y = (int)value.Y;
        }
        private IGridTransform trans = new NullTransform();
        public IGridTransform Trans { get => trans; set => trans = value; }
        public Vector2 GameCoord {
            get => gamePos;
            set {
                gamePos = value;
                ScreenCoord = Trans.Trans(value);
            }
        }

        public Explosion(Point center, int blastLength, ISceneDelegate sceneDelegate, IGridTransform trans, IBombCollectable owner)
		{
            this.trans = trans;
            this.GameCoord = new Vector2(center.X, center.Y);
            this.SceneDelegate = sceneDelegate;
			this.center = center;
            this.distance = blastLength;
            this.owner = owner;
        }


        public void ExplodeEdges(int[] distance)
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
                for (int j = 1; j <= distance[i]; j++)
                {
                    SceneDelegate.ToAddEntity(new WaterExplosionEdge(i, j == distance[i], owner, (int)(X + (j * side.X * explosionTile)), (int)(Y + (j * side.Y * explosionTile))));
                }
            }
        }


        public override void Load()
        {

        }

        public void Display(int[] lengths)
        {
            ExplodeEdges(lengths);
        }
    }
}

