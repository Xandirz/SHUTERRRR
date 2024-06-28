using UnityEngine;

namespace Effects
{
    public class PoisonEffect : Effect
    {
        public PoisonEffect(int duration, int damage) : base(duration, damage)
        {
        }

        public override void OnApplyEffect(Entity entity, int duration)
        {
            throw new System.NotImplementedException();
        }

        public override Sprite GetSprite()
        {
            return Resources.Load<Sprite>("Sprites/green"); 
        }
    }
}