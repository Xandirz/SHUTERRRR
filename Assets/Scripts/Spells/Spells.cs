using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Spells : MonoBehaviour //todo нужно ли вытащить отсюда все заклинания в отдельные скрипты? давай сделаем их добавление к персонажу 
    {
        public Gun gun;
        public CircleCollider2D area;
        public GameObject rat;

        public void IncreaseFireRate()
        {
            StartCoroutine(FireRateIncreaseCountdown());
            if (gun.fireRate > 0.5f)
            {
                gun.fireRate -= 0.5f;
            }
        }

        public IEnumerator FireRateIncreaseCountdown()
        {
            int time = 5;
            for (int i = 0; i < time; i++)
            {
                yield return new WaitForSeconds(1); 
            }     
            gun.fireRate += 0.5f;
        }


    

        public void DamageArea(int damage)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, area.radius);

            foreach (var hitCollider in hitColliders)
            {
                Enemy enemy = hitCollider.GetComponent<Enemy>();
                if (hitCollider.CompareTag("Enemy"))
                {
                    enemy.TakeDamage(damage);
                    Vector2 dir = transform.position - enemy.gameObject.transform.position;
                    enemy.GetComponent<Rigidbody2D>().AddForce(-dir * 3f,  ForceMode2D.Impulse); //todo можно толкать  иначе?
                }
            }

        }
        
        public void SummonRat(Vector3 position)
        {
            GameObject summon = Instantiate(rat, position, Quaternion.identity);
        }
    }
