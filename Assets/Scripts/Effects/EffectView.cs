using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class EffectView : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private EffectItem effectItemPrefab;
        
        private List<GameObject> allSlides = new();
        
        public void Constructor(List<Effect> effects)
        {
            foreach (var slide in allSlides)
                Destroy(slide);

            allSlides.Clear();

            foreach (var effect in effects)
            {
                if (!effect.IsPassed)
                {
                    var item = Instantiate(effectItemPrefab, parent);
                    item.Constructor(effect, effect.Duration);
                
                    allSlides.Add(item.gameObject);
                }
            }
        }
    }
}