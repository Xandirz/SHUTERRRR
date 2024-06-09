using UnityEngine;

namespace Effects
{
    public class FireEffect : Effect
    {
        public FireEffect(int turnDuration) : base(turnDuration)
        {
        }

        public override void OnApplyEffect(Enemy enemy, int turnDuration)
        {
            int fireDamage = turnDuration;
        }

        public override Sprite GetSprite()
        {
            return Resources.Load<Sprite>("Sprites/whiteSquare");
        }
    }
}