
using CrazyArcade.CAFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CrazyArcade.Demo1;
using CrazyArcade.Singletons;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using CrazyArcade.BombFeature;
using System.Diagnostics;
using CrazyArcade.CAFrameWork.InputSystem;
using Microsoft.Xna.Framework.Input;
using CrazyArcade.CAFrameWork.SoundEffectSystem;
using CrazyArcade.CAFrameWork.Transition;

namespace CrazyArcade.PlayerStateMachine
{
    public class PlayerCharacter : Character, IInputController, ISavable
    {
        
        Dictionary<int, Action> commands = new Dictionary<int, Action>();
        public PlayerCharacter(int[] keySet) : base(false)
        {
            Action[] actions = new Action[7];
            actions[0] = KeyUp;
            actions[1] = KeyDown;
            actions[2] = KeyLeft;
            actions[3] = KeyRight;
            actions[4] = KeySpace;
            actions[5] = KeyN;
            actions[6] = KeyB;
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
            if (playerState.ProcessAttaction())
                SceneDelegate.ToAddEntity(new CASoundEffect("SoundEffects/PlaceBomb"));
        }

        private void KeyN()
        {
            playerState.ProcessItem("needle");
        }
        
        private void KeyB()
        {
            playerState.ProcessItem("shield");
        }

        public Dictionary<int, Action> getCommands()
        {
            return commands;
        }
    }
}