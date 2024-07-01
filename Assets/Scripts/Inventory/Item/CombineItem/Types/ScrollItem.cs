using Inventory;
using Inventory.Types;
using UnityEngine;

namespace _Project.Scripts.Inventory.Item.CombineItem.Types
{
    public class ScrollItem : global::Inventory.Item, ICombineItem
    {
        private readonly global::Inventory.Item changeTempleteItem;
        
        public ScrollItem(global::Inventory.Item changeTempleteItem, Sprite icon, string title, ItemRarity rarity) : base(icon, title, ItemSlotType.Upgrade, rarity, changeTempleteItem.Stats, ItemPerk.None)
        {
            this.changeTempleteItem = changeTempleteItem;
        }

        public  bool CheckCombineAbility(global::Inventory.Item item)
        {
            return item.SlotType != ItemSlotType.Upgrade;
        }

        public global::Inventory.Item CombineWith(global::Inventory.Item secondItem)
        {
            var t = changeTempleteItem;
            return new UpgradeItem(t.Icon, t.Icon.name, t.Rarity, secondItem.Stats);
        }
    }
}