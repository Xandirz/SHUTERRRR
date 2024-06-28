using UnityEngine;

namespace Perks
{
    public class RatShot :  Perk
    {
        public Rat rat;
        public override int AmountOfShots()
        {
            return 0;
        }

        public override bool isFire()
        {
            return false;
        }

        public bool GetChance(int maxChance)
        {
            int chance = Random.Range(0, maxChance); 
            if (chance < 20)
            {
                return true;
            }
            else return false;
        }
    }
}