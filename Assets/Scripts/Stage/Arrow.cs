using UnityEngine;

public class Arrow : MonoBehaviour
{
    public static Arrow instance;

    public static int shot = 0;

    public GameObject arrow;
  
    private Hud hud;
    private Transform tr;
    private Rigidbody2D rb;

    private void Start()
    {
        arrow = GameObject.FindWithTag("Arrow");
        rb =arrow.GetComponent<Rigidbody2D>();
        tr = arrow.GetComponent<Transform>();
        hud = FindAnyObjectByType<Hud>();     
    }

    private void Awake()
    {
        if(!instance)
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, 1);

        if (collision.gameObject.name.Contains("ground"))
        {
            if (rb != null)
                rb.bodyType = RigidbodyType2D.Static;
        }

        if (collision.gameObject.name == "Swordsman")
           {
             if (rb != null)
                rb.bodyType = RigidbodyType2D.Static;


             if (tr != null)
               {
                  tr = collision.gameObject.transform;           
               }
            
            hud.Damage();
           }
    }
}