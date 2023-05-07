using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAni : MonoBehaviour
{
    public GameObject DeathUI;
    public int maxHealth = 100;
    private int currentHealth;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            ActivateDeathAni();
        }
    }

    private void ActivateDeathAni()
    {
       DeathUI.SetActive(true);
    }

     public void menu()
    {
       SceneManager.LoadScene(0);
    }

      public void QuitGame()
    {
        Application.Quit();
    }

}
