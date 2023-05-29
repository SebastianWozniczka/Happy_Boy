using UnityEngine;

public class Arrow : MonoBehaviour
{
   public PlayerMove playerMove;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Swordsman")
        {
            playerMove.countHit++;
        }
    }
}