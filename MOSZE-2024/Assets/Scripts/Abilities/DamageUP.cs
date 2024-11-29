using UnityEngine;

public class SpecialShotPowerUp : MonoBehaviour
{
    public float specialShotDuration = 10f; // Meddig tart a speciális lövés bónusz

    // Ha valaki nekiütközik ennek az objektumnak (pl. a játékos)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Csak a játékos veheti fel
        {
            
            Destroy(gameObject); // Eltüntetjük a pályán lévő tárgyat
        }
    }
}

