using UnityEngine;

namespace Effects
{
    public abstract class Effect
    {
        public int Duration;
        public int Damage { private set; get; }
        public bool IsPassed { private set; get; }
        
        public void AddDuration(int value)
        {
            Duration += value;
        }
        
        public Effect(int duration, int damage)
        {
            Duration = duration;
            Damage = damage;
        }
        public abstract void OnApplyEffect(Entity entity, int duration);  //todo больше одного эфекта почему  то не вмещается
        public abstract Sprite GetSprite();
    }
}