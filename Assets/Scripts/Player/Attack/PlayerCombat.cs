using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Transform attackPoint;

    private Controllers controllers;
    private Animator animator;

    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public float attackRate = 2.0f;
    public float nextAttackTime = 0f;
    private void Start()
    {
        controllers = FindAnyObjectByType<Controllers>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (controllers.fight)
            {
                Attack();
                controllers.fight = false;
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }     
    }

    void Attack()
    {      
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);

            if(enemy.GetComponent<Enemy>() != null)
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);   
    }
}
