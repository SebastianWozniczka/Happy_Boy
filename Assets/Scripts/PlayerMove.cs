using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject flame,eye,mugs;
  
    public GameObject[] mug;
    public Material mat;
    public Hud hud; 
    public int j;
   
    private Rigidbody2D rb;
    private Animator animator;
    
    private float speed = 5.0f;
    private float horizontal;
    private float jumpingPower = 15f;
    private bool isFacingRight = true;
    private bool isGrounded;
    private bool block;
    private float jTimer;
    public float countJump;
    public int countHit;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        jTimer = 0;
        countJump = 2;
        countHit = 0;
    }

    void Update()
    {
        if(countHit < 2)
        Flip();
        if (countHit == 1)
            Die();
        Jump();
        Var();     
    }

    private void Jump() 
    {
        if (Input.GetButtonDown("Jump") && !block)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            countJump--;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f || !isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);  
            
        }
        if (countJump == 0)
        {
            block = true;
            jTimer += Time.deltaTime;
            if (jTimer > 2)
            {
                block = false;
                jTimer = 0;
                countJump = 2;
            }          
        }

    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        isGrounded = true;     
    }

    private void OnCollisionExit(Collision collision)
    {    
        isGrounded = false;    
    }

    internal void Die()
    {
        flame.SetActive(true);
        eye.SetActive(true);

        speed = 10.0f;     
    }

    private void Var()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (rb.velocity.x != 0 && rb.velocity.y == 0) animator.SetTrigger("walk");
        else if (rb.velocity.y != 0) animator.SetTrigger("jump");
        else animator.SetTrigger("stand");

        if (countHit == 2 || transform.position.y < -3)
        {
            Time.timeScale = 0f;

            hud.win.enabled = true;         
        }

        if (j == 10)
        {
            GetComponent<SpriteRenderer>().material = mat;
            Destroy(gameObject, 2.0f);

            hud.lose.enabled = true;           
        }

        j = 0;
        for (int i = 0; i < mug.Length; i++)
        {
            if (mug[i] == null)
            {
                j++;

            }
        }
        hud.p = j;
    }
}
