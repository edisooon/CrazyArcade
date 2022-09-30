using CrazyArcade.CAFramework.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Demo1
{
    public class DemoController : IController
    {
        public IControllerDelegate Delegate { get; set; }

        public void Update(GameTime time)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Delegate.KeyUp();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Delegate.KeyDown();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Delegate.KeyLeft();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Delegate.KeyRight();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Delegate.KeySpace();
            }
        }
    }
}