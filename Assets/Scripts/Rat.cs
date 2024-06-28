
    using Effects;
    using UnityEngine;

    public class Rat : Entity
    {
        public int maxHp = 5;
        public int hp = 5;
        [Space] //передвижение
        public float moveSpeed = 1;
        private int moveSpeedMod = 1;
        private Animator _animator;
        [Space]
        public EntityView view;
        [Space] //атака
        public Transform target;
        public int damage = 1;
        public float attackRange = 0.1f;
        public float attackInterval = 1.0f;
        private float lastAttackTime;
        [Space] private EnemyManager _enemyManager;
       
        void Start()
        {
            _enemyManager = FindObjectOfType<EnemyManager>();
        }
        
        void Update() 
        {
            if (target == null   && _enemyManager.enemies.Count>0) //todo это нужно чтобы если врага убилито крыса побежала к другому врагу но надо проверить если враги вообще поэтому нужен менеджер врагов? чтобы проверять есть они или нет
            {
                NewTarget(null);
            }

            if (target != null)
            {
                Vector3 direction = (target.position - transform.position).normalized;

                float distance = Vector3.Distance(target.position, transform.position);

                if (distance > attackRange)
                {
                    var moveDirection = direction * (moveSpeed * Time.deltaTime);
                    Move(moveDirection);
                    //TOdo сделать pathfinder
                }
                else
                {
                    transform.position = transform.position; //остановка
                    Attack();
                } 
            }
          
        }
        
        public void NewTarget(Transform newTarget)
        {
            target = newTarget;
            if (newTarget == null  && _enemyManager.enemies.Count>0)
            {
                target = GameObject.FindGameObjectWithTag("Enemy").transform;
            }
        }
        
        private void Attack()
        {
            var myTarget = target.GetComponent<Enemy>(); //todo делать так?
                myTarget.TakeDamage(damage);
                damage = 0;
                myTarget.AddEffect(new PoisonEffect(2,1)); 
                Destroy(gameObject);
        }
    }
