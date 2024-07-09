
    using UnityEngine;

    public class RatSummonSpell : Spell
    {
        private GameObject rat;
        private Transform transform;
        
        public RatSummonSpell(PlayerConfig config, Transform transform) : base(2f, config)
        {
            this.transform = transform;
            rat = Resources.Load<GameObject>("Prefabs/Entities/Rat");
        }
        
        public override void OnUse()
        {
            Object.Instantiate(rat, transform.position, Quaternion.identity);
        }
    }
