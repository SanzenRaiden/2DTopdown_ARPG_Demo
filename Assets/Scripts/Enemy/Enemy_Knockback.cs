using UnityEngine;
using System.Collections;

public class Enemy_Knockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private EnemyMovement enemyMovement;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void Knockback(Transform player, float knockbackForce, float knockbackTime, float stunTime)
    {
        enemyMovement.ChangeState(EnemyState.Knockback);
        StartCoroutine(KnockbackCounter(knockbackTime, stunTime));
        Vector2 direction = (transform.position - player.position).normalized;
        rb.linearVelocity = direction * knockbackForce;
        Debug.Log("knockback applied.");
        
    }

    IEnumerator KnockbackCounter(float knockbackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemyMovement.ChangeState(EnemyState.Idle);

    }
}
