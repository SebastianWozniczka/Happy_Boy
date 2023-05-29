using UnityEngine;

public class Mugs : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {    
         Destroy(gameObject);
    }
}
