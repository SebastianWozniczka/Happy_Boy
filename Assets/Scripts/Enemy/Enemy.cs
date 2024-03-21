using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   public Image healthBar;
   private Rigidbody2D rb;
    public Transform playerTr;

   private readonly float maxHealth = 1;
   private float jumpTimer;

   private float currentHealth;

    private bool isGrounded;
    private bool canJump;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        jumpTimer = 0;
      
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= (float)damage/100f;

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
  
    public void Update()
    {
        healthBar.fillAmount = currentHealth;

       

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



        

       
    }
}
