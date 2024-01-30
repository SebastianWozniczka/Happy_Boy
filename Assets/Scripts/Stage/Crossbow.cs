using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Crossbow : MonoBehaviour
{
    public GameObject arrow,back,forward;
    public Transform dest;
    public Vector3 rotZ;
    
    public float bulletImpulse = 100.0f;
 
    private float speedRotation = 20.0f;
    private float angleZ;
    private float timer;
    private float posZ;

    void Start()
    {
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        rotZ = transform.localEulerAngles;
        angleZ = rotZ.z;
      
        if (timer > 5)
        {
            Vector2 position = (forward.transform.position - back.transform.position).normalized;

            GameObject ga = Instantiate(arrow, dest.position, transform.rotation);
            Rigidbody2D rb = ga.GetComponent<Rigidbody2D>();
           
            rb.AddForce(position * bulletImpulse, (ForceMode2D)ForceMode.Impulse);

            timer = 0;
        }
  
        posZ = speedRotation * Time.deltaTime;
        rotZ.z += posZ;
        transform.rotation = Quaternion.Euler(rotZ);
    }
}