using System;
using System.Collections;
using System.Collections.Generic;
using Perks;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public Bullet bulletPrefab;
    private float nextFireTime = 0.0f;
    public List<Perk> Perks = new List<Perk>();
    public List<Spell> Spells = new List<Spell>();
    public GameObject rat;
    [Space]
    public int ratSpawnChanceMaxNumber = 101;

    public bool isFire;
    public CircleCollider2D circleArea;

    [Space] 
    public PlayerConfig playerConfig;
    // Start is called before the first frame update
    void Start()
    {
            AddPerk(new DoubleShotPerk(playerConfig));
            AddPerk(new FireShot(playerConfig));
            AddPerk(new RatShot(playerConfig));

           // RemovePerk<DoubleShotPerk>();            
            
            Spells.Add(new RatSummonSpell(playerConfig, transform));
            Spells.Add(new IncreaseFireRate(5, 5, playerConfig));
            Spells.Add(new PushSpell(1, transform, circleArea, playerConfig));
    }

    public void AddPerk(Perk perk)
    {
        Perks.Add(perk);
        perk.OnActivate();
    }
    public void RemovePerk<T>() where T:Perk
    {
        foreach (var perk in Perks)
        {

            if (perk is T)
            {
                perk.OnDeactivate();
                Perks.Remove(perk);
            }
        }
    }
    // Update is called once per frame
    void Update()  //todo когда нажимаешь на спелл и он не откатился  то делать  попап сколько осталось  ждать
    {
        foreach (var spell in Spells)
            spell.Tick();
        
        if (Input.GetMouseButton(0) && Time.time > nextFireTime  && Time.timeScale > 0)
        {
            ShootBolt();
            nextFireTime = Time.time + playerConfig.fireRate;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Use<IncreaseFireRate>();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Use<PushSpell>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Use<RatSummonSpell>();
        }
    }

    public void Use<T>() where T:Spell
    {
        foreach (var spell in Spells)
        {
            if (spell is T)
            {
                spell.Use();
            }
        }
    }

    public void ShootBolt()
    {
        
      


        StartCoroutine(ShootBoltCoroutine());
    }
    
    private IEnumerator ShootBoltCoroutine() 
    {
        playerConfig.onPreShoot.Invoke();
        for (int i = 0; i < playerConfig.amountOfShots; i++)
        {
            var position = transform.position;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - position).normalized;
            Bullet bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.damage = playerConfig.damage;
            rb.velocity = direction * playerConfig.boltSpeed;


            

            yield return new WaitForSeconds(0.1f);  
        }

        playerConfig.onShoot.Invoke();
    }

    public void ChangeFireRate()
    {
        if (playerConfig.fireRate > 0.2f)
        {
            playerConfig.fireRate -= 0.2f;
        }
    }

    public void ChangeRatSpawnChance()
    {
        if (ratSpawnChanceMaxNumber > 21)
        {
            ratSpawnChanceMaxNumber -= 20;
        }
    }
}
