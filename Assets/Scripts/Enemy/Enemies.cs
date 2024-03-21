
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Enemy enemies;
    public EnemyMovement enemyMovement;

    public enum Enemy
    {
        Enemy1,
        Enemy2,
    }
    void Start()
    {
       if(enemies == Enemy.Enemy1)
        {
       
        }
    }
  
}
