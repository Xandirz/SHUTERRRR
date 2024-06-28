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


        
        foreach (var effect in currentEffects.ToList()) //todo добавил ту лист чтобы убрать Collection was modified
        {
            
            StartCoroutine(RefreshEffect(effect));
        }
        
    }

    private IEnumerator RefreshEffect(Effect effect)
    {
        Debug.Log(123);
        for (int i =  effect.Duration; i >  effect.Duration; i--)
        {
            TakeDamage(effect.Damage); //todo не работает(((
            effect.Duration--;
            yield return new WaitForSeconds(1);
        }
        currentEffects.Remove(effect);
    }


    private void Attack() //todo как  сделать атаку которую видно - аля взмах врага мечом который ты видишь за секунду до удара чтобы мог увернуться
    {
        if (Time.time - lastAttackTime >= attackInterval)
        {
            lastAttackTime = Time.time;
            var myTarget = target.GetComponent<Player>(); //todo делать так?
            myTarget.TakeDamage(damage);
            myTarget.AddEffect(new PoisonEffect(2,1)); 
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
