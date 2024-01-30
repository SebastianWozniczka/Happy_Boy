using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool isGrounded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.name == "ground")
            isGrounded = true;      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ground")
            isGrounded = false;
    }

}
