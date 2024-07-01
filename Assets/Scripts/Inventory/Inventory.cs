using System;
using System.Collections.Generic;

using Inventory.Types;
using Inventory.Utils;
using TMPro;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI attackTitle;
        [SerializeField] private TextMeshProUGUI defenceTitle;
        [Space]
        [SerializeField] private ItemGenerator itemGenerator;
        [SerializeField] private ItemCursor cursor;
        [SerializeField] private ItemInfoStats stats;
        [Space] 
        [SerializeField] private int numberOfBackpackSlots = 4;
        [Space]
        [SerializeField] private InventorySlot slotPrefab;
        [SerializeField] private RectTransform backpackItems;
        [Space]
        [SerializeField] private InventorySlot head;
        [SerializeField] private InventorySlot body;

        public List<InventorySlot> slots = new();
        public List<InventorySlot> backPackSlot = new();
        public List<Item> equippedItems = new();
        public event Action onEquippedItemsChange;
        private Item dragItem;

        private void Awake()
        {
            for (int i = 0; i < numberOfBackpackSlots; i++)
            {
                var slot = Instantiate(slotPrefab, backpackItems);
                slot.Clear();
                slot.Construct(this);
                backPackSlot.Add(slot);
            }

    

          
            
            head.Construct(this);
            body.Construct(this);
            
            slots.Add(head);
            slots.Add(body);
        }

        public bool TryDragItemFromSlot(Item item)
        {
            if (dragItem != null) return false;

            dragItem = item;
            cursor.Drag(item);

            return true;
        }

        public void UnDrag()
        {
            dragItem = null;
            cursor.Clear();
        }

        private Vector3[] localCorners = new Vector3[4];
        
        private void Update()
        {
            var mousePoisition = Input.mousePosition;
            cursor.transform.position = mousePoisition;
            
            stats.SetActive(false);
            
            foreach (var uiObject in UIHelper.GetAllPointerUI())
            {
                if (uiObject.TryGetComponent(out InventorySlot slot))
                {
                    var rectTransform = (RectTransform)stats.transform;
                    var slotRectTransform = (RectTransform)slot.transform;
                    
                    slotRectTransform.GetWorldCorners(localCorners);
                    rectTransform.position = localCorners[3];
                    
                    if (slot.Item != null)
                    {
                        stats.SetActive(true);
                        stats.Construct(slot.Item);
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.G))
                GenerateAndAddItem();
        }

        public void GenerateAndAddItem()
        {
            var item = itemGenerator.GenerateItem();
            TryAddItem(item);
        }
        
        public void TrySwapSlot(InventorySlot slot1, InventorySlot slot2)
        {
            SlotChangeStateRefresh(slot1, slot2);   
            RefreshInventoryStats();
        }

        private void SlotChangeStateRefresh(InventorySlot slot1, InventorySlot slot2)
        {
            if (slot1 == slot2) return;
            if (slot1.IsEmpty()) return;
            
            //Удаление
            if (slot2.Type == InventorySlot.SlotType.Garbage)
            {
                slot1.Clear();
                return;
            }
            
            if (slot2.IsEmpty())
            {
                if (slot2 is EquipableSlot slot2Equipable)
                {
                    var item = slot1.Item;

                    if (item.SlotType == slot2Equipable.SlotType)
                    {
                        slot2Equipable.Setup(slot1.Item);
                        slot1.Clear();
                    }
                }
                else
                {
                    var item = slot1.Item;

                    slot1.Clear();
                    slot2.Setup(item);
                }

                return;
            }

            if (!slot2.IsEmpty())
            {
                var buffer = slot1.Item;
                var buffer2 = slot2.Item;

                if (slot2 is EquipableSlot && slot1.Item.SlotType == slot2.Item.SlotType || slot1 is EquipableSlot && slot1.Item.SlotType == slot2.Item.SlotType)
                { 
                    slot1.Setup(buffer2);
                    slot2.Setup(buffer);
        
                    return;
                }
                
                if (slot1.Item is ICombineItem combineItem && !slot2.IsEmpty())
                {
                    var secondItem = slot2.Item;

                    if (combineItem.CheckCombineAbility(secondItem)) 
                    {
                        var newItem = combineItem.CombineWith(slot2.Item);

                        slot1.Clear();
                        slot2.Setup(newItem); 
                    }

                    return;
                }


              
                
                //обычная замена местами
                slot1.Setup(buffer2);
                slot2.Setup(buffer);
            }
        }

        public void RefreshInventoryStats()
        {
            string perk = "";
            string weaponType = "";
            int attack = 0;
            int armor = 0;
            int magicArmor = 0;
            
            equippedItems.Clear();

            foreach (var equipSlot in slots) 
            {
                if (equipSlot is EquipableSlot)
                {
                    if (!equipSlot.IsEmpty())
                    {
                        var item = equipSlot.Item;
                        equippedItems.Add(item);
                    }
                }
            }

         

            if (onEquippedItemsChange != null)
            {
                onEquippedItemsChange.Invoke();
            }
        }

        public List<Item> EquippedItemsList()
        {
            return equippedItems;
        }

        public bool TryAddItem(Item item)
        {
            foreach (var slot in backPackSlot)
            {
                if (slot.IsEmpty() && !(slot is EquipableSlot)) 
                {
                    slot.Setup(item);
                    return true;
                }
            }

            return false;
        }
    }
}