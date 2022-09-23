using CrazyArcade.CAFramework.Controller;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace CrazyArcade.BombFeature
{
    internal class BombTestController : IController
    {
        public IControllerDelegate Delegate { get; set; }
        bool m1PrevState = false;
        public void Update(GameTime time)
        {
            var mState = Mouse.GetState();
            if (mState.LeftButton == ButtonState.Pressed && !m1PrevState)
            {
                Delegate.LeftClick(mState.X, mState.Y);
                m1PrevState = true;
            }
            if (mState.LeftButton == ButtonState.Released && m1PrevState)
            {
                m1PrevState = false;
            }
        }
    }
}
