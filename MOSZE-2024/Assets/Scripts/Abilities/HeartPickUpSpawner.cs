using UnityEngine;

public class HeartPickUpSpawner : MonoBehaviour
{
    public GameObject heartPickUp;
    public float spawnTimer;
    public float minSpawnTime = 2;
    public float maxSpawnTime = 15;
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
             Instantiate(heartPickUp, transform.position, Quaternion.identity);  //Az EnemyBullet spawn-olásáért, irányáért felel
             spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
        }
       
    }
}