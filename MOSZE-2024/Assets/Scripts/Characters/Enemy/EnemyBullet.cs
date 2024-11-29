using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;  //Az EnemyBullet mozgásáért felel


    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;  //Az EnemyBullet alap sebessége
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);  //Az EnemyBullet lefelé irányuló mozgását írja le

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));  //Meghatározzuk azt a minimum határt, ameddig az EnemyBullet objektum mehet
        if (transform.position.y <= min.y)  //ha az EnemyBullet y pozíciója kisebb vagy egyenlő, mint a minimális határ
        {
            Destroy(gameObject);  //törölje az EnemyBullet gameObject-et
        }
    }


}
