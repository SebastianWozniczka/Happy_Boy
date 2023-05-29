using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject arrow;
    public Transform dest;
    

    public float rotZ;
    private float z;
    private float timer;

    void Start()
    {
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        rotZ = transform.localEulerAngles.z;
      

        if (timer > 5)
        {
            
            GameObject ga = Instantiate(arrow, dest.position, transform.rotation);
            Rigidbody2D rb = ga.GetComponent<Rigidbody2D>();
            Vector2 euler = transform.eulerAngles;

            if(rotZ > 0)
            {
                rb.velocity = Vector2.right * 100;
            }

            if (rotZ > 90)
            {
                rb.velocity = Vector2.up * 100;
            }

            if (rotZ > 180)
            {
                rb.velocity = Vector2.left * 100;
            }

            if (rotZ > 270)
            {
                rb.velocity = Vector2.down * 100;
            }

            timer = 0;
        }

       
            z = 20.0f *Time.deltaTime;
    
        rotZ += z;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
    }
}