using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   public Image healthBar;
    
   public GameObject helmet;
   public Transform playerTr;
   public LayerMask enemyLayers;
   public Transform attackPoint;
    public Vector2 distance;
    private Rigidbody2D rb;
   private Animator anim;

   public static bool isDead;

   public float attackRange = 0.5f;
   public float attackRate = 2.0f;
   public float nextAttackTime = 0f;

  
   private readonly float attackDamage = 10;
    
   private readonly float maxHealth = 1;
   private float jumpTimer;
   private float currentHealth;
   private bool isGrounded, fight;
   private bool canJump;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
        jumpTimer = 0;
        fight = true;
      
    }


    public void TakeDamage(float damage)
    {
        anim.SetTrigger("hurt");
        helmet.SetActive(false);
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
       

    }

    void Die()
    {
        isDead = true;
        currentHealth = 0;
        anim.SetTrigger("dead");
        rb.mass = 20;
        Destroy(gameObject,3);
    }

    void Attack()
    {

        anim.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D player in hitEnemies)
        {
            Debug.Log("We hit" + player.name);

            if (player.GetComponent<PlayerMove>() != null)
                player.GetComponent<PlayerMove>().TakeDamage(attackDamage);
        }
    }

    public void Update()
    {
        healthBar.fillAmount = currentHealth;


        float distance = Vector2.Distance(transform.position, playerTr.position);
        if(distance < 2)
        {
            
            fight = true;
        }

        if (Time.time >= nextAttackTime)
        {
            if (fight)
            {

                if(!isDead)
                Attack();
                fight = false;
                nextAttackTime = Time.time + 1f / attackRate;
            }
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
    }
}
