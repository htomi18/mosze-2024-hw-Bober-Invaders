using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class EnemyCounter : MonoBehaviour
{

    public int counter = 12;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void CountUp(int enemies)
    {
        counter--;  //A score-hoz hozzáadjuk a megszerzett pontot
        

        if (counter <= 0)
        {
            SceneController.isntance.NextLevel(); // Példa: új szint indítása
        }
    }
}
