using UnityEngine;
using System.Collections;
public class PlayerAbilityManager : MonoBehaviour
{

    public float specialShotDuration = 10f; // Meddig tart a speciális lövés bónusz
    public float bulletForce = 10f; // Alap lövedék sebesség
    private bool isSpecialShotActive = false; // Speciális lövés aktív-e

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "gally" && !isSpecialShotActive)
        {
            StartCoroutine(SpecialShot());
            Destroy(collider.gameObject);
        }
        
    }

    IEnumerator SpecialShot()
    {
        isSpecialShotActive = true;

        // Eredeti sebesség mentése
        float originalBulletForce = bulletForce;

        // Sebesség növelése
        bulletForce *= 2;

        // Várakozás a speciális időtartamra
        yield return new WaitForSeconds(specialShotDuration);

        // Sebesség visszaállítása
        bulletForce = originalBulletForce;

        isSpecialShotActive = false;
    }
}