
    using UnityEngine;

    public class PushSpell : Spell
    {
        private Transform transform;
        private CircleCollider2D area;
        private int damage;
        
        public PushSpell(int spellDamage, Transform playerPosition, CircleCollider2D playerArea, PlayerConfig config) : base(2, config)
        {
            this.transform = playerPosition;
            area = playerArea;
            damage = spellDamage;
        }

        public override void OnUse()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, area.radius);

            foreach (var hitCollider in hitColliders)
            {
                Enemy enemy = hitCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Vector2 dir = transform.position - enemy.gameObject.transform.position;
                    enemy.GetComponent<Rigidbody2D>().AddForce(-dir * 3f,  ForceMode2D.Impulse); //todo можно толкать  иначе?
                }
            }
        }
    }
