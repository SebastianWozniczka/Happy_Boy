
using System;
using System.Linq;
using UnityEngine;

public class Controllers : MonoBehaviour
{
    [SerializeField] PhysicsMaterial2D physicsMaterial1;

    private Rigidbody2D rb;
    private Animator anim;
    private Ground ground;


    public bool left, right, up, upRight, fight;
    public float delayBeforeDoubleJump = 0.5f;
    public float horizontal, hor = 0;
    public bool canDoubleJump = false;
    public float jumping;
    public float attackRate = 2.0f;

    private readonly float jumpHeight = 20;   
    private bool isFacingRight;  
    private bool isAble;
    private float nextAttackTime = 0f;
 

    
   
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       ground = FindAnyObjectByType<Ground>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {



        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right);

        if (hitLeft.distance <= 0.1 || hitRight.distance <= 0.1 || collision.gameObject.name == "Enemy_1")
        {
            rb.sharedMaterial = physicsMaterial1;
        }
        else
        {
            rb.sharedMaterial = null;
        }


        if(collision.gameObject.name == "Enemy_1")
        {
            rb.mass = 0.5f;
        }
        else
        {
            rb.mass = 1.0f;
        }
        

        


        if (collision.gameObject.name == "ground")
        {
            physicsMaterial1.bounciness = 0;
            if (!ground.isGrounded)
            {
                rb.AddForce(new Vector2(-horizontal * 30,0));
               
            }
        }
        up = false;
    }


    private void Update()
    {
        Rotation();
        Movement();
        Animation();

      
    }

    private void Rotation()
    {
        if (isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f)
        {
            {
                Flip();
            }
        }
    }

    private void Animation()
    {
        if (transform.position.y < 2.0f)
        {
            isAble = false;
        }

        if (transform.position.y > 5.0f)
        {
            isAble = true;
        }

        anim.SetBool("isAble", isAble);

        if ((horizontal != 0f && rb.velocity.y == 0) || (isAble && rb.velocity.x != 0) ) anim.SetTrigger("walk");
        else if (rb.velocity.y != 0 ) {
            anim.SetTrigger("jump");                      
        }
        else if (rb.velocity.y == 0) { anim.SetTrigger("stand"); } 
    }

    private void Flip()
    {      
        isFacingRight = !isFacingRight;
          
        Vector2 localScale = transform.localScale;
           
        localScale.x *= -1f;
        transform.localScale = localScale;       
    }

    public void Movement()
    {

       rb.velocity = new Vector2(horizontal, rb.velocity.y);


      


     


        if (up)
        {          
           JumpButton();
            up = false;
        }
        
      if (right)
           {
            horizontal = 15;
            
        }
        else if (left )
        {
            horizontal = -15;
           
        }
        else
        {
            horizontal = 0;
        }
    }

    public void JumpButton()
    {
        if (ground.isGrounded)
        {
            rb.velocity = Vector2.up * jumpHeight;

            jumping = 50;
           
            

            if (canDoubleJump)
            {
                rb.velocity = Vector2.up * jumpHeight;
                canDoubleJump = false;
            }

            ground.isGrounded = false;
        }
        else jumping = 0;
        
      
    }

    public void Up()
    {
        up = true;
    }

    public void Right()
    {
        right = true;
    }

    public void Left()
    {
        left = true;
    }

    public void Fight()
    {
        if (Time.time >= nextAttackTime)
        {
            fight = true;
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

}
