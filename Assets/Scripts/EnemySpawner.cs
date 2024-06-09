using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 5f;
    public Enemy enemyPrefab;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 5f, spawnRate); //todo поменять
    }

    public void SpawnEnemy()
    {
        var randPosition = new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(-4.0f, 4.0f), 0);
        Vector3 spawnPosition = transform.position;
        spawnPosition += randPosition;
        Enemy spawnedEnemy;
        spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
