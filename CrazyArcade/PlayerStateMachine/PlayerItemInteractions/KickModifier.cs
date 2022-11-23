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
    public class KickModifier : ItemModifier
    {
        public KickModifier()
        {
            Name = "kickItem";
            ItemRep = new SpriteAnimation(TextureSingleton.GetKick(), new Rectangle(0, 0, 42, 46));
            MaxCount = 1;
        }
        public override void ModifyStat()
        {
            ItemContainer.CanKick = true;
        }
    }
}
