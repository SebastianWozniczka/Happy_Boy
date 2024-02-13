
using System;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D rb;
    private Animator anim;   

    public bool left, right, up, upRight, fight, playerContact;
    public float horizontal, hor = 0; 
    public float jumping;
    public float distance;

    private float timeRotation, timeR, timeL, timeRotation2;
    private bool isFacingRight;   
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        up = false;
        timeRotation = 0;
        timeRotation2 = 0;
        timeR = 0;
        timeL = 0;
        distance = 0;
       
        
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
            timeR += Time.deltaTime;

            if(timeR > 0.1f)
            {
                horizontal = 10;
                timeR = 0;
            }
            

        }
        else if (left)
        {
            timeL += Time.deltaTime;
            if(timeL > 0.1f)
            {
                horizontal = -10;
                timeL = 0;
            }

           

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
        else if (rb.velocity.y != 0) anim.SetTrigger("jump");
        else if (rb.velocity.y == 0) anim.SetTrigger("stand");
    }

}
