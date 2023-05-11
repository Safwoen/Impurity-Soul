using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 10;
    public GameObject DeathUI;

    public GameObject endScreen;
    public int garbageCollected;
    

    public Healthbar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    

     private void ActivateDeathAni()
    {
       DeathUI.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(10);
            Destroy(other.gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        

        currentHealth-=damage;

         if (currentHealth <= 0)
        {
            currentHealth = 0;
            ActivateDeathAni();
        }
    }
    
    void Update()
    {
           
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        if (garbageCollected >= 1)
        {
            endScreen.SetActive(true);
        }


    }

    public void TakeDamageByEnemy(int damage)
    {
        currentHealth -= damage;
    }
    
    private void Die()
    {
        Debug.Log("Player has died!");
    }

    
   
    
}
