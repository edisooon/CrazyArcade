using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.Pirates;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.InputSystem
{
	public class PirateController: CAEntity, IInput, IGridBoxReciever
	{
        private int prefix;
        private const int baseIndex = 1000;
        private static int count = 0;

        private IGridBoxManager manager;
        public IGridBoxManager Manager { get => manager; set => manager = value; }

        private IPirate pirate;

        public PirateController(IPirate pirate)
		{
            count += 50;
            prefix = baseIndex + count;
            this.pirate = pirate;
		}

        public HashSet<int> GetInputs()
        {
            HashSet<int> res = new HashSet<int>();
            if (manager == null)
            {
                return res;
            }
            return res;
        }
        class Node
        {
            private Point pos;
			private Dir dir;
            public Node(Dir dir, Point point)
            {
                this.dir = dir;
                this.pos = point;
            }
        }
        bool isTargetBlock(Point point)
        {
            return false;
        }
		bool isBreakable(Point point)
		{
			return false;
		}
		bool isSafe(Point point)
        {
            return true;
        }
		private Node findSafe()
		{
			Node res = null;
			Queue<Node> q = new Queue<Node>();
			q.Enqueue(new Node(Dir.Up, pirate.PiratePosition));

			return res;
		}
		private Node findBreakable ()
		{
			Node res = null;
			Queue<Node> q = new Queue<Node>();
			q.Enqueue(new Node(Dir.Up, pirate.PiratePosition));

			return res;
		}

		private Node findTarget()
        {
            Node res = null;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(new Node(Dir.Up, pirate.PiratePosition));

            return res;
        }

		private void setDir(HashSet<int> res, Dir dir)
        {
            res.Add(prefix + (int)dir);
        }

        
        public override void Load()
        {

        }
    }
}

