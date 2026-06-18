using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public float speed = 5;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;

    private Vector2 moveInput;

    private bool isKnockedBack;

    public Player_Combat player_Combat;

    void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            player_Combat.Attack();
        }
       
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        if (isKnockedBack == false)
        {
            rb.linearVelocity = moveInput * StatsManager.Instance.speed;

            float moveSpeed = moveInput.magnitude;
            anim.SetFloat("Speed", moveSpeed);

            if (moveInput.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveInput.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void Knockback(Transform enemy, float knockbackForce, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity += direction * knockbackForce;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;

    }
}
