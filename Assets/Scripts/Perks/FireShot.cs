namespace Perks
{
    public class FireShot : Perk
    {
        public override int AmountOfShots()
        {
            return 0;
        }

        public override bool isFire()
        {
           return GetChance(60);
        }
    }
}