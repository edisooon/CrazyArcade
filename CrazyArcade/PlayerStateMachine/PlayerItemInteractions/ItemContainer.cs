using CrazyArcade.UI.GUI_Compositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine.PlayerItemInteractions
{
    public class ItemContainer
    {
        /*
         * This is going to be a bit more hard coded and coupled than I would like. If anyone has 
         * a better way of making it less coupled, please let me know.
         */
        public Dictionary<string, ItemModifier> ItemBox = new();
        private static readonly int defaultBlastLength = 1;
        private static readonly int defaultBombMaximum = 1;
        public int bombModifier;
        public int blastModifier;
        public ItemContainer()
        {
            ResetStats();
        }
        public void AddItem(ItemModifier item)
        {
            if (ItemBox.ContainsKey(item.name))
            {
                if (item.currentCount < item.maxCount)
                {
                    item.currentCount++;
                }
            }
            else
            {
                ItemBox.Add(item.name, item);
                item.ItemContainer = this;
            }
            RecalculateStats();
        }
        public void RemoveOneItem(ItemModifier item)
        {
            if (ItemBox.ContainsKey(item.name))
            {
                item.currentCount--;
                if (item.currentCount <= 0)
                {
                    ItemBox.Remove(item.name);
                }
            }
            RecalculateStats();
        }
        public void RemoveEntireItem(ItemModifier item)
        {
            ItemBox.Remove(item.name);
            RecalculateStats();
        }
        private void ResetStats()
        {
            bombModifier = defaultBombMaximum;
            blastModifier = defaultBlastLength;
        }
        private void RecalculateStats()
        {
            ResetStats();
            foreach (var mod in ItemBox)
            {
                mod.Value.ModifyStat();
            }
        }
    }
}
