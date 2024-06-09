using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int damage = 1;
    private float lifeTime = 5.0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //todo так проверять норм?
        {
            
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
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
