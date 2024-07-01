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
    public Spells spells;
    public GameObject rat;
    public bool isFire = false;
    [Space] 
    public float increaseFireRateCD = 5f;
    private float next1; //todo как не делать кд и время использование спела каждый раз для каждого спела
    public float damageAreaCD = 1;
    private float next2;
    public float summonRatCD = 1;
    private float next3;
    public int ratSpawnChanceMaxNumber = 101;

    [Space] 
    public PlayerConfig playerConfig;
    // Start is called before the first frame update
    void Start()
    {
        Perks.Add(new DoubleShot());
        Perks.Add(new FireShot());
        Perks.Add(new RatShot());
        Spells.Add(new RatSummonSpell(transform));
    }

    // Update is called once per frame
    void Update()  //todo когда нажимаешь на спелл и он не откатился  то делать  попап сколько осталось  ждать
    {
        if (Input.GetMouseButton(0) && Time.time > nextFireTime  && Time.timeScale > 0)
        {
            ShootBolt();
            nextFireTime = Time.time + playerConfig.fireRate;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)&& Time.time > next1)
        {
            spells.IncreaseFireRate();
            next1  = Time.time + increaseFireRateCD;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2)&& Time.time > next2)
        {
            spells.DamageArea(playerConfig.damage);
            next2  = Time.time + damageAreaCD;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&& Time.time > next3)
        {
            Use<RatSummonSpell>();
            next3  = Time.time + summonRatCD;
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
        foreach (Perk perk in Perks)
        {
            playerConfig.amountOfShots += perk.AmountOfShots();
        }

        foreach (Perk perk in Perks) //todo как сделать иначе
        {
            if (perk is FireShot firePerk)
            {
                isFire = firePerk.isFire();
            }

            if (perk is RatShot ratPerk)
            {
                //ratPerk.SummonRat(transform.position); //todo по  хорошему мне надо сделать так но я не могу в перк засунуть  префаб
                
                
                if (ratPerk.GetChance(ratSpawnChanceMaxNumber))
                {
                    GameObject summon = Instantiate(rat, transform.position, Quaternion.identity);
                }
            } 
        }


        StartCoroutine(ShootBoltCoroutine());
    }
    
    private IEnumerator ShootBoltCoroutine() 
    {
        for (int i = 0; i < playerConfig.amountOfShots; i++)
        {
            var position = transform.position;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - position).normalized;
            Bullet bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.damage = playerConfig.damage;
            rb.velocity = direction * playerConfig.boltSpeed;


            foreach (Perk perk in Perks) 
            {
                if (perk is FireShot firePerk)
                {
                    isFire = firePerk.isFire();
                }
            }
            

            yield return new WaitForSeconds(0.1f);  
        }

        playerConfig.amountOfShots = 1;
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
