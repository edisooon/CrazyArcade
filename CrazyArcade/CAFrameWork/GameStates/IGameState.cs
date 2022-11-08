using CrazyArcade.CAFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyArcade.Demo1;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public interface IGameState
    {
        public CAScene DefaultScene { get; }
        public void SwitchToGameOver();
    }
}
