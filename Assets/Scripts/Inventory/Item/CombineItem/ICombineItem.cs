using UnityEngine;

namespace Inventory.Types
{
    public interface  ICombineItem
    {
        public  bool CheckCombineAbility(Item item);
        public  Item CombineWith(Item secondItem);
    }
}