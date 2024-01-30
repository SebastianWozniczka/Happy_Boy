using UnityEngine;

public class Stars : MonoBehaviour
{
    public PlayerMove playerMove;

    private Hud hud;

    public bool ok;

    private float x, y, dv = 5;
   
    void Start()
    {
        hud = FindAnyObjectByType<Hud>();  

        x = transform.position.x;
        y = transform.position.y;
    }

    void Update()
    {
        float s = Mathf.Sin(x) / dv;

        x += 0.1f;       
        y += s;       

        transform.position = new Vector2(x, y);
        transform.Rotate(0, 0, Mathf.Sin(5));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMove.countJump != 0)
        {
            hud.health.fillAmount +=(1/10f); 
            playerMove.countJump += 1.0f;
            Destroy(gameObject);
        }
    }
}
