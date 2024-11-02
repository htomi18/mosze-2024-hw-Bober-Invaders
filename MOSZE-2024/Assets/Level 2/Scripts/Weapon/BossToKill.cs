using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossToKill : MonoBehaviour
{
    float speed;  //Ez jellemzi a Stick sebességét
    public GameObject explosionPrefab;
    
    public Slider healthBar;
    public int health = 500;  //Alapértelmezetten a miniBoss élete 500
    private int currentHealth;
   

    

    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        currentHealth = health;
        healthBar.maxValue = health;
        healthBar.value = currentHealth;
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

    public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.value = currentHealth;
            if (currentHealth <= 0)
            {
                Die();
            }

        }

        private void Die()
        {
            Debug.Log("A Boss meghalt!");
            
        }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        BossHP bossHP = collider.GetComponent<BossHP>();

        if (collider.gameObject.tag == "Polish_Boss")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            if (bossHP != null)
            {
                bossHP.TakeDamage(50);
            }

            Destroy(gameObject);
        }
        if (health <= 0)
        {
            Destroy(collider.gameObject);
        }
         
    }

     

}
