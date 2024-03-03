using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   public Image healthBar;
   private Rigidbody2D rb;
    public Transform playerTr;

   public int maxHealth = 100;
  
   private float jumpHeight;
   private float jumpTimer;

   private int currentHealth;

    private bool isGrounded;
    private bool canJump;
    private float x = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        jumpTimer = 0;
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

        if(collision.gameObject.name == "ground")
        {
            isGrounded = true;
        }
        



        if (collision.gameObject.name == "Swordsman")
        {
            rb.mass = 0.1f;
            canJump = false;
           
        }
        else
        {
            rb.mass = 1;
            canJump = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground")
        {
            isGrounded = true;
        }
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
        if(transform.position.x > playerTr.position.x)
        {
            x = 15;
        }

        if(transform.position.x < playerTr.position.x)
        {
            x = -15;
        }

        if(transform.position.x == playerTr.position.x)
        {
            x = 0;
        }


        RaycastHit2D hitGround = Physics2D.Raycast(transform.position, -Vector2.up);
       
        Debug.DrawRay(transform.position, -Vector2.up * hitGround.distance, Color.red);

        

      


        if (hitGround.collider != null)
        {
            if (hitGround.distance <= 0.2 )
            {


                jumpTimer += Time.deltaTime;

               if(jumpTimer > 2)
                {
                    if(canJump)
                    Jumping();
                    jumpTimer = 0;
                }
                
               
            }
        }



        healthBar.fillAmount = currentHealth / 100;

       
    }
}
