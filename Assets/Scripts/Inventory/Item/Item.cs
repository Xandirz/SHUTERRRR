using System;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class Item
    {
        [field: SerializeField] public Sprite Icon {  set; get; }
        [field: SerializeField] public string Title {  set; get; }
        [field: SerializeField] public ItemSlotType SlotType { set; get; }
        [field: SerializeField] public ItemRarity Rarity {  set; get; }
        [field: SerializeField] public ItemStats Stats {  set; get; }
        [field: SerializeField] public ItemPerk Perks {  set; get; }
        
        public Item(Sprite icon, string title, ItemSlotType slotType, ItemRarity rarity, ItemStats stats, ItemPerk perks)
        {
            Icon = icon;
            Title = title;
            SlotType = slotType;
            Rarity = rarity;
            Stats = stats;
            Perks = perks;
        }

        public Item Change(Sprite icon)
        {
            return new Item(icon, Title, SlotType, Rarity, Stats, Perks);
        }

        public Item Change(ItemStats stats)
        {
            return new Item(Icon, Title, SlotType, Rarity, stats, Perks);
        }
        
        public Item Change(ItemRarity rarity)
        {
            return new Item(Icon, Title, SlotType, rarity, Stats, Perks);
        }
        
      
    }
}