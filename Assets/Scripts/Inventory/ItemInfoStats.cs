using TMPro;
using UnityEngine;

namespace Inventory
{
    public class ItemInfoStats : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void Construct(Item item)
        {
            if (item == null)
            {
                SetActive(false);
                return;
            }
            
            string stats =  "Тип: " + item.SlotType + "\n";
                
            if (item.Stats != null)
            {
                stats += "Редкость: " + item.Rarity + "\n";
                      
                if (item.Stats.Attack > 0)
                {
                    stats += "Урон: " + item.Stats.Attack + "\n";
                }
                if (item.Stats.Defence > 0)
                {
                    stats += "Броня: " + item.Stats.Defence + "\n";
                }
                if (item.Stats.MagicDefence > 0)
                {
                    stats += "Защита от магии: " + item.Stats.MagicDefence + "\n";
                }
                if (item.Stats.Mana > 0)
                {
                    stats += "Мана: " + item.Stats.Mana + "\n";
                }
                if (item.Perks > 0)
                {
                    stats +=  "Перк: " + item.Perks + "\n";
                }
            }

        
            text.text = stats;
        }
    }
}