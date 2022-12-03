using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFrameWork.InputSystem;
using CrazyArcade.CAFrameWork.SoundEffectSystem;
using CrazyArcade.GameGridSystems;
using CrazyArcade.PlayerStateMachine;
using Microsoft.Xna.Framework;

namespace CrazyArcade.Pirates
{
	public class PirateCharacter: Character, IPirate
	{
		IPirateInput input;


        public int RemainingBombs => this.BombCapacity - this.BombsOut;

        public int BlastLength => this.CurrentBlastLength;

		Dictionary<int, Action> commands = new Dictionary<int, Action>();
		public PirateCharacter() : base(true)
		{
			this.lives = 1;
			this.input = new PirateController();
			input.Pirate = this;
			Action[] actions = new Action[5];
			//actions[0] = KeyUp;
			//actions[1] = KeyLeft;
			//actions[2] = KeyDown;
			//actions[3] = KeyRight;
			//actions[4] = KeySpace;
			int[] keySet = input.ValidKeys;
			for (int i = 0; i < keySet.Length; i++)
			{
				commands[keySet[i]] = actions[i];
			}
		}

		private bool isMoving()
		{
			return moveInputs.X != 0 || moveInputs.Y != 0;
		}

		private void KeyUp()
		{
			if (isMoving()) return;
			moveInputs.Y -= 1;
			direction = Dir.Up;

		}

		private void KeyDown()
		{
			if (isMoving()) return;
			moveInputs.Y += 1;
			direction = Dir.Down;
		}

		private void KeyLeft()
		{
			if (isMoving()) return;
			moveInputs.X -= 1;
			direction = Dir.Left;
		}

		private void KeyRight()
		{
			if (isMoving()) return;
			moveInputs.X += 1;
			direction = Dir.Right;
		}

		private void KeySpace()
		{
			Console.WriteLine();
			if (playerState.CouldPutBomb && this.putBomb())
				SceneDelegate.ToAddEntity(new CASoundEffect("SoundEffects/PlaceBomb"));
		}

		public Dictionary<int, Action> getCommands()
		{
			return commands;
		}

        public override void Load()
        {
            base.Load();
			SceneDelegate.ToAddEntity(input);
			SceneDelegate.IncreaseEnemyCount();
        }
        public override void Deload()
        {
            base.Deload();
			SceneDelegate.ToRemoveEntity(input);
			SceneDelegate.DecreaseEnemyCount();
        }
    }
}

