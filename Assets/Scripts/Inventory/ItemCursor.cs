using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class ItemCursor : MonoBehaviour
    {
        [SerializeField] private Image icon;
       
        private void SetAlpha(float alpha)
        {
            var color = icon.color;
            color.a = alpha;

            icon.color = color;
        }

        public void Clear()
        {
            SetAlpha(0);
        }

        public void Drag(Item item)
        {
            icon.sprite = item.Icon;
            SetAlpha(0.5f);
        }
    }
}