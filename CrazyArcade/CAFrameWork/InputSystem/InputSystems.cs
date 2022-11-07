using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.InputSystem
{
	public class InputSystems: IGameSystem
	{
        List<IInput> inputs;
        List<IInputController> controllers;
        HashSet<int> inputKeys;
		public InputSystems()
		{
		}

        public void AddSprite(IEntity sprite)
        {
            if (sprite is IInput)
            {
                inputs.Add(sprite as IInput);
            }
            if (sprite is IInputController)
            {
                controllers.Add(sprite as IInputController);
            }
        }

        public void RemoveAll()
        {
            inputs = new List<IInput>();
            controllers = new List<IInputController>();
        }

        public void RemoveSprite(IEntity sprite)
        {
            if (sprite is IInput)
            {
                inputs.Remove(sprite as IInput);
            }
            if (sprite is IInputController)
            {
                controllers.Remove(sprite as IInputController);
            }
        }

        public void Update(GameTime time)
        {
            inputKeys = new HashSet<int>();
            foreach(IInput input in inputs)
            {
                inputKeys.UnionWith(input.GetInputs());
            }
            foreach(IInputController controller in controllers)
            {
                Dictionary<int, Action> commands = controller.getCommands();
                foreach(int key in inputKeys)
                {
                    commands[key]();
                }
            }
        }
    }
}

