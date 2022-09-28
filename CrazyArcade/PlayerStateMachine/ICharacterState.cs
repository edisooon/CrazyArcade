using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine
{
    public interface ICharacterState
    {
        public void ProcessState(GameTime time);
        public SpriteAnimation[] SetSprites();
        public int setSpeed();
        public void processItem();
        public void processRide();
        public void processAttaction();
    }
}
