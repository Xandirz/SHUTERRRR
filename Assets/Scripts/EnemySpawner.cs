using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 5f;
    public Enemy enemyPrefab;
    public List<SpriteRenderer> spawners;
    public Color deactivatedSpawnerColor;
    private SpriteRenderer selectedSpawner;
    [Space] 
    private EnemyManager _enemyManager;

    [Space] 
    public int hpIncrease =  0;
    public int spawnRateIncrease  = 4;
    void Start()
    {
        _enemyManager = FindObjectOfType<EnemyManager>();
        InvokeRepeating("SpawnEnemy", 5f, spawnRate); //todo поменять
    }

    public void SpawnEnemy()
    {
        selectedSpawner = spawners[Random.Range(0, spawners.Count)];
        selectedSpawner.color = Color.red;
        Invoke("Spawn", 1f);
    }

    public void Spawn()
    {
        Enemy spawnedEnemy;
        
        int chance = Random.Range(0, 101); 
        if (chance < 30)
        {
            hpIncrease++;
        }
        if (hpIncrease >= 5)
        {
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 3f, 3); 
        }
        selectedSpawner.color = deactivatedSpawnerColor;
        spawnedEnemy = Instantiate(enemyPrefab, selectedSpawner.transform.position, Quaternion.identity);
        spawnedEnemy.maxHp += hpIncrease;
        
        
    }
}
