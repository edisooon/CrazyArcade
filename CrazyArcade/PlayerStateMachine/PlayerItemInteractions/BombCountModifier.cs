using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine.PlayerItemInteractions
{
    public class BombCountModifier : ItemModifier
    {
        public BombCountModifier()
        {
            name = "bombItem";
        }
        public override void ModifyStat()
        {
            ItemContainer.bombModifier += currentCount;
        }
    }
}
