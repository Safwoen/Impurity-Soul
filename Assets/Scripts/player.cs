using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 10;
     

      private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(10);
            Destroy(other.gameObject);
        }
    }

    


     private void TakeDamage(int damage)
    {
        currentHealth-=damage;
        if (currentHealth<= 0)
        {
            Die();
        }
    }


     public Healthbar healthBar;
    void Start()
    {
        currentHealth = maxHealth ; 
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
          if(Input.GetKeyDown (KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

     void TakeDamageByEnemy(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    

      private void Die()
    {
        Debug.Log("Player has died!");
        
    }


}
