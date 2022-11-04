using CrazyArcade.CAFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.CAFrameWork.GameStates
{
    public interface IGameState
    {
        public CAScene Scene { get; }
        public CAScene Restore { get; set; }
        public void SwitchToGameOver();
    }
}
