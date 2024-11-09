using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BossHP : MonoBehaviour
{
    public GameObject victory;
    
    public Slider healthBar;
    public int health = 1000;  //Alapértelmezetten a miniBoss élete 500
    private int currentHealth;

    public void Start()
    {
        currentHealth = health;
        healthBar.maxValue = health;
        healthBar.value = currentHealth;
        victory.SetActive(false);
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            Die();
            Destroy(gameObject);
            healthBar.gameObject.SetActive(false);
            victory.SetActive(true);
        }

    }

    private void Die()
    {
        Debug.Log("A Boss meghalt!");
    }


}
