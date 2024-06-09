
using UnityEngine;

namespace Perks
{
    public class DoubleShot : Perk
    {
        public override int AmountOfShots()
        {
            int chance = Random.Range(0, 101); //todo как вынести рандомайзер куда-то чтобы отовсюду его можно было вызывать а не прописывать каждый раз
            if (chance < 50)
            {
                return 0;
            }
            else return 1;
        }
    }
}