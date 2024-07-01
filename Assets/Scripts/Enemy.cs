using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Effects;
using TMPro;
using UnityEngine;

public class Enemy : Entity
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
    public float attackRange = 1.0f;
    public float attackInterval = 1.0f;
    private float lastAttackTime;
    [Space] private EnemyManager _enemyManager;
    public SpriteRenderer enemyHitArea;
    private bool canAttack = false;
    private float attackDelay = 1;
    private float effectDurationTimer;
    private float timer;

    void Start()
    {
        hp = maxHp;
        view.ChangeHpText(hp,maxHp);
        _enemyManager = FindObjectOfType<EnemyManager>();
        _enemyManager.enemies.Add(this);

    }

    // Update is called once per frame
    void Update() //todo почистить тут все
    {
        if (target == null)
        {
            NewTarget(null);
        }

        if (!canAttack)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            enemyHitArea.transform.localPosition = direction;

            enemyHitArea.transform.right = direction;

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
                canAttack = true;
                enemyHitArea.gameObject.SetActive(true);

            }
        }


        if (canAttack)
        {
            timer += Time.deltaTime; 
            if (timer > attackDelay)
            {
                timer = 0;
                
                Attack();
                canAttack = false;
                enemyHitArea.gameObject.SetActive(false);
            }
        }

        effectDurationTimer += Time.deltaTime;
        if (effectDurationTimer > 1)
        {
            effectDurationTimer = 0;
            foreach (var effect in currentEffects.ToList())
            {
                TakeDamage(effect.Damage);
            }

        }

        foreach (var effect in currentEffects.ToList()) 
        {
            effect.Duration -= Time.deltaTime;
            if (effect.Duration < 0)
            {
                currentEffects.Remove(effect);
                OnChangeEffects?.Invoke();
            }
        }
        
    }

  
  
    private void Attack() 
    {
        if (Time.time - lastAttackTime >= attackInterval)
        {
            float zRotation = enemyHitArea.transform.eulerAngles.z;
            float angleInRadians = zRotation * Mathf.Deg2Rad;
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(enemyHitArea.transform.position, enemyHitArea.size, angleInRadians);
           
            foreach (var hitCollider in hitColliders)
            {
                Player enemy = hitCollider.GetComponent<Player>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    enemy.AddEffect(new PoisonEffect(2,1)); 
                }
                   
            }
        }
    }

    public void TakeDamage(int damage) //todo давай сделаем анимацию получения урона - она есть в спрайтах
    {
        
        hp -= damage;
        DamagePopUp.Create(transform.position,damage,false,false, "");
        view.ChangeHpText(hp,maxHp);
        if (hp < 0)
        {
            _enemyManager.enemies.Remove(this);
            _enemyManager.enemyDied();
            Destroy(gameObject);
        }
    }
    
    public void NewTarget(Transform newTarget)
    {
        target = newTarget;
        if (newTarget == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
