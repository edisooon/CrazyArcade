using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.CAFrameWork.InputSystem
{
	public class KeyBoardInput: CAEntity, IInput
	{

        //KeyNum * 2 means Key is down
        //KeyNum * 2 + 1 means key have just gone up
		public KeyBoardInput()
		{
		}
        HashSet<int> inputs = new HashSet<int>();
        public HashSet<int> GetInputs()
        {
            return inputs;
        }
        public override void Update(GameTime time)
        {
            KeyboardState state = Keyboard.GetState();
            HashSet<int> res = new HashSet<int>();
            Keys[] pressed = state.GetPressedKeys();
            foreach (Keys key in pressed)
            {
                res.Add(KeyDown(key));
            }
            inputs.ExceptWith(res);
            foreach (int key in inputs)
            {
                if (key % 2 == 0)
                {
                    res.Add(key + 1);
                }
            }
            inputs = res;
        }

        public override void Load()
        {

        }
        //returns a hashcode of keydown state of the key
        public static int KeyDown(Keys key)
        {
            return (int)key * 2;
        }
        //returns a hashcode of keyup state of the key
        public static int KeyUp(Keys key)
        {
            return (int)key * 2 + 1;
        }
    }
}

