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
            itemRep = new CAFramework.SpriteAnimation //Start here
        }
        public override void ModifyStat()
        {5
            ItemContainer.bombModifier += currentCount;
        }
    }
}
