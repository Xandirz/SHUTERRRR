using UnityEngine;

namespace Inventory
{
    public class EquipableSlot : InventorySlot
    {
        [field: SerializeField] public ItemSlotType SlotType { private set; get; }
    }
}