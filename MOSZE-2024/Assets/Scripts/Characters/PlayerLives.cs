using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerLives : MonoBehaviour
{

    public int lives = 3;  //A karakter életének meghatározása
    public Image[] livesUI;
    private PointManager pointManager;  //a PointManager script-et hívja meg. A pontok levonása miatt fontos
    //public GameObject defeat;
    private bool isDead;
    public SceneController sceneManager;
    
    
    
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1){
            pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();  //A játék indításakor megkeresi a pontokat az itt behivatkozott pointManager számára
        }
        //defeat.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//OnCollisionEnter2D-vel fogom folyamat nézni, hogy a karakter bármilyen interakcióba lépett-e az ellenféllel (ellenség testével vagy lövedékével)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "ellenseg"  || collision.collider.gameObject.tag == "Polish_Boss")  //azt vizsgáljuk, hogy az ellenség talált-e el minket
        {
            Destroy(collision.collider.gameObject); //Semmisítse meg azt az ellenséget, akivel ütköztünk
            pointManager.UpdateScore(-50);  //Alapértelmezetten ha egy ellenséggel ütközünk, akkor -50 pont jár érte
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
            if (lives <= 0 && !isDead)  //ha lecsökkent, ellenőrizzük, hogy még van-e tövábbi életünk
            {
                isDead = true;
                Destroy(gameObject);  //ha nincs, akkor a karakterünk semmisüljön meg
                //defeat.SetActive(true);
                sceneManager.gameOver();
                
            } 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy_Bullet" || collision.gameObject.tag == "Boss_Bullet")  //azt vizsgáljuk, hogy az ellenség lövedéke talált-e el minket
        {
            Destroy(collision.gameObject); //Semmisítse meg az EnemyBullet-et
            if(SceneManager.GetActiveScene().buildIndex == 1){
                pointManager.UpdateScore(-50);  //Alapértelmezetten ha eltalálnak, akkor -50 pont jár érte
            }
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
            if (lives <= 0 && !isDead)  //ha lecsökkent, ellenőrizzük, hogy még van-e tövábbi életünk
            {
                isDead = true;
                
                Destroy(gameObject);  //ha nincs, akkor a karakterünk semmisüljön meg
                //defeat.SetActive(true);
                sceneManager.gameOver();
            } 
        }

        
    }

    
        
    
    
}
