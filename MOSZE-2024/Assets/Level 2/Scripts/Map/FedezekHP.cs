using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FedezekHP : MonoBehaviour
{

    public int health = 300;
    
    void Start()
    {
        
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss_Bullet")  //azt vizsgáljuk, hogy az ellenség lövedéke talált-e el minket
        {
            Destroy(collision.gameObject); //Semmisítse meg az EnemyBullet-et
            
            health -= 50;  //ha igen, akkor csökkenjen az életünk eggyel
            
            if (health <= 0)  //ha lecsökkent, ellenőrizzük, hogy még van-e tövábbi életünk
            {
                Destroy(gameObject);  //ha nincs, akkor a karakterünk semmisüljön meg
            } 
        }
        if (collision.gameObject.tag == "stick")
        {
            Destroy(collision.gameObject);
        }
    }

    
}
