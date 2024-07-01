using Inventory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public enum SlotType
        {
            Item,
            Garbage,
            Backpack,
            Chest
        }

        [field: SerializeField] public SlotType Type { private set; get; }

        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private Image icon;
        [SerializeField] private Image background;
        
        
        [SerializeField] private Color32 defaultColor = Color.white;
        [SerializeField] private Color32 commonColor = Color.white;
        [SerializeField] private Color32 uncommonColor = Color.white;
        [SerializeField] private Color32 rareColor = Color.white;
        [SerializeField] private Color32 legendary = Color.white;
        
        private Color32[] backgroundColors;

        [Space] 
        [SerializeField] private GameObject itemInfoWindow;
        [SerializeField] private TextMeshProUGUI itemInfoText;
        
        private void Awake()
        {
            backgroundColors = new[]
            {
                commonColor,
                uncommonColor,
                rareColor,
                legendary,
            };
        }

        public Item Item { private set; get; }

        private Inventory inventory;
        private bool isDrag;

        private void SetColor(Color32 color)
        {
            title.color = color;
            background.color = color;
        }

        private void SetAlpha(float alpha)
        {
            var titleColor = title.color;
            
            titleColor.a = alpha;
            title.color = titleColor;

            var iconColor = icon.color;
            iconColor.a = alpha;
            
            icon.color = iconColor;
        }

        public void Construct(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public void Setup(Item item)
        {
            Item = item;

            title.text = item.Title; //todo иногда итемы пропадают при перетаскивании если что то задеть и ошибки присылают в эту точку - возможно это случается когда переносишь итем в тот же слот откуда переносил
            icon.sprite = item.Icon;

            var color = backgroundColors[(int)item.Rarity];
            
            SetColor(color);
            SetAlpha(1);
        }

        public bool IsEmpty()
        {
            return Item == null;
        }

        public void Clear()
        {
            Item = null;
            
            SetColor(defaultColor);
            SetAlpha(0);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (IsEmpty())
                return;

            if (!isDrag)
            {
                if (inventory.TryDragItemFromSlot(Item))
                {
                    Debug.Log("Drag started");
                    isDrag = true;
                }
            }
        }
        
        
        public void OnPointerUp(PointerEventData eventData)
        {
            if (isDrag)
            {
                inventory.UnDrag();
                isDrag = false;

                foreach (var uiObject in UIHelper.GetAllPointerUI())
                {
                    if (uiObject.TryGetComponent(out InventorySlot slot))
                    {
                        inventory.TrySwapSlot(this, slot);
                        break;
                    }
                }
            }
        }
    }
}