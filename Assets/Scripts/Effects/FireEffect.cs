using UnityEngine;

namespace Effects
{
    public class FireEffect : Effect
    {
        
        public FireEffect(int duration, int damage) : base(duration, damage)
        {
            damage = 1;
        }

        public override void OnApplyEffect(Entity entity, int duration)
        {
        }

        public override Sprite GetSprite()
        {
            return Resources.Load<Sprite>("Sprites/Fire+Sparks1"); 
        }
    }
}