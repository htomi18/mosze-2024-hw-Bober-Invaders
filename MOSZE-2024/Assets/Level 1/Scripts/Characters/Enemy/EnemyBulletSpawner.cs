using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{


    public GameObject enemyBullet;
    public float spawnTimer;
    public float minSpawnTime = 2;
    public float maxSpawnTime = 6;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
             Instantiate(enemyBullet, transform.position, Quaternion.identity);  //Az EnemyBullet spawn-olásáért, irányáért felel
             spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
        }
       
    }
}
