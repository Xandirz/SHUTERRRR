using System.Collections;
using System.Collections.Generic;
using Effects;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int damage = 1;
    private float lifeTime = 5.0f;

    public bool isFire = false; //todo как сделать иначе

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
            if (isFire)
            {
                enemy.AddEffect(new FireEffect(2,1));
            }
            
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
}
