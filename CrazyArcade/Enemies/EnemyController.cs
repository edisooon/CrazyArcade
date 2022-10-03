using CrazyArcade.CAFramework.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Enemy
{
    public class EnemyController : IController
    {
        public IControllerDelegate Delegate { get; set; }

        public void Update(GameTime time)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                Delegate.Key_p();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                Delegate.Key_o();
            }
         
        }
    }
}