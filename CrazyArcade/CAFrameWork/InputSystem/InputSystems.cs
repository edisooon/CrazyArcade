using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;

namespace CrazyArcade.CAFrameWork.InputSystem
{
	public class InputSystems: IGameSystem
	{
        List<IInput> inputs = new List<IInput>();
        List<IInputController> controllers = new List<IInputController>();
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
                Dictionary<int, Action> commands = controller.GetCommands();
                Dictionary<CodeRange, Action<int>> rangeCommands = controller.GetRangeCommands();
				foreach (int key in inputKeys)
                {
                    if (commands.ContainsKey(key) && commands[key] != null)
                    {
                        commands[key]();
                    }
                    foreach(CodeRange range in rangeCommands.Keys)
                    {
                        if (range.Contains(key))
                        {
                            rangeCommands[range](key);
						}
                    }
                }
            }
        }
    }
}

