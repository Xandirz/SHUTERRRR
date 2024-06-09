using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Effects
{
    public class EffectItem : MonoBehaviour
        {
            [SerializeField] private Image image;
            [SerializeField] private TextMeshProUGUI turnAmountText;
        
            public void Constructor(Effect effect, int turnAmount)
            {
                image.sprite = effect.GetSprite();
                turnAmountText.text = turnAmount.ToString();
            }
            
        }
}