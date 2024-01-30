
using System;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D rb;
    private Animator anim;   
    private GameObject go;

    public bool left, right, up, upRight, fight, isGrounded, playerContact;
    public float horizontal, hor = 0; 
    public float jumping;
    public float distance;

    private float jumpHeight = 20, timeRotation, timeR, timeL, timeContact,timeJump,jumpSpeed;
    private bool isFacingRight;   
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        go = GameObject.FindWithTag("Enemy");
        
        isGrounded = true;
        up = false;
        timeRotation = 0;
        timeR = 0;
        timeL = 0;
        distance = 0;
        timeContact = 0;
        timeJump = 0;
    }

    
    void Update()
    {
        Rotation();
        Movement();
        Animation();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.name == "Swordsman")
        {
            playerContact = true;
        }

        up = false;
    }

    private void Rotation()
    {
        if (isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f)
        {
            timeRotation += Time.deltaTime;
            if (timeRotation > 0.5f)
            {
                Flip();
                timeRotation = 0;
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

        if (!isGrounded)
        {
            timeJump += Time.deltaTime;
            if(timeJump > 0.5f)
            {
                jumpSpeed = -100;
                timeJump = 0;
            }
        }else jumpSpeed = rb.velocity.y;



        if (playerContact)
        {
            right = true;

            if (right)
            {
                right = false;
                left = true;
            }

            if (left)
            {
                left = false;
                right = true;
            }

            timeContact += Time.deltaTime;
            if(timeContact > 1)
            {

                if (left)
                {
                    left =false;
                    right = true;
                }

                if (right)
                {
                    right=false;
                    left = true;
                }


                playerContact = false;
                timeContact = 0;
            }
            

        } else
               
        /*{

            if (player.transform.position.x < transform.position.x)
            {
                left = true;
                right = false;
            }
            else if (player.transform.position.x > transform.position.x)
            {
                right = true;
                left = false;
            }
            else if (player.transform.position.x == transform.position.x)
            {
                up = true;
                right = true;

                timeJump += Time.deltaTime;
                if (timeJump > 1)
                {
                    right = false;
                    timeJump = 0;
                }
            }

        }*/


        distance = Vector2.Distance(go.transform.position, transform.position);

        
        rb.velocity = new Vector2(horizontal,jumpSpeed);

        if (up)
        {
            //JumpButton();
        }

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

    public void JumpButton()
    {
        if (isGrounded)
        {

            rb.velocity = Vector2.up * jumpHeight;

            jumping = 50;

            isGrounded = false;
        }
        else jumping = 0;


    }

    private void Animation()
    {
        if (horizontal != 0f && rb.velocity.y == 0) anim.SetTrigger("walk");
        else if (rb.velocity.y != 0) anim.SetTrigger("jump");
        else if (rb.velocity.y == 0) anim.SetTrigger("stand");
    }

}
