using UnityEngine;

namespace Perks
{
    public class RatShot :  Perk
    {
        public Rat rat;

        public RatShot(PlayerConfig playerConfig) : base(playerConfig)
        {
        }

        public override void OnActivate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnDeactivate()
        {
            throw new System.NotImplementedException();
        }
    }
}