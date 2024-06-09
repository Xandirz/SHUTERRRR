using System.Collections;
using System.Collections.Generic;
using Effects;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int damage = 1;
    private float lifeTime = 5.0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
            enemy.ApplyEffect(new FireEffect(25));
            
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
}
