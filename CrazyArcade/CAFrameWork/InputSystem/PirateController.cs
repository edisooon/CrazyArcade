using System;
using System.Collections.Generic;
using System.Xml.Linq;
using CrazyArcade.Blocks;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.DoorUtils;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.Items;
using CrazyArcade.Pirates;
using Microsoft.Xna.Framework;
using Point = Microsoft.Xna.Framework.Point;

namespace CrazyArcade.CAFrameWork.InputSystem
{
	enum PirateKeys
	{
		keyUp		= 0,
		keyLeft		= 1,
		keyDown		= 2,
		keyRight	= 3,
		keySpace	= 4
	}
	public class PirateController: CAEntity, IPirateInput, IGridBoxReciever
	{
		private ITimer timer;

        private int prefix;
        private const int baseIndex = 1000;
        private static int count = 0;

        private IGridBoxManager manager;
        public IGridBoxManager Manager { get => manager; set => manager = value; }
        public IPirate Pirate { set => pirate = value; }

		private int[] validKeys;
        public int[] ValidKeys => validKeys;

        private IPirate pirate;

        public PirateController()
		{
            count += 50;
            prefix = baseIndex + count;
			validKeys = new int[]
			{
				prefix + 0,
				prefix + 1,
				prefix + 2,
				prefix + 3,
				prefix + 4,
			};
		}
		private HashSet<int> keys = new HashSet<int>();
		public HashSet<int> GetInputs() => keys;
        class Node
        {
            private Point pos;
			private Dir dir;
			public Point Pos => pos;
			public Dir Direction => dir;
			public Node Parent;
			public Node(Dir dir, Point point, Node parent) : this(dir, point)
			{
				this.Parent = parent;
			}

			public Node(Dir dir, Point point)
            {
                this.dir = dir;
                this.pos = point;
            }
			//public void Print()
			//{
			//	recPrint();
			//	Console.WriteLine();
			//}
			//private void recPrint()
			//{
			//	if (Parent != null)
			//	{
			//		Console.Write(" -> ");
			//		Parent.recPrint();
			//	}
			//	Console.Write("(Point: " + pos.X + " " + pos.Y + ")");
			//}
        }
        bool isTargetBlock(Point point)
        {
			return (manager.CheckAvailable(
				new GridBoxPosition(point, (int)GridObjectDepth.Item)
			) is Item && manager.CheckAvailable(
                new GridBoxPosition(point, (int)GridObjectDepth.Item)
            ) is not Key && manager.CheckAvailable (
				new GridBoxPosition(point, (int)GridObjectDepth.Box)
			) == null) || playerInRange.Contains(point);
        }
		bool isBreakable(Point point)
		{
			return manager.CheckAvailable(
				new GridBoxPosition(point, (int)GridObjectDepth.Item)
			) is BreakableBlock;
		}
		bool isSafe(Point point)
        {
            return !manager.IsPotentialDemageTile(point);
        }
		private Node findSafe()
		{
			Node res = null;
			Queue<Node> q = new Queue<Node>();
			HashSet<Point> traveled = new HashSet<Point>();
			for (int i = 0; i < 4; i++)
			{
				q.Enqueue(new Node((Dir)i, adjPoint(pirate.PiratePosition, (Dir)i)));
			}
			while (q.Count > 0)
			{
				Node node = q.Dequeue();
				if (isSafe(node.Pos))
				{
					res = node;
				}
				if (manager.CheckAvailable(new GridBoxPosition(node.Pos, (int)GridObjectDepth.Box))
					== null)
				{
					for (int i = 0; i < 4; i++)
					{
						Point newP = adjPoint(node.Pos, (Dir)i);
						if (!traveled.Contains(newP))
						{
							traveled.Add(newP);
							q.Enqueue(new Node(node.Direction, newP, node));
						}
					}
				}
			}

			return res;
		}
		private Node findBreakable()
		{
			return find(isBreakable);
		}

		private Node findTarget()
		{
			return find(isTargetBlock);
		}

		private Node find(Func<Point, bool> check)
        {
            Node res = null;
            Queue<Node> q = new Queue<Node>();
			HashSet<Point> traveled = new HashSet<Point>();
			for (int i = 0; i < 4; i++)
            {
                q.Enqueue(new Node((Dir)i, adjPoint(pirate.PiratePosition, (Dir)i)));
            }
			while(q.Count > 0)
			{
				Node node = q.Dequeue();
				if (check(node.Pos))
				{
					return node;
				}
				if (manager.CheckAvailable(new GridBoxPosition(node.Pos, (int)GridObjectDepth.Box))
					== null)
				{
					for (int i = 0; i < 4; i++)
					{
						Point newP = adjPoint(node.Pos, (Dir)i);
						if (!traveled.Contains(newP))
						{
							traveled.Add(newP);
							q.Enqueue(new Node(node.Direction, newP));
						}
					}
				}
			}

			return res;
        }

		private void setDir(HashSet<int> res, Dir dir)
        {
            res.Add(prefix + (int)dir);
        }

        
        public override void Load()
        {

		}
        private Point adjPoint(Point point, Dir dir)
        {
			Point[] direction = new Point[]
			{
					new Point(0, -1),
					new Point(-1, 0),
					new Point(0, 1),
					new Point(1, 0)
            };
            return new Point(point.X + direction[(int)dir].X, point.Y + direction[(int)dir].Y);
        }
		private void detect(Point point, HashSet<Point> set, Dir dir)
		{
			Point current = point;
			for (int i = 0; i < pirate.BlastLength; i++)
			{
                current = adjPoint(current, dir);
				if (manager.CheckAvailable(new GridBoxPosition(current, (int)GridObjectDepth.Box)) != null)
				{
					return;
				}
				set.Add(current);
			}
		}
		private HashSet<Point> PotentialDangerousTile(Point point)
		{
			HashSet<Point> set = new HashSet<Point>();
			for (int i = 0; i < 4; i++)
			{
				detect(point, set, (Dir)i);
			}
			return set;
		}
		HashSet<Point> playerInRange = new HashSet<Point>();
        private void updatePlayerRange()
        {
			playerInRange = new HashSet<Point>();
			foreach (Vector2 pos in this.SceneDelegate.PlayerPositions)
			{
				playerInRange.Add(new Point((int)pos.X, (int)pos.Y));
				playerInRange.UnionWith(PotentialDangerousTile(new Point((int)pos.X, (int)pos.Y)));
			}

		}
		private HashSet<int> updateKey()
		{
			if (manager == null || pirate == null) return new HashSet<int>();
			HashSet<int> res = new HashSet<int>();
			Node node;
			if (pirate.RemainingBombs == 0)
			{
				if (!isSafe(pirate.PiratePosition) && (node = findSafe()) != null)
				{
					res.Add(prefix + (int)node.Direction);
				}
				return res;
			}
			if (playerInRange.Contains(pirate.PiratePosition))
			{
				res.Add(prefix + (int)PirateKeys.keySpace);
			}
			if ((node = findTarget()) != null)
			{
				res.Add(prefix + (int)node.Direction);
			}
			//else if ((node = findBreakable()) != null)
			//{
			//	res.Add(prefix + (int)node.Direction);
			//}
			//else if ((node = findSafe()) != null)
			//{
			//	res.Add(prefix + (int)node.Direction);
			//}
			return res;
		}
        public override void Update(GameTime time)
        {
            base.Update(time);
			if (pirate == null)
				return;
			if (timer == null)
			{
				timer = new CATimer(time.TotalGameTime);
			}
			timer.Update(time.TotalGameTime);
			if (timer.TotalMili > 100)
			{
				timer = new CATimer(time.TotalGameTime);
				updatePlayerRange();
				keys = updateKey();
			}
		}
    }
}

