using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStick : MonoBehaviour
{
    float speed;  //Ez jellemzi a Stick sebességét


    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
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
}
