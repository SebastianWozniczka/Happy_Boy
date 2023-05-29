using UnityEngine;

public class Head : MonoBehaviour
{
    public PlayerMove playerMove;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Tilemap")
        {
            anim.SetTrigger("head");
            playerMove.countHit++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            anim.SetTrigger("jump");
        }
    }

}
