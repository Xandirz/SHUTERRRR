using Inventory;
using Inventory.Types;
using UnityEngine;

namespace _Project.Scripts.Inventory.Item.CombineItem.Types
{
    public class UpgradeItem : global::Inventory.Item,ICombineItem
    {
        public UpgradeItem(Sprite icon, string title, ItemRarity rarity, ItemStats stats) : base(icon, title, ItemSlotType.Upgrade, rarity, stats, ItemPerk.None)
        {
        }
        
        public  global::Inventory.Item CombineWith(global::Inventory.Item item)
        {
            var itemStats = item.Stats;
            var myStats = Stats;


            var stats = new ItemStats(
                itemStats.Attack + myStats.Attack, 
                itemStats.Defence + myStats.Defence,
                itemStats.MagicDefence + myStats.MagicDefence,
                itemStats.Mana + myStats.Mana);

            item.Stats = stats;
            return item; 
        }

        public  bool CheckCombineAbility(global::Inventory.Item item)
        {
            return item.SlotType != ItemSlotType.Upgrade;
        }
    }
}