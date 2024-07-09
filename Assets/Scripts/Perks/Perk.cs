using UnityEngine;

namespace Perks
{
    public abstract class Perk
    {
        public Perk(PlayerConfig playerConfig)
        {
        }

        public abstract void OnActivate();
        public abstract void OnDeactivate();
    }
}