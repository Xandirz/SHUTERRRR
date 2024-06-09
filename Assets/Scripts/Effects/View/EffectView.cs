using Effects;
using UnityEngine;
using UnityEngine.UI;

public class EffectView : MonoBehaviour
{
    [SerializeField] private Image _image;
    
    public void Constructor(Effect effect)
    {
        _image.sprite = effect.GetSprite();
    }
}