using CrazyArcade.UI;
using CrazyArcade.UI.GUI_Compositions;
using Microsoft.Xna.Framework;
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
        private List<ItemModifier> guiList = new();
        private static readonly int defaultBlastLength = 1;
        private static readonly int defaultBombMaximum = 1;
        private static readonly int defaultSpeed = 5;
        public int BombModifier;
        public int BlastModifier;
        public int SpeedModifier;
        public bool CanKick;
        private int itemCount = 0;
        private Vector2 anchorPoint = new(50, 50);
        public ItemContainer()
        {
            ResetStats();
        }
        public void AddItem(ItemModifier item)
        {
            if (ItemBox.ContainsKey(item.Name))
            {
                if (item.CurrentCount < item.MaxCount)
                {
                    item.CurrentCount++;
                    UpdateGuiItemCount(item);
                }
            }
            else
            {
                ItemBox.Add(item.Name, item);
                guiList.Add(item);
                itemCount++;
                item.ItemContainer = this;
                GenerateGuiElement(item, itemCount);
            }
            RecalculateStats();
        }
        public void RemoveOneItem(ItemModifier item)
        {
            if (ItemBox.ContainsKey(item.Name))
            {
                item.CurrentCount--;
                if (item.CurrentCount <= 0)
                {
                    guiList.Remove(ItemBox[item.Name]);
                    ItemBox.Remove(item.Name);
                    UI_Singleton.RemoveComposition(item.Name);
                    itemCount--;
                } 
                else
                {
                    UpdateGuiItemCount(item);
                }
            }
            RecalculateStats();
        }
        public void RemoveEntireItem(ItemModifier item)
        {
            ItemBox.Remove(item.Name);
            RecalculateStats();
        }
        private void ResetStats()
        {
            BombModifier = defaultBombMaximum;
            BlastModifier = defaultBlastLength;
            SpeedModifier = defaultSpeed;
            CanKick = false;
        }
        private void RecalculateStats()
        {
            ResetStats();
            foreach (var mod in ItemBox)
            {
                mod.Value.ModifyStat();
            }
        }
        private void GenerateGuiElement(ItemModifier item, int count)
        {
            UI_Singleton.AddPreDesignedComposite(new ItemCountComposition(item.Name, item.ItemRep));
            UpdateGuiItemCount(item);
            UI_Singleton.MoveCompositePosition(item.Name, anchorPoint + new Vector2((count % 2) * 50, ((count-1) / 2) * 50));
        }
        private static void UpdateGuiItemCount(ItemModifier item)
        {
            UI_Singleton.ChangeComponentText(item.Name, "itemCount", "X" + item.CurrentCount.ToString());
        }
    }
}
