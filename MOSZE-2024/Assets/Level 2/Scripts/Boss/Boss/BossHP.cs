using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossHP : MonoBehaviour
{
    public GameObject victory;
    
    public Slider healthBar;
    public int health = 1000;  //Alapértelmezetten a miniBoss élete 500
    private int currentHealth;

    public SceneCon sceneController;
    
    public void Start()
    {
        currentHealth = health;
        healthBar.maxValue = health;
        healthBar.value = currentHealth;
       
        
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
            sceneController.win();
        }

    }

    private void Die()
    {
        Debug.Log("A Boss meghalt!");
    }

    
}
