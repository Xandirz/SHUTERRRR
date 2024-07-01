
    using UnityEngine;

    public class RatSummonSpell : Spell
    {
        private GameObject rat;
        private Transform position;
        public RatSummonSpell(Transform playerPosition)
        {
            rat = Resources.Load<GameObject>("Prefabs/Entities/Rat");
            position = playerPosition;
        }
        public override void Use()
        {
            Object.Instantiate(rat, position.position, Quaternion.identity);
        }
    }
