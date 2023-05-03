using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 10;

    public Healthbar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
    }
    
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Space))
        {
            TakeDamage(20);
        }
    
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
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
