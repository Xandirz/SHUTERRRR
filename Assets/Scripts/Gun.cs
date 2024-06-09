using System.Collections;
using System.Collections.Generic;
using Perks;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public Bullet bulletPrefab;
    public float boltSpeed = 10.0f;
    public float fireRate =1f; 
    public int damage = 1;
    private float nextFireTime = 0.0f;
    public bool canShoot = true;
    public List<Perk> Perks = new List<Perk>();

    public int amountOfShots = 1;
    // Start is called before the first frame update
    void Start()
    {
        Perks.Add(new DoubleShot());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFireTime && canShoot && Time.timeScale > 0)
        {
            ShootBolt();
            nextFireTime = Time.time + fireRate;
        }
    }

    public void ShootBolt()
    {
        foreach (Perk perk in Perks)
        {
            amountOfShots += perk.AmountOfShots();
        }

        StartCoroutine(ShootBoltCoroutine());
    }
    
    private IEnumerator ShootBoltCoroutine() //todo норм ли корутиной сделать?
    {
        for (int i = 0; i < amountOfShots; i++)
        {
            var position = transform.position;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - position).normalized;
            Bullet bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.damage = damage;
            rb.velocity = direction * boltSpeed;

            yield return new WaitForSeconds(0.1f);  
        }

        amountOfShots = 1;
    }
}
