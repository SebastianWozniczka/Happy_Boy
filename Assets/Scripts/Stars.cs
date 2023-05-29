using UnityEngine;

public class Stars : MonoBehaviour
{
    public PlayerMove playerMove;

    private float x, y, dv = 50;
    public bool ok;
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    void Update()
    {
        float s = Mathf.Sin(x) / dv;

        transform.position = new Vector2(x, y);
        transform.Rotate(0, 0, Mathf.Sin(1));

        x += 0.005f;       
        y += s;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMove.countJump != 0)
        {
            playerMove.countJump += 1.0f;
            Destroy(gameObject);
        }
    }
}
