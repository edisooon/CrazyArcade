using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
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
            itemRep = new SpriteAnimation(TextureSingleton.GetBomb(), new Rectangle(0, 0, 64, 64));
        }
        public override void ModifyStat()
        {
            ItemContainer.BombModifier += currentCount;
        }
    }
}
