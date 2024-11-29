using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossBulletSpawner : MonoBehaviour
{
    public GameObject BossBullet;
    public float spawnTimer;
    public float minSpawnTime = 2;
    public float maxSpawnTime = 2;

    public GameObject bulletPrefab; // a lövedék prefab-je
    public float bulletSpeed = 5f; // lövedék sebessége
    public int minBullets = 3; // minimum lövésszám
    public int maxBullets = 8; // maximum lövésszám
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
           
            Instantiate(BossBullet, transform.position, Quaternion.identity);  //Az EnemyBullet spawn-olásáért, irányáért felel
            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);

            int bulletCount = Random.Range(minBullets, maxBullets);

        for (int i = 0; i < bulletCount; i++)
        {
            // Véletlenszerű szög kiválasztása a kilövés irányához
            float angle = Random.Range(230f, 330f);
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            // Lövedék példányosítása és irányának beállítása
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;
        }
        }
    }

    
}
