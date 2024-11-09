using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bober_Lives : MonoBehaviour
{

    public int lives = 3;  //A karakter életének meghatározása
    public Image[] livesUI;
    public GameObject defeat;

    public void Start()
    {
        defeat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Karakterünk sebződéséért felel
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss_Bullet")  //azt vizsgáljuk, hogy az ellenség lövedéke talált-e el minket
        {
            Destroy(collision.gameObject); //Semmisítse meg az EnemyBullet-et
            
            lives -= 1;  //ha igen, akkor csökkenjen az életünk eggyel

            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }

            if (lives <= 0)  //ha lecsökkent, ellenőrizzük, hogy még van-e tövábbi életünk
            {
                Destroy(gameObject);  //ha nincs, akkor a karakterünk semmisüljön meg
                defeat.SetActive(true);
            } 
        }
    }

}
