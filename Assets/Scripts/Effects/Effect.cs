using UnityEngine;

namespace Effects
{
    public abstract class Effect
    {
        public float Duration;
        public int Damage { private set; get; }
        public bool IsPassed { private set; get; }
        
        public void AddDuration(float value)
        {
            Duration += value;
        }
        
        public Effect(int duration, int damage)
        {
            Duration = duration;
            Damage = damage;
        }
        
        public abstract void OnApplyEffect(Entity entity, int duration);  
        public abstract Sprite GetSprite();
    }
}