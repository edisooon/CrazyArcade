using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.InputSystem;
using CrazyArcade.GameGridSystems;
using CrazyArcade.PlayerStateMachine;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Pirates
{
	public class PirateCharacter: CAEntity, IPirate
	{
		PlayerCharacter character;
		IPirateInput input;

		public PirateCharacter(IPirateInput input)
        {
			this.input = input;
			input.Pirate = this;
			character = new PlayerCharacter(input.ValidKeys);
        }

        public int RemainingBombs => throw new NotImplementedException();

        public int BlastLength => throw new NotImplementedException();

		//----------IGridable Start------------
		private Vector2 gamePos;
		private Vector2 pos;
		protected Rectangle enemyBoundingBox = new Rectangle(0, 0, 36, 36);
		public  Vector2 ScreenCoord
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
		public  Vector2 GameCoord
		{
			get => gamePos;
			set
			{
				gamePos = value;
				ScreenCoord = trans.Trans(value);
			}
		}
		private IGridTransform trans = new NullTransform();
		public  IGridTransform Trans { get => trans; set => trans = value; }
		//----------IGridable End------------
		public override void Load()
        {
			this.SceneDelegate.ToAddEntity(character);
			this.SceneDelegate.ToAddEntity(input);
        }
    }
}

