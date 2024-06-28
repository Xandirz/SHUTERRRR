using UnityEngine;

namespace Perks
{
    public abstract class Perk
    {
        public abstract int AmountOfShots();
        public abstract bool isFire();

        public bool GetChance(int numberToBeMoreThan)
        {
            int chance = Random.Range(0, 101); 
            if (chance < numberToBeMoreThan)
            {
                return false;
            }
            else return true;
        }
    }
}