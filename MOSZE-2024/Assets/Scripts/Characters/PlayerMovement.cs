using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
   public GameObject BulletStick;  //ez a játékosunk Stick prefab-je
   public Transform FirePoint;  //ez a játékosunkhoz rendelt tüzelési pont, ahonnan a stick fog indulni
   public float bulletForce = 0;  //a lövedék mozgási sebességét adjuk meg előre
   public float moveSpeed = 0;  //karakter mozgási sebességét adjuk meg előre
   public Rigidbody2D rb;
   private Vector2 moveDirection;
   

void Update()
{
   ProcessInputs();

   if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
}

void Shoot()
    {
        GameObject bullet = Instantiate(BulletStick, FirePoint.position, FirePoint.rotation);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }

void FixedUpdate()
{
   Move();
}

//karakter mozgását adjuk meg X és Y tengelyeken
   void ProcessInputs()
   {
      float moveX = Input.GetAxisRaw("Horizontal");
      float moveY = Input.GetAxisRaw("Vertical");

      moveDirection = new Vector2(moveX, moveY).normalized; 
   }


//A karakter mozgásáért felel
   void Move()  
   {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

   }
}
