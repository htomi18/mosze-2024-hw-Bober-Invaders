using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;





public class BulletStick : MonoBehaviour
{
    public float speed;  //Ez jellemzi a Stick sebességét
    
    
    public GameObject explosionPrefab;
    private PointManager pointManager;  //a PointManager script-et hívja meg. A pontok hozzáadása miatt fontos
    private EnemyCounter enemyCounter;
    public Slider healthBar;
    public int health = 500;
    private int currentHealth;
    
    
    void Start()
    {
        speed = 8f;
        
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();  //A játék indításakor megkeresi a pontokat az itt behivatkozott pointManager számára
        enemyCounter = GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>();  //A játék indításakor megkeresi a pontokat az itt behivatkozott pointManager számára
        
        
        
    }
   
    
    
    void Update()
    {
        Vector2 position = transform.position;  //Ezzel megkapjuk a stick jelenlegi helyzetét

        position = new Vector2(position.x, position.y + speed*Time.deltaTime);  //Ezzel kapjuk meg mindig a stick új helyét
        
        transform.position = position;  //Ezzel frissítjük a stick helyét

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));  //Meghatározzuk, hogy mennyi az a maximális határ, ameddig a stick elmehet

        if (transform.position.y > max.y)  //ha a stick y pozíciója nagyobb, mint a maximális határ
        {
            Destroy(gameObject);  //("rombolja") törölje a stick gameObject-et
        }
        
        
    }

    



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ellenseg")  //Azt ellenőrizzük, hogy amit eltalált a BulletStick, az ellenség volt-e vagy sem
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);  //Az ellenséget megsemmisíti    
            enemyCounter.CountUp(-1);
            pointManager.UpdateScore(50);  //Alapértelmezetten ha egy ellenséget kilövünk, akkor 50 pont jár érte
            Destroy(gameObject);  //A BulletStick-et megsemmisíti
        }
        
    }
        
    
}
