using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine.PlayerItemInteractions
{
    public abstract class ItemModifier
    {
        public string Name;
        public SpriteAnimation ItemRep = new(TextureSingleton.GetNull(), 1, 0, 0, 0);
        public int MaxCount = 100;
        public int CurrentCount = 1;
        public ItemContainer ItemContainer;
        public virtual void ModifyStat()
        {
            //this will be overritten by future implementers
        }
    }
}
