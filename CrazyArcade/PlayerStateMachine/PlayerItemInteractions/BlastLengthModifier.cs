using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine.PlayerItemInteractions
{
    public class BlastLengthModifier : ItemModifier
    {
        public BlastLengthModifier()
        {
            name = "blastItem";
        }
        public override void ModifyStat()
        {
            ItemContainer.blastModifier += currentCount;
        }
    }
}
