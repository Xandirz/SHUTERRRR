using System.Collections.Generic;
using Effects;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Entity : MonoBehaviour
    {
        public int maxHp = 1;
        public int hp = 1;
        public List<Effect> currentEffects = new List<Effect>();

        public void Move(Vector2 direction)
        {
          transform.Translate(direction,Space.World);
        }

        public void TakeDamage()
        {
            
        }

        public void ApplyEffect(Effect effect)
        {
            currentEffects.Add(effect);
        }
    }
}