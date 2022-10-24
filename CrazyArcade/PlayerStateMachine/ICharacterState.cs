using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;
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
        public int SetSpeed();
        public void ProcessItem();
        public void ProcessRide();
        public void ProcessAttaction();
    }
}