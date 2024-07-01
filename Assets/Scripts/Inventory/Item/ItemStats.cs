using System;

namespace Inventory
{
    [Serializable]
    public class ItemStats
    {
        public int Attack { private set; get; }
        public int Defence { private set; get; }
        public int MagicDefence { private set; get; }
        public int Mana { private set; get; }

        public ItemStats(int attack, int defence, int magicDefence, int mana)
        {
            Attack = attack;
            Defence = defence;
            MagicDefence = magicDefence;
            Mana = mana;
        }

        public static ItemStats CreatRandomStats()
        {
            var r = new Random();

            return new ItemStats(r.Next(), r.Next(),r.Next(), r.Next());
        }

        public static ItemStats CreatRandomStats(ItemSlotType type, ItemRarity rarity)
        {
            int attack = 0;
            int defence = 0;
            int magicDefence = 0;
            int mana = 0;
            switch (type)
            {
                case ItemSlotType.Body:
                    defence++;
                    break;
                case ItemSlotType.Head:
                    defence++;
                    break;
                case ItemSlotType.Weapon:
                    attack += 2;
                    break;
                case ItemSlotType.Upgrade:
                    attack++;
                    defence++;
                    break;
                default:
                    break;
            }

            switch (rarity)
            {
                case ItemRarity.Common:
                    break;
                case ItemRarity.Uncommon:
                    defence++;
                    attack++;
                    break;
                case ItemRarity.Rare:
                    defence += 2;
                    attack += 2;
                    mana++;
                    break;
                case ItemRarity.Legendary:
                    defence += 3;
                    attack += 3;
                    mana += 3;
                    magicDefence++;
                    break;
                default:
                    break;
            }

            return new ItemStats(attack, defence, magicDefence,mana);
        }
    }
}