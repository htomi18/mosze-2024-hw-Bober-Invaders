using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hatar")  //ha az ellenség találkozik a határral, akkor pattanjon vissza
        {
            transform.position = new Vector3(transform.position.x, transform.position.y -1, transform.position.z);
            moveSpeed *= -1;
        }

        if (gameObject.transform.position.x < -15.35 || gameObject.transform.position.x > 15.46) //ha valamelyik ellenség kimenne a "képernyőről", akkor semmisüljön meg
        {
            Destroy(gameObject);
        }

    }
}
