using UnityEngine;

namespace Effects
{
    public abstract class Effect
    {
        public int Duration { private set; get; }
        public bool IsPassed { private set; get; }
        
        public void AddDuration(int value)
        {
            Duration += value;
        }
        
        public Effect(int duration)
        {
            Duration = duration;
        }

        public void ApplyEffect(Enemy enemy)
        {
            if (IsPassed)
                return;
            
            OnApplyEffect(enemy, Duration);
            
            Duration -= 1;
            
            if (Duration == 0)
            {
                IsPassed = true;
                return;
            }
        }
        
        public abstract void OnApplyEffect(Enemy enemy, int duration);
        public abstract Sprite GetSprite();
    }
}