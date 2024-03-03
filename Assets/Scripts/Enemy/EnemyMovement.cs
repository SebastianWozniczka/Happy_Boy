
using System;
using UnityEngine;
using static UnityEngine.UI.Image;


public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
 
    

    private Rigidbody2D rb;
    private Animator anim;
   


    public bool left, right, up, upRight, fight, playerContact;
    public float horizontal, hor = 0; 
    public float jumping;
    public float distance;
  

    private float timeRotation,   timeRotation2, timeRotate;
    private bool isFacingRight, canJump;   
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


       
     
       

        up = false;
        timeRotation = 0;
        timeRotation2 = 0;
       
       
        distance = 0;
        timeRotate = 0;
        

    }

   

    void Update()
    {
        Rotation();
        Movement();
        Animation();

       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
   

        if (collision.gameObject.name == "Swordsman")
        {
            playerContact = true;
        }

    }

    private void Rotation()
    {
        if (isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f)
        {
            timeRotation2 += Time.deltaTime;
            if (timeRotation2 > 0.5f)
            {
                Flip();
                timeRotation2 = 0;
            }
        }
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



        if (playerContact)
        {
            horizontal = -horizontal;

            timeRotate += Time.deltaTime;

            if(timeRotate > 1)
            {
                horizontal = -horizontal;
                timeRotate = 0;
                playerContact = false;
            }
            
        }
       

       


        if (player.transform.position.x > transform.position.x)
        {
            movRight();
                  
            }

           
            
           if(player.transform.position.x < transform.position.x ){
            
            movLeft();
        } 
        
        rb.velocity = new Vector2(horizontal,rb.velocity.y);
     

        if (right)
        {
            
                
                horizontal = 7;
             
            

        }
        else if (left)
        {
           
          
                horizontal = -7;
           

           

        }
        else
        {
            horizontal = 0;
        }


    }

    private void movLeft()
    {

        timeRotation += Time.deltaTime;


        if(timeRotation > 1)
        {
            right = false;
            left = true;
            timeRotation = 0;
        }
       
    }

    private void movRight()
    {
        timeRotation += Time.deltaTime;
        if(timeRotation > 1)
        {
            right = true;
            left = false;
            timeRotation = 0;
        }

      
    }

    private void Animation()
    {
        if (horizontal != 0f && rb.velocity.y == 0) anim.SetTrigger("walk");
        if ((int)rb.velocity.y != (int)0) anim.SetTrigger("jump");
        if (rb.velocity.y == 0 && horizontal == 0) anim.SetTrigger("stand");
    }

}
