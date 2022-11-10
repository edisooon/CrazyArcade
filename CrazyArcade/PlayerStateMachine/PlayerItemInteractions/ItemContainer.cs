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
        private List<ItemModifier> GuiList = new();
        private static readonly int defaultBlastLength = 1;
        private static readonly int defaultBombMaximum = 1;
        private static readonly int defaultSpeed = 5;
        public int bombModifier;
        public int blastModifier;
        public int speedModifier;
        private int itemCount = 0;
        private Vector2 anchorPoint = new(50, 50);
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
                    UpdateGuiItemCount(item);
                }
            }
            else
            {
                ItemBox.Add(item.name, item);
                GuiList.Add(item);
                itemCount++;
                item.ItemContainer = this;
                GenerateGuiElement(item, itemCount);
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
                    GuiList.Remove(ItemBox[item.name]);
                    ItemBox.Remove(item.name);
                    UI_Singleton.RemoveComposition(item.name);
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
            ItemBox.Remove(item.name);
            RecalculateStats();
        }
        private void ResetStats()
        {
            bombModifier = defaultBombMaximum;
            blastModifier = defaultBlastLength;
            speedModifier = defaultSpeed;
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
            UI_Singleton.AddPreDesignedComposite(new ItemCountComposition(item.name, item.itemRep));
            UpdateGuiItemCount(item);
            UI_Singleton.MoveCompositePosition(item.name, anchorPoint + new Vector2((count % 2) * 50, ((count-1) / 2) * 50));
        }
        private static void UpdateGuiItemCount(ItemModifier item)
        {
            UI_Singleton.ChangeComponentText(item.name, "itemCount", "X" + item.currentCount.ToString());
        }
    }
}
