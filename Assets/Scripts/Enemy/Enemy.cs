using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   public Image healthBar;
   private Rigidbody2D rb;

   public int maxHealth = 100;
    private float jumpHeight; 

   private int currentHealth;

    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public void Jumping()
    {
       

        if (isGrounded)
        {

           rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);

            isGrounded = false;
        }
        else { 

        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");
    }
  
    void Update()
    {

        
        healthBar.fillAmount = currentHealth / 100;

        Jumping();
    }
}
