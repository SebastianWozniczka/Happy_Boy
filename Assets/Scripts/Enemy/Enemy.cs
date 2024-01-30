using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   public Image healthBar; 

   public int maxHealth = 100; 

   private int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damege)
    {
        currentHealth -= damege;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
    }
  
    void Update()
    {
        healthBar.fillAmount = currentHealth / 100;
    }
}
