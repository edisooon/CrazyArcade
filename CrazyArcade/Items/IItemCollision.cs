using CrazyArcade.PlayerStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.Items
{
    public interface IItemCollision
    {
    }
    public class PowerupCollision
    {
        private PlayerCharacter player;

        public PowerupCollision(PlayerCharacter player)
        {
            this.player = player;
        }
        public void CollisionCheck()
        {

        }
    }
}
