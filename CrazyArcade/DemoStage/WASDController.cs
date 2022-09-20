using System;
using System.Collections.Generic;
using CrazyArcade.CAFrameWork.Controller;
using CrazyArcade.CAFrameWork.Singleton;
using Microsoft.Xna.Framework.Input;

namespace CrazyArcade.DemoStage
{
	public class WASDController: Controller
    {
        public override void Update()
        {
            if (Input.Keyboard.IsKeyDown(Keys.W))
            {
                Delegate.KeyUp();
            }
            if (Input.Keyboard.IsKeyDown(Keys.A))
            {
                Delegate.KeyLeft();
            }
            if (Input.Keyboard.IsKeyDown(Keys.S))
            {
                Delegate.KeyDown();
            }
            if (Input.Keyboard.IsKeyDown(Keys.D))
            {
                Delegate.KeyRight();
            }
            if (Input.Keyboard.IsKeyDown(Keys.Space))
            {
                Delegate.KeySpace();
            }
        }
    }
}

