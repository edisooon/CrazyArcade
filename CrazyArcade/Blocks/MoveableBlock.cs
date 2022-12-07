using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.GridBoxSystem;
using CrazyArcade.Items;
using CrazyArcade.PlayerStateMachine;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Blocks
{
	public class MoveableBlock: BreakableBlock, IGridPlayerCollidable
	{
		private readonly int duration = 500;
		private class MoveOp
		{
			public MoveOp(Vector2 to, Dir dir)
			{
				this.To = to;
				this.Dir = dir;
			}
			public Vector2 To;
			public Dir Dir;
		}
		public MoveableBlock(Vector2 position, Rectangle source) : base(position, source) { }

		readonly Vector2[] displacement = new Vector2[]
		{
			new Vector2(0, -1),
			new Vector2(-1, 0),
			new Vector2(0, 1),
			new Vector2(1, 0)
		};
		private MoveOp moveOp = null;
		ITimer timer;
		public void Collide(IPlayer player)
		{
			GridBoxPosition pos = new GridBoxPosition(
				this.Position.X + (int)displacement[(int)player.Direction].X,
				this.Position.Y + (int)displacement[(int)player.Direction].Y,
				this.Position.Depth);
			if (this.manager.MoveBoxTo(this, pos))
			{
				moveOp = new MoveOp(new Vector2(pos.X, pos.Y), player.Direction);
			}
		}

		public override void Update(GameTime time)
		{
			base.Update(time);
			if (moveOp != null)
			{
				if (timer == null)
				{
					timer = new CATimer(time.TotalGameTime);
				}
				timer.Update(time.TotalGameTime);
				GameCoord = displacement[(int)moveOp.Dir] * timer.FrameDiff.Milliseconds / duration;
				if (timer.TotalMili >= duration)
				{
					this.GameCoord = moveOp.To;
					moveOp = null;
				}
			}
		}
	}
}

