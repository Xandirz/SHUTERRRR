using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        hp = maxHp;
        view.ChangeHpText(hp,maxHp);

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
        
        
    }
    


    private void Attack()
    {
        if (Time.time - lastAttackTime >= attackInterval)
        {
            lastAttackTime = Time.time;
            target.GetComponent<Player>().TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        
        hp -= damage;
        DamagePopUp.Create(transform.position,damage,false,false, "");
        view.ChangeHpText(hp,maxHp);
        if (hp < 0)
        {
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
