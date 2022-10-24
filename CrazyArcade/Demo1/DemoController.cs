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
        bool spacePrevPressed = false;
        static int mouseTolerance = 25;
        int rightMousePrevPressed = mouseTolerance;
        int leftMousePrevPressed = mouseTolerance;

        public void Update(GameTime time)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Delegate.KeyUp();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))

            {
                Delegate.KeyDown();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Delegate.KeyLeft();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Delegate.KeyRight();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && leftMousePrevPressed == mouseTolerance)
            {
                Delegate.LeftClick();
                leftMousePrevPressed = 0;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                if (rightMousePrevPressed < mouseTolerance)
                {
                    rightMousePrevPressed++;
                }

            }
            if (Mouse.GetState().RightButton == ButtonState.Pressed && rightMousePrevPressed == mouseTolerance)
            {
                Delegate.RightClick();
                rightMousePrevPressed = 0;
            }
            if (Mouse.GetState().RightButton == ButtonState.Released)
            {
                if (leftMousePrevPressed < mouseTolerance)
                {
                    leftMousePrevPressed++;
                }
                    
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !spacePrevPressed)

            {
                Delegate.KeySpace();
                spacePrevPressed = true;
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                spacePrevPressed = false;
            }
            

        }

    }
}
