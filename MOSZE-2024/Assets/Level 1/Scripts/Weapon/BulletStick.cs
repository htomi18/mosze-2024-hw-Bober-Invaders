using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletStick : MonoBehaviour
{
    float speed;  //Ez jellemzi a Stick sebességét
    
    //public int counter = 0;
    public GameObject explosionPrefab;
    private PointManager pointManager;  //a PointManager script-et hívja meg. A pontok hozzáadása miatt fontos

    // Start is called before the first frame update
    
    void Start()
    {
        speed = 8f;
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();  //A játék indításakor megkeresi a pontokat az itt behivatkozott pointManager számára
        
    }
   
    // Update is called once per frame
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
            /*counter++;
            if (counter >= 4)
            {
                SceneController.isntance.NextLevel(); // Példa: új szint indítása
            }*/
            pointManager.UpdateScore(50);  //Alapértelmezetten ha egy ellenséget kilövünk, akkor 50 pont jár érte
            
            Destroy(gameObject);  //A BulletStick-et megsemmisíti
            
            
        }
    

    }
}
